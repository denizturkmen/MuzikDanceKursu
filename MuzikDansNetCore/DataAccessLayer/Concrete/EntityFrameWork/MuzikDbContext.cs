using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MuzikDansNetCore.Entities;

namespace MuzikDansNetCore.DataAccessLayer.Concrete.EntityFrameWork
{
    public class MuzikDbContext : DbContext
    {
        public MuzikDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DENIZ-PC;Database=MuzikDanceDB;Integrated Security=true");
        }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Branch> Branches { get; set; }

    }
}
