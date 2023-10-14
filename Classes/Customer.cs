using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairs.Classes;

class Customer : Person {
    public string Email { get; set; }
    public DateTime Register_Date { get; set; }
    public List<Vehicle> Vehicles { get; set; }
    public List<Order> Orders { get; set; }
    public List<Bill> Bills { get; set; }

    public Customer (int Id, string Name, string Telephone,string email, DateTime register_date):base(Id, Name, Telephone) {
        this.Email = email;
        this.Register_Date = register_date;
        this.Vehicles = new List<Vehicle>();
        this.Orders = new List<Order>();
        this.Bills = new List<Bill>();
    }

    public Customer () {}

    public static string email;

    public override void Get_Values (string type){
        base.Get_Values($"{type}");
        Console.Write($"Enter {type}'s email: ");email = Console.ReadLine();
    }
    public static void Add_Customer (List<Customer> customers){
        new Customer().Get_Values("customer");
        DateTime currentDate = DateTime.Today;
        Customer newCustomer = new( id, name, telephone, email, currentDate);
        customers.Add(newCustomer);
    }

    public static void View_One (List<Customer> customers){
        Console.Clear();
        try {
            Customer customer = Find_Customer(customers);
            Console.WriteLine($"Id: {customer.Id}\nName: {customer.Name}\nTelephone: {customer.Telephone}\nEmail: {customer.Email}\nVehicles: {customer.Vehicles.Count}\nOrders: {customer.Orders.Count}\nBills: {customer.Bills.Count}\n");
            Console.WriteLine("Enter some key to continue");Console.ReadKey();
        }catch (Exception ex){Console.WriteLine("An error occurred: " + ex.Message);Console.ReadKey();}
    }
    public static void View_All (List<Customer> customers){
        Console.Clear();
        if (customers.Count != 0){
            Console.WriteLine("");
            foreach (Customer customer in customers){
                Console.WriteLine($"Id: {customer.Id}\nName: {customer.Name}\nTelephone: {customer.Telephone}\nEmail: {customer.Email}\nVehicles: {customer.Vehicles.Count}\nOrders: {customer.Orders.Count}\nBills: {customer.Bills.Count}\n");
            } Console.Write("Enter some key to continue");Console.ReadKey();
        } else {Console.Write("The customer's list doesn't has no one, enter some key to continue");Console.ReadKey();}
    }

    public static Customer Find_Customer (List<Customer> customers){
        Console.Clear();
        Customer.View_All(customers);
        Console.Clear();
        Console.Write("Enter customer's id: ");while (!int.TryParse(Console.ReadLine(), out id)){Console.WriteLine("Please, enter a correct option");}
        Console.Write("Enter customer's name: ");name = Console.ReadLine();
        return customers.Find(e => e.Id == id && e.Name.ToLower() == name.ToLower());
    }
    public static void Remove_Customer (List<Customer> customers){
        Customer.View_All(customers);
        customers.Remove(Customer.Find_Customer(customers));
    }
}
