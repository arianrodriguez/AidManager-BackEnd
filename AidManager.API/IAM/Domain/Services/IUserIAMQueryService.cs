using AidManager.API.IAM.Domain.Model.Aggregates;
using AidManager.API.IAM.Domain.Model.Queries;

namespace AidManager.API.IAM.Domain.Services;

public interface IUserIAMQueryService
{
    Task<UserAuth?> Handle(GetUserIAMByIdQuery query);
}