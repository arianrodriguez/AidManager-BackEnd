using AidManager.API.SampleBounded.Domain.Model.Commands;
using AidManager.API.SampleBounded.Interfaces.REST.Resources;

namespace AidManager.API.SampleBounded.Interfaces.REST.Transform;

public static class CreateBookCommandFromResourceAssembler
{
    public static CreateBookCommand ToCommandFromResource(CreateBookResource resource) =>
        new CreateBookCommand(resource.Name, resource.Author);
}