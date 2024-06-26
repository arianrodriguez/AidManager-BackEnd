﻿using AidManager.API.ManageTasks.Domain.Model.Aggregates;
using AidManager.API.ManageTasks.Domain.Model.Queries;

namespace AidManager.API.ManageTasks.Domain.Services;

public interface ITaskQueryService
{
    Task<IEnumerable<TaskItem>> Handle(GetAllTasksQuery query);
    Task<TaskItem> Handle(GetTaskByIdQuery query); 
    Task<List<TaskItem>> Handle(GetTasksByProjectIdQuery query);
}