using System;
using System.Threading.Tasks;
using AidManager.API.SampleBounded.Domain.Model.Aggregates;
using AidManager.API.SampleBounded.Domain.Model.Queries;
using AidManager.API.SampleBounded.Domain.Repositories;
using AidManager.API.SampleBounded.Domain.Services;

namespace AidManager.API.SampleBounded.Application.Internal.QueryServices;

public class BookQueryService(IBookRepository bookRepository) : IBookQueryService
{
    // repository -> implementation of IBookRepository
    public async Task<Book> Handle(GetBookByIdQuery query)
    {
        Console.WriteLine("query service called");
        return await bookRepository.FindByIdAsync(query.Id);
    }
}
 