using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Tracker.Models
{
    class Transaction
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public String TransactionType { get; set; }
        public Double Amount { get; set; }
        public Contact Contact { get; set; }
    }
}
