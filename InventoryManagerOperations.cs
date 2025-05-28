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
using static Project.allCategories;
using static Project.InventoryManagerOperations;

namespace Project
{
    public partial class InventoryManagerOperations : Form
    {
        string connectionString = "Data Source= SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";

        public InventoryManagerOperations()
        {
            InitializeComponent();
            LoadCategories();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = Categories.SelectedIndex;

            
        }

        private void InventoryManagerOperations_Load(object sender, EventArgs e)
        {
            Products.DisplayMember = "ToString";

        }

        private void LoadCategories()
        {
            // Clear existing items in the listBox1
            Categories.Items.Clear();

            // SQL query to select all categories
            string query = "SELECT * FROM Categories";

            // Create a SqlConnection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the database connection
                connection.Open();

                // Create a SqlCommand to execute the query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the query and get a data reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if the reader has rows
                        while (reader.Read())
                        {
                            // Assuming the second column is CategoryName
                            string categoryName = reader.GetString(1);

                            // Add the category name to the listBox1
                            Categories.Items.Add(categoryName);
                        }
                    }
                }
            }
        }
        private void buttonUpdateStock_Click(object sender, EventArgs e)
        {
            if (Products.SelectedIndex != -1)
            {
                // Get the selected product from the listBox2
                Product selectedProduct = (Product)Products.SelectedItem;

                // Retrieve the new stock count from the TextBox
                if (int.TryParse(textBoxStockCount.Text, out int newStockCount))
                {
                    // Update the stock count in the ListBox
                    selectedProduct.StockCount = newStockCount;

                    // Update the display in the ListBox
                    Products.Items[Products.SelectedIndex] = selectedProduct;

                    // Update the database with the new stock count (you need to implement this)
                    UpdateStockCountInDatabase(selectedProduct.ProductID, newStockCount);
                }
                else
                {
                    // Display an error message if the entered stock count is not a valid integer
                    MessageBox.Show("Please enter a valid stock count (integer).");
                }
            }
        }
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Categories.SelectedIndex != -1)
            {
                string selectedCategory = Categories.SelectedItem.ToString();

                // Clear existing items in the listBox2
                Products.Items.Clear();

                // SQL query to select products for the selected category with their prices
                string query = "SELECT P.ProductID, P.Name, P.Price, P.StockCount " +
               "FROM Products P " +
               "JOIN Categories C ON P.CategoryID = C.CategoryID " +
               "WHERE C.CategoryName = @CategoryName";


                // Create a SqlConnection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    connection.Open();

                    // Create a SqlCommand to execute the query
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add a parameter to the query to filter by category name
                        command.Parameters.AddWithValue("@CategoryName", selectedCategory);

                        // Execute the query and get a data reader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Check if the reader has rows
                            while (reader.Read())
                            {
                                int productID = reader.GetInt32(0);
                                string productName = reader.GetString(1);
                                decimal productPrice = reader.GetDecimal(2);
                                int stockCount = reader.GetInt32(3); // Added to retrieve StockCount

                                Products.Items.Add(new Product { ProductID = productID, Name = productName, Price = productPrice, StockCount = stockCount });
                            }
                        }
                    }
                }
            }
        }

            private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Products.SelectedIndex != -1)
            {
                // Get the selected product from the listBox2
                Product selectedProduct = (Product)Products.SelectedItem;

                // Display the product details in the TextBox
                textBoxProductName.Text = selectedProduct.Name;
                textBoxStockCount.Text = selectedProduct.StockCount.ToString();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Display a success message
            MessageBox.Show("Account Logged out!");
            this.Hide();
            loginstaff loginstaff = new loginstaff();
            loginstaff.Show();
        }

        private void stockCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateStockCountInDatabase(int productID, int newStockCount)
        {
            string query = "UPDATE Products SET StockCount = @NewStockCount WHERE ProductID = @ProductID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewStockCount", newStockCount);
                    command.Parameters.AddWithValue("@ProductID", productID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Stock count updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update stock count.");
                    }
                }
            }
        }
        // Add StockCount property to your Product class
        public class Product
        {
            public int ProductID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int StockCount { get; set; }

            // Override ToString to display the product information
            public override string ToString()
            {
                return $"{Name} - ${Price} - Stock: {StockCount}";
            }
        }

        private void buttonUpdateStock_Click_1(object sender, EventArgs e)
        {
            if (Products.SelectedIndex != -1)
            {
                // Get the selected product from the listBox2
                Product selectedProduct = (Product)Products.SelectedItem;

                // Retrieve the new stock count from the TextBox
                if (int.TryParse(textBoxStockCount.Text, out int newStockCount))
                {
                    // Update the stock count in the ListBox
                    selectedProduct.StockCount = newStockCount;

                    // Update the display in the ListBox
                    Products.Items[Products.SelectedIndex] = selectedProduct;

                    // Update the database with the new stock count (you need to implement this)
                    UpdateStockCountInDatabase(selectedProduct.ProductID, newStockCount);
                }
                else
                {
                    // Display an error message if the entered stock count is not a valid integer
                    MessageBox.Show("Please enter a valid stock count (integer).");
                }
            }
        }
    }

}
