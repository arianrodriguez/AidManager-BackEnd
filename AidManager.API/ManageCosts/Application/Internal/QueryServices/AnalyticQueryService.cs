using AidManager.API.ManageCosts.Domain.Model.Aggregates;

namespace AidManager.API.ManageCosts.Application.Internal.QueryServices;

public class AnalyticQueryService(IAnalyticRepository analyticRepository) :IAnalyticQueryService
{
    public async Task<Analytic> Handle(GetAnalyticByIdQuery query)
    {
        Console.WriteLine("Query service called");
        return await analyticRepository.FindByIdAsync(query.id);
    }
}