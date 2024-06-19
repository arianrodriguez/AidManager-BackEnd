using AidManager.API.Authentication.Domain.Model.Aggregates;
using AidManager.API.Authentication.Interfaces.REST.Resources;

namespace AidManager.API.Authentication.Interfaces.REST.Transform;

public static class CreateCompanyResourceFromEntityAssembler
{
    public static GetCompanyResource ToResourceFromEntity(Company company) =>
        new GetCompanyResource(company.Id, company.BrandName, company.IdentificationCode, company.Country, company.Phone, company.UserId);
}