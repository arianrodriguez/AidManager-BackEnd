using AidManager.API.Authentication.Domain.Model.Commands;
using AidManager.API.Authentication.Domain.Model.Entities;
using AidManager.API.Authentication.Domain.Repositories;
using AidManager.API.Authentication.Domain.Services;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.Authentication.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command)
    {
        var user = new User(command.FirstName, command.LastName, command.Email, command.Password, command.ProfileImg,
            command.Role, command.CompanyName);
        await userRepository.AddAsync(user);
        await unitOfWork.CompleteAsync();
        return user;
    }
}