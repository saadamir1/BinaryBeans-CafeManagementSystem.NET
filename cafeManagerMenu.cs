using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class cafeManagerMenu : Form
    {
        public cafeManagerMenu()
        {
            InitializeComponent();
        }

        private void cafeManagerMenu_Load(object sender, EventArgs e)
        {

        }

        private void editCustomers_Click(object sender, EventArgs e)
        {
            editCustomersData editCustomersData = new editCustomersData();
            editCustomersData.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Account Logged out!");
            this.Close();
            CutomerLogin CutomerLogin = new CutomerLogin();
            CutomerLogin.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginstaff loginstaff = new loginstaff();
            loginstaff.Show();
        }
    }
}
