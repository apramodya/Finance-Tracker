using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Tracker.Models
{
    class Contact
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public  String Description { get; set; }
        public String FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
        public Contact(int Id, String FirstName, String LastName, String Description)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Description = Description;
        }
    }
}
