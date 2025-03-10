﻿namespace Finance_Tracker.Category
{
    partial class CategoriesView
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
            this.expenseCategoriesList = new System.Windows.Forms.ListView();
            this.incomeCategoriesList = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // expenseCategoriesList
            // 
            this.expenseCategoriesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expenseCategoriesList.HideSelection = false;
            this.expenseCategoriesList.Location = new System.Drawing.Point(80, 84);
            this.expenseCategoriesList.MaximumSize = new System.Drawing.Size(209, 403);
            this.expenseCategoriesList.Name = "expenseCategoriesList";
            this.expenseCategoriesList.Size = new System.Drawing.Size(209, 403);
            this.expenseCategoriesList.TabIndex = 0;
            this.expenseCategoriesList.Tag = "0";
            this.expenseCategoriesList.UseCompatibleStateImageBehavior = false;
            this.expenseCategoriesList.View = System.Windows.Forms.View.List;
            this.expenseCategoriesList.Click += new System.EventHandler(this.expenseCategorySelected);
            // 
            // incomeCategoriesList
            // 
            this.incomeCategoriesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incomeCategoriesList.HideSelection = false;
            this.incomeCategoriesList.Location = new System.Drawing.Point(614, 84);
            this.incomeCategoriesList.MaximumSize = new System.Drawing.Size(209, 403);
            this.incomeCategoriesList.Name = "incomeCategoriesList";
            this.incomeCategoriesList.Size = new System.Drawing.Size(209, 403);
            this.incomeCategoriesList.TabIndex = 1;
            this.incomeCategoriesList.Tag = "1";
            this.incomeCategoriesList.UseCompatibleStateImageBehavior = false;
            this.incomeCategoriesList.View = System.Windows.Forms.View.List;
            this.incomeCategoriesList.Click += new System.EventHandler(this.incomeCategorySelected);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(323, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(266, 73);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add new";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addNewCategory);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Expense";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(656, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Income";
            // 
            // CategoriesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 529);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.incomeCategoriesList);
            this.Controls.Add(this.expenseCategoriesList);
            this.MaximizeBox = false;
            this.Name = "CategoriesView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Categories";
            this.Activated += new System.EventHandler(this.CategoriesView_Activated);
            this.Load += new System.EventHandler(this.CategoriesView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView expenseCategoriesList;
        private System.Windows.Forms.ListView incomeCategoriesList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}