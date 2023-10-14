using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairs.Classes;

class Auto_Repairs {

    public List<Customer> Customer_List { get; set; }
    public List<Employee> Employee_List { get; set; }

    public Auto_Repairs (){
        this.Employee_List = new List<Employee>();
        this.Customer_List = new List<Customer>();
    }
}