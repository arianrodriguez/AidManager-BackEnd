using AidManager.API.Collaborate.Domain.Model.Commands;
using AidManager.API.Collaborate.Interfaces.REST.Resources;

namespace AidManager.API.Collaborate.Interfaces.REST.Transform;

public static class UpdatePostRatingCommandFromResourceAssembler
{
    public static UpdatePostRatingCommand ToCommandFromResource(int postId, UpdatePostRatingResource resource)
    {
        return new UpdatePostRatingCommand(
            postId,
            resource.Rating,
            resource.UserId
        );
    }
}