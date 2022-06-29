using Microsoft.EntityFrameworkCore;
using TWJobs.Core.Data.EntityConfigs;

namespace TWJobs.Core.Data.Contexts;

public class TWJobsDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("Server=Localhost;Database=TWJobs;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new JobEntityConfig());
    }
}