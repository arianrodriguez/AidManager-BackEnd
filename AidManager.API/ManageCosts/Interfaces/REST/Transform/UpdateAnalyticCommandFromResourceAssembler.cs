using AidManager.API.ManageCosts.Domain.Model.Commands;
using AidManager.API.ManageCosts.Interfaces.REST.Resources;

namespace AidManager.API.ManageCosts.Interfaces.REST.Transform;

public class UpdateAnalyticCommandFromResourceAssembler
{
    public static UpdateAnalyticCommand ToCommandFromResource(int id, UpdateAnalyticResource resource) =>
        new UpdateAnalyticCommand(id, resource.Title, resource.Description, resource.Cost, resource.Progress,
            resource.Current, resource.Expected);
}