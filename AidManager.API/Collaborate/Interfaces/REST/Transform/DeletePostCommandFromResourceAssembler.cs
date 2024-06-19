using AidManager.API.Collaborate.Domain.Model.Commands;

namespace AidManager.API.Collaborate.Interfaces.REST.Transform;

public class DeletePostCommandFromResourceAssembler
{
    public static DeletePostCommand ToCommandFromResource(int id)
    {
        return new DeletePostCommand(id);
    }
}