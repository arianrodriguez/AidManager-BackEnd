using AidManager.API.ManageTasks.Domain.Model.Aggregates;
using AidManager.API.ManageTasks.Domain.Repositories;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AidManager.API.ManageTasks.Infrastructure.Repositories;
public class TaskItemsRepository : BaseRepository<TaskItem>, ITaskRepository
{
    public TaskItemsRepository(AppDBContext context) : base(context) {}
    
    public Task<TaskItem> CreateTaskItem(TaskItem entity)
    {
        using (var transaction = Context.Database.BeginTransaction())
        {
            Console.WriteLine("Task:" + entity);
            
            try
            {
                Context.Set<TaskItem>().Add(entity);
                Context.SaveChanges();
                transaction.Commit();
                Console.WriteLine("Task created successfully");
                return Task.FromResult(entity);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error creating task" + ex.Message);
                transaction.Rollback();
            }
            return Task.FromResult<TaskItem>(null);
            
        }
    }
    
    
    public  Task<TaskItem?> GetAllTasksByProjectId(int id)
    {
        return  Context.Set<TaskItem>().FirstOrDefaultAsync(f => f.Id == id);
    }
    
    public async Task<IEnumerable<TaskItem>> GetAllTasks()
    {
        return await Context.Set<TaskItem>().ToListAsync();
    }
    
}
