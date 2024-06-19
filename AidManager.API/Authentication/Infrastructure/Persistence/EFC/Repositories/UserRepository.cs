using AidManager.API.Authentication.Domain.Model.Entities;
using AidManager.API.Authentication.Domain.Repositories;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AidManager.API.Authentication.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDBContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindUserByEmail(string email)
    {
        using (var trans = Context.Database.BeginTransaction())
        {
            try
            {
                Console.WriteLine("Searching by email user in UserRepository");
                var result = await Context.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
                await trans.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                Console.WriteLine("Error searching by email user in UserRepository");
                await trans.RollbackAsync();
                return null;
            }
        }
    }
}