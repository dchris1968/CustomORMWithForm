﻿using System;
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
        
        MarinaDBConnector marinaTable;
        
       
           
        public Form1()
        {
            InitializeComponent();
            try
            {
                marinaTable = new MarinaDBConnector("Data Source=(local);Initial Catalog=ALEXAMARA;User Id=sa;Password=abc123;Integrated Security=false;");
            }
            catch (SqlException e)
            {
                MessageBox.Show("Database has bad connection - Closing program.  ");
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string myChoice = txtDelete.Text;
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
            string myChoice = txtDelete.Text;
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
            string myChoice = txtUpdate.Text;
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
            MarinaDBRow row = marinaTable.Select(txtSelect.Text);
            txtMarina_Num.Text = row.id;
            txtMarina_Name.Text = row.name;
            txtMarina_Address.Text = row.address;
            txtMarina_City.Text = row.city;
            txtMarina_State.Text = row.state;
            txtMarina_Zip.Text = row.zip;            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();

            //Diplays non-modal form
            form.Show();
        }
    }
}
