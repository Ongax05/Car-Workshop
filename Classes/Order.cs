using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairs.Classes;

class Order {
    public string Order_Id { get; set; }
    public DateTime Order_Date { get; set; }
    public Customer Realted_Customer { get; set; }
    public Vehicle Related_Vehicle { get; set; }
    public string Customer_Judgment { get; set; }
    public List<Employee> Employees_in_Charge { get; set; }
    public List<string> Experts_Judgments { get; set; }
    public List<Approval_Order> Approval_Orders { get; set;}

    public Order(string orderId, Customer customer, Vehicle vehicle, string customer_judgement){
        this.Order_Id = orderId;
        this.Order_Date = DateTime.Today;
        this.Realted_Customer = customer;
        this.Related_Vehicle = vehicle;
        this.Customer_Judgment = customer_judgement;
        this.Employees_in_Charge = new List<Employee>();
        this.Experts_Judgments = new List<string>();
        this.Approval_Orders = new List<Approval_Order>();
    }

    public static string order_id;
    public static string customer_judgement;

    public static void Add_Order(Customer customer, Vehicle vehicle) {
        Console.Write("Enter Order id: ");order_id = Console.ReadLine();
        Console.Write("Enter Customer judgement: ");customer_judgement = Console.ReadLine();
        customer.Orders.Add(new Order(order_id,customer,vehicle,customer_judgement));
    }
    public static Order Find_Order(List<Order> orders) {
        Console.Write("Enter Order id: ");order_id = Console.ReadLine();
        return orders.Find(o => o.Order_Id == order_id);
    }

    public static void Remove_Order(List<Order> orders) {
        Order order = Order.Find_Order(orders);
        if (order == null) {Console.WriteLine("Order not found, try again, enter some key to continue");Console.ReadKey();}
        else {orders.Remove (order);}
    }

    public static void View_All (List<Order> orders) {
        Console.Clear();
        foreach (Order order in orders)
        {
            Console.Write($"Order id: {order.Order_Id}\nOrder date: {order.Order_Date}\nRelated customer: {order.Realted_Customer.Name}\nVehicle plate: {order.Related_Vehicle.Plate}\n");
        } Console.WriteLine($"Enter some key for continue");Console.ReadKey();
    }
    public static void View_One(List<Order> orders) {
        Order order = Find_Order(orders);
        Console.Write($"Order id: {order.Order_Id}\nOrder date: {order.Order_Date}\nRelated customer: {order.Realted_Customer.Name}\nVehicle plate: {order.Related_Vehicle.Plate}\nCustomer judgement: {order.Customer_Judgment}");
        Console.WriteLine("Judgements");
        foreach (String judgement in order.Experts_Judgments) {
            Console.Write($"{judgement}");
        }
        Console.WriteLine("Experts judgements\n");
        foreach (string judgement in order.Experts_Judgments)
        {
            Console.WriteLine($"{judgement}\n");
        }
        Console.WriteLine("Employees on charge\n");
        foreach(Employee employee in order.Employees_in_Charge){
            Console.Write($"{employee.Name}");
        }
        Console.WriteLine("Approval orders\n");
        foreach (Approval_Order approval_Order in order.Approval_Orders)
        {
            Console.WriteLine($"\nRelated order{approval_Order.Related_Order}");
            foreach (Spare spare in approval_Order.Spares){
                System.Console.WriteLine($"Spare name: {spare.Spare_Name}\nSpare amount: {spare.Amount}");
            }
        }
        Console.WriteLine("Enter some key to continue");Console.ReadKey();
    }
}