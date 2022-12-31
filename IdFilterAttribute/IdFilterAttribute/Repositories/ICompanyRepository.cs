using IdFilterAttribute.Data;

namespace IdFilterAttribute.Repositories;

public interface ICompanyRepository
{
   Task Addasync (Company company);
   Task<List<Company>> GetCompanies();
   Company GetById(int companyId);
   Task Delete (int companyId);

}