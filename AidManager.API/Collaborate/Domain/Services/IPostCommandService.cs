using System.Threading.Tasks;
using AidManager.API.Collaborate.Domain.Model.Commands;
using AidManager.API.Collaborate.Domain.Model.Entities;

namespace AidManager.API.Collaborate.Domain.Services;

public interface IPostCommandService
{
    Task<Post?> Handle(CreatePostCommand command);
    Task<Post?> Handle(DeletePostCommand command);
    
    Task<Post?> Handle(UpdatePostRatingCommand command);
}