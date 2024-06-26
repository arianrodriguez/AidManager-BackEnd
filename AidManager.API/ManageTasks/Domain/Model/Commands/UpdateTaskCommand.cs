namespace AidManager.API.ManageTasks.Domain.Model.Commands;

public record UpdateTaskCommand(int Id, string Title, string Description, DateTime DueDate, string State, string Assigned);

