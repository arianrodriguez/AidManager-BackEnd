namespace AidManager.API.ManageTasks.Interfaces.REST.Resources;

public record UpdateTaskItemResource(int Id, string Title, string Description, DateTime DueDate, string State, string UserId);