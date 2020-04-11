using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finance_Tracker.Category
{
    public partial class AddNewCategoryView : Form
    {
        public AddNewCategoryView()
        {
            InitializeComponent();
        }

        private void saveCategory(object sender, EventArgs e)
        {
            if (categoryNameTextBox.Text.Length == 0)
            {
                MessageBox.Show(
                    "Please add a category name", 
                    "Missing field", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            } else if (categoryTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a category type", 
                    "Missing field", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var categoryName = categoryNameTextBox.Text;
            var categoryType = categoryTypeComboBox.SelectedItem.ToString();

            MessageBox.Show(categoryName + " " + categoryType);
        }
    }
}
