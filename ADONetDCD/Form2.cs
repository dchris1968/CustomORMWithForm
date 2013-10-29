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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Marina m1 = new Marina();
            m1.id = txtMarina_Num.Text;
            m1.name = txtMarina_Name.Text;
            m1.address = txtMarina_Address.Text;
            m1.city = txtMarina_City.Text;
            m1.state = txtMarina_State.Text;
            m1.zip = txtMarina_Zip.Text;
        }
    }
}
