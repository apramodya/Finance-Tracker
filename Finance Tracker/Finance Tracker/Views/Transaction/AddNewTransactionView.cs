using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Finance_Tracker.Views.Transaction
{
    public class ComboItem
    {
        public String Text { get; set; }
        public int Value { get; set; }
    }
    public partial class AddNewTransactionView : Form
    {
        public AddNewTransactionView()
        {
            InitializeComponent();

            contactsComboBox.DisplayMember = "Text";
            contactsComboBox.ValueMember = "Value";
        }
        private void AddNewTransactionView_Load(object sender, EventArgs e)
        {
            LoadContacts();
        }
        private void saveTransaction(object sender, EventArgs e)
        {
            var amount = amountTextBox.Text;
            var category = categoriesComboBox.SelectedItem;
            var contact = contactsComboBox.SelectedValue;
            var date = datePicker.Value;
        }
        private void LoadContacts()
        {
            using (DataBase.DBContainer db = new DataBase.DBContainer())
            {
                ArrayList ComboItems = new ArrayList();

                var contacts = from Contacts in db.Contacts
                               select Contacts;

                foreach (var contact in contacts)
                {
                    Models.Contact contact1 = new Models.Contact();
                    contact1.Id = contact.Id;
                    contact1.FirstName = contact.FirstName;
                    contact1.LastName = contact.LastName;
                    contact1.Description = contact.Description;

                    ComboItems.Add(new ComboItem { Text = contact.FirstName, Value = contact.Id });
                }

                contactsComboBox.DataSource = ComboItems;
                contactsComboBox.DisplayMember = "Text";
                contactsComboBox.ValueMember = "Value";
            }
        }
    }
}
