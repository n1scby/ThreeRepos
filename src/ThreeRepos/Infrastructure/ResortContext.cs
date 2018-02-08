using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class ResortContext : DbContext
    {
        public ResortContext(DbContextOptions<ResortContext> options) : base(options)
        {

        }
        public DbSet<Resort> Resorts { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
        //}
    
    }
}
