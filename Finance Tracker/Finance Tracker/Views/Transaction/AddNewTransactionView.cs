using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Finance_Tracker.Views.Transaction
{
   
    public partial class AddNewTransactionView : Form
    {
        public Boolean isUpdating = false;
        internal Models.Transaction updatingTransaction;
        Models.TransactionType selectedTransactionType = Models.TransactionType.Expense;
        public AddNewTransactionView()
        {
            InitializeComponent();

            contactsComboBox.DisplayMember = "Text";
            contactsComboBox.ValueMember = "Value";
        }
        private void AddNewTransactionView_Load(object sender, EventArgs e)
        {
            LoadTransactionTypes();
            LoadContacts();
            LoadCategories();

            if (isUpdating)
            {
                var categeoryId = updatingTransaction.Category.Id;
                var contactId = updatingTransaction.Contact.Id;
                
                amountNumericUpDown.Value = (decimal)updatingTransaction.Amount;
                
                contactsComboBox.SelectedValue = contactId;
                datePicker.Value = updatingTransaction.DateTime;

                if (updatingTransaction.TransactionType == Models.TransactionType.Expense)
                {
                    selectedTransactionType = Models.TransactionType.Expense;
                    LoadCategories();
                    transactionTypeComboBox.SelectedItem = transactionTypeComboBox.Items[0];
                } else
                {
                    selectedTransactionType = Models.TransactionType.Income;
                    LoadCategories();
                    transactionTypeComboBox.SelectedItem = transactionTypeComboBox.Items[1];
                }

                categoriesComboBox.SelectedValue = categeoryId;
            }
        }
        private void saveTransaction(object sender, EventArgs e)
        {
            var amount = decimal.ToDouble(amountNumericUpDown.Value);
            var categoryId = int.Parse(categoriesComboBox.SelectedValue.ToString());
            var contactId = int.Parse(contactsComboBox.SelectedValue.ToString());
            var date = datePicker.Value;

            if (amount == 0)
            {
                MessageBox.Show(
                    "Please add an amount",
                    "Missing field",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            } else if (categoryId == 0)
            {
                MessageBox.Show(
                    "Please select a category",
                    "Missing field",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (isUpdating)
            {

            } else
            {
                using (DataBase.DBContainer db = new DataBase.DBContainer())
                {
                    var selectedContact = (from Contacts in db.Contacts
                                          where Contacts.Id == contactId
                                          select Contacts).FirstOrDefault();

                    var selectedCategory = (from Categories in db.Categories
                                            where Categories.Id == categoryId
                                            select Categories).FirstOrDefault();

                    DataBase.Transaction transaction = new DataBase.Transaction
                    {
                        Amount = amount,
                        Category = selectedCategory,
                        DateTime = date,
                        Contact = selectedContact,
                        TransactionType = selectedTransactionType.ToString()
                    };

                    db.Transactions.Add(transaction);
                    db.SaveChanges();
                }

                this.Close();
            }
        }
        private void LoadTransactionTypes()
        {
            transactionTypeComboBox.Items.Add(Models.TransactionType.Expense);
            transactionTypeComboBox.Items.Add(Models.TransactionType.Income);
            transactionTypeComboBox.SelectedItem = transactionTypeComboBox.Items[0];
        }
        private void LoadContacts()
        {
            using (DataBase.DBContainer db = new DataBase.DBContainer())
            {
                ArrayList ComboItems = new ArrayList();
                ComboItems.Add(new ComboItem { Text = null, Value = 0 });

                var contacts = from Contacts in db.Contacts
                               select Contacts;

                foreach (var contact in contacts)
                {
                    ComboItems.Add(new ComboItem { Text = contact.FirstName + " " + contact.LastName, Value = contact.Id });
                }

                contactsComboBox.DataSource = ComboItems;
                contactsComboBox.DisplayMember = "Text";
                contactsComboBox.ValueMember = "Value";
            }
        }

        private void LoadCategories()
        {
            using (DataBase.DBContainer db = new DataBase.DBContainer())
            {
                categoriesComboBox.DataSource = null;
                ArrayList ComboItems = new ArrayList();
                ComboItems.Add(new ComboItem { Text = null, Value = 0 });

                var categories = from Categories in db.Categories
                                 where Categories.TransactionType == selectedTransactionType.ToString()
                               select Categories;

                foreach (var category in categories)
                {
                    ComboItems.Add(new ComboItem { Text = category.Name, Value = category.Id });
                }

                categoriesComboBox.DataSource = ComboItems;
                categoriesComboBox.DisplayMember = "Text";
                categoriesComboBox.ValueMember = "Value";
            }
        }

        private void transactionTypeChanged(object sender, EventArgs e)
        {
            var selection = transactionTypeComboBox.SelectedItem;

            if (selection.ToString() == "Expense")
            {
                selectedTransactionType = Models.TransactionType.Expense;
                LoadCategories();
            } else
            {
                selectedTransactionType = Models.TransactionType.Income;
                LoadCategories();
            }
        }
    }
    public class ComboItem
    {
        public String Text { get; set; }
        public int Value { get; set; }
    }
}
