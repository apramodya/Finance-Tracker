using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finance_Tracker
{
    public partial class homeView : Form
    {
        public homeView()
        {
            InitializeComponent();
        }

        private void homeView_Load(object sender, EventArgs e)
        {

        }

        private void categoriesDidPress(object sender, EventArgs e)
        {
            Category.CategoriesView categoriesView = new Category.CategoriesView();
            categoriesView.ShowDialog();
        }

        private void contactsDidPress(object sender, EventArgs e)
        {
            Views.Contact.ContactsView contactsView = new Views.Contact.ContactsView();
            contactsView.ShowDialog();
        }

        private void transactionsDidPress(object sender, EventArgs e)
        {

        }

        private void predictionsDidPress(object sender, EventArgs e)
        {

        }

        private void reportsDidPress(object sender, EventArgs e)
        {

        }
    }
}
