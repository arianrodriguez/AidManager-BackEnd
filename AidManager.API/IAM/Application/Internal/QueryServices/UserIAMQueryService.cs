using AidManager.API.IAM.Domain.Model.Aggregates;
using AidManager.API.IAM.Domain.Model.Queries;
using AidManager.API.IAM.Domain.Repositories;
using AidManager.API.IAM.Domain.Services;

namespace AidManager.API.IAM.Application.Internal.QueryServices;

public class UserIAMQueryService(IUserIAMRepository userRepository) : IUserIAMQueryService
{
    public async Task<UserAuth?> Handle(GetUserIAMByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }
}