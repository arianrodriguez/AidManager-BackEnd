using AidManager.API.Authentication.Domain.Model.Entities;
using AidManager.API.Authentication.Interfaces.REST.Resources;

namespace AidManager.API.Authentication.Interfaces.REST.Transform;

public static class CreateMessageResourceFromEntityAssembler
{
    public static MessageResource ToResourceFromEntity(Message message)
    {
        return new MessageResource(message.Id, message.Description, message.Date, message.UserIdReceiver, message.UserIdSender);
    }
}