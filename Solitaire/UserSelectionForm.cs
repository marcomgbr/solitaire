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
    public partial class UserSelectionForm : CleanDarkForm
    {
        public User SelectedUser { get; private set; }
        public UserSelectionForm()
        {
            InitializeComponent();

            DialogResult = DialogResult.Ignore;
            FillUsersList();
        }

        private void FillUsersList()
        {
            usersListView.Items.Clear();
            foreach (var item in GameSession.Instance.UserCollection.GetUsers())
            {
                ListViewItem lvItem = usersListView.Items.Add(new ListViewItem(
                    new[] { item.Id.ToString(), item.Username, item.Alias }));
                lvItem.Tag = item;
                lvItem.Selected = item.IsCurrentUser;
                if (item.IsCurrentUser) currentUserLabel.Text = item.Alias;
            }
        }

        private void usersListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                User user = (User)e.Item.Tag;
                user.IsCurrentUser = e.IsSelected;
                if (((User)e.Item.Tag).IsCurrentUser) currentUserLabel.Text = ((User)e.Item.Tag).Alias;
            }
        }

        private void UserSelectionForm_Shown(object sender, EventArgs e)
        {
            okButton.Focus();
        }
        
        private void okButton_Click(object sender, EventArgs e)
        {
            SetSelectedUser();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void usersListView_DoubleClick(object sender, EventArgs e)
        {
            SetSelectedUser();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SetSelectedUser()
        {
            if (usersListView.SelectedItems != null && usersListView.SelectedItems.Count > 0)
            {
                this.SelectedUser = (User)usersListView.SelectedItems[0].Tag;
            }
        }

        private void UserSelectionForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUserForm newUserForm = new NewUserForm();
            if (newUserForm.ShowDialog() == DialogResult.OK)
            {
                FillUsersList();
            }
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usersListView.SelectedItems != null && usersListView.SelectedItems.Count >0)
            {
                if(MsgBox.Format(MessageBoxButtons.OKCancel).t("Are you sure you want to").salmon.b.t("delete").eb
                    .white.t("the selected user?").Show() != DialogResult.OK)
                {
                    return;
                }

                User user = (User)usersListView.SelectedItems[0].Tag;
                GameSession.Instance.UserCollection.GetUsers().Remove(user);
                usersListView.Items.Remove(usersListView.SelectedItems[0]);
            }
        }

        private void UserSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetSelectedUser();
        }

        private void usersListView_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button.Equals(MouseButtons.Right))
            {
                mainMenu.Show(usersListView, new Point(e.X, e.Y));
            }
        }
    }
}
