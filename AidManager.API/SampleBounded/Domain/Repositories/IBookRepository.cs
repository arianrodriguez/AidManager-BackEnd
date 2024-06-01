using System.Threading.Tasks;
using AidManager.API.SampleBounded.Domain.Model.Aggregates;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.SampleBounded.Domain.Repositories;

public interface IBookRepository : IBaseRepository<Book>
{
     public Task<Book> CreateBook(Book entity);
}