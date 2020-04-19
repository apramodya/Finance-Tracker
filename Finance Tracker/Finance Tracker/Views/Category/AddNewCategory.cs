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
        public Boolean isUpdating = false;
        internal Models.Category Category;
        private DataSets.DSCategory dbData = new DataSets.DSCategory();
        private Boolean didSaveButtonPress = false;
        public AddNewCategoryView()
        {
            InitializeComponent();
        }
        private void AddNewCategoryView_Load(object sender, EventArgs e)
        {
            categoryTypeComboBox.Items.Add(Models.TransactionType.Expense);
            categoryTypeComboBox.Items.Add(Models.TransactionType.Income);

            if (isUpdating)
            {
                categoryNameTextBox.Text = Category.Name;
                categoryTypeComboBox.SelectedItem = Category.Type;

                // save button
                saveButton.Location = new Point(
                    categoryTypeComboBox.Location.X - 160,
                    categoryTypeComboBox.Location.Y + 60);
                // delete button
                Button deleteButton = new Button();
                deleteButton.Size = saveButton.Size;
                deleteButton.Font = saveButton.Font;
                deleteButton.Text = "Delete";
                deleteButton.Location = new Point(
                    categoryTypeComboBox.Location.X - 10,
                    categoryTypeComboBox.Location.Y + 60);
                this.Controls.Add(deleteButton);

                deleteButton.Click += DeleteButton_Click;
            }
            else
            {
                // xml
                String filePath = String.Format(
                    "{0}\\{1}",
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "DSCategories.txt"
                    );
                try
                {
                    dbData.ReadXml(filePath, XmlReadMode.InferSchema);

                    var name = "";
                    var type = "";

                    foreach (DataTable table in dbData.Tables)
                    {
                        Console.WriteLine(table.TableName);

                        foreach (var row in table.AsEnumerable())
                        {
                            name = row[0].ToString();
                            type = row[1].ToString();
                        }
                    }

                    categoryNameTextBox.Text = name;

                    if (type == "Expense")
                    {
                        categoryTypeComboBox.SelectedItem = Models.TransactionType.Expense;
                    } else if (type == "Income")
                    {
                        categoryTypeComboBox.SelectedItem = Models.TransactionType.Income;
                    }
                } catch { }
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
                    var category = (from Categories in db.Categories
                                    where Category.Id == Categories.Id
                                    select Categories).FirstOrDefault();

                    if (category != null)
                    {
                        db.Categories.Remove(category);
                        db.SaveChanges();
                    }
                }

                didSaveButtonPress = true;
                this.Close();
            }
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

            // database
            if (isUpdating)
            {
                using (DataBase.DBContainer db = new DataBase.DBContainer())
                {
                    var category = (from Categories in db.Categories
                                   where Categories.Id == Category.Id
                                   select Categories).FirstOrDefault();

                    if (category != null)
                    {
                        category.Name = categoryName;
                        category.TransactionType = categoryType;
                    }

                    db.SaveChanges();
                }

                didSaveButtonPress = true;
                this.Close();
            } else
            {
                using (DataBase.DBContainer db = new DataBase.DBContainer())
                {
                    DataBase.Category category = new DataBase.Category
                    {
                        Name = categoryName,
                        TransactionType = categoryType,
                    };

                    db.Categories.Add(category);
                    db.SaveChanges();
                }

                didSaveButtonPress = true;

                // data set
                this.dbData.Category.Rows.RemoveAt(0);
                this.dbData.AcceptChanges();

                // xml
                String filePath = String.Format(
                "{0}\\{1}",
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "DSCategories.txt"
                );
                this.dbData.WriteXml(filePath);

                this.Close();
            }
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            if (!didSaveButtonPress)
            {
                var categoryName = categoryNameTextBox.Text;
                var categoryType = "";

                if (categoryTypeComboBox.SelectedItem != null)
                {
                    categoryType = categoryTypeComboBox.SelectedItem.ToString();
                }

                // data set
                this.dbData.Category.Clear();
                this.dbData.Category.AddCategoryRow(categoryName, categoryType);
                this.dbData.AcceptChanges();

                // xml
                String filePath = String.Format(
                    "{0}\\{1}",
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "DSCategories.txt"
                    );
                this.dbData.WriteXml(filePath);
            }
        }
    }
}
