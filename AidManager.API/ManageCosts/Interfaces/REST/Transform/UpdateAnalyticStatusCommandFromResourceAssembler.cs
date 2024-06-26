using AidManager.API.ManageCosts.Domain.Model.Commands;
using AidManager.API.ManageCosts.Interfaces.REST.Resources;

namespace AidManager.API.ManageCosts.Interfaces.REST.Transform;

public class UpdateAnalyticStatusCommandFromResourceAssembler
{
    public static UpdateAnalyticStatusCommand ToCommandFromResource(int id, UpdateAnalyticStatusResource resource)
    {
        return new UpdateAnalyticStatusCommand(
            id,
            resource.Status
        );
    }
}