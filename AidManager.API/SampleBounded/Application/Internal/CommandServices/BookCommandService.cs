using System;
using System.Threading.Tasks;
using AidManager.API.SampleBounded.Domain.Model.Aggregates;
using AidManager.API.SampleBounded.Domain.Model.Commands;
using AidManager.API.SampleBounded.Domain.Repositories;
using AidManager.API.SampleBounded.Domain.Services;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.SampleBounded.Application.Internal.CommandServices;

public class BookCommandService(IBookRepository bookRepository, IUnitOfWork unitOfWork) : IBookCommandService
{
    // repository -> implementation of IBookRepository
    public async Task<Book> Handle(CreateBookCommand command)
    {
        Console.WriteLine("command service called");
        var book = new Book(command);
        Console.WriteLine("book Aggregate created");
        //await bookRepository.AddAsync(book);
        bookRepository.CreateBook(book);
        Console.WriteLine("book added to repository");
        await unitOfWork.CompleteAsync();
        Console.WriteLine("unit of work completed");
        return book;
    }
}