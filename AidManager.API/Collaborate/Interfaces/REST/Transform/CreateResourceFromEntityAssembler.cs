using AidManager.API.Collaborate.Domain.Model.Entities;
using AidManager.API.Collaborate.Interfaces.REST.Resources;

namespace AidManager.API.Collaborate.Interfaces.REST.Transform;

public static class CreateResourceFromEntityAssembler
{
    public static CreatePostResource ToResourceFromEntity(Post post)
    {
        return new CreatePostResource(post.Title, post.Description, post.Rating, post.UserId);
    }
}