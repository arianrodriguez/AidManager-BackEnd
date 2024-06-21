namespace AidManager.API.Authentication.Domain.Model.Commands;

public record CreateNewMessageCommand(string Date, string Message, int UserIdReceiver, int UserIdSender);