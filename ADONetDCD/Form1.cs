using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONetDCD
{
    public partial class Form1 : Form
    {
        private MarinaDBConnector marinaTable = new MarinaDBConnector("Data Source=(local);Initial Catalog=ALEXAMARA;User Id=sa;Password=abc123;Integrated Security=false;");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string myChoice = textBox3.Text;
            int numRowsAffected = marinaTable.Update(myChoice, txtMarina_Name.Text, txtMarina_Address.Text, txtMarina_City.Text, txtMarina_State.Text, txtMarina_Zip.Text);
            if (numRowsAffected == 1)
            {
                MessageBox.Show("Marina number " + txtMarina_Num + " added.");
            }
            else
            {
                MessageBox.Show("Nothing has been added.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string myChoice = textBox3.Text;
            int numRowsAffected = marinaTable.Delete(myChoice);
            if (numRowsAffected == 1)
            {
                MessageBox.Show("Marina number "+ myChoice +" deleted.");
            }
            else
            {
                MessageBox.Show("Nothing has been deleted.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string myChoice = textBox2.Text;
            int numRowsAffected = marinaTable.Update(myChoice, txtMarina_Num.Text, txtMarina_Name.Text, txtMarina_Address.Text, txtMarina_City.Text, txtMarina_State.Text, txtMarina_Zip.Text);
            if (numRowsAffected == 1)
            {
                MessageBox.Show("Marina number " + myChoice + " updated.");
            }
            else
            {
                MessageBox.Show("Nothing has been updated.");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            MarinaDBRow row = marinaTable.Select(textBox1.Text);
            txtMarina_Num.Text = row.id;
            txtMarina_Name.Text = row.name;
            txtMarina_Address.Text = row.address;
            txtMarina_City.Text = row.city;
            txtMarina_State.Text = row.state;
            txtMarina_Zip.Text = row.zip;            
        }
    }
}
