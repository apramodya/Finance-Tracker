using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finance_Tracker.Views.Transaction
{
    public partial class TransactionsView : Form
    {
        public TransactionsView()
        {
            InitializeComponent();
        }

        private void addNewTransaction(object sender, EventArgs e)
        {
            AddNewTransactionView addNewTransactionView = new AddNewTransactionView();
            addNewTransactionView.ShowDialog();
        }
        private void TransactionsView_Activated(object sender, EventArgs e)
        {
            DateTime date = monthCalendar.SelectionRange.Start;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            DisplayData(firstDayOfMonth, lastDayOfMonth);
        }
        private void DisplayData(DateTime firstDayOfMonth, DateTime lastDayOfMonth)
        {
            using (DataBase.DBContainer db = new DataBase.DBContainer())
            {
                var transations = (from Transactions in db.Transactions
                                   where (Transactions.DateTime <= lastDayOfMonth && Transactions.DateTime >= firstDayOfMonth)
                                   select Transactions);

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Id");
                dataTable.Columns.Add("Date");
                dataTable.Columns.Add("Amount");
                dataTable.Columns.Add("Category");
                dataTable.Columns.Add("Transaction Type");
                dataTable.Columns.Add("Contact");
                DataRow row = null;

                foreach (var transation in transations)
                {
                    row = dataTable.NewRow();
                    String fullName = "-";

                    if (transation.Contact != null)
                    {
                        fullName = transation.Contact.FirstName + " " + transation.Contact.LastName;
                    }

                    dataTable.Rows.Add(
                        transation.Id,
                        transation.DateTime.ToShortDateString(),
                        transation.Amount,
                        transation.Category.Name,
                        transation.TransactionType,
                        fullName);
                }

                dataGridView.DataSource = dataTable;
                dataGridView.Columns[0].Visible = false;
            }
        }

        private void transactionClicked(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = int.Parse(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());

            AddNewTransactionView addNewTransactionView = new AddNewTransactionView();

            using (DataBase.DBContainer db = new DataBase.DBContainer())
            {
                var transaction = (from Transactions in db.Transactions
                                where id == Transactions.Id
                                select Transactions).FirstOrDefault();

                if (transaction != null)
                {
                    // contact
                    Models.Contact _contact = new Models.Contact();
                    if (transaction.Contact != null)
                    {
                        var selectedContact = (from Contacts in db.Contacts
                                               where Contacts.Id == transaction.Contact.Id
                                               select Contacts).FirstOrDefault();
                        
                        _contact.Id = selectedContact.Id;
                        _contact.FirstName = selectedContact.FirstName;
                        _contact.LastName = selectedContact.LastName;
                        _contact.Description = selectedContact.Description;
                    }

                    // category
                    var selectedCategory = (from Categories in db.Categories
                                            where Categories.Id == transaction.Category.Id
                                            select Categories).FirstOrDefault();
                    Models.Category _category = new Models.Category();
                    _category.Id = selectedCategory.Id;
                    _category.Name = selectedCategory.Name;
                    if (selectedCategory.TransactionType == "Expense")
                    {
                        _category.Type = Models.TransactionType.Expense;
                    }
                    else
                    {
                        _category.Type = Models.TransactionType.Income;
                    }

                    // transaction
                    Models.Transaction _transaction = new Models.Transaction();
                    _transaction.Id = id;
                    _transaction.Amount = transaction.Amount;
                    _transaction.DateTime = transaction.DateTime;
                    _transaction.Category = _category;
                    _transaction.Contact = _contact;

                    if (transaction.TransactionType == "Expense")
                    {
                        _transaction.TransactionType = Models.TransactionType.Expense;
                    }
                    else
                    {
                        _transaction.TransactionType = Models.TransactionType.Income;
                    }

                    addNewTransactionView.isUpdating = true;
                    addNewTransactionView.Text = "Update transaction";
                    addNewTransactionView.updatingTransaction = _transaction;
                    addNewTransactionView.ShowDialog();
                }
            }
        }

        private void dateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime date = monthCalendar.SelectionRange.Start;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            DisplayData(firstDayOfMonth, lastDayOfMonth);
        }
    }
}
