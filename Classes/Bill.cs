using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairs.Classes;


class Bill {
    public string Order_Id { get; set; }
    public string Bill_Id { get; set; }
    public List<Spare> Approved_Spares { get; set; }
    public long SubTotal { get; set; }
    public long Labor_Value { get; set; }
    public float Taxes { get; set; }
    public long Total { get; set; }

    public Bill(string order_Id, string bill_Id, long subTotal, long labor_Value,float taxes, long total) {
        this.Order_Id = order_Id;
        this.Bill_Id = bill_Id;
        this.Approved_Spares = new List<Spare>();
        this.SubTotal = subTotal;
        this.Labor_Value = labor_Value;
        this.Taxes = taxes;
        this.Total = total;
    }
}