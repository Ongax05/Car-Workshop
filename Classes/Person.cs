using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairs.Classes;

class Person {
    
    public int Id {get; set;}
    public string Name {get; set;}
    public string Telephone {get; set;}
    public Person(int Id, string Name, string Telephone){
        this.Id = Id;
        this.Name = Name;
        this.Telephone = Telephone;
    }

    public Person (){}

    public static int id;
    public static string name;
    public static string telephone;

    public virtual void Get_Values (string type){
        Console.Write($"Enter {type}'s id: ");while (!int.TryParse(Console.ReadLine(), out id)){Console.WriteLine("Please, enter a correct option");}
        Console.Write($"Enter {type}'s name: ");name = Console.ReadLine();
        Console.Write($"Enter {type}'s telephone: ");telephone = Console.ReadLine();
    }
}