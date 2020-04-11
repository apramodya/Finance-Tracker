namespace Finance_Tracker
{
    partial class homeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.categoriesBtn = new System.Windows.Forms.Button();
            this.contactsBtn = new System.Windows.Forms.Button();
            this.transactionsBtn = new System.Windows.Forms.Button();
            this.predictionsBtn = new System.Windows.Forms.Button();
            this.reportsBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.income = new System.Windows.Forms.TextBox();
            this.expense = new System.Windows.Forms.TextBox();
            this.balance = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // categoriesBtn
            // 
            this.categoriesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriesBtn.Location = new System.Drawing.Point(657, 124);
            this.categoriesBtn.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
            this.categoriesBtn.Name = "categoriesBtn";
            this.categoriesBtn.Size = new System.Drawing.Size(440, 80);
            this.categoriesBtn.TabIndex = 0;
            this.categoriesBtn.Text = "Categories";
            this.categoriesBtn.UseVisualStyleBackColor = true;
            this.categoriesBtn.Click += new System.EventHandler(this.categoriesDidPress);
            // 
            // contactsBtn
            // 
            this.contactsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactsBtn.Location = new System.Drawing.Point(657, 217);
            this.contactsBtn.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
            this.contactsBtn.Name = "contactsBtn";
            this.contactsBtn.Size = new System.Drawing.Size(440, 80);
            this.contactsBtn.TabIndex = 1;
            this.contactsBtn.Text = "Contacts";
            this.contactsBtn.UseVisualStyleBackColor = true;
            this.contactsBtn.Click += new System.EventHandler(this.contactsDidPress);
            // 
            // transactionsBtn
            // 
            this.transactionsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionsBtn.Location = new System.Drawing.Point(657, 310);
            this.transactionsBtn.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
            this.transactionsBtn.Name = "transactionsBtn";
            this.transactionsBtn.Size = new System.Drawing.Size(440, 80);
            this.transactionsBtn.TabIndex = 2;
            this.transactionsBtn.Text = "Transactions";
            this.transactionsBtn.UseVisualStyleBackColor = true;
            this.transactionsBtn.Click += new System.EventHandler(this.transactionsDidPress);
            // 
            // predictionsBtn
            // 
            this.predictionsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predictionsBtn.Location = new System.Drawing.Point(657, 403);
            this.predictionsBtn.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
            this.predictionsBtn.Name = "predictionsBtn";
            this.predictionsBtn.Size = new System.Drawing.Size(440, 80);
            this.predictionsBtn.TabIndex = 3;
            this.predictionsBtn.Text = "Predictions";
            this.predictionsBtn.UseVisualStyleBackColor = true;
            this.predictionsBtn.Click += new System.EventHandler(this.predictionsDidPress);
            // 
            // reportsBtn
            // 
            this.reportsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsBtn.Location = new System.Drawing.Point(657, 496);
            this.reportsBtn.Margin = new System.Windows.Forms.Padding(10, 3, 3, 10);
            this.reportsBtn.Name = "reportsBtn";
            this.reportsBtn.Size = new System.Drawing.Size(440, 80);
            this.reportsBtn.TabIndex = 4;
            this.reportsBtn.Text = "Reports";
            this.reportsBtn.UseVisualStyleBackColor = true;
            this.reportsBtn.Click += new System.EventHandler(this.reportsDidPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1031, 650);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "v1.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(39, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 55);
            this.label2.TabIndex = 6;
            this.label2.Text = "Income";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(34, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 55);
            this.label3.TabIndex = 7;
            this.label3.Text = "Expenses";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(39, 403);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 55);
            this.label4.TabIndex = 8;
            this.label4.Text = "Balance";
            // 
            // income
            // 
            this.income.Enabled = false;
            this.income.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.income.Location = new System.Drawing.Point(339, 242);
            this.income.Name = "income";
            this.income.Size = new System.Drawing.Size(234, 56);
            this.income.TabIndex = 9;
            this.income.Text = "0.00";
            this.income.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // expense
            // 
            this.expense.Enabled = false;
            this.expense.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expense.Location = new System.Drawing.Point(339, 317);
            this.expense.Name = "expense";
            this.expense.Size = new System.Drawing.Size(234, 56);
            this.expense.TabIndex = 10;
            this.expense.Text = "0.00";
            this.expense.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // balance
            // 
            this.balance.Enabled = false;
            this.balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balance.Location = new System.Drawing.Point(339, 403);
            this.balance.Name = "balance";
            this.balance.Size = new System.Drawing.Size(234, 56);
            this.balance.TabIndex = 11;
            this.balance.Text = "0.00";
            this.balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // homeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 712);
            this.Controls.Add(this.balance);
            this.Controls.Add(this.expense);
            this.Controls.Add(this.income);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportsBtn);
            this.Controls.Add(this.predictionsBtn);
            this.Controls.Add(this.transactionsBtn);
            this.Controls.Add(this.contactsBtn);
            this.Controls.Add(this.categoriesBtn);
            this.MaximizeBox = false;
            this.Name = "homeView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finance Tracker";
            this.Load += new System.EventHandler(this.homeView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button categoriesBtn;
        private System.Windows.Forms.Button contactsBtn;
        private System.Windows.Forms.Button transactionsBtn;
        private System.Windows.Forms.Button predictionsBtn;
        private System.Windows.Forms.Button reportsBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox income;
        private System.Windows.Forms.TextBox expense;
        private System.Windows.Forms.TextBox balance;
    }
}

