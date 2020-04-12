using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finance_Tracker.Views.Contact
{
    public partial class AddNewContactView : Form
    {
        private DataSets.DSContacts dbData = new DataSets.DSContacts();
        public AddNewContactView()
        {
            InitializeComponent();
        }

        private void saveContact(object sender, EventArgs e)
        {
            if (firstNameTextBox.Text.Length == 0 )
            {
                MessageBox.Show(
                    "Please add first name",
                    "Missing field",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            } else if (lastNameTextBox.Text.Length == 0)
            {
                MessageBox.Show(
                    "Please add last name",
                    "Missing field",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var firstName = firstNameTextBox.Text;
            var lastName = lastNameTextBox.Text;
            var description = descriptionTextBox.Text;

            // data set
            this.dbData.Contacts.AddContactsRow(firstName, lastName, description);
            this.dbData.AcceptChanges();
            
            // xml
            String filePath = String.Format(
                "{0}\\{1}",
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "DSContacts.txt"
                );
            this.dbData.WriteXml(filePath);

            // database
            using (DataBase.DBContainer db = new DataBase.DBContainer())
            {
                DataBase.Contact contact = new DataBase.Contact {
                    FirstName = firstName,
                    LastName = lastName,
                    Description = description,
                };

                db.Contacts.Add(contact);
                db.SaveChanges();
            }

            this.Close();
        }

        private void AddNewContactView_Load(object sender, EventArgs e)
        {

        }
    }
}
