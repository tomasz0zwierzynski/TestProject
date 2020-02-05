using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workers.Models;

namespace Workers.Data
{
    public class WorkerContext : DbContext
    {

        public WorkerContext( DbContextOptions<WorkerContext> options) : base(options)
        {
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().ToTable("Worker");
            modelBuilder.Entity<Salary>().ToTable("Salary");
            modelBuilder.Entity<Position>().ToTable("Position");
        }

    }
}
