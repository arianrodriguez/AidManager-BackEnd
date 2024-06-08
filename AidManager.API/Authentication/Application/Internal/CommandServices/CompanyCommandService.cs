using AidManager.API.Authentication.Domain.Model.Aggregates;
using AidManager.API.Authentication.Domain.Model.Commands;
using AidManager.API.Authentication.Domain.Repositories;
using AidManager.API.Authentication.Domain.Services;

namespace AidManager.API.Authentication.Application.Internal.CommandServices;

public class CompanyCommandService(ICompanyRepository companyRepository) : ICompanyCommandService
{
    public async Task<bool> handle(CreateCompanyCommand command)
    {
        var company = new Company(command.BrandName, command.IdentificationCode, command.Country, command.Phone, command.UserId);
        
        var result = await companyRepository.CreateCompany(company);
        return result;
    }
}