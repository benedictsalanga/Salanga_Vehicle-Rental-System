using System;
using System.Collections.Generic;

class Vehicle
{
    public string vehicleId, brand;
    public double dailyRate;

    public Vehicle(string id, string brand, double rate)
    {
        vehicleId = id;
        this.brand = brand;
        dailyRate = rate;
    }

    public virtual double calculateRentalCost(int days)
    {
        return dailyRate * days;
    }

    public virtual void displayInfo()
    {
        Console.WriteLine(brand);
    }
}

class Car : Vehicle
{
    public int numSeats;

    public Car(string id, string brand, double rate, int seats)
        : base(id, brand, rate)
    {
        numSeats = seats;
    }

    public override double calculateRentalCost(int days)
    {
        return dailyRate * days * 1.10;
    }

    public override void displayInfo()
    {
        Console.WriteLine($"Car [ID={vehicleId}, Brand={brand}, Seats={numSeats}]");
    }
}

class Motorcycle : Vehicle
{
    public int engineCapacity;

    public Motorcycle(string id, string brand, double rate, int cc)
        : base(id, brand, rate)
    {
        engineCapacity = cc;
    }

    public override double calculateRentalCost(int days)
    {
        return dailyRate * days * 0.95;
    }

    public override void displayInfo()
    {
        Console.WriteLine($"Motorcycle [ID={vehicleId}, Brand={brand}, CC={engineCapacity}]");
    }
}

class Customer
{
    public string name, licenseNumber;
    public Vehicle rentedVehicle;

    public Customer(string name, string license)
    {
        this.name = name;
        licenseNumber = license;
    }

    public void rentVehicle(Vehicle v)
    {
        rentedVehicle = v;
    }

    public void returnVehicle()
    {
        rentedVehicle = null;
    }

    public void printRentalSummary(int days)
    {
        Console.WriteLine("\n=== Customer Rental Summary ===");
        Console.WriteLine($"Customer: {name} (License: {licenseNumber})");
        Console.WriteLine($"Rented: {rentedVehicle.brand} Car");
        Console.WriteLine($"Total Cost for {days} days: ${rentedVehicle.calculateRentalCost(days):F2}");
    }
}

class Program
{
    static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        vehicles.Add(new Car("101", "Toyota", 100, 5));
        vehicles.Add(new Motorcycle("102", "Yamaha", 50, 150));

        Console.WriteLine("=== Vehicle Rental Costs ===");

        foreach (Vehicle v in vehicles)
        {
            v.displayInfo();
            Console.WriteLine($"Cost for 3 days: ${v.calculateRentalCost(3):F2}");
        }

        Customer customer = new Customer("Alice", "AB1234");
        customer.rentVehicle(new Car("103", "Honda", 100, 5));
        customer.printRentalSummary(5);
    }
}
