using AidManager.API.ManageTasks.Domain.Model.Aggregates;
using AidManager.API.Shared.Domain.Repositories;

namespace AidManager.API.ManageTasks.Domain.Repositories;

public interface IProjectRepository : IBaseRepository<Project>
{
    Task<bool> ExistsProject(int projectId);
    Task<bool> ExistsByName(string name);
    Task<IEnumerable<Project>> GetAllProjectsByCompanyId(string companyId);
}