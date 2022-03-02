using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joe_sAutomotive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double OilLubeCharges()
        {
            double ret = 0.0;
            if (checkBox1.Checked == true)
                ret += 26;
            if (checkBox2.Checked == true)
                ret += 18;
            return ret;
        }
        private double FlushCharges()
        {
            double ret = 0.0;
            if (checkBox6.Checked == true)
                ret += 60;
            if (checkBox7.Checked == true)
                ret += 80;
            return ret;
        }

        private double MiscCharges()
        {
            double ret = 0.0;
            if (checkBox3.Checked == true)
                ret += 15;
            if (checkBox4.Checked == true)
                ret += 100;
            if (checkBox5.Checked == true)
                ret += 20;
            return ret;
        }
        private double toDouble(TextBox s)
        {
            if (s.Text.Length == 0)
                return 0;
            else
                return double.Parse(s.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            double val = toDouble(textBox2);
            double temp3, temp4, temp5;
            temp3 = (OilLubeCharges() + FlushCharges() + MiscCharges() + val);
            temp4 = toDouble(textBox1);
            temp5 = (toDouble(textBox1) * .06);
            textBox3.Text = temp3.ToString("C3");
            textBox4.Text = temp4.ToString("C3");
            textBox5.Text = temp5.ToString("C3");
            textBox6.Text = (temp3 + temp4 + temp5).ToString("C3");
        }

        private void clearOilLube()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }
        private void clearMisc()
        {
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
        }

        private void clearFlushes()
        {
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        private void clearOther()
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void clearFees()
        {
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearOilLube();
            clearMisc();
            clearFlushes();
            clearOther();
            clearFees();
        }
    }
}
