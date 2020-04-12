namespace Finance_Tracker.Views.Contact
{
    partial class ContactsView
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
            this.contactsListView = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contactsListView
            // 
            this.contactsListView.HideSelection = false;
            this.contactsListView.Location = new System.Drawing.Point(142, 53);
            this.contactsListView.MaximumSize = new System.Drawing.Size(260, 469);
            this.contactsListView.Name = "contactsListView";
            this.contactsListView.Size = new System.Drawing.Size(260, 469);
            this.contactsListView.TabIndex = 0;
            this.contactsListView.UseCompatibleStateImageBehavior = false;
            this.contactsListView.View = System.Windows.Forms.View.List;
            this.contactsListView.DoubleClick += new System.EventHandler(this.contactDoubleClicked);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(503, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 77);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add new";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addNewContact);
            // 
            // ContactsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 572);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.contactsListView);
            this.MaximizeBox = false;
            this.Name = "ContactsView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contacts";
            this.Activated += new System.EventHandler(this.ContactsView_Activated);
            this.Load += new System.EventHandler(this.ContactsView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView contactsListView;
        private System.Windows.Forms.Button button1;
    }
}