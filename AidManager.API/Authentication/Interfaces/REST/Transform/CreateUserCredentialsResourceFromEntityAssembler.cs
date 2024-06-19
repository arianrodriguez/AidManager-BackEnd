using AidManager.API.Authentication.Domain.Model.Entities;
using AidManager.API.Authentication.Interfaces.REST.Resources;

namespace AidManager.API.Authentication.Interfaces.REST.Transform;

public static class CreateUserCredentialsResourceFromEntityAssembler
{
    public static UserCredentialsResource ToResourceFromEntity(User user, string password)
    {
        return new UserCredentialsResource(user.Email, password);
    }
}