using Microsoft.EntityFrameworkCore;
using paginationSample.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();  

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseLazyLoadingProxies().UseSqlite(builder.Configuration.GetConnectionString("dafault")));

var app = builder.Build();

  if (((IApplicationBuilder)app).ApplicationServices.GetService<IHttpContextAccessor>() != null)
                HttpContextHelper.Accessor = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IHttpContextAccessor>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();