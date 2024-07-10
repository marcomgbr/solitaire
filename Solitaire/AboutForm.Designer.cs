
namespace Solitaire
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.aboutPicture = new System.Windows.Forms.PictureBox();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.aboutPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // aboutPicture
            // 
            this.aboutPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutPicture.Image = ((System.Drawing.Image)(resources.GetObject("aboutPicture.Image")));
            this.aboutPicture.Location = new System.Drawing.Point(16, 52);
            this.aboutPicture.Name = "aboutPicture";
            this.aboutPicture.Size = new System.Drawing.Size(500, 375);
            this.aboutPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.aboutPicture.TabIndex = 8;
            this.aboutPicture.TabStop = false;
            this.aboutPicture.Click += new System.EventHandler(this.aboutPicture_Click);
            // 
            // okButton
            // 
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Location = new System.Drawing.Point(441, 444);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 485);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.aboutPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutForm";
            this.Controls.SetChildIndex(this.aboutPicture, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.aboutPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox aboutPicture;
        private System.Windows.Forms.Button okButton;
    }
}