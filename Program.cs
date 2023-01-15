
using HistoricalTimelines;
using System;
using System.Linq;

using var db = new HistoricalEntities();

Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new Entity");
db.Add(new Person {Name = "Henry IV, King of England", 
                   Latitude = 53.164140M, 
                   Longitude = 0.0163800M, 
                   Time_Birth = new DateOnly ( 1367, 4, 1 ), 
                   Time_Death = new DateOnly ( 1413, 3, 20) });
db.Add(new Building {Name = "Versailles", 
                     Latitude = 48.801407M,
                     Longitude = 2.130122M,
                     Built = new DateOnly (1661, 07, 17) });
db.SaveChanges();

// Read
Console.WriteLine("Querying for an Entity");
var entity = db.Entities
    .OrderBy(b => b.EntityId)
    .First();

// Update
Console.WriteLine("Updating the database and adding an Entity");
db.Entities.First(a => a.EntityId == 2);
entity.Persons.Add(
    new Person {Name = "Richard I Lionheart, King of England",
                Time_Birth = new DateOnly (1157, 9, 8),
                Latitude = 51.7550582885742M,
                Longitude = -1.26209998130798M,
                Time_Death = new DateOnly (1199, 4, 6)
    });
db.SaveChanges();

// Delete
Console.WriteLine("Delete the Entity");
db.Remove(entity);
db.SaveChanges();
