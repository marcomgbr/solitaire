using MMG.FormDecoration;
using MMG.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solitaire
{
    public partial class NewUserForm : CleanDarkForm
    {
        public NewUserForm()
        {
            InitializeComponent();
        }
        public int x = 1;
        private void okButton_Click(object sender, EventArgs e)
        {
            if(usernameTextBox.Text == "" || aliasTextBox.Text == "")
            {
                MsgBox.Format().t("You").green.b.t("must").eb.white.t("provide a Username and an Alias.").Show();
                return;
            }

            if(GameSession.Instance.UserCollection.FindByUsername(usernameTextBox.Text) != null)
            {
                MsgBox.Format().t("Username already exists.").Show();
                return;
            }

            User user = GameSession.Instance.UserCollection.CreateUser();
            user.Username = usernameTextBox.Text;
            user.Alias = aliasTextBox.Text;
            GameSession.Instance.UserCollection.AddUser(user);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void NewUserForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                Close();
            }
        }

        private void usernameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                aliasTextBox.Focus();
            }
        }

        private void aliasTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                okButton.Focus();
            }
        }

        private void NewUserForm_Shown(object sender, EventArgs e)
        {
            usernameTextBox.Focus();
        }
    }
}
