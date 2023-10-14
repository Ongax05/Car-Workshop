using AutoRepairs.Views;
using AutoRepairs.Classes;

class Program {
  static void Main(){
    int opt;
    int opt2;
    int opt3;
    Auto_Repairs auto_Repairs = new();

    do{
      Console.Clear();
      opt = View.DisplayMenu("1.Manage Workshop\n2.Reapairs\n3.Leave");
      Customer customer;
      Vehicle vehicle;
      switch (opt){
        #region Manage Workshop Menu
        case 1:
          do{
            Console.Clear();
            opt2 = View.DisplayMenu("1.Employees\n2.Customers\n3.Vehicles\n4.Leave");
            switch (opt2){
              #region Employee Menu
              case 1:
                do {
                  Console.Clear();
                  opt3 = View.DisplayMenu("1.Add employee\n2.Remove employee\n3.View all employees\n4.View specific employee\n5.Leave");
                  switch (opt3){
                    case 1:
                      Employee.Add_Employee(auto_Repairs.Employee_List);
                      break;
                    case 2:
                      Employee.Remove_Employee(auto_Repairs.Employee_List);
                      break;
                    case 3:
                      Employee.View_All(auto_Repairs.Employee_List);
                      break;
                    case 4:
                      Employee.View_One(auto_Repairs.Employee_List);
                      break;
                    case 5:
                      break;
                    default:
                      Console.WriteLine("Invalid option");
                      break;
                  }
                } while (opt3 != 5);
                break;
              #endregion
              
              #region Costumer Menu
              case 2:
                do {
                  Console.Clear();
                  opt3 = View.DisplayMenu("1.Add Customer\n2.Remove customer\n3.View all customers\n4.View specific customer\n5.Leave");
                  switch (opt3){
                    case 1:
                      Customer.Add_Customer(auto_Repairs.Customer_List);
                      break;
                    case 2:
                      Customer.Remove_Customer(auto_Repairs.Customer_List);
                      break;
                    case 3:
                      Customer.View_All(auto_Repairs.Customer_List);
                      break;
                    case 4:
                      Customer.View_One(auto_Repairs.Customer_List);
                      break;
                    default:
                      Console.WriteLine("Invalid option");
                      break;
                  }
                } while (opt3 != 5);
                break;
              #endregion           

              #region Vehicles menu
              case 3:
                do {
                  Console.Clear();
                  if (auto_Repairs.Customer_List.Count == 0){Console.WriteLine("At least, enter 1 customer, enter some key for continue");Console.ReadKey();break;}
                  opt3 = View.DisplayMenu("1.Add vehicle\n2.Remove vehicle\n3.View all\n4.View one\n5.Leave");
                  switch (opt3){
                    case 1:
                      customer = Customer.Find_Customer(auto_Repairs.Customer_List);
                      if (customer != null){
                        Vehicle.Add_Vehicle(customer.Vehicles);
                      } else {Console.WriteLine("Customer not found, enter some key to continue");Console.ReadKey();}
                      break;
                    case 2:
                      customer = Customer.Find_Customer(auto_Repairs.Customer_List);
                      if (customer != null){
                        Vehicle.Remove_Vehicle(customer.Vehicles);
                      } else {Console.WriteLine("Customer not found, enter some key to continue");Console.ReadKey();}
                      break;
                    case 3:
                      customer = Customer.Find_Customer(auto_Repairs.Customer_List);
                      if (customer != null){
                        Console.Clear();
                        Vehicle.View_All(customer.Vehicles);
                      } else {Console.WriteLine("Customer not found, enter some key to continue");Console.ReadKey();}
                      break;
                    case 4:
                      customer = Customer.Find_Customer(auto_Repairs.Customer_List);
                      if (customer != null){
                        try{
                        Vehicle.View_One(Vehicle.Find_Vehicle(customer.Vehicles)); Console.WriteLine("Enter some key to continue");Console.ReadKey();
                        } catch (Exception e) { Console.WriteLine($"An error ocurred : {e}");}
                      } else {Console.WriteLine("Customer not found, enter some key to continue");Console.ReadKey();}
                      break;
                      case 5:
                        break;
                    default:
                      Console.WriteLine("Invalid option");
                      break;
                  }
                } while (opt3 != 5);
                break;
              #endregion

              default:
                Console.WriteLine("Invalid option");
                break;
            }
          } while (opt2 != 4);
          break;
        #endregion 
        
        #region Repairs Menu
        case 2:
        do{
          Console.Clear();
          opt2 = View.DisplayMenu("1.Orders\n2.Bills\n3.Approval orders\n4.Leave");
          customer = Customer.Find_Customer(auto_Repairs.Customer_List);
          vehicle = new Vehicle();
          #region Vars
        if (customer == null){
          Console.WriteLine("Customer not found, try again, enter some key to continue");Console.ReadKey();opt2 = 5;
        } else {
          if (customer.Vehicles.Count == 0){
            System.Console.WriteLine("Add one vehicle at least, enter some key to continue");Console.ReadKey();opt2 = 5;
          } else {
            vehicle = Vehicle.Find_Vehicle(customer.Vehicles);
            if (vehicle == null){System.Console.WriteLine("Vehicle not found, enter some key to continue");Console.ReadKey();opt2 = 5;}
          }
        }
        #endregion
        
          Console.Clear();
          switch (opt2){
            #region Orders
            case 1:
              do {
                Console.Clear();
                opt3 = View.DisplayMenu("1.Add order\n2.Remove order\n3.View all\n4.View one\n5.Leave");
                switch (opt3){
                  case 1:
                    Order.Add_Order(customer,vehicle);
                    break;
                  case 2:
                    Order.Remove_Order(customer.Orders);
                    break;
                  case 3:
                    Order.View_All(customer.Orders);
                    break;
                  case 4:
                    Order.View_One(customer.Orders);
                    break;
                  case 5:
                    break;
                  default:
                    Console.WriteLine("Invalid input, try again, enter some key to continue");Console.ReadKey();
                    break;
                }
              } while (opt3 != 5);
              break;
            #endregion

            #region Approval_orders
            case 3:
              Order order = Order.Find_Order(customer.Orders);
              if (order != null){
                do {
                  Console.Clear();
                  opt3 = View.DisplayMenu("1.Add Approval order\n2.Remove Approval order\n3.View all\n4.View one\n5.Leave");
                  switch (opt3){
                    case 1:
                      Order.Add_Order(customer,vehicle);
                      break;
                    case 2:
                      Order.Remove_Order(customer.Orders);
                      break;
                    case 3:
                      Order.View_All(customer.Orders);
                      break;
                    case 4:
                      Order.View_One(customer.Orders);
                      break;
                    case 5:
                      break;
                    default:
                      Console.WriteLine("Invalid input, try again, enter some key to continue");Console.ReadKey();
                      break;
                  }
                } while (opt3 != 5);
              } else {Console.WriteLine($"The order does not exist");Console.ReadKey();}
              break;
            #endregion

            case 4:
            opt2 = 4;
              break;
            default:
              opt2 = 4;
              break;
          }
        } while (opt2 != 4);
          break;
        #endregion
      }
    } while (opt != 3);
  }
}