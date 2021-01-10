using System;
using Microsoft.EntityFrameworkCore;

namespace JobPortalAPI.Models
{
    public class JobDbContext:DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=JobPortal.db");
    }
}
