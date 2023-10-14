using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairs.Views;

public class View {
    public static int HandleInput (){
        int choice;
        Console.Write("Please, Enter your choice: ");
        while (!int.TryParse(Console.ReadLine(),out choice)){
            Console.WriteLine("Invalid input, do it again.");
        } return choice;
    }
    public static int DisplayMenu (string menuData){
        Console.WriteLine(menuData);
        return HandleInput();
    }
}