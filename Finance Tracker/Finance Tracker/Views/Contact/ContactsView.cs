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

        private void addNewContact(object sender, EventArgs e)
        {
            AddNewContactView addNewContactView = new AddNewContactView();
            addNewContactView.ShowDialog();
        }
    }
}
