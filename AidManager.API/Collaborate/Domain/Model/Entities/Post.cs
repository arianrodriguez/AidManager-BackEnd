using System.ComponentModel.DataAnnotations.Schema;
using AidManager.API.Authentication.Domain.Model.Entities;
using AidManager.API.Collaborate.Domain.Model.Commands;

namespace AidManager.API.Collaborate.Domain.Model.Entities;

public class Post
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    
    public string Subject { get; private set; }
    public string Description { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    public int Rating { get; set; } // don't use private set here, because we want to update it
    
    public int CompanyId { get; private set; }
    
    [ForeignKey("UserId")]
    public int UserId { get; private set; }
    
    public User User { get; private set; }
    
    public Post()
    {
        
    }
    
    public Post(CreatePostCommand command, User User)
    {
        this.Title = command.Title;
        this.Subject = command.Subject;
        this.Description = command.Description;
        CreatedAt = DateTime.Now;
        this.Rating = command.Rating;
        this.CompanyId = command.CompanyId;
        this.UserId = command.UserId;
        this.User = User;
    }
    
}