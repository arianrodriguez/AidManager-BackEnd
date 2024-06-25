using AidManager.API.ManageTasks.Domain.Model.Aggregates;
using AidManager.API.ManageTasks.Interfaces.REST.Resources;

namespace AidManager.API.ManageTasks.Interfaces.REST.Transform;

public class ProjectResourceFromEntityAssembler
{
    public static ProjectResource ToResourceFromEntity(Project entity) =>
        new ProjectResource(entity.Id,entity.Name, entity.Description, entity.ImageUrl, entity.CompanyId);
}