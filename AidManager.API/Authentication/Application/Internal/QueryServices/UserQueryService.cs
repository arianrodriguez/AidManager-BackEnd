using AidManager.API.Authentication.Domain.Model.Entities;
using AidManager.API.Authentication.Domain.Model.Queries;
using AidManager.API.Authentication.Domain.Repositories;
using AidManager.API.Authentication.Domain.Services;

namespace AidManager.API.Authentication.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<IEnumerable<User>?> Handle(GetAllUsersQuery query)
    {
        Console.WriteLine("Obtaining all users");
        return await userRepository.ListAsync();
    }
}