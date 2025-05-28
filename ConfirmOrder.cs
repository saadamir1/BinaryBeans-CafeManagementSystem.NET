using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Project.allCategories;

namespace Project
{
    public partial class ConfirmOrderForm : Form
    {
        private bool feedbackControlsVisible = false;
        private int newOrderID;
        private SqlConnection connection;
        private string connectionString = "Data Source=SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";

        public ConfirmOrderForm()
        {
            InitializeComponent();
            connection = new SqlConnection("Data Source= SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True");

        }

        private List<Product> cartProducts;
        private decimal totalCost;

        public ConfirmOrderForm(List<Product> cartProducts, decimal totalCost)
        {
            InitializeComponent();

            // Initialize the cartProducts and totalCost fields
            this.cartProducts = cartProducts;
            this.totalCost = totalCost;
            SetFeedbackControlsVisibility(false);
            // Hide the rating and review controls initially
            ratingBox.Visible = false;
            label3.Visible = false;
            ratingBox.Visible = false;
            Review.Visible = false;
            button1.Visible = true;
            totalCostLabel.Visible = true;
            button3.Visible = false;


            // Display the final receipt
            DisplayReceipt();
        }

        private void DisplayReceipt()
        {
            // Clear existing items in the receiptListBox
            receiptListBox.Items.Clear();

            // Create a dictionary to store product quantities
            Dictionary<int, int> productQuantities = new Dictionary<int, int>();

            // Populate the dictionary with product quantities
            foreach (Product product in cartProducts)
            {
                if (productQuantities.ContainsKey(product.ProductID))
                {
                    productQuantities[product.ProductID]++;
                }
                else
                {
                    productQuantities.Add(product.ProductID, 1);
                }
            }

            // Add a fixed heading to the receiptListBox
            receiptListBox.Items.Add($"{"Product Name",-25}{"Quantity",-10}{"Price",-15}");

            // Add the products to the receiptListBox with quantities and prices
            foreach (var kvp in productQuantities)
            {
                Product product = cartProducts.Find(p => p.ProductID == kvp.Key);
                int quantity = kvp.Value;
                decimal subtotal = product.Price * quantity;

                // Format the output with fixed-width columns for a professional look
                string productName = $"{product.Name,-25}";
                string productLine = $"{productName}{quantity,-10}{subtotal:C}";
                receiptListBox.Items.Add(productLine);
            }

            // Display the total cost in a label
            totalCostLabel.Text = $"Total Cost: {totalCost:C}";
            customerInfo.Text = $"Customer ID: 1\nCustomer Name: John Doe";
        }


        private void SetFeedbackControlsVisibility(bool isVisible)
        {
            // Set the visibility of feedback-related controls
            button2.Visible = isVisible;
            ratingBox.Visible = isVisible;
            reviewBox.Visible = isVisible;
            totalCostLabel.Visible = false;
            button1.Visible = false;
            label3.Visible = true;
            ratingBox.Visible = true;
            Review.Visible = true;
            button3.Visible = true;
        }

        private void ConfirmOrderForm_Load(object sender, EventArgs e)
        {
            // You can add any necessary initialization code here
        }

        private void receiptListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // You can add any logic for when the receiptListBox selection changes
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            // You can add any logic for when the text in textBoxEmail changes
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // You can add any logic for when label4 is clicked
        }

