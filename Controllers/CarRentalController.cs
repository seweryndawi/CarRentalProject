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
    public ActionResult<List<Car>> GetAll()
    {
        return Ok(_carService.GetAll());
    }


    [HttpGet("{id}")]
    public ActionResult<Car?> Get(int id)
    {
        if (_carService.Get(id) is not Car car)
        {
            return NotFound();
        }

        return Ok(car);
    }


    [HttpPost]
    public ActionResult Add(Car car)
    {
        if (car == null)
        {
            return BadRequest();
        }

        car.Id = _carService.GetNextId();
        _carService.Add(car);
        return CreatedAtAction(nameof(Get), new {id = car.Id}, car);
    }


    [HttpPut("{id}")]
    public IActionResult Change(int id, Car car)
    {
        if (id != car.Id)
        {
            return BadRequest();
        }

        else if (_carService.Get(id) == null)
        {
            return NotFound();
        }

        _carService.Update(car);
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (_carService.Get(id) == null)
        {
            return NotFound();
        }

        _carService.Delete(id);
        return NoContent();
    }
}