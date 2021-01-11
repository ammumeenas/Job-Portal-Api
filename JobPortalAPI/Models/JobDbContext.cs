using System;
using Microsoft.EntityFrameworkCore;

namespace JobPortalAPI.Models
{
    public class JobDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobSkill> JobSkill {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=JobPortal.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobSkill>()
                .HasKey(cs => new { cs.JobId, cs.SkillId });
        }

    }
}
