using AidManager.API.SampleBounded.Domain.Model.Aggregates;
using AidManager.API.SampleBounded.Domain.Model.Commands;

namespace AidManager.API.SampleBounded.Domain.Services;

public interface IBookCommandService
{
    Task<Book> Handle(CreateBookCommand command);
}