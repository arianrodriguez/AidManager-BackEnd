using System.Net.Mime;
using AidManager.API.ManageTasks.Domain.Model.Commands;
using AidManager.API.ManageTasks.Domain.Model.Queries;
using AidManager.API.ManageTasks.Domain.Services;
using AidManager.API.ManageTasks.Interfaces.REST.Resources;
using AidManager.API.ManageTasks.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace AidManager.API.ManageTasks.Interfaces;

[ApiController]
[Route("/Projects/{projectId}/Tasks")]
[Produces(MediaTypeNames.Application.Json)]
public class TaskItemsController(ITaskCommandService taskCommandService, ITaskQueryService taskQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateTaskItem([FromBody] CreateTaskItemResource resource)
    {
       
        var createTaskItemCommand = CreateTaskItemCommandFromResourceAssembler.ToCommandFromResource(resource); 
        Console.WriteLine("The TaskItemController is called. and the Task Item is assembled." + createTaskItemCommand);
        var result = await taskCommandService.Handle(createTaskItemCommand);
        Console.WriteLine("The Create Item Command is handled in the taskCommandService.");
        var taskItemById = this.GetTaskItemById(result.Id);
        Console.WriteLine("Task by id called" + taskItemById.Result);
        return CreatedAtAction(nameof(GetTaskItemById), new { id = result.Id }, 
            TaskItemResourceFromEntityAssembler.ToResourceFromEntity(result));
        
    }
    
    [HttpGet("/{id}")]
    public async Task<ActionResult<TaskItemResource>> GetTaskItemById(int id)
    {
        var taskItem = await taskQueryService.Handle(new GetTaskByIdQuery(id));
        if (taskItem == null)
        {
            return NotFound();
        }
        var resource = TaskItemResourceFromEntityAssembler.ToResourceFromEntity(taskItem);
        return Ok(resource);
    }
    
    [HttpPut]
    public async Task<ActionResult> UpdateTaskItem([FromBody] UpdateTaskItemResource resource)
    {
        var updateTaskCommand = UpdateTaskItemCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await taskCommandService.Handle(updateTaskCommand);
        return Ok(TaskItemResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    [HttpDelete("/{id}")]
    public async Task<ActionResult> DeleteTaskItem(int id)
    {
        var deleteTaskItemCommand = new DeleteTaskCommand(id);
        var result = await taskCommandService.Handle(deleteTaskItemCommand);
        return Ok(TaskItemResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItemResource>>> GetAllTaskItems()
    {
        var getAllTasksQuery = new GetAllTasksQuery();
        var result = await taskQueryService.Handle(getAllTasksQuery);
        var resources = result.Select(TaskItemResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
}