namespace AidManager.API.ManageTasks.Domain.Model.Commands;

public record CreateTaskCommand(string Title, string Description, DateTime DueDate, int ProjectId, string State, string Assigned);