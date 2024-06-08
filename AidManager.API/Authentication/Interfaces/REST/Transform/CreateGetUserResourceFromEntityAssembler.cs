using AidManager.API.Authentication.Domain.Model.Entities;
using AidManager.API.Authentication.Interfaces.REST.Resources;

namespace AidManager.API.Authentication.Interfaces.REST.Transform;

public static class CreateGetUserResourceFromEntityAssembler
{
    public static GetUserResource ToResourceFromEntity(User user)
    {
        return new GetUserResource(user.Id, user.FirstName, user.LastName, user.Age, user.Email, user.Phone, user.Occupation, user.Password, user.ProfileImg, user.Role, user.CompanyName, user.Bio, user.CompanyId);
    }
}