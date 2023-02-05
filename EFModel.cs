using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalTimelines
{
    public class HistoricalEntities : DbContext
    {
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public string DbPath { get; }

        public HistoricalEntities()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "deafult.db");
        }

       
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data Source={DbPath}");
    }

    public class Entity
    {
        public int EntityId { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public DateTime Date { get; set; }

        public List<Person> Persons { get; } = new();
        public List<Building> Buildings { get; } = new();
    }

    public class Person
    {
        public int NameId { get; set; }
        public string Name { get; set; }
        public string? Lastname { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public DateOnly Time_Birth { get; set; }
        public DateOnly? Time_Death { get; set; }    

        public Entity Entity { get; set; }

        
    }
    public class Building
    {
        public int NameId { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateOnly Built { get; set; }
        public DateOnly? Razed { get; set; }
        public Entity Entity { get; set; }
    }
}
