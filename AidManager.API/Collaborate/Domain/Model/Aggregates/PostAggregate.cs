using AidManager.API.Collaborate.Domain.Model.Entities;

namespace AidManager.API.Collaborate.Domain.Model.Aggregates;

// this class is not used for now but it will be used in the future
public class PostAggregate
{
    public Post post { get; private set; }
    
    // guid keyword it uses to generate a new GUID value for the AuthorId property
    //public Guid AuthorId { get; private set; }
    
    /*public PostAggregate(Post post, User author)
    {
        Post = post;
        Author = author;
    }*/
    
}