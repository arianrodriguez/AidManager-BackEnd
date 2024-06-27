using AidManager.API.Authentication.Domain.Model.Commands;
using AidManager.API.Authentication.Interfaces.REST.Resources;

namespace AidManager.API.Authentication.Interfaces.REST.Transform;

public static class CreateMessageCommandFromResourceAssembler
{
    public static CreateNewMessageCommand ToCommandFromResource(CreateMessageResource resource)
    {
        return new CreateNewMessageCommand(resource.Date, resource.Message, resource.UserIdReceiver, resource.UserIdSender);
    }
}