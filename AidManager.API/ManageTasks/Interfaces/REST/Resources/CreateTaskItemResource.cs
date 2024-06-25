namespace AidManager.API.ManageTasks.Interfaces.REST.Resources;

public record CreateTaskItemResource(string Title, string Description, DateTime DueDate, string State, string UserId);