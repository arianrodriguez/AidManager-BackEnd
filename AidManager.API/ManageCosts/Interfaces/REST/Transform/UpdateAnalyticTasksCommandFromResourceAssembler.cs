using AidManager.API.ManageCosts.Domain.Model.Commands;
using AidManager.API.ManageCosts.Interfaces.REST.Resources;

namespace AidManager.API.ManageCosts.Interfaces.REST.Transform;

public class UpdateAnalyticTasksCommandFromResourceAssembler
{
    public static UpdateAnalyticTasksCommand ToCommandFromResource(int id, UpdateAnalyticTasksResource resource)
    {
        return new UpdateAnalyticTasksCommand(
            id,
            resource.Tasks
        );
    }
    
}