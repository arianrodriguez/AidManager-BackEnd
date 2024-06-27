using AidManager.API.ManageCosts.Domain.Model.Commands;
using AidManager.API.ManageCosts.Interfaces.REST.Resources;

namespace AidManager.API.ManageCosts.Interfaces.REST.Transform;

public class CreateAnalyticsCommandFromResourceAssembler
{
    public static CreateAnalyticsCommand ToCommandFromResource(CreateAnalyticsResource resource)
    {
        return new CreateAnalyticsCommand(
            resource.ProjectId,
            resource.Tasks, // Aquí se cambió 'resource.Lines' por 'resource.Tasks'
            resource.Payments,
            resource.Progressbar,
            resource.Status,
            resource.Lines // Aquí se cambió 'resource.Tasks' por 'resource.Lines'
        );
    }
}