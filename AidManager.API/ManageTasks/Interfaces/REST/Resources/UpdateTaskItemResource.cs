namespace AidManager.API.ManageTasks.Interfaces.REST.Resources;

public record UpdateTaskItemResource(int Id, string Title, string Description, DateTime DueDate, int ProjectId, string State, string UserId);