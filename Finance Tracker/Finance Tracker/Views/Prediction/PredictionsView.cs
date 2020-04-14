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
                var transactions = (from Transactions in db.Transactions
                                    select Transactions.Amount);

                if (transactions != null)
                {
                }
            }
        }
        private void PredictionsView_Load(object sender, EventArgs e)
        {

        }
    }
}
