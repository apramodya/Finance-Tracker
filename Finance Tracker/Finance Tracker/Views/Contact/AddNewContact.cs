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
        public Boolean isUpdating = false;
        internal Models.Contact Contact;
        private DataSets.DSContacts dbData = new DataSets.DSContacts();
        public AddNewContactView()
        {
            InitializeComponent();
        }
        private void AddNewContactView_Load(object sender, EventArgs e)
        {
            if (isUpdating)
            {
                firstNameTextBox.Text = Contact.FirstName;
                lastNameTextBox.Text = Contact.LastName;
                descriptionTextBox.Text = Contact.Description;

                // save button
                saveButton.Location = new Point(
                    descriptionTextBox.Location.X - 100, 
                    descriptionTextBox.Location.Y + 60);
                // delete button
                Button deleteButton = new Button();
                deleteButton.Size = saveButton.Size;
                deleteButton.Font = saveButton.Font;
                deleteButton.Text = "Delete";
                deleteButton.Location = new Point(
                    descriptionTextBox.Location.X + 50,
                    descriptionTextBox.Location.Y + 60);
                this.Controls.Add(deleteButton);

                deleteButton.Click += DeleteButton_Click;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                    "Are you sure you want to delete?",
                    "Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                using (DataBase.DBContainer db = new DataBase.DBContainer())
                {
                    var contact = (from Contacts in db.Contacts
                                   where Contact.Id == Contacts.Id
                                   select Contacts).FirstOrDefault();

                    if (contact != null)
                    {
                        db.Contacts.Remove(contact);
                        db.SaveChanges();
                    }
                }

                this.Close();
            }
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
            if (isUpdating)
            {
                using (DataBase.DBContainer db = new DataBase.DBContainer())
                {
                    var contact = (from Contacts in db.Contacts
                                    where Contact.Id == Contacts.Id
                                    select Contacts).FirstOrDefault();

                    if (contact != null )
                    {
                        contact.FirstName = firstName;
                        contact.LastName = lastName;
                        contact.Description = description;
                    }

                    db.SaveChanges();
                }

                this.Close();
            } else
            {
                using (DataBase.DBContainer db = new DataBase.DBContainer())
                {
                    DataBase.Contact contact = new DataBase.Contact
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Description = description,
                    };

                    db.Contacts.Add(contact);
                    db.SaveChanges();
                }

                this.Close();
            }
        }
    }
}
