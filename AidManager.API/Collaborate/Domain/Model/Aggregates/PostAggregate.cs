using AidManager.API.Collaborate.Domain.Model.Entities;

namespace AidManager.API.Collaborate.Domain.Model.Aggregates;

// this class is not used for now but it will be used in the future
public class PostAggregate
{
    public Post post { get; private set; }
    
    public PostAggregate()
    {
        this.post = new Post();
    }
    
    public PostAggregate(Post post)
    {
        this.post = post;
    }
    
}