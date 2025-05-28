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

namespace Project
{
    public partial class AllProductList : Form
    {
        public AllProductList()
        {
            InitializeComponent();
            LoadProducts();

        }

        private void AllProductList_Load(object sender, EventArgs e)
        {

        }
        private void LoadProducts()
        {
            string connectionString = "Data Source=SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ProductID, Name FROM Products";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int productID = reader.GetInt32(0);
                            string productName = reader.GetString(1);

                            // Assuming listBox1 is your ListBox control
                            listBox1.Items.Add($"{productID} - {productName}");
                        }
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
