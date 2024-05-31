using AidManager.API.Collaborate.Domain.Model.Entities;
using AidManager.API.Collaborate.Domain.Model.Queries;

namespace AidManager.API.Collaborate.Domain.Services;

public interface IPostQueryService
{
    // "Task" keywords it used to represent an asynchronous operation that returns a result of type "IEnumerable<Post>?"
    Task<IEnumerable<Post>?> Handle(GetAllPostsQuery query);
    Task<Post?> Handle(GetPostById query);
}