using AidManager.API.SampleBounded.Domain.Model.Commands;

namespace AidManager.API.SampleBounded.Domain.Model.Aggregates;

public class Book
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Author { get; private set; }

    protected Book()
    {
        this.Name = "nothing";
        this.Author = "nothing";
    }

    public Book(CreateBookCommand command)
    {
        this.Name = command.Name;
        this.Author = command.Author;
    }
}