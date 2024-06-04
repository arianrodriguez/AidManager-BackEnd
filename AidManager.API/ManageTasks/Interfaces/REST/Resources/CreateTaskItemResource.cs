namespace AidManager.API.ManageTasks.Interfaces.REST.Resources;

public record CreateTaskItemResource(string Title, string Description, DateTime DueDate, int ProjectId, string State, string UserId);