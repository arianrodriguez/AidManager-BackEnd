using AidManager.API.Authentication.Domain.Model.Aggregates;
using AidManager.API.Authentication.Domain.Model.Queries;
using AidManager.API.Authentication.Domain.Repositories;
using AidManager.API.Authentication.Domain.Services;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.Authentication.Application.Internal.QueryServices;

public class CompanyQueryService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork) : ICompanyQueryService
{
    public async Task<Company?> handle(GetCompanyByUIDQuery query)
    {
        return await companyRepository.FindCompanyByUID(query.UID);
    }
    
}