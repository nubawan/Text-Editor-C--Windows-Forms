using System.Drawing.Printing;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;
        public ToolStripMenuItem font;
        public ToolStripMenuItem color;
        public ToolStripMenuItem copy;
        public ToolStripMenuItem paste;
        bool IsSaved;
        public Form1()
        {
            InitializeComponent();
            Instance = this;
            font = fontToolStripMenuItem;
            color = colorToolStripMenuItem;
            copy = copyToolStripMenuItem;
            paste = pasteToolStripMenuItem;
            IsSaved = false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to save?", "Confirm", MessageBoxButtons.YesNoCancel);


            if (dr == DialogResult.Yes)
            {
                saveFileDialog1.ShowDialog();
                richTextBox1.Text = "";
            }
            else if (dr == DialogResult.No)
            {
                richTextBox1.Text = "";
            }
            else
            {

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Rich Text File (*.rtf)|*.rtf|Plain Text File (*.txt)|*.txt";
            openDlg.FilterIndex = 1;
            openDlg.Title = "Open a file";

            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openDlg.FileName, RichTextBoxStreamType.RichText);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            string filename = "";

            saveDlg.Filter = "Rich Text File (*.rtf)|*.rtf|Plain Text File (*.txt)|*.txt";
            saveDlg.DefaultExt = "*.rtf";
            saveDlg.FilterIndex = 1;
            saveDlg.Title = "Save the contents";

            DialogResult retval = saveDlg.ShowDialog();
            if (retval == DialogResult.OK)
            {
                filename = saveDlg.FileName;

                RichTextBoxStreamType stream_type;
                if (saveDlg.FilterIndex == 2)
                    stream_type = RichTextBoxStreamType.PlainText;
                else
                    stream_type = RichTextBoxStreamType.RichText;

                richTextBox1.SaveFile(filename, stream_type);
            }
            else
            {
                return;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDialog1.Document = printDoc;
            printDialog1.AllowSelection = true;
            printDialog1.AllowSomePages = true;
            if (printDialog1.ShowDialog() == DialogResult.OK) printDoc.Print();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Preview Document";

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDoc;

            printPreviewDialog.ShowDialog();
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();

            pageSetupDialog.PageSettings = new System.Drawing.Printing.PageSettings();

            pageSetupDialog.PrinterSettings = new System.Drawing.Printing.PrinterSettings();

            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Printing.PageSettings newPageSettings = pageSetupDialog.PageSettings;
                System.Drawing.Printing.PrinterSettings newPrinterSettings = pageSetupDialog.PrinterSettings;
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.ShowDialog();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void foreColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionBackColor = colorDialog1.Color;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
