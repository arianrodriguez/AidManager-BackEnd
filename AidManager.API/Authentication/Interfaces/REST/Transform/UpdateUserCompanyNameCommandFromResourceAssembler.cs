using AidManager.API.Authentication.Domain.Model.Commands;
using AidManager.API.Authentication.Interfaces.REST.Resources;

namespace AidManager.API.Authentication.Interfaces.REST.Transform;

public class UpdateUserCompanyNameCommandFromResourceAssembler
{
    public static UpdateUserCompanyNameCommand ToCommandFromResource(int id, UpdateUserCompanyNameResource resource)
    {
        return new UpdateUserCompanyNameCommand(
            id,
            resource.CompanyName
        );
    }
}