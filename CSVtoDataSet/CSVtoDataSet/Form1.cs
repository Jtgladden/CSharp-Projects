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

namespace CSVtoDataSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadData_button_Click(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            string delimiter = ",";
            string tablename = "Books Table";
            string filename = "books.csv";

            DataSet dataset = new DataSet();
            StreamReader sr = new StreamReader(filename);

            dataset.Tables.Add(tablename);
            dataset.Tables[tablename].Columns.Add("book Title");
            dataset.Tables[tablename].Columns.Add("book Price");

            string allData = sr.ReadToEnd();
            string[] rows = allData.Split("\r".ToCharArray());

            foreach (string r in rows)
            {
                string[] items = r.Split(delimiter.ToCharArray());
                dataset.Tables[tablename].Rows.Add(items);
            }

            this.dataGridView1.DataSource = dataset.Tables[0].DefaultView;
        }
    }
}
