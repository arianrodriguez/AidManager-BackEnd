namespace AidManager.API.Collaborate.Interfaces.REST.Resources;

public record UpdatePostRatingResource(
    int Rating,
    int UserId
);