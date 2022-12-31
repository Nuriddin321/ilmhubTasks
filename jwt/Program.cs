using System.Collections.Immutable;
using jwt.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Settings>(builder.Configuration.GetSection(nameof(Settings)));

var settings = builder.Configuration.GetSection(nameof(Settings)).Get<Settings>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // bu autentikatsiya qachonki [Authorize] attributi bor actionga request keganda ishga tushadi va request headeridagi jwt malumotlariga qarab userni autentikatsiya qiladi
    .AddJwtBearer(jwtoption =>
    {
        jwtoption.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = "Project1",
            ValidateAudience = true,
            ValidAudience = "Room1",    
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey =  new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(settings.SecurityKey!)) 
        };
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
