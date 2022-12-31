using System.Collections.Immutable;
using identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TelegramSink;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlite("Data source=users.db");
});
//identityconfig
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 4;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
    })
    .AddEntityFrameworkStores<AppDbContext>();

//logconfig

// builder.Logging.ClearProviders(); 

var logger = new LoggerConfiguration()
    .WriteTo.File(
        path: "Log.txt",
        fileSizeLimitBytes: 50000,
        rollingInterval: RollingInterval.Day)
    // .WriteTo.Console()
    .WriteTo.TeleSink("5612175896:AAG_PLY9G9HgQ8gT8xxp5hdRH2pxaodCKcs","-1001522282297")
    .CreateLogger();

builder.Logging.AddSerilog(logger);


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
