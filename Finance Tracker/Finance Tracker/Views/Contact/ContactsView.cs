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

        Models.Contact[] contactsList = {
            new Models.Contact(1, "Pramodya", "Abe"),
        };

        private void addNewContact(object sender, EventArgs e)
        {
            AddNewContactView addNewContactView = new AddNewContactView();
            addNewContactView.ShowDialog();
        }

        private void ContactsView_Load(object sender, EventArgs e)
        {
            foreach (Models.Contact contact in contactsList)
            {
                ListViewItem newItem = new ListViewItem();
                newItem.Tag = contact.Id;
                newItem.Text = contact.FullName;

                contactsListView.Items.Add(newItem);
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
    }
}
