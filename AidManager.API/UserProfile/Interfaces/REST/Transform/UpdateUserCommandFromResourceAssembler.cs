using AidManager.API.UserProfile.Domain.Model.Commands;
using AidManager.API.UserProfile.Interfaces.REST.Resources;

namespace AidManager.API.UserProfile.Interfaces.REST.Transform;

public static class UpdateUserCommandFromResourceAssembler
{
    public static UpdateUserCommand ToCommandFromResource(UpdateUserResource resource) =>
        new UpdateUserCommand(resource.FirstName, resource.LastName, resource.Age, resource.Phone, resource.Occupation, resource.ProfileImg, resource.Bio);
}