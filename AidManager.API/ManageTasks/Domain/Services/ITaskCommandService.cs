using AidManager.API.ManageTasks.Domain.Model.Aggregates;
using AidManager.API.ManageTasks.Domain.Model.Commands;

namespace AidManager.API.ManageTasks.Domain.Services;

public interface ITaskCommandService
{
    Task<TaskItem> Handle(CreateTaskCommand command);
    Task<TaskItem> Handle(UpdateTaskCommand command);
    Task<TaskItem> Handle(DeleteTaskCommand command);
}