using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Finance_Tracker.Views.Report
{
    public partial class ReportsView : Form
    {
        String selection = "";
        public ReportsView()
        {
            InitializeComponent();

            criteriaComboBox.Items.Add("Daily");
            criteriaComboBox.Items.Add("Monthly");
            criteriaComboBox.Items.Add("Annual");
        }

        private void criteriaSelected(object sender, EventArgs e)
        {
            if (criteriaComboBox.SelectedItem.ToString() == "Daily")
            {
                selection = "Daily";
            }
            else if (criteriaComboBox.SelectedItem.ToString() == "Monthly")
            {
                selection = "Monthly";
            }
            else if (criteriaComboBox.SelectedItem.ToString() == "Annual")
            {
                selection = "Annual";
            }

            loadComboBoxes(selection);
            showGenerateButton();
        }
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (selection == "Daily")
            {
                var datesComboBoxSelection = int.Parse(Controls.OfType<ComboBox>()
                .Where(x => x.Name == "datesComboBox").FirstOrDefault().SelectedItem.ToString());
                var monthsComboBoxSelection = int.Parse(Controls.OfType<ComboBox>()
                    .Where(x => x.Name == "monthsComboBox").FirstOrDefault().SelectedIndex.ToString()) + 1;
                var yearsComboBoxSelection = int.Parse(Controls.OfType<ComboBox>()
                    .Where(x => x.Name == "yearsComboBox").FirstOrDefault().SelectedItem.ToString());

                DateTime firstDate = new DateTime(yearsComboBoxSelection, monthsComboBoxSelection, datesComboBoxSelection);
                DateTime lastDate = firstDate.AddDays(1).AddMinutes(-1);
                
                getReport(firstDate, lastDate, selection);
            } 
            else if (selection == "Monthly")
            {
                var monthsComboBoxSelection = int.Parse(Controls.OfType<ComboBox>()
                    .Where(x => x.Name == "monthsComboBox").FirstOrDefault().SelectedIndex.ToString()) + 1;
                var yearsComboBoxSelection = int.Parse(Controls.OfType<ComboBox>()
                    .Where(x => x.Name == "yearsComboBox").FirstOrDefault().SelectedItem.ToString());
                DateTime firstDate = new DateTime(yearsComboBoxSelection, monthsComboBoxSelection, 1);
                DateTime lastDate = firstDate.AddMonths(1).AddDays(0).AddMinutes(-1);

                getReport(firstDate, lastDate, selection);
            } 
            else if (selection == "Annual")
            {
                var yearsComboBoxSelection = int.Parse(Controls.OfType<ComboBox>()
                    .Where(x => x.Name == "yearsComboBox").FirstOrDefault().SelectedItem.ToString());
                DateTime firstDate = new DateTime(yearsComboBoxSelection, 1, 1);
                DateTime lastDate = firstDate.AddMonths(12).AddDays(0).AddMinutes(-1);

                getReport(firstDate, lastDate, selection);
            }
        }
        private void showGenerateButton()
        {
            Button generateButton = new Button();
            generateButton.Text = "Generate";
            generateButton.Font = label1.Font;
            generateButton.Size = new Size(157, 37);
            generateButton.Location = new Point(label1.Location.X + 180, label1.Location.Y + 100);
            generateButton.Click += GenerateButton_Click;
            Controls.Add(generateButton);
        }
        private void loadComboBoxes(String selection)
        {
            // years combo box
            int[] years = new int[] { 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027 };
            ComboBox yearsComboBox = new ComboBox();
            yearsComboBox.Name = "yearsComboBox";
            yearsComboBox.DataSource = years;
            yearsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            yearsComboBox.Location = new Point(label1.Location.X + 20, label1.Location.Y + 50);

            // months combo box
            String[] months = new String[] {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            ComboBox monthsComboBox = new ComboBox();
            monthsComboBox.Name = "monthsComboBox";
            monthsComboBox.DataSource = months;
            monthsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            monthsComboBox.Location = new Point(label1.Location.X + 180, label1.Location.Y + 50);

            // dates combo box
            int[] dates = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31};
            ComboBox datesComboBox = new ComboBox();
            datesComboBox.Name = "datesComboBox";
            datesComboBox.DataSource = dates;
            datesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            datesComboBox.Location = new Point(label1.Location.X + 340, label1.Location.Y + 50);

            if (selection == "Annual")
            {
                clearComboBoxes(); 
                Controls.Add(yearsComboBox);
            } 
            else if (selection == "Monthly")
            {
                clearComboBoxes();
                Controls.Add(yearsComboBox);
                Controls.Add(monthsComboBox);
            }
            else if (selection == "Daily")
            {
                clearComboBoxes();
                Controls.Add(yearsComboBox);
                Controls.Add(monthsComboBox);
                Controls.Add(datesComboBox);
            }
        }
        private void clearComboBoxes()
        {
            Controls.Remove(Controls.OfType<ComboBox>().Where(x => x.Name == "datesComboBox").FirstOrDefault());
            Controls.Remove(Controls.OfType<ComboBox>().Where(x => x.Name == "monthsComboBox").FirstOrDefault());
            Controls.Remove(Controls.OfType<ComboBox>().Where(x => x.Name == "yearsComboBox").FirstOrDefault());
        }
        private void getReport(DateTime firstDate, DateTime lastDate, String selection)
        {
            Task task = Task.Run(() =>
            {
                using (DataBase.DBContainer db = new DataBase.DBContainer())
                {
                    var transactions = (from Transactions in db.Transactions
                                        where Transactions.DateTime <= lastDate && Transactions.DateTime >= firstDate
                                        select Transactions);

                    if (transactions != null)
                    {
                        string fileName = String.Format("{0} report.csv", selection);
                        string csvFilePath = String.Format(
                            "{0}\\{1}",
                            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                            fileName);
                        var csv = new StringBuilder();

                        var headerLine = string.Format("{0},{1},{2},{3}", "date", "amount", "contact", "category");
                        csv.AppendLine(headerLine);

                        foreach (var transaction in transactions)
                        {
                            var date = transaction.DateTime.ToShortDateString();
                            var amount = transaction.Amount.ToString();
                            var contact = (transaction.Contact != null) ? transaction.Contact.FirstName : "-";
                            var category = transaction.Category.Name;

                            var newLine = string.Format("{0},{1},{2},{3}", date, amount, contact, category);
                            csv.AppendLine(newLine);
                        }

                        File.WriteAllText(csvFilePath, csv.ToString());
                    }
                }
            });

            task.Wait();

            if (task.Status == TaskStatus.RanToCompletion)
            {
                String caption = String.Format("{0} report", selection);
                String message = String
                    .Format("{0} {1}", "Report generated successfully in", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
        }

        private void ReportsView_Load(object sender, EventArgs e)
        {

        }
    }
}
