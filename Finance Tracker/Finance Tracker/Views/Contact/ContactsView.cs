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
    public partial class ContactsView : Form
    {
        public ContactsView()
        {
            InitializeComponent();
        }

        private void ContactsView_Load(object sender, EventArgs e) {}
        private void ContactsView_Activated(object sender, EventArgs e)
        {
            loadContacts();
        }
        private void contactClicked(object sender, EventArgs e)
        {
            AddNewContactView addNewContactView = new AddNewContactView();

            if (contactsListView.SelectedItems.Count > 0)
            {
                ListViewItem item = contactsListView.SelectedItems[0];
                var id = int.Parse(item.Tag.ToString());

                using (DataBase.DBContainer db = new DataBase.DBContainer())
                {
                    var contact = (from Contacts in db.Contacts
                                where id == Contacts.Id
                                select Contacts).FirstOrDefault();

                    if (contact != null)
                    {
                        Models.Contact _contact = new Models.Contact();
                        _contact.Id = contact.Id;
                        _contact.FirstName = contact.FirstName;
                        _contact.LastName = contact.LastName;
                        _contact.Description = contact.Description;

                        addNewContactView.Contact = _contact;
                        addNewContactView.isUpdating = true;

                        addNewContactView.ShowDialog();
                    }
                }
            }
        }
        private void contactDoubleClicked(object sender, EventArgs e)
        {
            if (contactsListView.SelectedItems.Count > 0)
            {
                ListViewItem item = contactsListView.SelectedItems[0];

                MessageBox.Show(item.Tag.ToString() + " " + item.Text);
            }
        }
        private void addNewContact(object sender, EventArgs e)
        {
            AddNewContactView addNewContactView = new AddNewContactView();
            addNewContactView.ShowDialog();
        }
        private void loadContacts()
        {
            contactsListView.Items.Clear();

            using (DataBase.DBContainer db = new DataBase.DBContainer())
            {
                var query = from Contacts in db.Contacts
                            select Contacts;

                foreach (var contact in query)
                {
                    ListViewItem newItem = new ListViewItem();

                    newItem.Tag = contact.Id;
                    newItem.Text = contact.FirstName + " " + contact.LastName;

                    contactsListView.Items.Add(newItem);
                }
            }
        }
    }
}
