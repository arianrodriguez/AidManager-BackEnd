using AidManager.API.ManageCosts.Domain.Model.Commands;
using AidManager.API.ManageCosts.Interfaces.REST.Resources;

namespace AidManager.API.ManageCosts.Interfaces.REST.Transform;

public class UpdateAnalyticLinesCommandFromResourceAssembler
{
    public static UpdateAnalyticLinesCommand ToCommandFromResource(int id, UpdateAnalyticLinesResource resource)
    {
        return new UpdateAnalyticLinesCommand(
            id,
            resource.Lines
        );
    }
}