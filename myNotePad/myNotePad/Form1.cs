using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myNotePad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.FileName = "";
            string filter = "Text Files (*.txt, )* txt|All Files (*.*)(*.*)";
            open.Filter = filter;
            open.Title = "Open";
            if (open.ShowDialog(this) == DialogResult.OK)
            {
                textBox1.Text = System.IO.File.ReadAllText(open.FileName);
            }
            else
            {
                return;
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            String filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            save.Filter = filter;
            save.Title = "Save";
            if (save.ShowDialog(this) == DialogResult)
            {
                System.IO.File.WriteAllText(save.FileName, textBox1.Text);
            }
            else
            {
                return;
            }
        }

        System.Drawing.Printing.PrintDocument prntDoc = new System.Drawing.Printing.PrintDocument();

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog print = new PrintDialog();
            prntDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(prntDoc_PrintPage);
            if (print.ShowDialog(this) == DialogResult.OK)
                prntDoc.Print();
        }

        private void prntDoc_PrintPage(Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(textBox1.Text, textBox1.Font, Brushes.Black, 0, 0);
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog preview = new PrintPreviewDialog();
            prntDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(prntDoc_PrintPage);
            preview.Document = prntDoc;
            if (preview.ShowDialog(this) == DialogResult.OK)
                prntDoc.Print();
            else
                return;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            String filter = "Text Files (*.txt)*|.txt|All Files (*.*)|*.*";
            save.Filter = filter;
            save.Title = "Save";
            if (save.ShowDialog(this) == DialogResult.OK)
            {
                System.IO.File.WriteAllText(save.FileName, textBox1.Text);
            }
            else
                return;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kUndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.ShowColor = true;
            font.ShowEffects = true;
            if(font.ShowDialog(this) == DialogResult.OK)
            {
                textBox1.ForeColor = font.Color;
                textBox1.Font = font.Font;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Int32 lines = textBox1.Lines.Length;
            Int32 textLength = textBox1.Text.Length;
            toolStripStatusLabel1.Text = "Lines: " + lines + " Characters: " + textLength;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Int32 lines = textBox1.Lines.Length;
            Int32 textLength = textBox1.Text.Length;
            toolStripStatusLabel1.Text = "Lines: " + lines + " Characters: " + textLength;
        }
    }
}
