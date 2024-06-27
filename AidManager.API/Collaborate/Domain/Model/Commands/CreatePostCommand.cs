namespace AidManager.API.Collaborate.Domain.Model.Commands;

public record CreatePostCommand(
    string Title,
    string Subject,
    string Description,
    int Rating,
    string CompanyId,
    int UserId
);