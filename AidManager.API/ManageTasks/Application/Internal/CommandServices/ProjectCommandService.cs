﻿using AidManager.API.ManageTasks.Domain.Model.Aggregates;
using AidManager.API.ManageTasks.Domain.Model.Commands;
using AidManager.API.ManageTasks.Domain.Repositories;
using AidManager.API.ManageTasks.Domain.Services;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.ManageTasks.Application.Internal.CommandServices;

public class ProjectCommandService(IProjectRepository projectRepository, IUnitOfWork unitOfWork): IProjectCommandService
{
    public async Task<Project> Handle(CreateProjectCommand command)
    {
        bool existsByName = await projectRepository.ExistsByName(command.Name);
        
        if (existsByName)
        {
            throw new Exception($"Project with name {command.Name} already exists.");
        }
        
        var project = new Project(command);
        
        try
        {
            await projectRepository.AddAsync(project);
            await unitOfWork.CompleteAsync();
            return project;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}