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
    public partial class AboutForm : CleanDarkForm
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutPicture_Click(object sender, EventArgs e)
        {
            string target = "https://maurelio.com.br";
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MsgBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MsgBox.Show(other.Message);
            }
        }
    }
}
