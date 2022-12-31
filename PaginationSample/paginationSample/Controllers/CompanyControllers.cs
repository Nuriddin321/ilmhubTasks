using System.Net.Http.Headers;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using paginationSample.Data;
using paginationSample.Dtos;
using paginationSample.Entities;

namespace paginationSample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly AppDbContext _context;

    public CompanyController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("addcompany")]
    public async Task<IActionResult> CreateCompany(CompanyDto companyDto)
    {
        var company = new Company()
        {
            Name = companyDto.Name
        };

        _context.Companies?.Add(company);

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("companies")]
    public async Task<IActionResult> GetCompanies([FromQuery] PaginationParams paginationParams)
    {
        var companies = await _context.Companies.AsQueryable().ToPagedListAsync(paginationParams);

        HttpContext.Response.Headers.TryGetValue("x-pagination", out var values); //headerdan malumotlani olib stringga saqlavotti
        var data = JsonConvert.DeserializeObject<PaginationMetaData>(values.ToString()); 

        return Ok(companies ); // data
    }
}