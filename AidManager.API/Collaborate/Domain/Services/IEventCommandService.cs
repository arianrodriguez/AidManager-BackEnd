using System.Diagnostics.Tracing;
using AidManager.API.Collaborate.Domain.Model.Aggregates;
using AidManager.API.Collaborate.Domain.Model.Commands;
using AidManager.API.Collaborate.Domain.Model.Entities;

namespace AidManager.API.Collaborate.Domain.Services;

public interface IEventCommandService
{
    Task<Boolean> handle(CreateEventCommand command);
    Task<Boolean> handle(EditEventCommand command);
    Task<Boolean> handle(DeleteEventCommand command);
}