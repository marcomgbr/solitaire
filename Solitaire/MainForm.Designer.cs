
namespace Solitaire
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.userStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stockStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.wasteStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.scoreStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.gameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.gameNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scoresMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gameExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpHowToPlayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.mainContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendToBuildPileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableau = new System.Windows.Forms.Panel();
            this.statusStrip.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.mainContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.ForestGreen;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userStatusLabel,
            this.stockStatusLabel,
            this.wasteStatusLabel,
            this.scoreStatusLabel,
            this.timeStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 706);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1008, 24);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 12;
            this.statusStrip.Text = "statusStrip1";
            // 
            // userStatusLabel
            // 
            this.userStatusLabel.AutoSize = false;
            this.userStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.userStatusLabel.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.userStatusLabel.Name = "userStatusLabel";
            this.userStatusLabel.Size = new System.Drawing.Size(200, 19);
            this.userStatusLabel.Text = "Player: Default";
            this.userStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stockStatusLabel
            // 
            this.stockStatusLabel.AutoSize = false;
            this.stockStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.stockStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.stockStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.stockStatusLabel.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.stockStatusLabel.Name = "stockStatusLabel";
            this.stockStatusLabel.Size = new System.Drawing.Size(100, 19);
            this.stockStatusLabel.Text = " Stock: 0";
            this.stockStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wasteStatusLabel
            // 
            this.wasteStatusLabel.AutoSize = false;
            this.wasteStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.wasteStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.wasteStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.wasteStatusLabel.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.wasteStatusLabel.Name = "wasteStatusLabel";
            this.wasteStatusLabel.Size = new System.Drawing.Size(100, 19);
            this.wasteStatusLabel.Text = "Waste: 0";
            this.wasteStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scoreStatusLabel
            // 
            this.scoreStatusLabel.AutoSize = false;
            this.scoreStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.scoreStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.scoreStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.scoreStatusLabel.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.scoreStatusLabel.Name = "scoreStatusLabel";
            this.scoreStatusLabel.Size = new System.Drawing.Size(100, 19);
            this.scoreStatusLabel.Text = " Score: 0";
            this.scoreStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timeStatusLabel
            // 
            this.timeStatusLabel.AutoSize = false;
            this.timeStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.timeStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.timeStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.timeStatusLabel.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.timeStatusLabel.Name = "timeStatusLabel";
            this.timeStatusLabel.Size = new System.Drawing.Size(150, 19);
            this.timeStatusLabel.Text = " Time: 00:00:00";
            this.timeStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameMenu,
            this.userToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1008, 25);
            this.mainMenu.TabIndex = 13;
            this.mainMenu.Text = "Game";
            // 
            // gameMenu
            // 
            this.gameMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameNewMenuItem,
            this.scoresMenuItem,
            this.toolStripSeparator1,
            this.gameExitMenuItem});
            this.gameMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameMenu.ForeColor = System.Drawing.Color.Green;
            this.gameMenu.Name = "gameMenu";
            this.gameMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.gameMenu.Size = new System.Drawing.Size(55, 21);
            this.gameMenu.Text = "Game";
            // 
            // gameNewMenuItem
            // 
            this.gameNewMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.gameNewMenuItem.Name = "gameNewMenuItem";
            this.gameNewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.gameNewMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gameNewMenuItem.Text = "New";
            this.gameNewMenuItem.Click += new System.EventHandler(this.newGameMenuItem_Click);
            // 
            // scoresMenuItem
            // 
            this.scoresMenuItem.Name = "scoresMenuItem";
            this.scoresMenuItem.Size = new System.Drawing.Size(152, 22);
            this.scoresMenuItem.Text = "View Scores";
            this.scoresMenuItem.Click += new System.EventHandler(this.scoresMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // gameExitMenuItem
            // 
            this.gameExitMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.gameExitMenuItem.Name = "gameExitMenuItem";
            this.gameExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.gameExitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gameExitMenuItem.Text = "Exit";
            this.gameExitMenuItem.Click += new System.EventHandler(this.gameExitMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectUserToolStripMenuItem,
            this.newUserToolStripMenuItem});
            this.userToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userToolStripMenuItem.ForeColor = System.Drawing.Color.Green;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.userToolStripMenuItem.Text = "User";
            // 
            // selectUserToolStripMenuItem
            // 
            this.selectUserToolStripMenuItem.Name = "selectUserToolStripMenuItem";
            this.selectUserToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.selectUserToolStripMenuItem.Text = "Select User";
            this.selectUserToolStripMenuItem.Click += new System.EventHandler(this.selectUserToolStripMenuItem_Click);
            // 
            // newUserToolStripMenuItem
            // 
            this.newUserToolStripMenuItem.Name = "newUserToolStripMenuItem";
            this.newUserToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newUserToolStripMenuItem.Text = "New User";
            this.newUserToolStripMenuItem.Click += new System.EventHandler(this.newUserToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpHowToPlayMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.Green;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(49, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpHowToPlayMenuItem
            // 
            this.helpHowToPlayMenuItem.Name = "helpHowToPlayMenuItem";
            this.helpHowToPlayMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpHowToPlayMenuItem.Size = new System.Drawing.Size(179, 22);
            this.helpHowToPlayMenuItem.Text = "Learn to play";
            this.helpHowToPlayMenuItem.Click += new System.EventHandler(this.helpHowToPlayMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // mainContextMenu
            // 
            this.mainContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToBuildPileToolStripMenuItem});
            this.mainContextMenu.Name = "mainContextMenu";
            this.mainContextMenu.Size = new System.Drawing.Size(167, 26);
            // 
            // sendToBuildPileToolStripMenuItem
            // 
            this.sendToBuildPileToolStripMenuItem.Name = "sendToBuildPileToolStripMenuItem";
            this.sendToBuildPileToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.sendToBuildPileToolStripMenuItem.Text = "Send to Build Pile";
            this.sendToBuildPileToolStripMenuItem.Click += new System.EventHandler(this.sendToBuildPileToolStripMenuItem_Click);
            // 
            // tableau
            // 
            this.tableau.AllowDrop = true;
            this.tableau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableau.Location = new System.Drawing.Point(0, 25);
            this.tableau.Name = "tableau";
            this.tableau.Size = new System.Drawing.Size(1008, 681);
            this.tableau.TabIndex = 14;
            this.tableau.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tableau_MouseDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.tableau);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solitaire";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.mainContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem gameMenu;
        private System.Windows.Forms.ToolStripMenuItem gameNewMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel stockStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel scoreStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel timeStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem gameExitMenuItem;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.ToolStripStatusLabel userStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpHowToPlayMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel wasteStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mainContextMenu;
        private System.Windows.Forms.ToolStripMenuItem sendToBuildPileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scoresMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel tableau;
    }
}

