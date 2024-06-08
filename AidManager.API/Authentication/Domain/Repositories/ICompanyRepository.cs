using AidManager.API.Authentication.Domain.Model.Aggregates;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.Authentication.Domain.Repositories;

public interface ICompanyRepository : IBaseRepository<Company>
{
    Task<bool> CreateCompany(Company company);
    Task<Company?> FindCompanyByUID(string UID);
}