namespace AidManager.API.Collaborate.Domain.Model.Commands;

public record CreatePostCommand(string Title, string Description, int Rating, int UserId);