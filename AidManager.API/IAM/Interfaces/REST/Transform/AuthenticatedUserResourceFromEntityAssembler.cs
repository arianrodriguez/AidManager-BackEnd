using AidManager.API.Authentication.Domain.Model.Entities;
using AidManager.API.IAM.Domain.Model.Aggregates;
using AidManager.API.IAM.Interfaces.REST.Resources;

namespace AidManager.API.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(UserAuth entity, string token)
    {
        return new AuthenticatedUserResource(entity.Id, entity.Username, token);
    }
}