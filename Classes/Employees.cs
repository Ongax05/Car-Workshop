using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairs.Classes;

class Employee : Person {
    public string Speciality{get;set;}
    public Employee(int Id,string Name,string Telephone,string Speciality):base(Id,Name,Telephone){ 
        this.Speciality = Speciality;
    }

    public Employee (){}

    public static string speciality;
    public override void Get_Values (string type){
        base.Get_Values($"{type}");
        Console.Write($"Enter {type}'s speciality: ");speciality = Console.ReadLine();
    }
    public static void Add_Employee (List<Employee> employees){
        new Employee().Get_Values("employee");
        Employee newEmployee = new( id, name, telephone, speciality);
        employees.Add(newEmployee);
    }

    public static void View_One (List<Employee> employees){
        Console.Clear();
        try {
            Employee employee = Find_Employee(employees);
            Console.WriteLine($"Id: {employee.Id}\nName: {employee.Name}\nTelephone: {employee.Telephone}\nEmail: {employee.Speciality}\n");
            Console.WriteLine("Enter some key to continue");Console.ReadKey();
        }catch (Exception ex){Console.WriteLine("An error occurred: " + ex.Message);Console.ReadKey();}
    }
    public static void View_All (List<Employee> employees){
        Console.Clear();
        if (employees.Count != 0){
            Console.WriteLine("");
            foreach (Employee employee in employees){
                Console.WriteLine($"Id: {employee.Id}\nName: {employee.Name}\nTelephone: {employee.Telephone}\nSpeciality: {employee.Speciality}\n");
            } Console.Write("Enter some key to continue");Console.ReadKey();
        } else {Console.Write("The employee's list doesn't has no one, enter some key to continue");Console.ReadKey();}
    }

    public static Employee Find_Employee (List<Employee> employees){
        Console.Clear();
        Employee.View_All(employees);
        Console.Clear();
        Console.Write("Enter employee's id: ");while (!int.TryParse(Console.ReadLine(), out id)){Console.WriteLine("Please, enter a correct option");}
        Console.Write("Enter employee's name: ");name = Console.ReadLine();
        return employees.Find(e => e.Id == id && e.Name.ToLower() == name.ToLower());
    }
    public static void Remove_Employee (List<Employee> employees){
        Employee.View_All(employees);
        employees.Remove(Employee.Find_Employee(employees));
    }
}