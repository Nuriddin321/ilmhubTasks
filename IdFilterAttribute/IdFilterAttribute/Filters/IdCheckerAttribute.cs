using IdFilterAttribute.Data;
using IdFilterAttribute.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IdFilterAttribute.Filters;

public class IdCheckerAttribute : ActionFilterAttribute
{
    private readonly AppDbContext _context;
    private readonly string _notFoundExceptionMessage = "One or more object hasn't be found";
    private readonly string _noParametersFoundExceptionMessage = "Error! Any parameters about ID have not been found";
    private readonly string _notFoundRepositoryExceptionMessage = "Repository based on given parameter has not been found!";
    private const string _targetClass = "Repository";

    public IdCheckerAttribute(AppDbContext context)
    {
        _context = context;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {


        var parameters = context.ActionArguments
            .Where(kvp => kvp.Key.ToLower().Contains("id"))
            .ToDictionary(x => x.Key, x => x.Value); //bu metod - attribute berilgan metodni argumentlarini nomini key, berilgan qiymatini value qilib oladi

        if (parameters.Count <= 0)
        {
            throw new BadHttpRequestException(_noParametersFoundExceptionMessage);
            return;
        }

        var normalizedParameters = Normalizer(parameters);

        if (normalizedParameters.Any(kvp => FindTypeByName(kvp.Key + _targetClass) is null))
        {
            throw new BadHttpRequestException(_notFoundRepositoryExceptionMessage);
            return;
        }

        var classTypes = new Dictionary<Type, object?>();

        foreach (var kvp in normalizedParameters)
        {
            classTypes.Add(FindTypeByName(kvp.Key + _targetClass), kvp.Value);
        }

        var results = new List<bool>();

        foreach (var kvp in classTypes)
        {
            var instance = (IEntityExistsRepository)Activator.CreateInstance(kvp.Key, _context)!;
            var id = kvp.Value;

            results.Add(await instance.IsExists(id));
        }

        if (results.Any(b => b == false))
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            throw new BadHttpRequestException(_notFoundExceptionMessage);
            return;
        }

        await next();
    }

    private Dictionary<string, object?> Normalizer(IDictionary<string, object?> parameters)
    {
        var normalizedKeys = parameters.Keys.Select(key => key[..^2]);
        var values = parameters.Values;

        var mappedDictionary = normalizedKeys.Zip(values, (k, v) => new { k, v })
         .ToDictionary(x => x.k, x => x.v);

        return mappedDictionary;


    }

    private Type? FindTypeByName(string entityName) =>
        AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => t.IsClass && t.Name.ToLower() == entityName.ToLower());
}