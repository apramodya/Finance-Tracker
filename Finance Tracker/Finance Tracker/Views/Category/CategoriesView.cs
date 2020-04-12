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

        Models.Category[] incomeCategories = {
            new Models.Category(1, "Savings", Models.TransactionType.Income),
            new Models.Category(2, "Salary", Models.TransactionType.Income),
            new Models.Category(3, "Loan", Models.TransactionType.Income),
        };
        Models.Category[] expenseCategories = {
            new Models.Category(1, "Travel", Models.TransactionType.Expense),
            new Models.Category(2, "Food", Models.TransactionType.Expense),
            new Models.Category(3, "Medicine", Models.TransactionType.Expense),
        };

        private void CategoriesView_Load(object sender, EventArgs e)
        {

            foreach (Models.Category cateogry in incomeCategories)
            {
                ListViewItem newItem = new ListViewItem();
                newItem.Tag = cateogry.Id;
                newItem.Text = cateogry.Name;

                incomeCategoriesList.Items.Add(newItem);
            }

            foreach (Models.Category cateogry in expenseCategories)
            {
                ListViewItem newItem = new ListViewItem();
                newItem.Tag = cateogry.Id;
                newItem.Text = cateogry.Name;

                expenseCategoriesList.Items.Add(newItem);
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

        private void addNewCategory(object sender, EventArgs e)
        {
            Category.AddNewCategoryView addNewCategoryView = new AddNewCategoryView();
            addNewCategoryView.ShowDialog();
        }
    }
}
