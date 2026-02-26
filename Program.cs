using sdev2301_a1_ZorawarSinghRandhawa.Data;

using var db = new AppDbContext();
db.Database.EnsureCreated();

Console.WriteLine("Database created successfully!");