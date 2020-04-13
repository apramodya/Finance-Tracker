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

        private void TransactionsView_Load(object sender, EventArgs e)
        {

        }
    }
}
