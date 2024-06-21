namespace AidManager.API.ManageTasks.Interfaces.REST.Resources;

public record CreateProjectResource(string Name, string Description, string ImageUrl, string CompanyId);
