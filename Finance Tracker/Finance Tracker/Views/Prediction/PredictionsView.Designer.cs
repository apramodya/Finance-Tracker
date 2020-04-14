namespace Finance_Tracker.Views.Prediction
{
    partial class PredictionsView
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
            this.label2 = new System.Windows.Forms.Label();
            this.predictionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a criteria";
            // 
            // criteriaComboBox
            // 
            this.criteriaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.criteriaComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.criteriaComboBox.FormattingEnabled = true;
            this.criteriaComboBox.Location = new System.Drawing.Point(516, 140);
            this.criteriaComboBox.Name = "criteriaComboBox";
            this.criteriaComboBox.Size = new System.Drawing.Size(321, 41);
            this.criteriaComboBox.TabIndex = 1;
            this.criteriaComboBox.SelectedIndexChanged += new System.EventHandler(this.criteriaSelected);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Predicted expenses";
            // 
            // predictionTextBox
            // 
            this.predictionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predictionTextBox.Location = new System.Drawing.Point(511, 283);
            this.predictionTextBox.Name = "predictionTextBox";
            this.predictionTextBox.ReadOnly = true;
            this.predictionTextBox.Size = new System.Drawing.Size(326, 40);
            this.predictionTextBox.TabIndex = 3;
            // 
            // PredictionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 424);
            this.Controls.Add(this.predictionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.criteriaComboBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "PredictionsView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Predictions";
            this.Load += new System.EventHandler(this.PredictionsView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox criteriaComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox predictionTextBox;
    }
}