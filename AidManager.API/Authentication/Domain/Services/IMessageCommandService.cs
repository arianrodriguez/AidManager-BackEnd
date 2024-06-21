using AidManager.API.Authentication.Domain.Model.Commands;
using AidManager.API.Authentication.Domain.Model.Entities;

namespace AidManager.API.Authentication.Domain.Services;

public interface IMessageCommandService
{
    Task<Message?> Handle(CreateNewMessageCommand command);
}