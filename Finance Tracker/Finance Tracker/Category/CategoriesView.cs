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
    public partial class CategoriesView : Form
    {
        public CategoriesView()
        {
            InitializeComponent();
        }

        string[] incomeCategories = { "Salary", "Savings" };
        string[] expenseCategories = { "Food", "Travel", "Medicine" };

        private void CategoriesView_Load(object sender, EventArgs e)
        {
            var i = 0;
            foreach (string cateogry in incomeCategories)
            {
                ListViewItem newItem = new ListViewItem();
                newItem.Tag = i;
                newItem.Text = cateogry;

                incomeCategoriesList.Items.Add(newItem);

                i++;
            }

            var j = 0;
            foreach (string cateogry in expenseCategories)
            {
                ListViewItem newItem = new ListViewItem();
                newItem.Tag = i;
                newItem.Text = cateogry;

                expenseCategoriesList.Items.Add(newItem);

                i++;
            }
        }

        private void expenseCategorySelected(object sender, EventArgs e)
        {
            if (expenseCategoriesList.SelectedItems.Count > 0)
            {
                ListViewItem item = expenseCategoriesList.SelectedItems[0];
                MessageBox.Show(item.Tag.ToString() + " " + item.Text);
            }
        }

        private void incomeCategorySelected(object sender, EventArgs e)
        {
            if (incomeCategoriesList.SelectedItems.Count > 0)
            {
                ListViewItem item = incomeCategoriesList.SelectedItems[0];
                MessageBox.Show(item.Tag.ToString() + " " + item.Text);
            }
        }
    }
}
