using AidManager.API.SampleBounded.Domain.Model.Aggregates;
using AidManager.API.SampleBounded.Interfaces.REST.Resources;

namespace AidManager.API.SampleBounded.Interfaces.REST.Transform;

public static class BookResourceFromEntityAssembler
{
    public static BookResource ToResourceFromEntity(Book entity) =>
        new BookResource(entity.Id, entity.Name, entity.Author);
}