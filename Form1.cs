using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mansoura_G1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlDataAdapter1.Fill(dataSet11);
            sqlConnection1.Close();
            dataGridView1.DataSource = dataSet11.Tables[0];
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DataRow dRow = dataSet11.Tables[0].NewRow();
            dRow["Id"] = int.Parse(textBox1.Text);
            dRow[1] = textBox2.Text;
            dataSet11.Tables[0].Rows.Add(dRow);
            textBox1.Text = textBox2.Text = "";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int UpdateID = int.Parse(textBox1.Text);
            DataRow dRow = dataSet11.Tables[0].Rows.Find(UpdateID);
            if(dRow != null)
            {
                dRow[1] = textBox2.Text;
                textBox1.Text = textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Record Not Found");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlDataAdapter1.Update(dataSet11);
            sqlConnection1.Close();
        }
    }
}
