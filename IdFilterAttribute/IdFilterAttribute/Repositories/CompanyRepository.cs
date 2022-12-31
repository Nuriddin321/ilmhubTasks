using IdFilterAttribute.Data;
using IdFilterAttribute.Filters;
using JFA.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace IdFilterAttribute.Repositories;

[Scoped]  // from JFA.DependencyInjection package
public class CompanyRepository : ICompanyRepository, IEntityExistsRepository
{
    private readonly AppDbContext _context;
    protected DbSet<Company> DbSet;
    public CompanyRepository(AppDbContext context)
    {
        _context = context;
        DbSet = _context.Set<Company>();
    }

    public async Task Addasync(Company company)
    {
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int companyId)
    {
        var company = _context.Companies?.FirstOrDefault(c => c.Id == companyId);

        _context.Companies?.Remove(company);
        await _context.SaveChangesAsync();
    }

  
    public Company GetById(int companyId)
    {
        var company = _context.Companies?.FirstOrDefault(c => c.Id == companyId);

        return company;
    }

    public async Task<List<Company>> GetCompanies()
    {
        return await _context.Companies!.ToListAsync();
    }

    public async Task<bool> IsExists(object? id)
    {
        return await DbSet.FindAsync(id) != null;
    }
}