using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Statement_Streamline
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class MyListBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }

        /*
        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            double value;
            if (double.TryParse(textBox1.Text, out value))
                textBox1.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            else
                textBox1.Text = String.Empty;
        }
        */

        private double toDouble(string s)
        {
            var currency = s.Substring(s.LastIndexOf('-') + 1);
            if (currency.Length == 0)
                return 0;
            else
                return double.Parse(currency);
        }
        private double total()
        {
            double total = 0;
            for (int i = 0; i < checkedListBox1.Items.Count; i ++)
            {
                total += toDouble((checkedListBox1.Items[i] as MyListBoxItem).Value);
            }
            return total;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Title = comboBox1.Text + "-" + comboBox2.Text + "-" + comboBox3.Text + " = " + textBox1.Text;
            string Data = comboBox3.Text + "-" + comboBox1.Text.Substring(comboBox1.Text.LastIndexOf('-') + 1) + "-" + comboBox2.Text + "-" + textBox1.Text;
            checkedListBox1.DisplayMember = "Text";
            checkedListBox1.ValueMember = "Value";
            checkedListBox1.Items.Insert(0, new MyListBoxItem { Text = Title, Value = Data });
        }

        

        private void Form1_Load(object sender, EventArgs e)
            {
                AllocConsole();
            }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = total().ToString("C3");
        }

        class purchase
        {
            public string code;
            public double cost;

        }

        class report
        {
            public string code;
            public double totalCost;
            public report(string c, double cost)
            {
                code = c;
                totalCost = cost;
            }
        }

        private string returnCode(string str)
        {
            string sep = "-";
            int sepPos = str.LastIndexOf(sep);
            return str.Substring(0, sepPos);
        }

        private void compileReport()
        {
            List<purchase> purchases = new List<purchase>();
            List<report> reports = new List<report>();

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                purchase item = new purchase();
                item.code = returnCode((checkedListBox1.Items[i] as MyListBoxItem).Value);
                item.cost = toDouble((checkedListBox1.Items[i] as MyListBoxItem).Value);
                purchases.Insert(i, item);
                item = null;
            }

            
            bool added = false;
            foreach (purchase p in purchases)
            {
                foreach (report r in reports)
                {
                    if (p.code == r.code)
                    {
                        r.totalCost += p.cost;
                        added = true;
                    }
                }
                if (added != true)
                {
                    reports.Add(new report(p.code, p.cost));
                }
                added = false;
            }

            foreach (report r in reports)
            {
                Console.WriteLine(r.code + "=" + r.totalCost.ToString("C3"));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.Clear();
            compileReport();
        }
    }
}
