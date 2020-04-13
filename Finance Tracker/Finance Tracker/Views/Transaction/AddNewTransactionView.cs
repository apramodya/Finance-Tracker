using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finance_Tracker.Views.Transaction
{
    public partial class AddNewTransactionView : Form
    {
        public AddNewTransactionView()
        {
            InitializeComponent();
        }
        private void AddNewTransactionView_Load(object sender, EventArgs e)
        {

        }
        private void saveTransaction(object sender, EventArgs e)
        {

        }
        private void LoadContacts()
        {
            using (DataBase.DBContainer db = new DataBase.DBContainer())
            {
                var contacts = from Contacts in db.Contacts
                               select Contacts;

                foreach (var contact in contacts)
                {
                    Models.Contact contact1 = new Models.Contact();
                    contact1.Id = contact.Id;
                    contact1.FirstName = contact.FirstName;
                    contact1.LastName = contact.LastName;
                    contact1.Description = contact.Description;

                    contactsComboBox.Items.Add(new { Text = contact1.FullName, Value = contact1 });
                }
            }
        }
    }
}
