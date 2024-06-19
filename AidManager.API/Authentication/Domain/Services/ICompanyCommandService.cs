using AidManager.API.Authentication.Domain.Model.Commands;

namespace AidManager.API.Authentication.Domain.Services;

public interface ICompanyCommandService
{
    Task<bool> handle(CreateCompanyCommand command);
}