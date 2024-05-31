using AidManager.API.Collaborate.Domain.Model.Entities;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.Collaborate.Domain.Repositories;

public interface IPostRepository : IBaseRepository<Post>
{
    Task<Post?> FindPostById(int id);
    Task<IEnumerable<Post>?> GetAllPosts();
    // it will be implemented in the future to return a Post object
    //Task<Post?> FindPostByUser(int id);
}