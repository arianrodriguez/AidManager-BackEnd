using AidManager.API.ManageTasks.Domain.Model.Aggregates;
using AidManager.API.ManageTasks.Domain.Model.Commands;
using AidManager.API.ManageTasks.Domain.Repositories;
using AidManager.API.ManageTasks.Domain.Services;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.ManageTasks.Application.Internal.CommandServices;

public class TaskCommandService(ITaskRepository taskRepository, IUnitOfWork unitOfWork) : ITaskCommandService
{
    public async Task<TaskItem> Handle(CreateTaskCommand command)
    {
        
        Console.WriteLine("command service called");
        var task = new TaskItem(command);
        Console.WriteLine("task Aggregate created");
        await taskRepository.CreateTaskItem(task);
        Console.WriteLine("task added to repository");
        await unitOfWork.CompleteAsync();
        Console.WriteLine("unit of work completed");
        return task;
    }
    
    public async Task<TaskItem> Handle(UpdateTaskCommand command)
    {

        var task = await taskRepository.FindByIdAsync(command.Id);
        Console.WriteLine("command service called");
        if (task is null) throw new Exception("Task not found");
        task.UpdateTask(command);
        Console.WriteLine("task Aggregate updated");
        await taskRepository.Update(task);
        Console.WriteLine("task updated in repository");
        await unitOfWork.CompleteAsync();
        Console.WriteLine("unit of work completed");
        return task;
    }
    
    public async Task<TaskItem> Handle(DeleteTaskCommand command)
    {
        var task = await taskRepository.FindByIdAsync(command.Id);
        if (task is null) throw new Exception("Task not found");
        await taskRepository.Remove(task);
        await unitOfWork.CompleteAsync();
        return task;
    }
    
    
}