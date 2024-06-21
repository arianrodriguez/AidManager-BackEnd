using AidManager.API.Authentication.Domain.Model.Commands;

namespace AidManager.API.Authentication.Domain.Model.Entities;

public class Message
{
    public int Id { get; private set; }
    public string Date { get; private set; }
    public string Description { get; private set; }
    public int UserIdReceiver { get; private set; }
    public int UserIdSender { get; private set; }
    
    public Message()
    {

    }

    public Message(CreateNewMessageCommand command)
    {
        this.Date = command.Date;
        this.Description = command.Message;
        this.UserIdReceiver = command.UserIdReceiver;
        this.UserIdSender = command.UserIdSender;
        
    }
}