using System;

namespace AidManager.API.Collaborate.Domain.Model.Entities;

public class Post
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime PublicationDate { get; private set; }
    public int Rating { get; private set; }
    public int UserId { get; private set; }
    
    // El id es autogenerado al crear una instancia de post
    public Post(string Title, string Description, int Rating, int UserId)
    {
        this.Title = Title;
        this.Description = Description;
        PublicationDate = DateTime.Now;
        this.Rating = Rating;
        this.UserId = UserId;
    }
    
}