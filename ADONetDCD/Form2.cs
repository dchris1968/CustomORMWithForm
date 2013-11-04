using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONetDCD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
                
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Marina row = new Marina();

            row.id = txtMarina_Num.Text;
            row.name = txtMarina_Name.Text;
            row.address = txtMarina_Address.Text;
            row.city = txtMarina_City.Text;
            row.state = txtMarina_State.Text;
            row.zip = txtMarina_Zip.Text;

            row.Update();
            MessageBox.Show("Marina number " + txtMarina_Num.Text + " updated.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Marina.GetMarinaById(txtDelete.Text).Delete();
            MessageBox.Show("Marina number " + txtDelete.Text + " deleted.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Marina row = new Marina();

            row.id = txtMarina_Num.Text;
            row.name = txtMarina_Name.Text;
            row.address = txtMarina_Address.Text;
            row.city = txtMarina_City.Text;
            row.state = txtMarina_State.Text;
            row.zip = txtMarina_Zip.Text;

            row.Update();

            MessageBox.Show("Marina number " + txtMarina_Num.Text + " added.");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Marina row = Marina.GetMarinaById(txtSelect.Text);

            txtMarina_Num.Text = row.id;
            txtMarina_Name.Text = row.name;
            txtMarina_Address.Text = row.address;
            txtMarina_City.Text = row.city;
            txtMarina_State.Text = row.state;
            txtMarina_Zip.Text = row.zip;
        }
    }
}
