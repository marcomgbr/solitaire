using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.IO;
using MMG.Forms;

namespace Solitaire
{
    public partial class MainForm : Form
    {
        readonly Point PILES_TOP_LEFT = new Point(20, 20);
        readonly int HORIZONTAL_PILES_SPACING = 20;
        readonly string USER_DATA_PATH = Application.UserAppDataPath + @"\user-collecion.data";

        Size cardSize = new Size(120, 175);

        GameController gameController;
        
        public MainForm()
        {
            InitializeComponent();

            if (!Directory.Exists(Application.UserAppDataPath))
            {
                Directory.CreateDirectory(Application.UserAppDataPath);
            }

            InitGame();
        }

        private void InitGame()
        {
            tableau.Visible = false;

            GameSession.Instance.Init(gameTimer, userStatusLabel, stockStatusLabel, 
                wasteStatusLabel, timeStatusLabel, scoreStatusLabel);

            string deckImagesDir = Path.GetDirectoryName(Application.ExecutablePath) + @"\data\deck";
            this.gameController = new GameController(tableau, deckImagesDir);
            
            GameSession.Instance.Controller = this.gameController;
            GameSession.Instance.UserDataFile
                   = new ObjectBinaryPersistence<UserCollection>(USER_DATA_PATH);
            GameSession.Instance.UserCollection = InitUserData();

            this.gameController.DoLayout(cardSize, HORIZONTAL_PILES_SPACING, PILES_TOP_LEFT);
        }

        private UserCollection InitUserData()
        {
            
            UserCollection userCollection = null;
            if (File.Exists(USER_DATA_PATH))
            {  
                userCollection = GameSession.Instance.UserDataFile.Load();
            }

            if (userCollection == null || userCollection.GetUsers().Count == 0)
            {
                userCollection = new UserCollection();
                User user = userCollection.CreateUser();
                user.Username = "default";
                user.Alias = "Default User";
                userCollection.AddUser(user);
                GameSession.Instance.User = user;
                GameSession.Instance.UserDataFile.PersistentObject = userCollection;
            }

            return userCollection;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            SelectUser();
            tableau.Visible = true;
        }

        private void selectUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MsgBox.Format(MessageBoxButtons.OKCancel).green.b.t("Attention!").eb
                .white.t("Selecting another user will restart the game!").Show();
            if (result == DialogResult.OK)
            {
                DialogResult = DialogResult.Retry;
                Close();
            }
        }

        private void SelectUser()
        {
            UserSelectionForm userSelection = new UserSelectionForm();
            if (userSelection.ShowDialog() == DialogResult.OK && userSelection.SelectedUser != null)
            {
                GameSession.Instance.User = userSelection.SelectedUser;
            }
            else
            {
                User user = GameSession.Instance.UserCollection.FindByUsername("default");
                if (user != null)
                {
                    GameSession.Instance.User = user;
                }
                else
                {
                    CreateDefaultUser();
                }
            }
        }

        private void CreateDefaultUser()
        {
            User user = GameSession.Instance.UserCollection.CreateUser();
            user.Username = "default";
            user.Alias = "Default User";
            GameSession.Instance.UserCollection.AddUser(user);
            GameSession.Instance.User = user;
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NewUserForm().ShowDialog();
        }

        private void newGameMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            DoLayout();
        }

        // from Winuser.h
        const int WM_SYSCOMMAND = 0x0112;
        readonly IntPtr SC_MAXIMIZE = new IntPtr(0xF030);
        readonly IntPtr SC_RESTORE = new IntPtr(0xF120);
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    if (m.WParam == SC_MAXIMIZE || m.WParam == SC_RESTORE)
                    {
                        DoLayout();
                    }
                    break;
            }
        }

        private void DoLayout()
        {
            Size cardSize = CalcNewCardSize();
            double tableauLeft = (tableau.Width - (7 * cardSize.Width) - (6 * HORIZONTAL_PILES_SPACING))/2;
            gameController.DoLayout(cardSize, HORIZONTAL_PILES_SPACING, new Point((int)Math.Round(tableauLeft), 20));
        }

        private Size CalcNewCardSize()
        {
            double newCardWidth = (tableau.Width - 160) / 7;
            double newCardHeight = newCardWidth * 1.4583333333333333333333;
            if (newCardHeight * 3.5 > tableau.Height)
            {
                newCardHeight = tableau.Height / 3.5;
                newCardWidth = newCardHeight * 0.685714285714285714285714;  
            }

            return new Size((int)Math.Round(newCardWidth), (int)Math.Round(newCardHeight));
        }

        private void gameExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            GameSession.Instance.UpdateTime();
        }

        private void helpHowToPlayMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void sendToBuildPileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.gameController.SendAllToBuildPiles();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameSession.Instance.UserDataFile.Save();
            GameSession.Invalidate();
        }

        private void scoresMenuItem_Click(object sender, EventArgs e)
        {
            ScoresForm scoreForm = new ScoresForm();
            scoreForm.ShowDialog();
        }

        private void tableau_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                mainContextMenu.Show(tableau, new Point(e.X, e.Y));
            }
        }
    }
}
