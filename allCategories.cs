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
    public partial class allCategories : Form
    {

        string connectionString = "Data Source= SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";

        List<Product> cartProducts = new List<Product>(); // List to store cart products

        private int customerId;

        // Constructor to accept customer ID
        public allCategories(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
            LoadCategories();
        }

        private void LoadCategories()
        {
            // Clear existing items in the listBox1
            listBox1.Items.Clear();

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
                            listBox1.Items.Add(categoryName);
                        }
                    }
                }
            }
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selectedCategory = listBox1.SelectedItem.ToString();

                // Clear existing items in the listBox2
                listBox2.Items.Clear();

                // SQL query to select products for the selected category with their prices
                string query = "SELECT P.ProductID, P.Name, P.Price " +
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
                                // Assuming the first column is ProductID, the second is Product Name, and the third is Price
                                int productID = reader.GetInt32(0);
                                string productName = reader.GetString(1);
                                decimal productPrice = reader.GetDecimal(2);

                                // Add the product name and right-aligned price to the listBox2 with adjusted spacing
                                listBox2.Items.Add(new Product { ProductID = productID, Name = productName, Price = productPrice });
                            }
                        }
                    }
                }
            }
        }


            private void allCategories_Load(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void addToCartButton_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                Product selectedProduct = (Product)listBox2.SelectedItem;

                // Add the selected product to the cartProducts list
                cartProducts.Add(selectedProduct);

                // Update the cartListBox to show the cart contents and get the total cost
                decimal totalCost = UpdateCartListBox();
                totalCostLabel.Text = $"Total Cost: {totalCost:C}";

                // Clear the selected index in listBox2
                //listBox2.SelectedIndex = -1;
            }
        }


        private void cartListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private decimal UpdateCartListBox()
        {
            // Clear existing items in the cartListBox
            cartListBox.Items.Clear();

            decimal totalCost = 0;

            // Add the cart products to the cartListBox
            foreach (Product product in cartProducts)
            {
                cartListBox.Items.Add($"{product.Name,-30} {product.Price,10:C}");
                totalCost += product.Price;
            }

            // Display the total cost in a label (you can use a label to display additional information)
            totalCostLabel.Text = $"Total Cost: {totalCost:C}";

            return totalCost;
        }




        // Define a simple Product class to store product information
        public class Product
        {
            public int ProductID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }

            public override string ToString()
            {
                return $"{Name} - {Price:C}";
            }
        }


        private void totalCostLabel_Click(object sender, EventArgs e)
        {

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            // Check if an item is selected in the cartListBox
            if (cartListBox.SelectedIndex != -1)
            {
                // Retrieve the selected item (assumed to be a string)
                string selectedCartItem = (string)cartListBox.SelectedItem;

                // Extract the product name from the selected string
                string productName = selectedCartItem.Split(' ')[0]; // Assuming the product name is the first part of the string

                // Find and remove the corresponding product from the cartProducts list
                Product productToRemove = cartProducts.FirstOrDefault(product => product.Name == productName);

                if (productToRemove != null)
                {
                    cartProducts.Remove(productToRemove);
                }

                // Update the cartListBox and total cost
                decimal totalCost = UpdateCartListBox();
                totalCostLabel.Text = $"Total Cost: {totalCost:C}";
            }
        }



        private string GenerateReceipt()
        {
            StringBuilder receipt = new StringBuilder();

            receipt.AppendLine("Receipt");
            receipt.AppendLine("-----------");

            foreach (Product product in cartProducts)
            {
                receipt.AppendLine($"{product.Name,-30} {product.Price,10:C}");
            }

            receipt.AppendLine("-----------");
            receipt.AppendLine($"Total Cost: {cartProducts.Sum(product => product.Price):C}");
            receipt.AppendLine("-----------");

            return receipt.ToString();
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
{
    // Display the generated receipt
    string receiptContent = GenerateReceipt();
    MessageBox.Show(receiptContent, "Receipt");
}

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the ReceiptForm
            ConfirmOrderForm ConfirmOrderForm = new ConfirmOrderForm(cartProducts, cartProducts.Sum(product => product.Price));

            // Show the ReceiptForm
            ConfirmOrderForm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            CustomerMenu customerMenu = new CustomerMenu(customerId);
            customerMenu.Show();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerMenu customerMenu = new CustomerMenu(customerId);
            customerMenu.Show();
        }
    }
}
