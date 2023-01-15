
using HistoricalTimelines;
using System;
using System.Linq;

using var db = new HistoricalEntities();

Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new Entity");
db.Add(new Person { Name  = "Henry IV", Title = "King of England" });
db.Add(new Building { Name = "Versailles", Built = new DateTime (1661) });
db.SaveChanges();

// Read
Console.WriteLine("Querying for an Entity");
var entity = db.Entities
    .OrderBy(b => b.EntityId)
    .First();

// Update
Console.WriteLine("Updating the database and adding an Entity");
entity.Time_Birth = new DateTime (1367, (DateTimeKind)6);
entity.Persons.Add(
    new Person { Name = "Richard I Lionheart", Title = "King of England" });
db.SaveChanges();

// Delete
Console.WriteLine("Delete the Entity");
db.Remove(entity);
db.SaveChanges();
