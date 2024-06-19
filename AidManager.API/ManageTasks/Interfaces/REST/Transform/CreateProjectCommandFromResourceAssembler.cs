using AidManager.API.ManageTasks.Domain.Model.Commands;
using AidManager.API.ManageTasks.Interfaces.REST.Resources;

namespace AidManager.API.ManageTasks.Interfaces.REST.Transform;

public class CreateProjectCommandFromResourceAssembler
{
    public static CreateProjectCommand ToCommandFromResource(CreateProjectResource resource) =>
        new CreateProjectCommand(resource.Name, resource.Description, resource.ImageUrl);

}