using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using policy_cors.Data;
using Serilog;
using TelegramSink;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data source=users.db");
});

//identity config
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 4;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
    }
).AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>();

//logconfig
var logger = new LoggerConfiguration()
    .WriteTo.TeleSink("5612175896:AAG_PLY9G9HgQ8gT8xxp5hdRH2pxaodCKcs", "-1001522282297", minimumLevel: Serilog.Events.LogEventLevel.Error)
    .CreateLogger();

builder.Logging.AddSerilog(logger);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//policy config
builder.Services.AddAuthorization(policyOptions =>
{
    policyOptions.AddPolicy("jeki", policy => 
    {
        policy.RequireClaim("Age", "18");
        policy.RequireRole("Admin");
    });
});

//cors config
builder.Services.AddCors(option =>
{
    // option.AddPolicy("All", cors =>  corslani hammasini o'tqizvoradi
    // {
    //     cors.AllowAnyHeader()
    //         .AllowAnyOrigin()
    //         .AllowAnyMethod();
    // });

    option.AddPolicy("Front", cors =>
    {
        cors.WithHeaders("Sarlavha", "X-DataCount")
            .WithOrigins("https://localhost:7256", "domain2")
            .WithMethods("PUT");
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
