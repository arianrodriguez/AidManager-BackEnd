using AidManager.API.Authentication.Domain.Model.Commands;
using AidManager.API.Authentication.Interfaces.REST.Resources;

namespace AidManager.API.Authentication.Interfaces.REST.Transform;

public static class CreateCompanyCommandFromResourceAssembler
{
    public static CreateCompanyCommand ToCommandFromResource(CreateCompanyResource resource)
    {
        return new CreateCompanyCommand(resource.BrandName, resource.IdentificationCode, resource.Country,
            resource.Phone, resource.UserId);
    }
}