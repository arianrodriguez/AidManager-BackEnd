using AidManager.API.ManageTasks.Domain.Model.Aggregates;
using AidManager.API.ManageTasks.Domain.Repositories;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AidManager.API.ManageTasks.Infrastructure.Repositories;

public class ProjectsRepository : BaseRepository<Project>, IProjectRepository
{
    public ProjectsRepository(AppDBContext context) : base(context){}
    
    public Task<bool> ExistsProject(int projectId)
    {
        return Context.Set<Project>().AnyAsync(f => f.Id == projectId);
    }
    
    public Task<bool> ExistsByName(string name)
    {
        return Context.Set<Project>().AnyAsync(f => f.Name == name);
    }
    
    public async Task<IEnumerable<Project>> GetAllProjectsByCompanyId(string companyId)
    {
        return await Context.Set<Project>().Where(f => f.CompanyId == companyId).ToListAsync();
    }
    
}