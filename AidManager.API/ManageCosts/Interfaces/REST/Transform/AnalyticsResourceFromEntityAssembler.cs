using AidManager.API.ManageCosts.Domain.Model.Aggregates;
using AidManager.API.ManageCosts.Interfaces.REST.Resources;

namespace AidManager.API.ManageCosts.Interfaces.REST.Transform;

public class AnalyticsResourceFromEntityAssembler
{
    public static AnalyticsResource ToResourceFromEntity(Analytics analytic)
    {
        return new AnalyticsResource(
            analytic.Id,
            analytic.ProjectId,
            analytic.Lines,
            analytic.Payments,
            analytic.Progressbar,
            analytic.Status,
            analytic.Tasks 
        );
    }
}