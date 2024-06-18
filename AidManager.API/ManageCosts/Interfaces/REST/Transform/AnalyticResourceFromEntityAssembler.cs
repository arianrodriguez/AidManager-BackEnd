using AidManager.API.ManageCosts.Domain.Model.Aggregates;
using AidManager.API.ManageCosts.Interfaces.REST.Resources;

namespace AidManager.API.ManageCosts.Interfaces.REST.Transform;

public static class AnalyticResourceFromEntityAssembler
{
    public static AnalyticResource ToResourceFromEntity(Analytic entity) =>
        new AnalyticResource(entity.Id, entity.Title, entity.Description, entity.Cost, entity.Progress, entity.Current,
            entity.Expected);
}