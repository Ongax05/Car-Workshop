using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRepairs.Classes;
class Approval_Order{
    public Order Related_Order { get; set; }
    public List<Spare> Spares { get; set; } 

    public Approval_Order (Order order){
        this.Related_Order = order;
        this.Spares = new List<Spare> ();
    }
}