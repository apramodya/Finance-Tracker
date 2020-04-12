using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Tracker.Models
{
    class Category
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public TransactionType Type { get; set; }

        public Category(int Id, String Name, TransactionType Type)
        {
            this.Id = Id;
            this.Name = Name;
            this.Type = Type;
        }
    }
}
