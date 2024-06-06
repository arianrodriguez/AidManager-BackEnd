using AidManager.API.Collaborate.Domain.Model.Commands;

namespace AidManager.API.Collaborate.Domain.Model.Entities;

public class Event
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Date { get; private set; }
    public string Location { get; private set; }
    public string Description { get; private set; }
    public string Color { get; private set; }
    public int PostId { get; private set; }

    public Event()
    {
        
    }
    
    public Event(string Name, string Date, string Location, string Description, string Color, int PostId)
    {
        this.Name = Name;
        this.Location = Location;
        this.Description = Description;
        this.Color = Color;
        this.Date = Date;
        this.PostId = PostId;
    }

    public Event(CreateEventCommand command)
    {
        this.Name = command.Name;
        this.Location = command.Location;
        this.Description = command.Description;
        this.Color = command.Color;
        this.Date = command.Date;
        this.PostId = command.PostId;
    }
    
}