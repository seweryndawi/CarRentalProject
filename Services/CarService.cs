using CarRental.Data;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services;

public class CarService
{
    private readonly CarRentalContext _context;
    public CarService(CarRentalContext context)
    {
        _context = context;
    }


    public async Task AddAsync(Car car)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
    }


    public async Task<Car?> GetAsync(int id)
    {
        return await _context.Cars.FirstOrDefaultAsync(obj => obj.Id == id);
    }


    public async Task<List<Car>> GetAllAsync()
    {
        return await _context.Cars.ToListAsync();
    }


    public async Task DeleteAsync(int id)
    {
        if (await GetAsync(id) is Car carToDelete)
        {
            _context.Cars.Remove(carToDelete);
            await _context.SaveChangesAsync();
        }
    }


    public async Task UpdateAsync(int id, Car car)
    {
        if (await _context.Cars.FindAsync(id) is Car carToUpdate)
        {
            carToUpdate.Name = car.Name;
            carToUpdate.Cost = car.Cost;
            carToUpdate.Available = car.Available;
            await _context.SaveChangesAsync();
        }
    }


    public async Task<bool> Rent(int id)
    {
        Car carToRent = (await _context.Cars.FindAsync(id))!;
        
        if(carToRent.Available == false)
            return false;

        carToRent.Available = false;
        await _context.SaveChangesAsync();
        return true;
    }
}