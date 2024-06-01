using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AidManager.API.SampleBounded.Domain.Model.Aggregates;
using AidManager.API.SampleBounded.Domain.Repositories;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AidManager.API.SampleBounded.Infraestructure.Repositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{   
    // repository -> here implement transactions 
    public BookRepository(AppDBContext context) : base(context) {}


    // managing transactions BEST PRATICES YESI
    public Task<Book> CreateBook(Book entity)
    {
        using (var transaction = Context.Database.BeginTransaction())
        {
            try
            {
                Context.Set<Book>().Add(entity);
                Context.SaveChanges();
                transaction.Commit();
                Console.WriteLine("Book created successfully");
                return Task.FromResult(entity);
            }
            catch(Exception)
            {
                Console.WriteLine("Error creating book");
                transaction.Rollback();
            }
            return Task.FromResult<Book>(null);
            
        }
    }
    public Task AddAsync(Book entity)
    {
        Console.WriteLine("adding book to repository");
        return base.AddAsync(entity);
    }

    public async Task<IEnumerable<Book>> FindByIdAsync(int id)
    {
        Console.WriteLine("find by id in BookRepository");
        return await Context.Set<Book>().Where(b => b.Id == id).ToListAsync();
    }
    
}