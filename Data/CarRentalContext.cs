using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data;

public class CarRentalContext: DbContext
{
    public DbSet<Car> Cars {get; set;}

    public string DbPath {get;} = null!;

    public CarRentalContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "CarRental.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}