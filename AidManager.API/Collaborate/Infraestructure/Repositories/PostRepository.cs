using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AidManager.API.Collaborate.Domain.Model.Entities;
using AidManager.API.Collaborate.Domain.Repositories;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AidManager.API.Collaborate.Infraestructure.Repositories;

// here manage the CRUD operations of the Post entity in the database using Entity Framework Core from IPostRepository
public class PostRepository(AppDBContext context) : BaseRepository<Post>(context), IPostRepository
{
    public async Task<IEnumerable<Post>?> GetAllPosts()
    {
        using (var transaction = Context.Database.BeginTransaction())
        {
            try
            {
                Console.WriteLine("Getting all posts in PostRepository");
                var result = await Context.Set<Post>()
                    .Include(p => p.User) // Carga el objeto User asociado con cada Post
                    .ToListAsync();
                await transaction.CommitAsync();
                Console.WriteLine("All posts got in PostRepository");
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error getting all posts in PostRepository" + e.Message);
                throw;
            }
        }
    }

    public async Task<Post?> FindPostById(int id)
    {
        using (var transaction = Context.Database.BeginTransaction())
        {
            try
            {
                Console.WriteLine("Finding post by id in PostRepository");
                var result = await Context.Set<Post>()
                    .Include(p => p.User)
                    .FirstOrDefaultAsync(x => x.Id == id);
                await transaction.CommitAsync();
                Console.WriteLine("Post found by id in PostRepository");
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error finding post by id in PostRepository" + e.Message);
                throw;
            }
        }
    }

    public async Task<IEnumerable<Post>?> GetAllPostsByCompanyId(int companyId)
    {
        using (var transaction = Context.Database.BeginTransaction())
        {
            try
            {
                Console.WriteLine("Getting all posts by company id in PostRepository");
                var result = await Context.Set<Post>()
                    .Include(p => p.User)
                    .Where(x => x.CompanyId == companyId)
                    .ToListAsync();
                await transaction.CommitAsync();
                Console.WriteLine("All posts by company id got in PostRepository");
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error getting all posts by company id in PostRepository" + e.Message);
                throw;
            }
        }
    }
}