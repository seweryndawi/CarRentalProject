using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data;

public class CarRentalContext: DbContext
{
    public CarRentalContext(DbContextOptions<CarRentalContext> options): base(options)
    {
    }
    public DbSet<Car> Cars {get; set;}
}