using MMG.FormDecoration;
using MMG.Forms;
using MMG.CustomPresentation.RTF;
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
    public partial class ScoresForm : CleanDarkForm
    {
        public ScoresForm()
        {
            InitializeComponent();
            FillScore(50);
        }

        private void FillScore(int maxCount)
        {
            var allGameResults = GameSession.Instance.UserCollection.GetUsers()
                .SelectMany( user => user.GetMatches().Select(
                    gameResult => new {
                        GameResult = gameResult,
                        UserAlias = user.Alias
                    }))
                    .OrderByDescending(result => result.GameResult.Score)
                    .ThenBy(result => result.GameResult.GameDuration)
                    .Take(maxCount);
            
            rankingListView.Items.Clear();
            int place = 0;
            foreach (var item in allGameResults)
            {
                ListViewItem lvItem = rankingListView.Items.Add(new ListViewItem(
                    new[] { (++place).ToString(), item.UserAlias, 
                    item.GameResult.Score.ToString(), item.GameResult.GameDuration.ToString(),
                    item.GameResult.Date.ToString(), item.GameResult.UserId.ToString()
                    }));
                lvItem.Tag = item;
            }

            FillScoreRTF(allGameResults.ToList<dynamic>());
            FillScorePlainText(allGameResults.ToList<dynamic>());
        }

        private void FillScoreRTF(List<dynamic> lines)
        {
            RTFBuilder builder = new RTFBuilder();
            TABLEBorders borders = new TABLEBorders() 
            { 
                LeftBorderStyle = TABLEBorderStyle.NONE, 
                RightBorderStyle = TABLEBorderStyle.NONE 
            };
            builder.table(TRAlignVertical.CENTER, borders, 20, 40, 20, 40, 40, 20)
            .pf(8).tr.b.td.t("PLACE").etd
                .td.t("ALIAS").etd
                .td.t("SCORE").etd
                .td.t("DURATION").etd
                .td.t("DATE").etd
                .td.t("USER ID").etd.eb.etr.pack();

            rtfTable.Clear();
            int place = 0;
            foreach (var item in lines)
            {
                builder.tr.td.t((++place).ToString()).etd
                    .td.t(item.UserAlias).etd
                    .td.t(item.GameResult.Score.ToString()).etd
                    .td.t(item.GameResult.GameDuration.ToString()).etd
                    .td.t(item.GameResult.Date.ToString()).etd
                    .td.t(item.GameResult.UserId.ToString()).etd.etr.pack();
            }
            
            rtfTable.Rtf = builder.ep.etable.GetRTFString();
        }

        private void FillScorePlainText(List<dynamic> lines)
        {
            StringBuilder sb = new StringBuilder();
            plainTextTable.Clear();
            int place = 0;
            foreach (var item in lines)
            {
                sb.Append((++place).ToString().PadRight(7)).Append(item.UserAlias.PadRight(30))
                    .Append(item.GameResult.UserId.ToString().PadRight(7))
                    .Append(item.GameResult.Score.ToString().PadRight(7))
                    .Append(item.GameResult.GameDuration.ToString().PadRight(20))
                    .Append(item.GameResult.Date.ToString().PadRight(20))
                    .Append("\n");
            }
            
            plainTextTable.Text = sb.ToString();

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void resultCountText_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Allow only digits and control characters (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Allow only up to 10 digits
            if (char.IsDigit(e.KeyChar) && textBox.Text.Length >= 10)
            {
                e.Handled = true;
            }
        }

        private void fillListButton_Click(object sender, EventArgs e)
        {
            FillScore(int.Parse(maxCountText.Text));
        }

        private void ScoresForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                Close();
            }
        }
    }
}
