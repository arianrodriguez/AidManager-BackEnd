using AidManager.API.Authentication.Interfaces.REST.Resources;
using AidManager.API.Authentication.Interfaces.REST.Transform;
using AidManager.API.Collaborate.Domain.Model.Entities;
using AidManager.API.Collaborate.Interfaces.REST.Resources;

namespace AidManager.API.Collaborate.Interfaces.REST.Transform;

public static class PostResourceFromEntityAssembler
{
    public static PostResource ToResourceFromEntity(Post post)
    {
        GetUserResource user = CreateGetUserResourceFromEntityAssembler.ToResourceFromEntity(post.User);
        
        return new PostResource(
            post.Id,
            post.Title,
            post.Subject,
            post.Description, 
            post.CreatedAt,
            post.Rating, 
            post.CompanyId,
            user
        );
    }
}