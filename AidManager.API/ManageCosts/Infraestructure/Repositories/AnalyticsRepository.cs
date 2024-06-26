using AidManager.API.ManageCosts.Domain.Model.Aggregates;
using AidManager.API.ManageCosts.Domain.Repositories;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AidManager.API.ManageCosts.Infraestructure.Repositories;

public class AnalyticsRepository: BaseRepository<Analytics>, IAnalyticsRepository
{
    
    public AnalyticsRepository(AppDBContext context) : base(context)
    {
    }
     
    public async Task<Analytics?> GetAnalyticsById(int id)
    {
        using (var transaction = Context.Database.BeginTransaction())
        {
            try
            {
                return await Context.Set<Analytics>().FindAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
    
    public async Task<Analytics?> GetAnalyticsByProjectId(int projectId)
    {
        using (var transaction = Context.Database.BeginTransaction())
        {
            try
            {
                return await Context.Set<Analytics>().FirstOrDefaultAsync(x => x.ProjectId == projectId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
    
    public async Task<Analytics?> FindAnalyticsById(int id)
    {
        using (var transaction = Context.Database.BeginTransaction())
        {
            try
            {
                return await Context.Set<Analytics>().FindAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
    
}