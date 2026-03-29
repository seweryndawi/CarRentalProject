using CarRental.Models;
using CarRental.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarRentalController : ControllerBase
{
    private readonly CarService _carService;

    public CarRentalController(CarService carService)
    {
        _carService = carService;
    }


    [HttpGet]
    public async Task<ActionResult<List<Car>>> GetAll()
    {
        return Ok(await _carService.GetAllAsync());
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Car?>> Get(int id)
    {
        if (await _carService.GetAsync(id) is not Car car)
        {
            return NotFound();
        }

        return Ok(car);
    }


    [HttpPost]
    public async Task<ActionResult> Add(Car car)
    {
        if (car == null)
        {
            return BadRequest();
        }

        await _carService.AddAsync(car);
        return CreatedAtAction(nameof(Get), new {id = car.Id}, car);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Change(int id, Car car)
    {
        if (id != car.Id)
        {
            return BadRequest();
        }

        else if (await _carService.GetAsync(id) == null)
        {
            return NotFound();
        }

        await _carService.UpdateAsync(id, car);
        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (await _carService.GetAsync(id) == null)
        {
            return NotFound();
        }

        await _carService.DeleteAsync(id);
        return NoContent();
    }
}