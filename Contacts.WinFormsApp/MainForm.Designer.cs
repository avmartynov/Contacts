namespace Contacts.WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button exitButton;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Button deleteContactButton;
            System.Windows.Forms.Button editContactButton;
            System.Windows.Forms.Button newContactButton;
            System.Windows.Forms.Button filterButton;
            System.Windows.Forms.Button clearFilterButton;
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.Label label5;
            this.mainFormModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.filterLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.contactListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.contactsListBox = new System.Windows.Forms.ListBox();
            exitButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            deleteContactButton = new System.Windows.Forms.Button();
            editContactButton = new System.Windows.Forms.Button();
            newContactButton = new System.Windows.Forms.Button();
            filterButton = new System.Windows.Forms.Button();
            clearFilterButton = new System.Windows.Forms.Button();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            panel1 = new System.Windows.Forms.Panel();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormModelBindingSource)).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactListBindingSource)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            exitButton.Location = new System.Drawing.Point(367, 235);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(105, 23);
            exitButton.TabIndex = 5;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainFormModelBindingSource, "ContactListLabel", true));
            label1.Location = new System.Drawing.Point(12, 8);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(130, 15);
            label1.TabIndex = 0;
            label1.Text = "Contacts (10000 items):";
            // 
            // mainFormModelBindingSource
            // 
            this.mainFormModelBindingSource.DataSource = typeof(Contacts.WinFormsApp.MainFormModel);
            // 
            // deleteContactButton
            // 
            deleteContactButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            deleteContactButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.mainFormModelBindingSource, "SelectedContactEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            deleteContactButton.Location = new System.Drawing.Point(121, 165);
            deleteContactButton.Name = "deleteContactButton";
            deleteContactButton.Size = new System.Drawing.Size(90, 23);
            deleteContactButton.TabIndex = 1;
            deleteContactButton.Text = "Delete Contact";
            deleteContactButton.UseVisualStyleBackColor = true;
            deleteContactButton.Click += new System.EventHandler(this.deleteContactButton_Click);
            // 
            // editContactButton
            // 
            editContactButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            editContactButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.mainFormModelBindingSource, "SelectedContactEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            editContactButton.Location = new System.Drawing.Point(14, 165);
            editContactButton.Name = "editContactButton";
            editContactButton.Size = new System.Drawing.Size(98, 23);
            editContactButton.TabIndex = 0;
            editContactButton.Text = "Edit Contact...";
            editContactButton.UseVisualStyleBackColor = true;
            editContactButton.Click += new System.EventHandler(this.editContactButton_Click);
            // 
            // newContactButton
            // 
            newContactButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            newContactButton.Location = new System.Drawing.Point(245, 235);
            newContactButton.Name = "newContactButton";
            newContactButton.Size = new System.Drawing.Size(113, 23);
            newContactButton.TabIndex = 4;
            newContactButton.Text = "New Contact...";
            newContactButton.UseVisualStyleBackColor = true;
            newContactButton.Click += new System.EventHandler(this.newContactButton_Click);
            // 
            // filterButton
            // 
            filterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            filterButton.Location = new System.Drawing.Point(12, 235);
            filterButton.Name = "filterButton";
            filterButton.Size = new System.Drawing.Size(113, 23);
            filterButton.TabIndex = 1;
            filterButton.Text = "Filter...";
            filterButton.UseVisualStyleBackColor = true;
            filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // clearFilterButton
            // 
            clearFilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            clearFilterButton.Location = new System.Drawing.Point(134, 235);
            clearFilterButton.Name = "clearFilterButton";
            clearFilterButton.Size = new System.Drawing.Size(105, 23);
            clearFilterButton.TabIndex = 2;
            clearFilterButton.Text = "Clear Filter";
            clearFilterButton.UseVisualStyleBackColor = true;
            clearFilterButton.Click += new System.EventHandler(this.clearFilterButton_Click);
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            flowLayoutPanel1.Controls.Add(this.filterLabel);
            flowLayoutPanel1.ForeColor = System.Drawing.Color.Red;
            flowLayoutPanel1.Location = new System.Drawing.Point(148, 8);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            flowLayoutPanel1.Size = new System.Drawing.Size(91, 17);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // filterLabel
            // 
            this.filterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterLabel.AutoSize = true;
            this.filterLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainFormModelBindingSource, "FilterMessage", true));
            this.filterLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.filterLabel.ForeColor = System.Drawing.Color.Red;
            this.filterLabel.Location = new System.Drawing.Point(88, 0);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.filterLabel.Size = new System.Drawing.Size(0, 15);
            this.filterLabel.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(this.nameTextBox);
            panel1.Controls.Add(this.phoneTextBox);
            panel1.Controls.Add(this.flowLayoutPanel2);
            panel1.Controls.Add(deleteContactButton);
            panel1.Controls.Add(editContactButton);
            panel1.Location = new System.Drawing.Point(245, 27);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(227, 200);
            panel1.TabIndex = 3;
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactListBindingSource, "Name", true));
            this.nameTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nameTextBox.Location = new System.Drawing.Point(14, 58);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(197, 16);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.Text = "Name Name";
            this.nameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contactListBindingSource
            // 
            this.contactListBindingSource.DataMember = "Contacts";
            this.contactListBindingSource.DataSource = this.mainFormModelBindingSource;
            this.contactListBindingSource.PositionChanged += new System.EventHandler(this.contactListBindingSource_PositionChanged);
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.phoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactListBindingSource, "Phone", true));
            this.phoneTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.phoneTextBox.Location = new System.Drawing.Point(14, 95);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.ReadOnly = true;
            this.phoneTextBox.Size = new System.Drawing.Size(197, 16);
            this.phoneTextBox.TabIndex = 3;
            this.phoneTextBox.Text = "Phone Phone";
            this.phoneTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.phoneTextBox.WordWrap = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(label5);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(219, 15);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contactListBindingSource, "ContactId", true));
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(202, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(17, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "12";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.mainFormModelBindingSource, "SelectedContactEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            label5.Location = new System.Drawing.Point(181, 0);
            label5.Margin = new System.Windows.Forms.Padding(0);
            label5.Name = "label5";
            label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            label5.Size = new System.Drawing.Size(21, 15);
            label5.TabIndex = 4;
            label5.Text = "ID:";
            // 
            // contactsListBox
            // 
            this.contactsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contactsListBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedIndex", this.mainFormModelBindingSource, "SelectedContactIndex", true));
            this.contactsListBox.DataSource = this.contactListBindingSource;
            this.contactsListBox.DisplayMember = "Name";
            this.contactsListBox.FormattingEnabled = true;
            this.contactsListBox.IntegralHeight = false;
            this.contactsListBox.ItemHeight = 15;
            this.contactsListBox.Location = new System.Drawing.Point(12, 27);
            this.contactsListBox.Name = "contactsListBox";
            this.contactsListBox.Size = new System.Drawing.Size(227, 200);
            this.contactsListBox.TabIndex = 0;
            this.contactsListBox.ValueMember = "ContactId";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 270);
            this.Controls.Add(flowLayoutPanel1);
            this.Controls.Add(clearFilterButton);
            this.Controls.Add(filterButton);
            this.Controls.Add(panel1);
            this.Controls.Add(exitButton);
            this.Controls.Add(newContactButton);
            this.Controls.Add(this.contactsListBox);
            this.Controls.Add(label1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 293);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Address Book";
            ((System.ComponentModel.ISupportInitialize)(this.mainFormModelBindingSource)).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contactListBindingSource)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private BindingSource mainFormModelBindingSource;
        private BindingSource contactListBindingSource;
        private Label label4;
        private Label filterLabel;
        private FlowLayoutPanel flowLayoutPanel2;
        private TextBox phoneTextBox;
        private TextBox nameTextBox;
        private ListBox contactsListBox;
    }
}