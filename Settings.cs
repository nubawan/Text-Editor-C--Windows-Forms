using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TextEditor
{
    public partial class Settings : Form
    {
        public static Settings Instance;
        public Settings()
        {
            InitializeComponent();
            Instance = this;
        }

        private void btn_Hide_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
               Form1.Instance.fontToolStripMenuItem.Visible = false;
               this.Close();
            }
            else
            {
                Form1.Instance.fontToolStripMenuItem.Visible = true;
                this.Close();
            }
            
            if (checkBox2.Checked)
            {
                Form1.Instance.colorToolStripMenuItem.Visible = false;
                this.Close();
            }
            else
            {
               Form1.Instance.colorToolStripMenuItem.Visible = true;
                this.Close();
            }
            
            if (checkBox3.Checked)
            {
                Form1.Instance.copyToolStripMenuItem.Visible = false;
                this.Close();
            }
            else
            {
                Form1.Instance.copyToolStripMenuItem.Visible = true;
                this.Close();
            }
           
            if (checkBox4.Checked)
            {
                Form1.Instance.pasteToolStripMenuItem.Visible = false;
                this.Close();
            }
            else
            {
                Form1.Instance.pasteToolStripMenuItem.Visible = true;
                this.Close();
            }

        }
    }
}
