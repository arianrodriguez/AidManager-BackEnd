using AidManager.API.Collaborate.Domain.Model.Entities;

namespace AidManager.API.Collaborate.Domain.Model.Aggregates;

public class EventAggregate
{
    Event eventEntity;

    public EventAggregate()
    {
        this.eventEntity = new Event();
    }

    public EventAggregate(Event eventEntity)
    {
        this.eventEntity = eventEntity;
    }
}