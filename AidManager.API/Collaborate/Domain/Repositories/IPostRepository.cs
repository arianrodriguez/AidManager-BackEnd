using System.Collections.Generic;
using System.Threading.Tasks;
using AidManager.API.Collaborate.Domain.Model.Entities;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.Collaborate.Domain.Repositories;

public interface IPostRepository : IBaseRepository<Post>
{
    Task<Post?> FindPostById(int id);
    Task<IEnumerable<Post>?> GetAllPosts();
    Task<IEnumerable<Post>?> GetAllPostsByCompanyId(string companyId);
}