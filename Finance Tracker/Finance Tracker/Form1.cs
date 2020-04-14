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
        private void homeView_Activated(object sender, EventArgs e)
        {
            using (DataBase.DBContainer db = new DataBase.DBContainer())
            {
                var expense = 0.0;
                var income = 0.0;

                DateTime date = DateTime.Now;
                var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                var transations = (from Transactions in db.Transactions
                                   where (Transactions.DateTime <= lastDayOfMonth && Transactions.DateTime >= firstDayOfMonth)
                                   select Transactions);

                if (transations != null)
                {
                    foreach (var transaction in transations)
                    {
                        if (transaction.TransactionType == "Expense")
                        {
                            expense += transaction.Amount;
                        } else
                        {
                            income += transaction.Amount;
                        }
                    }
                }

                incomeTextBox.Text = income.ToString("0.00");
                expenseTextBox.Text = expense.ToString("0.00");
                balanceTextBox.Text = (income - expense).ToString("0.00");
            }
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
            Views.Transaction.TransactionsView transactionsView = new Views.Transaction.TransactionsView();
            transactionsView.ShowDialog();
        }
        private void predictionsDidPress(object sender, EventArgs e)
        {
            Views.Prediction.PredictionsView predictionsView = new Views.Prediction.PredictionsView();
            predictionsView.ShowDialog();
        }
        private void reportsDidPress(object sender, EventArgs e)
        {

        }
    }
}
