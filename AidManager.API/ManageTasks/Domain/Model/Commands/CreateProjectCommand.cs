namespace AidManager.API.ManageTasks.Domain.Model.Commands;

public record CreateProjectCommand( string Name, string Description, string ImageUrl);