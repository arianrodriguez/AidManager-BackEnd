using AidManager.API.Shared.Infraestructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AidManager.API.Shared.Infraestructure.Persistence.EFC.Configuration;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions options) : base(options){}
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // this method is to configure the database schema and the tables
        base.OnModelCreating(builder);
        
        // this is to the name tables conver to snake case "LuchoPortuano" -> "lucho_portuano"
        builder.UseSnakeCaseNamingConvention();
    }
}