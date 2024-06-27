namespace AidManager.API.Collaborate.Interfaces.REST.Resources;

public record CreatePostResource(string Title, string Subject, string Description, int Rating, int CompanyId, int UserId);

