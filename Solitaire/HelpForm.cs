using ApplicationInfo;
using MMG.FormDecoration;
using PdfiumViewer;
using System;
using System.Windows.Forms;

namespace Solitaire
{
    public partial class HelpForm : CleanDarkForm
    {
        PdfViewer pdfViewer;
        public HelpForm()
        {
            InitializeComponent();

            pdfViewer = new PdfViewer();
            pdfViewer.Dock = DockStyle.Fill;
            pdfViewer.Parent = mainPanel;
            InitViewer();
            Disposed += (s, e) => pdfViewer.Document?.Dispose();

            string str = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\doc\Solitaire.pdf";

            
        }

        private void InitViewer()
        {
            // Set what is to be displayed to the user
            PDFPermissions p = new PDFPermissions
            {
                MainMenuVisible = false,
                MainToolBarVisible = true,
                MainStatusBarVisible = true,

                OpenEnabled = false,
                SaveEnabled = true,
                PrintEnabled = true,
                DocumentPropertiesEnabled = true,
                EditEnabled = true
            };

            // Here's a little function pointer to update the title bar
            Action<string> setDocumentName = (name) => this.Text = name + " - MMG PDF Viewer";
            pdfViewer.Init(p, setDocumentName);
            pdfViewer.IniFile = new IniFile();
        }

        private void helpTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            HelpForm_KeyUp(sender, e);
        }
        private void HelpForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void HelpForm_Shown(object sender, EventArgs e)
        {
            pdfViewer.OpenDocument(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\doc\Solitaire.pdf");
        }
    }
}
