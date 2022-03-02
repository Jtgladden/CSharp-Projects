using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace csvReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                listBox1.Items.Clear();
                StreamReader inputFile;
                string line;
                int count = 0;
                int total;
                double average;
                char[] delim = { ',' };
                inputFile = File.OpenText("Grades.csv");

                while (!inputFile.EndOfStream)
                {
                    count++;
                    line = inputFile.ReadLine();
                    string[] tokens = line.Split(delim);

                    total = 0;

                    foreach (string str in tokens)
                    {
                        total += int.Parse(str);
                    }
                    average = (double)total / tokens.Length;

                    listBox1.Items.Add("The average for student " + count + " is " + average.ToString("n1"));

                }

                inputFile.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
