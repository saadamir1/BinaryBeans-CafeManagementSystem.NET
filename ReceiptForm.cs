using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Project.allCategories;

namespace Project
{
    public partial class ReceiptForm : Form
    {
        private List<Product> cartProducts;
        private decimal totalCost;
        private List<allCategories.Product> cartProducts1;
        private decimal v;

        public ReceiptForm(List<Product> cartProducts, decimal totalCost)
        {
            InitializeComponent();
            this.cartProducts = cartProducts;
            this.totalCost = totalCost;

            GenerateReceipt();
        }

       /* public ReceiptForm(List<allCategories.Product> cartProducts1, decimal v)
        {
            this.cartProducts1 = cartProducts1;
            this.v = v;
        }*/

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

/*            // Now, add the "Place Order" button to the form
            Button placeOrderButton = new Button();
            placeOrderButton.Text = "Place Order";
            placeOrderButton.Click += PlaceOrderButton_Click;

            // Set the location of the button (you can adjust this as needed)
            placeOrderButton.Location = new Point(10, 10);

            // Add the button to the form
            Controls.Add(placeOrderButton);*/
        }

        private void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            // Handle the click event for the "Place Order" button
            // You can add code here to place the order in the database or perform any other actions.
            InsertOrderIntoDatabase();

            // Optionally, close the form or perform additional actions after placing the order.
            MessageBox.Show("Order placed successfully!");
            Close();
        }


        private void InsertOrderIntoDatabase()
        {
            string connectionString = "Data Source=SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Insert into Orders table
                string insertOrderQuery = "INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) VALUES (@CustomerID, @OrderDate, @TotalAmount)";
                using (SqlCommand command = new SqlCommand(insertOrderQuery, connection))
                {
                    // Replace with actual CustomerID (you need to retrieve it based on the logged-in user or customer selection)
                    int customerId = 1; // Replace with actual CustomerID
                    command.Parameters.AddWithValue("@CustomerID", customerId);
                    command.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    command.Parameters.AddWithValue("@TotalAmount", totalCost);
                    command.ExecuteNonQuery();
                }

                // Insert into OrderItems table
                foreach (Product product in cartProducts)
                {
                    string insertOrderItemQuery = "INSERT INTO OrderItems (OrderID, ProductID, Quantity, Subtotal) VALUES (@OrderID, @ProductID, @Quantity, @Subtotal)";
                    using (SqlCommand orderItemCommand = new SqlCommand(insertOrderItemQuery, connection))
                    {
                        // Retrieve the OrderID of the order you just inserted
                        string getLastOrderIdQuery = "SELECT TOP 1 OrderID FROM Orders ORDER BY OrderID DESC";
                        using (SqlCommand getLastOrderIdCommand = new SqlCommand(getLastOrderIdQuery, connection))
                        {
                            int orderId = (int)getLastOrderIdCommand.ExecuteScalar();

                            // Insert the order item
                            orderItemCommand.Parameters.AddWithValue("@OrderID", orderId);
                            orderItemCommand.Parameters.AddWithValue("@ProductID", product.ProductID);
                            orderItemCommand.Parameters.AddWithValue("@Quantity", 1); // You may need to adjust this based on your logic
                            orderItemCommand.Parameters.AddWithValue("@Subtotal", product.Price);
                            orderItemCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void receiptTextBox_TextChanged(object sender, EventArgs e)
        {
            // If you want to perform any action when the receipt text changes
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
