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

            MessageBox.Show(firstName);
        }
    }
}
