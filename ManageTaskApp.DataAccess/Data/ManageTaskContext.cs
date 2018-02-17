using ManageTaskApp.DataAccess.DBEntities;
using ManageTaskApp.DataAccess.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageTaskApp.DataAccess.Data
{
    public class ManageTaskContext : DbContext
    {
        public ManageTaskContext(DbContextOptions<ManageTaskContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new TaskMap(modelBuilder.Entity<ManageTask>());
        }
        public DbSet<ManageTask> ManageTask { get; set; }
    }
}