using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystemDaniel.Models
{
    public class Balance
    {
        public int Id { get; set; }
        public int AccountBalance { get; set; }
    }
    public class Payments
    {
        public int Id { get; set; }       
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }
        public string ClosedReason { get; set; }

    }

    public class TableHeaders
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string ClosedReason { get; set; }

    }
}
