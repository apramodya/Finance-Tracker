namespace Finance_Tracker.Views.Report
{
    partial class ReportsView
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
            this.label1 = new System.Windows.Forms.Label();
            this.criteriaComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(552, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a criteria to generate reports";
            // 
            // criteriaComboBox
            // 
            this.criteriaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.criteriaComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaComboBox.FormattingEnabled = true;
            this.criteriaComboBox.Location = new System.Drawing.Point(689, 67);
            this.criteriaComboBox.Name = "criteriaComboBox";
            this.criteriaComboBox.Size = new System.Drawing.Size(275, 41);
            this.criteriaComboBox.TabIndex = 1;
            this.criteriaComboBox.SelectedIndexChanged += new System.EventHandler(this.criteriaSelected);
            // 
            // ReportsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 454);
            this.Controls.Add(this.criteriaComboBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "ReportsView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.ReportsView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox criteriaComboBox;
    }
}