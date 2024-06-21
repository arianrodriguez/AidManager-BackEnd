using AidManager.API.Authentication.Domain.Model.Commands;
using AidManager.API.Authentication.Domain.Model.Entities;
using AidManager.API.Authentication.Domain.Repositories;
using AidManager.API.Authentication.Domain.Services;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.Authentication.Application.Internal.CommandServices;

public class MessageCommandService(IMessageRepository messageRepository, IUnitOfWork unitOfWork) : IMessageCommandService
{
    public async Task<Message?> Handle(CreateNewMessageCommand command)
    {
        try
        {
            Message message = new Message(command);
            await messageRepository.AddAsync(message);
            await unitOfWork.CompleteAsync();
            return message;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error " + e.Message);
            return null;
        }
    }
}