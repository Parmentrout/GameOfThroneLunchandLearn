using GameOfThrones.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameOfThrones.Repository
{
    public class GotContext : DbContext
    {
        public GotContext() :
            base("name=GotContext")
        {
            Database.SetInitializer(new GotDbInitializer());
        }

        public virtual DbSet<House> Houses { get; set; }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>().ToTable("Houses");
            modelBuilder.Entity<Person>().ToTable("People");
            modelBuilder.Entity<Pet>().ToTable("Pets");

            base.OnModelCreating(modelBuilder);
        }
    }
}