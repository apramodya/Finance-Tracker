using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finance_Tracker.Views.Prediction
{
    public partial class PredictionsView : Form
    {
        public PredictionsView()
        {
            InitializeComponent();

            criteriaComboBox.Items.Add("Daily");
            criteriaComboBox.Items.Add("Weekly");
            criteriaComboBox.Items.Add("Monthly");
            criteriaComboBox.Items.Add("Annually");
        }

        private void criteriaSelected(object sender, EventArgs e)
        {
            String selection = "";
            if (criteriaComboBox.SelectedItem.ToString() == "Daily")
            {
                selection = "Daily";
            } 
            else if (criteriaComboBox.SelectedItem.ToString() == "Weekly")
            {
                selection = "Weekly";
            }
            else if (criteriaComboBox.SelectedItem.ToString() == "Monthly")
            {
                selection = "Monthly";
            }
            else if (criteriaComboBox.SelectedItem.ToString() == "Annually")
            {
                selection = "Annually";
            }

            getPrediction(selection);
        }

        void getPrediction(String selection)
        {
            using (DataBase.DBContainer db = new DataBase.DBContainer())
            {
                var transactionsAmountArray = (from Transactions in db.Transactions
                                               where Transactions.TransactionType == "Expense"
                                               select Transactions.Amount);

                var firstTransactionDate = (from Transactions in db.Transactions
                                            select Transactions)
                                            .OrderBy(x => x.DateTime)
                                            .FirstOrDefault().DateTime;
                DateTime currentDate = DateTime.Now;

                if (transactionsAmountArray != null && firstTransactionDate != null)
                {
                    if (selection == "Daily")
                    {
                        var totalDays = (currentDate - firstTransactionDate).TotalDays;
                        var totalAmount = 0.0;
                        foreach (var amount in transactionsAmountArray)
                        {
                            totalAmount += amount;
                        }

                        var averageAmount = totalAmount / totalDays;
                        predictionTextBox.Text = averageAmount.ToString("0.00");
                    }
                    else if (selection == "Weekly")
                    {
                        var totalWeeks = (currentDate - firstTransactionDate).TotalDays / 7;
                        var totalAmount = 0.0;
                        foreach (var amount in transactionsAmountArray)
                        {
                            totalAmount += amount;
                        }

                        var averageAmount = totalAmount / totalWeeks;
                        predictionTextBox.Text = averageAmount.ToString("0.00");
                    }
                    else if (selection == "Monthly")
                    {
                        var totalMonths = (currentDate - firstTransactionDate).TotalDays / 30;
                        var totalAmount = 0.0;
                        foreach (var amount in transactionsAmountArray)
                        {
                            totalAmount += amount;
                        }

                        var averageAmount = totalAmount / totalMonths;
                        predictionTextBox.Text = averageAmount.ToString("0.00");
                    }
                    else if (selection == "Annually")
                    {
                        var totalYears = (currentDate - firstTransactionDate).TotalDays / 365;
                        var totalAmount = 0.0;
                        foreach (var amount in transactionsAmountArray)
                        {
                            totalAmount += amount;
                        }

                        var averageAmount = totalAmount / totalYears;
                        predictionTextBox.Text = averageAmount.ToString("0.00");
                    }

                }
            }
        }
        private void PredictionsView_Load(object sender, EventArgs e)
        {

        }
    }
}
