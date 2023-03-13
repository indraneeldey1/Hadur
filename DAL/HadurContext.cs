using System.Reflection;
using DAL.Models;
using Hadur.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class HadurContext: DbContext
{
    public DbSet<UsersDbModel> Users { get; set; }
    
    public HadurContext(DbContextOptions<HadurContext> options): base(options)
    {
    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}