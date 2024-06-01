using System.Diagnostics.Tracing;
using AidManager.API.Collaborate.Domain.Model.Commands;
using AidManager.API.Collaborate.Domain.Model.Entities;
using AidManager.API.Collaborate.Domain.Repositories;
using AidManager.API.Collaborate.Domain.Services;

namespace AidManager.API.Collaborate.Application.Internal.CommandServices;

public class EventCommandService(IEventRepository eventRepository) : IEventCommandService
{
    public async Task<Boolean> handle(CreateEventCommand command)
    {
        var eventEntity = new Event(command.name, command.date, command.location, command.description, command.color); 
        var result = await eventRepository.AddAsync(eventEntity);
        return result;
    }
}