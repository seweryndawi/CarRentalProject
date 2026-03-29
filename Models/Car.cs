namespace CarRental.Models;

public class Car
{
    public int Id {get; set;}
    public string Name {get; set;} = null!;
    public int Cost {get; set;}
    public bool Available {get; set;}
}