        private void reviewBox_TextChanged(object sender, EventArgs e)
        {
            // You can add any logic for when the text in reviewBox changes
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // You can add any logic for when button2 is clicked
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = "Data Source= SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";

            int newOrderID;


            // For example:
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string getMaxOrderIDQuery = "SELECT MAX(OrderID) FROM Orders;";
                int maxOrderID;
                using (SqlCommand command = new SqlCommand(getMaxOrderIDQuery, connection))
                {
                    object result = command.ExecuteScalar();
                    maxOrderID = result == DBNull.Value ? 0 : Convert.ToInt32(result);
                }

                // Increment to assign a new OrderID
                newOrderID = maxOrderID + 1;

                // Get the current maximum OrderItemID from the OrderItems table
                string getMaxOrderItemIDQuery = "SELECT MAX(OrderItemID) FROM OrderItems;";
                int maxOrderItemID;
                using (SqlCommand command = new SqlCommand(getMaxOrderItemIDQuery, connection))
                {
                    object result = command.ExecuteScalar();
                    maxOrderItemID = result == DBNull.Value ? 0 : Convert.ToInt32(result);
                }

                // Increment to assign a new OrderItemID
                int newOrderItemID = maxOrderItemID + 1;

                // Insert into Orders table
                string insertOrderQuery = "INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount) VALUES (@OrderID, @CustomerID, GETDATE(), @TotalAmount);";
                using (SqlCommand command = new SqlCommand(insertOrderQuery, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", newOrderID);
                    command.Parameters.AddWithValue("@CustomerID", 1); // Replace with the actual customer ID
                    command.Parameters.AddWithValue("@TotalAmount", totalCost);

                    command.ExecuteNonQuery();
                }

                // Insert into OrderItems table
                foreach (Product product in cartProducts)
                {
                    string insertOrderItemQuery = "INSERT INTO OrderItems (OrderItemID, OrderID, ProductID, Quantity, Subtotal) VALUES (@OrderItemID, @OrderID, @ProductID, 1, @Subtotal);";
                    using (SqlCommand command = new SqlCommand(insertOrderItemQuery, connection))
                    {
                        command.Parameters.AddWithValue("@OrderItemID", newOrderItemID);
                        command.Parameters.AddWithValue("@OrderID", newOrderID);
                        command.Parameters.AddWithValue("@ProductID", product.ProductID);
                        command.Parameters.AddWithValue("@Subtotal", product.Price);

                        command.ExecuteNonQuery();
                    }

                    // Increment OrderItemID for the next iteration
                    newOrderItemID++;
                }
            }

            string receiptContent = GenerateReceipt(newOrderID);
            MessageBox.Show(receiptContent, "Receipt");

            // Optionally, you can display a success message or close the form
            MessageBox.Show("Order placed successfully!");
            //this.Close();
            feedbackControlsVisible = true;
            SetFeedbackControlsVisibility(feedbackControlsVisible);
        }

 
        private string GenerateReceipt(int orderNumber)
        {
            StringBuilder receipt = new StringBuilder();

            receipt.AppendLine("╔══════════════════════════════════════════════╗");
            receipt.AppendLine($"║                      Cafe Bytes Receipt                         ║");
            receipt.AppendLine("╚══════════════════════════════════════════════╝");

            receipt.AppendLine($"\nOrder #{orderNumber,5}");

            // Rest of the receipt content
            receipt.AppendLine("------------------------------");

            foreach (Product product in cartProducts)
            {
                // Use a fixed-width font for better alignment
                string productName = $"{product.Name,-25}";  
                string price = $"{product.Price:C}";

                // Align the text properly
                receipt.AppendLine($"{productName} {price,10}");
            }

            receipt.AppendLine("------------------------------");
            receipt.AppendLine($"Total Cost: {cartProducts.Sum(product => product.Price):C}");
            receipt.AppendLine("------------------------------");

            // Add a professional thanksgiving statement and mention the order time
            receipt.AppendLine($"Thank you for choosing Cafe Bytes!");
            receipt.AppendLine($"Your order (#{orderNumber}) was placed on {DateTime.Now.ToString("MMMM dd, yyyy HH:mm:ss")}");
            receipt.AppendLine("We appreciate your business. Have a great day!");

            return receipt.ToString();
        }




        private void totalCostLabel_Click(object sender, EventArgs e)
        {
            // You can add any logic for when totalCostLabel is clicked
        }

        private void customerInfo_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get the current maximum FeedbackID from the Feedback table
                    string getMaxFeedbackIDQuery = "SELECT MAX(FeedbackID) FROM Feedback;";

                    using (SqlCommand maxFeedbackIDCommand = new SqlCommand(getMaxFeedbackIDQuery, connection))
                    {
                        int maxFeedbackID;
                        object result = maxFeedbackIDCommand.ExecuteScalar();
                        maxFeedbackID = result == DBNull.Value ? 0 : Convert.ToInt32(result);

                        // Increment to assign a new FeedbackID
                        int newFeedbackID = maxFeedbackID + 1;

                        // Display relevant information in a message box
                        string message = $"Feedback ID: {newFeedbackID}\nOrder ID: {newOrderID}\nCustomer ID: 1\nRating: {ratingBox.Text}\nComment: {reviewBox.Text}\nFeedback Date: {DateTime.Now}";
                        MessageBox.Show(message, "Feedback Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Insert into the database
                        string insertFeedbackQuery = "INSERT INTO dbo.Feedback (FeedbackID, OrderID, CustomerID, Rating, Comment, FeedbackDate) VALUES (@FeedbackID, @OrderID, @CustomerID, @Rating, @Comment, @FeedbackDate);";
                        using (SqlCommand command = new SqlCommand(insertFeedbackQuery, connection))
                        {
                            command.Parameters.AddWithValue("@FeedbackID", newFeedbackID);
                            command.Parameters.AddWithValue("@OrderID", newOrderID);
                            command.Parameters.AddWithValue("@CustomerID", 1); // Replace with the actual customer ID
                            command.Parameters.AddWithValue("@Rating", Convert.ToInt32(ratingBox.Text)); // Use appropriate conversion
                            command.Parameters.AddWithValue("@Comment", reviewBox.Text);
                            command.Parameters.AddWithValue("@FeedbackDate", DateTime.Now);

                            command.ExecuteNonQuery();
                        }
                    }
                }

                // Optionally, you can display a success message or perform other actions after feedback submission
                MessageBox.Show("Feedback submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
