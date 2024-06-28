using AidManager.API.IAM.Domain.Model.Commands;
using AidManager.API.IAM.Interfaces.REST.Resources;

namespace AidManager.API.IAM.Interfaces.REST.Transform;

public class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}