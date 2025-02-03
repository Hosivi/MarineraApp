using AvantiPoint.MobileAuth.Stores;
using Domain.Aggregates;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContext;
public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Add a default organization
        var org = new Organization()
        {
            Name = "Default Organization"
        };
        modelBuilder.Entity<Organization>().HasData(org);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
    public DbSet<Concourse> Concourses { get; set; }
    public DbSet<Modality> Modalities { get; set; }
    public DbSet<TicketOffice> TicketOffices { get; set; }
    public DbSet<RegisterOffice> RegisterOffices { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ConcourseRule> ConcourseRules { get; set; }

    
}
