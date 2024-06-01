using System.Threading.Tasks;
using AidManager.API.SampleBounded.Domain.Model.Aggregates;
using AidManager.API.SampleBounded.Domain.Model.Queries;

namespace AidManager.API.SampleBounded.Domain.Services;

public interface IBookQueryService
{
    Task<Book> Handle(GetBookByIdQuery query);
}