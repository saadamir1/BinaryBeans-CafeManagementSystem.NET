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
    public partial class editCustomersData : Form
    {
        private bool registrationInProgress = false;
        private const string connectionString = "Data Source= SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";

        public editCustomersData()
        {
            InitializeComponent();
            LoadCustomerData();
        }

        private void editCustomersData_Load(object sender, EventArgs e)
        {
            register.Visible = false;
            inputcustomerID.Visible = false;
            CustomerID.Visible = false;
            deleteCustomer.Visible = false;
        }

        private void LoadCustomerData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to select all customers
                    string query = "SELECT * FROM Customers";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Assuming your input boxes are TextBox controls
                textBox1.Text = selectedRow.Cells["CustomerID"].Value.ToString();
                textBox2.Text = selectedRow.Cells["FirstName"].Value.ToString();
                textBox5.Text = selectedRow.Cells["LastName"].Value.ToString();
                textBox4.Text = selectedRow.Cells["Email"].Value.ToString();
                textBox3.Text = selectedRow.Cells["Phone"].Value.ToString();
                textBox6.Text = selectedRow.Cells["Passcode"].Value.ToString();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Update query with specified CustomerID
                    string updateQuery = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, " +
                                         "Email = @Email, Phone = @Phone, Passcode = @Passcode WHERE CustomerID = @CustomerID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Parameters to avoid SQL injection
                        command.Parameters.AddWithValue("@CustomerID", textBox1.Text);
                        command.Parameters.AddWithValue("@FirstName", textBox2.Text);
                        command.Parameters.AddWithValue("@LastName", textBox5.Text);
                        command.Parameters.AddWithValue("@Email", textBox4.Text);
                        command.Parameters.AddWithValue("@Phone", textBox3.Text);

                        // Check if Passcode is not empty before adding it to parameters
                        if (!string.IsNullOrWhiteSpace(textBox6.Text))
                        {
                            command.Parameters.AddWithValue("@Passcode", textBox6.Text);
                        }
                        else
                        {
                            // Pass NULL for Passcode if it's empty
                            command.Parameters.AddWithValue("@Passcode", DBNull.Value);
                        }

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Optionally, you can reload the customer data in the DataGridView
                            LoadCustomerData();
                        }
                        else
                        {
                            MessageBox.Show("No matching customer found for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                HandleError("An unexpected error occurred", ex);
            }
            catch (Exception ex)
            {
                HandleError("An unexpected error occurred", ex);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void addCustomer_Click(object sender, EventArgs e)
        {
            register.Visible = true;
            try
            {
                // Clear existing values
                textBox1.Clear(); // CustomerID
                textBox2.Clear(); // FirstName
                textBox5.Clear(); // LastName
                textBox4.Clear(); // Email
                textBox3.Clear(); // Phone
                textBox6.Clear(); // Passcode

                registrationInProgress = true;
                update.Enabled = false;

                // Disable CustomerID textbox and clear its value
                textBox1.Enabled = false;

                // Enable and focus on other textboxes for input
                textBox2.Enabled = true;
                textBox5.Enabled = true;
                textBox4.Enabled = true;
                textBox3.Enabled = true;
                textBox6.Enabled = true;

                // Generate new CustomerID by finding the maximum existing CustomerID and incrementing it by 1
                int newCustomerID = GetMaxCustomerID() + 1;
                textBox1.Text = newCustomerID.ToString();

                // Set focus on the FirstName textbox
                textBox2.Focus();

                register.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to get the maximum existing CustomerID
        private int GetMaxCustomerID()
        {
            int maxCustomerID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to get the maximum existing CustomerID
                    string query = "SELECT MAX(CustomerID) FROM Customers";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            maxCustomerID = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                HandleError("Error executing SQL command", ex);
            }
            catch (Exception ex)
            {
                HandleError("An unexpected error occurred", ex);
            }

            return maxCustomerID;
        }

        private void ChangeFontColor(Color color)
        {
            // Remove font color constraints
            textBox1.ForeColor = color;
            textBox2.ForeColor = color;
            textBox5.ForeColor = color;
            textBox4.ForeColor = color;
            textBox3.ForeColor = color;
            textBox6.ForeColor = color;
        }

        private void register_Click(object sender, EventArgs e)
        {
            register.Visible = false;
            update.Enabled = true;

            try
            {
                // Validate that all required fields are filled
                if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox5.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method if validation fails
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert query with specified CustomerID and allowing NULL for Passcode
                    string insertQuery = "INSERT INTO Customers (CustomerID, FirstName, LastName, Email, Phone, Passcode) " +
                                         "VALUES (@CustomerID, @FirstName, @LastName, @Email, @Phone, @Passcode)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Parameters to avoid SQL injection
                        command.Parameters.AddWithValue("@CustomerID", textBox1.Text);
                        command.Parameters.AddWithValue("@FirstName", textBox2.Text);
                        command.Parameters.AddWithValue("@LastName", textBox5.Text);
                        command.Parameters.AddWithValue("@Email", textBox4.Text);
                        command.Parameters.AddWithValue("@Phone", textBox3.Text);

                        // Check if Passcode is not empty before adding it to parameters
                        if (!string.IsNullOrWhiteSpace(textBox6.Text))
                        {
                            command.Parameters.AddWithValue("@Passcode", textBox6.Text);
                        }
                        else
                        {
                            // Pass NULL for Passcode if it's empty
                            command.Parameters.AddWithValue("@Passcode", DBNull.Value);
                        }

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // After registration, hide the "register" button
                            register.Visible = false;

                            // Optionally, you can reload the customer data in the DataGridView
                            LoadCustomerData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to register customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL constraint violations
                if (ex.Number == 547) // Foreign key violation
                {
                    MessageBox.Show("A foreign key constraint violation occurred. Make sure the referenced data exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 2627 || ex.Number == 2601) // Unique constraint violation
                {
                    MessageBox.Show("A unique constraint violation occurred. Ensure that the data being inserted is unique.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 547) // Check constraint violation
                {
                    MessageBox.Show("A check constraint violation occurred. Make sure the data meets the specified constraints.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    HandleError("Error executing SQL command", ex);
                }
            }
            catch (Exception ex)
            {
                HandleError("An unexpected error occurred", ex);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                inputcustomerID.Visible = true;
                CustomerID.Visible = true;
                deleteCustomer.Visible = true;

                // Disable update button during delete operation
                update.Enabled = false;

                // Hide the "Register" button during delete operation
                register.Visible = false;

                // Set focus on the "Customer ID" text box
                CustomerID.Focus();
            }
            catch (Exception ex)
            {
                HandleError("An unexpected error occurred", ex);
            }
        }

        private void CustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputcustomerID_Click(object sender, EventArgs e)
        {

        }

        private void deleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                deleteCustomer.Visible = false;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Delete query based on specified CustomerID
                    string deleteQuery = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        // Parameters to avoid SQL injection
                        command.Parameters.AddWithValue("@CustomerID", CustomerID.Text);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Optionally, you can reload the customer data in the DataGridView
                            LoadCustomerData();
                        }
                        else
                        {
                            MessageBox.Show("No matching customer found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                HandleError("Error executing SQL command", ex);
            }
            catch (Exception ex)
            {
                HandleError("An unexpected error occurred", ex);
            }
            finally
            {
                // Reset the UI state after delete operation
                inputcustomerID.Visible = false;
                CustomerID.Visible = false;
                update.Enabled = true;
                register.Visible = true;
            }
        }

        private void HandleError(string message, Exception ex)
        {
            // Log the error
            Console.WriteLine($"{message}: {ex.Message}");

            // Display a user-friendly error message
            MessageBox.Show($"{message}. Please contact support for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
