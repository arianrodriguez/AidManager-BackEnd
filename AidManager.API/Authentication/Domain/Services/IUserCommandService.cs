using AidManager.API.Authentication.Domain.Model.Commands;
using AidManager.API.Authentication.Domain.Model.Entities;

namespace AidManager.API.Authentication.Domain.Services;

public interface IUserCommandService
{
    Task<User?> Handle(CreateUserCommand command);
    Task<bool> AuthenticateUser(ValidateUserCredentialsCommand command);
}