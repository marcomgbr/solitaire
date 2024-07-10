
namespace Solitaire
{
    partial class ScoresForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.table = new System.Windows.Forms.TabPage();
            this.rankingListView = new System.Windows.Forms.ListView();
            this.place = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alias = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.score = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rtf = new System.Windows.Forms.TabPage();
            this.rtfTable = new System.Windows.Forms.RichTextBox();
            this.plainText = new System.Windows.Forms.TabPage();
            this.plainTextTable = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maxCountText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fillListButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.table.SuspendLayout();
            this.rtf.SuspendLayout();
            this.plainText.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(557, 439);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(69, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Close";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.table);
            this.tabControl1.Controls.Add(this.rtf);
            this.tabControl1.Controls.Add(this.plainText);
            this.tabControl1.Location = new System.Drawing.Point(16, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(610, 369);
            this.tabControl1.TabIndex = 19;
            // 
            // table
            // 
            this.table.Controls.Add(this.rankingListView);
            this.table.Location = new System.Drawing.Point(4, 22);
            this.table.Name = "table";
            this.table.Padding = new System.Windows.Forms.Padding(3);
            this.table.Size = new System.Drawing.Size(602, 343);
            this.table.TabIndex = 0;
            this.table.Text = "Table";
            this.table.UseVisualStyleBackColor = true;
            // 
            // rankingListView
            // 
            this.rankingListView.BackColor = System.Drawing.Color.White;
            this.rankingListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rankingListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.place,
            this.alias,
            this.score,
            this.duration,
            this.date,
            this.userId});
            this.rankingListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rankingListView.FullRowSelect = true;
            this.rankingListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.rankingListView.HideSelection = false;
            this.rankingListView.Location = new System.Drawing.Point(3, 3);
            this.rankingListView.MultiSelect = false;
            this.rankingListView.Name = "rankingListView";
            this.rankingListView.Size = new System.Drawing.Size(596, 337);
            this.rankingListView.TabIndex = 17;
            this.rankingListView.UseCompatibleStateImageBehavior = false;
            this.rankingListView.View = System.Windows.Forms.View.Details;
            // 
            // place
            // 
            this.place.Text = "Place";
            this.place.Width = 50;
            // 
            // alias
            // 
            this.alias.Text = "Alias";
            this.alias.Width = 150;
            // 
            // score
            // 
            this.score.Text = "Score";
            this.score.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // duration
            // 
            this.duration.Text = "Duration";
            this.duration.Width = 120;
            // 
            // date
            // 
            this.date.Text = "Date";
            this.date.Width = 120;
            // 
            // userId
            // 
            this.userId.Text = "User Id";
            this.userId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rtf
            // 
            this.rtf.Controls.Add(this.rtfTable);
            this.rtf.Location = new System.Drawing.Point(4, 22);
            this.rtf.Name = "rtf";
            this.rtf.Padding = new System.Windows.Forms.Padding(3);
            this.rtf.Size = new System.Drawing.Size(602, 343);
            this.rtf.TabIndex = 1;
            this.rtf.Text = "Rich Text";
            this.rtf.UseVisualStyleBackColor = true;
            // 
            // rtfTable
            // 
            this.rtfTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfTable.Location = new System.Drawing.Point(3, 3);
            this.rtfTable.Name = "rtfTable";
            this.rtfTable.ReadOnly = true;
            this.rtfTable.Size = new System.Drawing.Size(596, 337);
            this.rtfTable.TabIndex = 19;
            this.rtfTable.Text = "";
            this.rtfTable.WordWrap = false;
            // 
            // plainText
            // 
            this.plainText.Controls.Add(this.plainTextTable);
            this.plainText.Location = new System.Drawing.Point(4, 22);
            this.plainText.Name = "plainText";
            this.plainText.Size = new System.Drawing.Size(602, 343);
            this.plainText.TabIndex = 2;
            this.plainText.Text = "Plain Text";
            this.plainText.UseVisualStyleBackColor = true;
            // 
            // plainTextTable
            // 
            this.plainTextTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.plainTextTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plainTextTable.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plainTextTable.Location = new System.Drawing.Point(0, 0);
            this.plainTextTable.Name = "plainTextTable";
            this.plainTextTable.ReadOnly = true;
            this.plainTextTable.Size = new System.Drawing.Size(602, 343);
            this.plainTextTable.TabIndex = 20;
            this.plainTextTable.Text = "";
            this.plainTextTable.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Show ";
            // 
            // maxCountText
            // 
            this.maxCountText.Location = new System.Drawing.Point(56, 441);
            this.maxCountText.Name = "maxCountText";
            this.maxCountText.Size = new System.Drawing.Size(46, 20);
            this.maxCountText.TabIndex = 21;
            this.maxCountText.Text = "50";
            this.maxCountText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resultCountText_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "first results.";
            // 
            // fillListButton
            // 
            this.fillListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fillListButton.Location = new System.Drawing.Point(173, 441);
            this.fillListButton.Name = "fillListButton";
            this.fillListButton.Size = new System.Drawing.Size(43, 23);
            this.fillListButton.TabIndex = 23;
            this.fillListButton.Text = "Go";
            this.fillListButton.UseVisualStyleBackColor = true;
            this.fillListButton.Click += new System.EventHandler(this.fillListButton_Click);
            // 
            // ScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.fillListButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxCountText);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "ScoresForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Best Scores";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ScoresForm_KeyUp);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.maxCountText, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.fillListButton, 0);
            this.tabControl1.ResumeLayout(false);
            this.table.ResumeLayout(false);
            this.rtf.ResumeLayout(false);
            this.plainText.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage table;
        private System.Windows.Forms.ListView rankingListView;
        private System.Windows.Forms.ColumnHeader place;
        private System.Windows.Forms.ColumnHeader alias;
        private System.Windows.Forms.ColumnHeader score;
        private System.Windows.Forms.ColumnHeader duration;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader userId;
        private System.Windows.Forms.TabPage rtf;
        private System.Windows.Forms.RichTextBox rtfTable;
        private System.Windows.Forms.TabPage plainText;
        private System.Windows.Forms.RichTextBox plainTextTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox maxCountText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button fillListButton;
    }
}