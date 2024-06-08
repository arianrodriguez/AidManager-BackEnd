using AidManager.API.ManageCosts.Domain.Model.Aggregates;
using AidManager.API.ManageCosts.Domain.Model.Queries;

namespace AidManager.API.ManageCosts.Domain.Services;

public interface IAnalyticQueryService
{
    Task<Analytic> Handle(GetAnalyticByIdQuery query);
    Task<IEnumerable<Analytic>> Handle(GetAllAnalytics query);
}