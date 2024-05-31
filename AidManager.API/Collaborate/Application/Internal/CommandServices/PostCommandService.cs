using AidManager.API.Collaborate.Domain.Model.Commands;
using AidManager.API.Collaborate.Domain.Model.Entities;
using AidManager.API.Collaborate.Domain.Repositories;
using AidManager.API.Collaborate.Domain.Services;
using AidManager.API.Collaborate.Infraestructure.Repositories;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.Collaborate.Application.Internal.CommandServices;

public class PostCommandService(IPostRepository postRepository, IUnitOfWork unitOfWork): IPostCommandService
{
    public async Task<Post?> Handle(CreatePostCommand command)
    {
        var post = new Post(command.Title, command.Description, command.Rating, command.UserId);
        await postRepository.AddAsync(post);
        await unitOfWork.CompleteAsync();
        return post;
    }
    
    public async Task<Post?> Handle(DeletePostCommand command)
    {
        var post = await postRepository.FindPostById(command.Id);
        
        if (post == null)
        {
            return null;
        }
        await postRepository.Remove(post);
        await unitOfWork.CompleteAsync();
        return post;
    }
}