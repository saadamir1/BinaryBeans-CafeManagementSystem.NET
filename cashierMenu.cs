using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project
{
    public partial class cashierMenu : Form
    {
        string connectionString = "Data Source= SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";
        private decimal originalTotalAmount = 0;
        private int selectedOrderID = 0;
        public cashierMenu()
        {
            InitializeComponent();
            LoadOrders();
            applyDiscount.Click += applyDiscount_Click;
            total.ReadOnly = true;
            newTotal.ReadOnly = true;
            // Set up columns for orderItemsDataGridView
            orderItemList.ColumnCount = 4; // Adjust the number of columns as needed

            // Add column headers
            orderItemList.Columns[0].Name = "OrderItemID";
            orderItemList.Columns[1].Name = "ProductName";
            orderItemList.Columns[2].Name = "Quantity";
            orderItemList.Columns[3].Name = "Subtotal";

            foreach (DataGridViewColumn column in orderItemList.Columns)
            {
                if (column.HeaderCell != null && column.HeaderCell.Style != null && column.HeaderCell.Style.Font != null)
                {
                    column.HeaderCell.Style.Font = new Font(column.HeaderCell.Style.Font, FontStyle.Bold);
                }
            }

            // Reduce font size of data entries
            orderItemList.DefaultCellStyle.Font = new Font("Arial", 8); // Adjust the font and size as needed
        }
        private void LoadOrders()
        {
            orderList.Items.Clear();

            string query = "SELECT O.OrderID, C.FirstName + ' ' + C.LastName AS CustomerName, O.OrderDate, O.TotalAmount " +
                           "FROM Orders O " +
                           "JOIN Customers C ON O.CustomerID = C.CustomerID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int orderID = reader.GetInt32(0);
                            string customerName = reader.GetString(1);
                            DateTime orderDate = reader.GetDateTime(2);
                            decimal total = reader.GetDecimal(3);

                            orderList.Items.Add($"{orderID} - {customerName} - {orderDate.ToShortDateString()} - Total: {total:C}");
                        }
                    }
                }
            }
        }

        private void orderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (orderList.SelectedIndex != -1)
            {
                // Extract the selected order details from the ListBox item
                string selectedOrderString = orderList.SelectedItem.ToString();
                int selectedIndex = selectedOrderString.IndexOf('-');
                selectedOrderID = int.Parse(selectedOrderString.Substring(0, selectedIndex).Trim());

                // Update the relevant textboxes with order details
                UpdateTextBoxes(selectedOrderID);
                // Populate order items for the selected order
                LoadOrderItems(selectedOrderID);
            }
        }



        private void UpdateTextBoxes(int selectedOrderID)
        {
            string query = "SELECT O.OrderID, O.TotalAmount " +
                           "FROM Orders O " +
                           "WHERE O.OrderID = @OrderID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", selectedOrderID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int orderID = reader.GetInt32(0);
                            decimal totalAmount = reader.GetDecimal(1);

                            // Update the originalTotalAmount variable
                            originalTotalAmount = totalAmount;

                            total.Text = totalAmount.ToString("C");
                            labelOrderDetails.Text = $"Order# {orderID} Total Amount:";
                        }
                    }
                }
            }
        }


        private void orderItemsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the event when an item in orderItemsList is selected
            // You can update text boxes like textBoxNetTotal and textBoxProductName here
            // Use the selected order item details to update the text boxes
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginstaff loginstaff = new loginstaff();
            loginstaff.Show();

        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Display a success message
            MessageBox.Show("Account Logged out!");
            this.Hide();
            loginstaff loginstaff = new loginstaff();
            loginstaff.Show();
            //Application.Exit();
        }

        private void total_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void applyDiscount_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(discount.Text, out decimal discountPercentage))
            {
                decimal discountAmount = originalTotalAmount * (discountPercentage / 100);
                decimal newTotalAmount = originalTotalAmount - discountAmount;

                newTotal.Text = newTotalAmount.ToString("C");
                UpdateDatabaseWithNewTotal(newTotalAmount);

                MessageBox.Show($"Discount of {discountPercentage}% applied. New total amount: {newTotalAmount:C}");
            }
            else
            {
                MessageBox.Show("Invalid discount percentage. Please enter a valid numeric value.");
            }
        }


        private void discount_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateDatabaseWithNewTotal(decimal newTotalAmount)
        {
            string query = "UPDATE Orders SET TotalAmount = @NewTotalAmount WHERE OrderID = @OrderID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewTotalAmount", newTotalAmount);
                    command.Parameters.AddWithValue("@OrderID", selectedOrderID);

                    command.ExecuteNonQuery();
                }
            }
            LoadOrders(); // show realtime change
        }

        private void newTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelOrderDetails_Click(object sender, EventArgs e)
        {

        }
        private void LoadOrderItems(int selectedOrderID)
        {
            // Clear existing rows in the DataGridView
            orderItemList.Rows.Clear();

            string query = "SELECT OI.OrderItemID, P.Name, OI.Quantity, OI.Subtotal " +
                           "FROM OrderItems OI " +
                           "JOIN Products P ON OI.ProductID = P.ProductID " +
                           "WHERE OI.OrderID = @OrderID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderID", selectedOrderID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int orderItemID = reader.GetInt32(0);
                            string productName = reader.GetString(1);
                            int quantity = reader.GetInt32(2);
                            decimal subtotal = reader.GetDecimal(3);

                            // Add a new row to the DataGridView
                            orderItemList.Rows.Add(orderItemID, productName, quantity, subtotal);
                        }
                    }
                }
            }
        }

        private void orderItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
