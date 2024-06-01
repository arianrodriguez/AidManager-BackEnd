namespace AidManager.API.Collaborate.Domain.Model.Commands;

public record CreateEventCommand(string name, string date, string location, string description, string color);