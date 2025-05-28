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
using Project;

namespace Project
{
    public partial class CustomerMenu : Form
    {
        private int customerId;
        private string customerName;

        // Constructor to accept customer ID
        public CustomerMenu(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
            LoadCustomerInfo(customerId);
            DisplayWelcomeMessage();
        }

        private void LoadCustomerInfo(int customerId)
        {
            string connectionString = "Data Source=SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT FirstName FROM Customers WHERE CustomerID = @CustomerId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customerName = reader["FirstName"].ToString();
                        }
                    }
                }
            }
        }

        private void DisplayWelcomeMessage()
        {
            if (!string.IsNullOrEmpty(customerName))
            {
                welcome.Text = $"Welcome, {customerName}!";
            }
        }

        private void CustomerMenu_Load(object sender, EventArgs e)
        {

        }




        private bool TableExists(DataTable schema, string tableName)
        {
            foreach (DataRow row in schema.Rows)
            {
                string table = (string)row["TABLE_NAME"];
                Console.WriteLine($"Found table: {table}");

                if (string.Equals(table, tableName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Table {tableName} exists!");
                    return true;
                }
            }

            Console.WriteLine($"Table {tableName} does not exist!");
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            allCategories allcategories = new allCategories(customerId);
            allcategories.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM Products", connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<string> products = new List<string>();

                while (reader.Read())
                {
                    int productID = reader.GetInt32(0);
                    string productName = reader.GetString(1);
                    int categoryID = reader.GetInt32(2);
                    decimal price = reader.GetDecimal(3);
                    int stockCount = reader.GetInt32(4);
                    ice
                    products.Add($"ID: {productID},     Name: {productName},      Category ID: {categoryID},        Price: {price}");
                }

                MessageBox.Show(string.Join("\n", products), "Products");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void customerInfo_Click(object sender, EventArgs e)
        {
            customerInfo.Text = $"1 - John Doe";

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            customerRegister CustomerRegister = new customerRegister(FormMode.EditProfile, customerId);
            CustomerRegister.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Display a success message
            MessageBox.Show("Account Logged out!");

            // Close the current form (editCustomerInfo)
            this.Close();

            // Optionally, open the menu form
            CutomerLogin CutomerLogin = new CutomerLogin();
            CutomerLogin.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DisplayPreviousOrders(customerId);

        }

        private void DisplayPreviousOrders(int customerId)
        {
            string connectionString = "Data Source=SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM Orders WHERE CustomerID = @CustomerId", connection);
            command.Parameters.AddWithValue("@CustomerId", customerId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<string> orders = new List<string>();

                while (reader.Read())
                {
                    int orderId = reader.GetInt32(0);
                    DateTime orderDate = reader.GetDateTime(2);
                    decimal totalAmount = reader.GetDecimal(3);

                    orders.Add($"Order ID: {orderId}, Date: {orderDate}, Total Amount: {totalAmount:C}");
                }

                MessageBox.Show(string.Join("\n", orders), "Previous Orders");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void welcome_Click(object sender, EventArgs e)
        {

        }
    }
}
   
