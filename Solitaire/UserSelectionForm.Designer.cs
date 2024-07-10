
namespace Solitaire
{
    partial class UserSelectionForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSelectionForm));
            this.okButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.currentUserLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createUserButton = new System.Windows.Forms.PictureBox();
            this.deleteUserButton = new System.Windows.Forms.PictureBox();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usersListView = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.createUserButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteUserButton)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(295, 273);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(69, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Select";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Current User:";
            // 
            // currentUserLabel
            // 
            this.currentUserLabel.AutoSize = true;
            this.currentUserLabel.Location = new System.Drawing.Point(90, 90);
            this.currentUserLabel.Name = "currentUserLabel";
            this.currentUserLabel.Size = new System.Drawing.Size(33, 13);
            this.currentUserLabel.TabIndex = 16;
            this.currentUserLabel.Text = "None";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Location = new System.Drawing.Point(220, 273);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(69, 23);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newUserToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem});
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(155, 48);
            // 
            // newUserToolStripMenuItem
            // 
            this.newUserToolStripMenuItem.Name = "newUserToolStripMenuItem";
            this.newUserToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.newUserToolStripMenuItem.Text = "New User";
            this.newUserToolStripMenuItem.Click += new System.EventHandler(this.newUserToolStripMenuItem_Click);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.deleteSelectedToolStripMenuItem.Text = "Delete Selected";
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedToolStripMenuItem_Click);
            // 
            // createUserButton
            // 
            this.createUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createUserButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createUserButton.Image = ((System.Drawing.Image)(resources.GetObject("createUserButton.Image")));
            this.createUserButton.Location = new System.Drawing.Point(340, 79);
            this.createUserButton.Name = "createUserButton";
            this.createUserButton.Size = new System.Drawing.Size(24, 24);
            this.createUserButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.createUserButton.TabIndex = 19;
            this.createUserButton.TabStop = false;
            this.createUserButton.Click += new System.EventHandler(this.newUserToolStripMenuItem_Click);
            // 
            // deleteUserButton
            // 
            this.deleteUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteUserButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteUserButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteUserButton.Image")));
            this.deleteUserButton.Location = new System.Drawing.Point(16, 272);
            this.deleteUserButton.Name = "deleteUserButton";
            this.deleteUserButton.Size = new System.Drawing.Size(24, 24);
            this.deleteUserButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.deleteUserButton.TabIndex = 20;
            this.deleteUserButton.TabStop = false;
            this.deleteUserButton.Click += new System.EventHandler(this.deleteSelectedToolStripMenuItem_Click);
            // 
            // id
            // 
            this.id.DisplayIndex = 2;
            this.id.Text = "Id";
            this.id.Width = 32;
            // 
            // alias
            // 
            this.alias.DisplayIndex = 1;
            this.alias.Text = "Alias";
            this.alias.Width = 200;
            // 
            // username
            // 
            this.username.DisplayIndex = 0;
            this.username.Text = "Username";
            this.username.Width = 100;
            // 
            // usersListView
            // 
            this.usersListView.BackColor = System.Drawing.Color.White;
            this.usersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.username,
            this.alias});
            this.usersListView.FullRowSelect = true;
            this.usersListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.usersListView.HideSelection = false;
            this.usersListView.Location = new System.Drawing.Point(16, 109);
            this.usersListView.MultiSelect = false;
            this.usersListView.Name = "usersListView";
            this.usersListView.Size = new System.Drawing.Size(348, 148);
            this.usersListView.TabIndex = 15;
            this.usersListView.UseCompatibleStateImageBehavior = false;
            this.usersListView.View = System.Windows.Forms.View.Details;
            this.usersListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.usersListView_ItemSelectionChanged);
            this.usersListView.DoubleClick += new System.EventHandler(this.usersListView_DoubleClick);
            this.usersListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.usersListView_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Select User";
            // 
            // UserSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 315);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deleteUserButton);
            this.Controls.Add(this.createUserButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.currentUserLabel);
            this.Controls.Add(this.usersListView);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "UserSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Solitaire";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserSelectionForm_FormClosing);
            this.Shown += new System.EventHandler(this.UserSelectionForm_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UserSelectionForm_KeyUp);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.usersListView, 0);
            this.Controls.SetChildIndex(this.currentUserLabel, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.createUserButton, 0);
            this.Controls.SetChildIndex(this.deleteUserButton, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.mainMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.createUserButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteUserButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentUserLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ContextMenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem newUserToolStripMenuItem;
        private System.Windows.Forms.PictureBox createUserButton;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private System.Windows.Forms.PictureBox deleteUserButton;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader alias;
        private System.Windows.Forms.ColumnHeader username;
        private System.Windows.Forms.ListView usersListView;
        private System.Windows.Forms.Label label2;
    }
}