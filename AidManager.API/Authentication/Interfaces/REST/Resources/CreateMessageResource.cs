namespace AidManager.API.Authentication.Interfaces.REST.Resources;

public record CreateMessageResource(string Date, string Message, int UserIdReceiver, int UserIdSender);