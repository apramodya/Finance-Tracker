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
        private void CategoriesView_Activated(object sender, EventArgs e)
        {
            loadCategories();
        }
        private void CategoriesView_Load(object sender, EventArgs e) {}

        private void expenseCategorySelected(object sender, EventArgs e)
        {
            AddNewCategoryView addNewCategoryView = new AddNewCategoryView();

            if (expenseCategoriesList.SelectedItems.Count > 0)
            {
                ListViewItem item = expenseCategoriesList.SelectedItems[0];
                var id = int.Parse(item.Tag.ToString());

                using (DataBase.DBContainer db = new DataBase.DBContainer())
                {
                    var Category = (from Categories in db.Categories
                                   where id == Categories.Id
                                   select Categories).FirstOrDefault();

                    if (Category != null)
                    {
                        Models.Category _category = new Models.Category();
                        _category.Id = Category.Id;
                        _category.Name = Category.Name;
                        _category.Type = Models.TransactionType.Expense;

                        addNewCategoryView.Category = _category;
                        addNewCategoryView.isUpdating = true;

                        addNewCategoryView.ShowDialog();
                    }
                }
            }
        }

        private void incomeCategorySelected(object sender, EventArgs e)
        {
            AddNewCategoryView addNewCategoryView = new AddNewCategoryView();

            if (incomeCategoriesList.SelectedItems.Count > 0)
            {
                ListViewItem item = incomeCategoriesList.SelectedItems[0];
                var id = int.Parse(item.Tag.ToString());

                using (DataBase.DBContainer db = new DataBase.DBContainer())
                {
                    var Category = (from Categories in db.Categories
                                    where id == Categories.Id
                                    select Categories).FirstOrDefault();

                    if (Category != null)
                    {
                        Models.Category _category = new Models.Category();
                        _category.Id = Category.Id;
                        _category.Name = Category.Name;
                        _category.Type = Models.TransactionType.Income;

                        addNewCategoryView.Category = _category;
                        addNewCategoryView.isUpdating = true;

                        addNewCategoryView.ShowDialog();
                    }
                }
            }
        }

        private void addNewCategory(object sender, EventArgs e)
        {
            Category.AddNewCategoryView addNewCategoryView = new AddNewCategoryView();
            addNewCategoryView.ShowDialog();
        }

        private void loadCategories()
        {
            incomeCategoriesList.Items.Clear();
            expenseCategoriesList.Items.Clear();

            using (DataBase.DBContainer db = new DataBase.DBContainer())
            {
                var query = from Categories in db.Categories
                            select Categories;

                foreach (var category in query)
                {
                    ListViewItem newItem = new ListViewItem();

                    newItem.Tag = category.Id;
                    newItem.Text = category.Name;

                    if (category.TransactionType == "Expense")
                    {
                        expenseCategoriesList.Items.Add(newItem);
                    } else
                    {
                        incomeCategoriesList.Items.Add(newItem);
                    }
                }
            }
        }
    }
}
