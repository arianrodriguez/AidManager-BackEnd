namespace AidManager.API.Authentication.Interfaces.REST.Resources;

public record MessageResource(int Id, string Date, string Message, int UserIdReceiver, int UserIdSender);