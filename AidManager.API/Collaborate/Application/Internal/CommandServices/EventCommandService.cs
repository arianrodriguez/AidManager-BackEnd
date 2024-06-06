using System.Diagnostics.Tracing;
using AidManager.API.Collaborate.Domain.Model.Aggregates;
using AidManager.API.Collaborate.Domain.Model.Commands;
using AidManager.API.Collaborate.Domain.Model.Entities;
using AidManager.API.Collaborate.Domain.Repositories;
using AidManager.API.Collaborate.Domain.Services;

namespace AidManager.API.Collaborate.Application.Internal.CommandServices;

public class EventCommandService(IEventRepository eventRepository) : IEventCommandService
{
    public async Task<Boolean> handle(CreateEventCommand command)
    {
        try
        {
            var eventEntity = new Event(command);
            var result = await eventRepository.AddAsync(eventEntity);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            return false;
        }
    }
}