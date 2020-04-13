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
            DisplayData();
        }
        private void DisplayData()
        {
            using (DataBase.DBContainer db = new DataBase.DBContainer())
            {
                var transations = (from Transactions in db.Transactions
                                   select Transactions);

                DataTable dt = new DataTable();
                dt.Columns.Add("Date");
                dt.Columns.Add("Amount");
                dt.Columns.Add("Category");
                dt.Columns.Add("Transaction Type");
                dt.Columns.Add("Contact");
                DataRow row = null;

                foreach (var rowObj in transations)
                {
                    row = dt.NewRow();
                    String fullName = "-";
                    if (rowObj.Contact != null)
                    {
                        fullName = rowObj.Contact.FirstName + " " + rowObj.Contact.LastName;
                    }
                    
                    dt.Rows.Add(
                        rowObj.DateTime.ToShortDateString(), 
                        rowObj.Amount, 
                        rowObj.Category.Name,
                        rowObj.TransactionType,
                        fullName);
                }

                dataGridView.DataSource = dt;
            }
        }
    }
}
