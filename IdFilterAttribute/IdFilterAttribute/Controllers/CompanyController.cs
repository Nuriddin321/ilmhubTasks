using IdFilterAttribute.Data;
using IdFilterAttribute.Filters;
using IdFilterAttribute.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace Name.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyController(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    [HttpPost("createcompany")]
    public async Task<ActionResult> AddCompany(string name)
    {
        var comp = new Company()
        {
            Name = name,
        };

        await _companyRepository.Addasync(comp);
        return Ok();
    }

    [HttpGet("{companyId:int}")]
    [IdValidation]
    public IActionResult GetById(int companyId)
    {
        var comp = _companyRepository.GetById(companyId);

        if(comp is null)
            return BadRequest();

        return Ok(comp);
    }

    [HttpGet("companies")]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _companyRepository.GetCompanies();
       
        return Ok(companies);
    }
}