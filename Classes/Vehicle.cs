using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairs.Classes;

class Vehicle {
    public string Plate { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string Mileage { get; set; }

    public Vehicle (string plate, string model, string color, string brand,string mileage) {
        this.Plate = plate;
        this.Model = model;
        this.Brand = brand;
        this.Color = color;
        this.Mileage = mileage;
    }

    public Vehicle (){}

    public static string plate;
    public static string model;
    public static string brand;
    public static string color;
    public static string mileage;

    public static void View_One (Vehicle vehicle) {
        Console.WriteLine ($"Vehicle plate: {vehicle.Plate}\nVehicle model: {vehicle.Model}\nVehicle brand: {vehicle.Brand}\nVehicle colour: {vehicle.Color}\nVehicle mileage: {vehicle.Mileage}\n");
    }
    public static void View_All (List<Vehicle> vehicles) {
        Console.Clear();
        foreach (Vehicle vehicle in vehicles) {
            View_One(vehicle);
        } Console.WriteLine ("Enter some key to continue");Console.ReadKey();
    }
    public static Vehicle Find_Vehicle (List<Vehicle> vehicles) {
        Console.Write("Enter vehicle's plate: "); plate = Console.ReadLine() ?? "Expected data";
        return vehicles.Find (vehicle => vehicle.Plate == plate);
    }

    public static void Add_Vehicle (List<Vehicle> vehicles) {
        Console.Write("Enter vehicle's plate: "); plate = Console.ReadLine() ?? "Expected data";
        Console.Write("Enter vehicle's model: "); model = Console.ReadLine() ?? "Expected data";
        Console.Write("Enter vehicle's brand: "); brand = Console.ReadLine() ?? "Expected data";
        Console.Write("Enter vehicle's color: "); color = Console.ReadLine() ?? "Expected data";
        Console.Write("Enter vehicle's mileage: "); mileage = Console.ReadLine() ?? "Expected data";
        vehicles.Add (new Vehicle (plate, model, brand, color, mileage));
    }
    public static void Remove_Vehicle (List<Vehicle> vehicles) {
        try{
            vehicles.Remove(Vehicle.Find_Vehicle(vehicles));
        } catch (Exception e) {Console.WriteLine($"An error occurred: {e}, enter some key to continue"); Console.ReadKey();
        }
    }
}