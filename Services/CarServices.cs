using CarRental.Models;

namespace CarRental.Services;
public class CarService
{
    public List<Car> Cars;
    private int _nextId = 3;
    public CarService()
    {
        Cars = new List<Car>()
        {
            new Car{Id = 1, Name = "Honda", Cost = 2850, Available = 2},
            new Car{Id = 2, Name = "Opel", Cost = 2000, Available = 3}
        };
    }


    public int GetNextId()
    {
        return _nextId;
    }


    public void Add(Car car)
    {
        car.Id = _nextId;
        _nextId++;
        Cars.Add(car);
    }


    public Car? Get(int id)
    {
        return Cars.FirstOrDefault(obj => obj.Id == id);
    }


    public List<Car>? GetAll()
    {
        return Cars;
    }


    public void Delete(int id)
    {
        if (Get(id) is Car carToDelete)
        {
            UpdateAllId(id);
            Cars.Remove(carToDelete);
            _nextId--;
        }
    }


    public void Update(Car car)
    {
        int index = Cars.FindIndex(obj => obj.Id == car.Id);
        if (index != -1) 
        {
            Cars[index] = car;
        }
    }


    private void UpdateAllId(int id)
    {
        if (id != _nextId-1) //Edge case
        {
            for (int index = id; index < _nextId-1; index++)
            {
                Cars[index].Id = index;
            }
        }
    }
}