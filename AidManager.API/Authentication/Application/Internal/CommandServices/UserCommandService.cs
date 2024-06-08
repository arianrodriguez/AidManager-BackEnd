using AidManager.API.Authentication.Domain.Model.Commands;
using AidManager.API.Authentication.Domain.Model.Entities;
using AidManager.API.Authentication.Domain.Repositories;
using AidManager.API.Authentication.Domain.Services;
using AidManager.API.Shared.Domain.Repositories;
using AidManager.API.UserProfile.Domain.Model.Commands;
using Microsoft.EntityFrameworkCore.Storage;

namespace AidManager.API.Authentication.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command)
    {
        var user = new User(command.FirstName, command.LastName, command.Age, command.Email, command.Phone, command.Occupation, command.Password, command.ProfileImg, command.Role, command.CompanyName, command.Bio);
        await userRepository.AddAsync(user);
        await unitOfWork.CompleteAsync();
        return user;
    }
    
    public async Task<User> Handle(UpdateUserCommand command, string email)
    {
        var user = await userRepository.FindUserByEmail(email);
        user.updateProfile(command);
        await userRepository.Update(user);
        await unitOfWork.CompleteAsync();
        return user;
    }

    public async Task<bool> AuthenticateUser(ValidateUserCredentialsCommand command)
    {
        var user = await userRepository.FindUserByEmail(command.Email);
        if (user == null)
        {
            return false;
        }
        
        Console.WriteLine("User found in UserRepository");
        Console.WriteLine(user.Password + " == " + command.Password);
        return user.Password == command.Password;
    }
}