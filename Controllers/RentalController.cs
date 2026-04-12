using CarRental.Models;
using CarRental.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentalController: ControllerBase
{
    private readonly CarService _carService;

    public RentalController(CarService carService)
    {
        _carService = carService;
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> RentCar(int id)
    {
        if(await _carService.GetAsync(id) is not Car)
        {
            return NotFound();
        }

        if(!await _carService.Rent(id))
        {
            return BadRequest();
        }
        
        return NoContent();
    }
}