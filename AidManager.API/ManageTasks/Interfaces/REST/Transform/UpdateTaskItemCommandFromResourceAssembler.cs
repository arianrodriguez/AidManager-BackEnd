using AidManager.API.ManageTasks.Domain.Model.Commands;
using AidManager.API.ManageTasks.Interfaces.REST.Resources;

namespace AidManager.API.ManageTasks.Interfaces.REST.Transform;

public static class UpdateTaskItemCommandFromResourceAssembler
{
    public static UpdateTaskCommand ToCommandFromResource(UpdateTaskItemResource resource) =>
        new UpdateTaskCommand(resource.Id , resource.Title, resource.Description, resource.DueDate, resource.ProjectId, resource.State, resource.UserId);

}