using AidManager.API.ManageCosts.Domain.Model.Aggregates;
using AidManager.API.Shared.Domain.Repositories;
namespace AidManager.API.ManageCosts.Domain.Repositories;

public interface IAnalyticRepository : IBaseRepository<Analytic>
{
    public Task<Analytic> CreateAnalytic(Analytic entity);
    public Task<IEnumerable<Analytic>> FindAllAsync();
}