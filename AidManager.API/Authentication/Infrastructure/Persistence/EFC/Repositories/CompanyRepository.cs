using AidManager.API.Authentication.Domain.Model.Aggregates;
using AidManager.API.Authentication.Domain.Repositories;
using AidManager.API.Shared.Domain.Repositories;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AidManager.API.Authentication.Infrastructure.Persistence.EFC.Repositories;

public class CompanyRepository(AppDBContext context) : BaseRepository<Company>(context), ICompanyRepository
{
    public async Task<bool> CreateCompany(Company company)
    {
        return await AddAsync(company);
    }
    
    public async Task<Company?> FindCompanyByUID(string UID)
    {
        return await Context.Set<Company>().Where(c => c.IdentificationCode == UID).FirstOrDefaultAsync();
    }
}