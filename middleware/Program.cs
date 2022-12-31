
using middleware.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<TilMiddleware>();

app.Run();
