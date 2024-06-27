using AidManager.API.ManageCosts.Domain.Model.Aggregates;
using AidManager.API.ManageCosts.Domain.Model.Queries;
using AidManager.API.ManageCosts.Domain.Repositories;
using AidManager.API.ManageCosts.Domain.Services;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.ManageCosts.Application.Internal.QueryServices;

public class AnalyticsQueryService(
    IAnalyticsRepository analyticsRepository,
    IUnitOfWork unitOfWork
    ) : IAnalyticsQueryService
{
        
    public async Task<Analytics?> Handle(GetAnalyticsByProjectId query)
    {
        try
        {
            return await analyticsRepository.GetAnalyticsByProjectId(query.ProjectId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<Analytics?> Handle(GetAnalyticsById query)
    {
        try
        {
            return await analyticsRepository.GetAnalyticsById(query.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}