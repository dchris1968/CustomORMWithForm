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
            try
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
            catch (Exception exception)
            {
                MessageBox.Show("Please enter a valid ID number.", "Update Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Marina.GetMarinaById(txtDelete.Text).Delete();
            MessageBox.Show("Marina number " + txtDelete.Text + " deleted.");            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception exception)
            {
                MessageBox.Show("Please enter a valid ID number.  Range of numbers is from 1 to 9999 only.", "New Record Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                Marina row = Marina.GetMarinaById(txtSelect.Text);

                if (row.id != null)
                {
                    txtMarina_Num.Text = row.id;
                    txtMarina_Name.Text = row.name;
                    txtMarina_Address.Text = row.address;
                    txtMarina_City.Text = row.city;
                    txtMarina_State.Text = row.state;
                    txtMarina_Zip.Text = row.zip;
                }
                else
                {
                    MessageBox.Show("Marina number does not exist.", "Marina Number Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Please enter a valid ID number", "Select Record Error", MessageBoxButtons.OK);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            List<Marina> marinas = Marina.GetAllMarinas();

            foreach (Marina row in marinas)
            {
                MessageBox.Show(row.id + " " + row.name + " " + row.address + " " + row.city + " " + row.state + " " + row.zip,"GetAllMarinas Listings");
                
            }

        }
    }
}
