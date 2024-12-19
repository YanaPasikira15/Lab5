using System;
using System.Collections.Generic;

abstract class Vehicle
{
    public double Speed { get; set; }
    public int Capacity { get; set; }
    public int CurrentPassengers { get; private set; }
    public abstract void Move();

    public void LoadPassengers(int count)
    {
        if (CurrentPassengers + count <= Capacity)
        {
            CurrentPassengers += count;
            Console.WriteLine($"{count} пасажирів посаджено. Загалом: {CurrentPassengers}");
        }
        else
            Console.WriteLine("Недостатньо місця.");
    }
    public void UnloadPassengers(int count)
    {
        if (CurrentPassengers >= count)
        {
            CurrentPassengers -= count;
            Console.WriteLine($"{count} пасажирів висаджено. Залишилося: {CurrentPassengers}");
        }
        else
            Console.WriteLine("Недостатньо пасажирів для висадки.");
    }
}

class Car : Vehicle
{
    public override void Move() => Console.WriteLine($"Машина рухається зі швидкістю {Speed} км/год");
}

class Bus : Vehicle
{
    public override void Move() => Console.WriteLine($"Автобус рухається зі швидкістю {Speed} км/год");
}

class Train : Vehicle
{
    public override void Move() => Console.WriteLine($"Потяг рухається зі швидкістю {Speed} км/год");
}

class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }

    public void DisplayRoute()
    {
        Console.WriteLine($"Маршрут: {StartPoint} -> {EndPoint}");
    }
    public double CalculateDistance() => new Random().Next(10, 100);
}

class TransportNetwork
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle) => vehicles.Add(vehicle);
    public void MoveVehicles()
    {
        foreach (var vehicle in vehicles)
            vehicle.Move();
    }
}

class Program
{
    static void Main()
    {
        var network = new TransportNetwork();
        var car = new Car { Speed = 100, Capacity = 4 };
        var bus = new Bus { Speed = 60, Capacity = 40 };
        var train = new Train { Speed = 120, Capacity = 200 };

        network.AddVehicle(car);
        network.AddVehicle(bus);
        network.AddVehicle(train);
        network.MoveVehicles();

        var route = new Route { StartPoint = "Київ", EndPoint = "Львів" };
        route.DisplayRoute();
        Console.WriteLine($"Відстань маршруту: {route.CalculateDistance()} км");
        car.LoadPassengers(3);
        bus.LoadPassengers(30);
        train.LoadPassengers(150);
        car.UnloadPassengers(1);
        bus.UnloadPassengers(10);
        train.UnloadPassengers(50);
    }
}
