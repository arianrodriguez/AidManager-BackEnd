using AidManager.API.Authentication.Domain.Model.Commands;
using AidManager.API.Authentication.Domain.Model.Entities;

namespace AidManager.API.Authentication.Domain.Services;

public interface IUserCommandService
{
    public Task<User?> Handle(CreateUserCommand command);
}