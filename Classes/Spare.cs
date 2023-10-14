using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairs.Classes;
class Spare {
    public string Spare_Id { get; set; }
    public string Spare_Name { get; set; }
    public long Unit_Price { get; set; }
    public int Amount { get; set; }
    public long Amount_Price { get; set; }
    public bool Status { get; set; }

    public Spare (string id, string name, long unit_price, int amount, bool status){
        this.Spare_Id = id;
        this.Spare_Name = name;
        this.Unit_Price = unit_price;
        this.Amount = amount;
        this.Amount_Price = amount * unit_price;
        this.Status = status;
    }
}