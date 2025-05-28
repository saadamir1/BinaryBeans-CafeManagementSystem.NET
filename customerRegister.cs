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
    public enum FormMode   // we are using this register form for 2 purposes: to register customer ofcourse, and to edit profile
    {
        Register,
        EditProfile
    }
    public partial class customerRegister : Form
    {
        //private int newCustomerId;
        private string originalFirstName;
        private string originalLastName;
        private string originalEmail;
        private string originalPhone;
        private string originalPasscode;
        private int customerId;
        private FormMode mode;  // Add a variable to store the mode

        public customerRegister(FormMode formMode, int customerId)
        {
            InitializeComponent();
            mode = formMode;

            this.customerId = customerId;  // Store the customer ID
            LoadCustomerData(customerId);

            if (mode == FormMode.Register)
            {
                button1.Text = "Register";  // Change button text for registration mode
            }
            else if (mode == FormMode.EditProfile)
            {
                button1.Text = "Update";  // Change button text for edit profile mode
                label1.Text = "Customer Information";
            }
        }
        private void LoadCustomerData(int YourCustomerID)
        {
            // Assuming you have a customer ID, replace "YourCustomerID" with the actual customer ID
            int customerId = YourCustomerID;

            string connectionString = "Data Source= SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT FirstName, LastName, Email, Phone, Passcode FROM Customers WHERE CustomerID = @CustomerId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Store the original values
                            originalFirstName = reader["FirstName"].ToString();
                            originalLastName = reader["LastName"].ToString();
                            originalEmail = reader["Email"].ToString();
                            originalPhone = reader["Phone"].ToString();
                            originalPasscode = reader["Passcode"].ToString();

                            // Display the original values in the textboxes
                            fname.Text = originalFirstName;
                            lname.Text = originalLastName;
                            email.Text = originalEmail;
                            phnum.Text = originalPhone;
                            passcode.Text = originalPasscode;
                        }
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void customerRegister_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void fname_TextChanged(object sender, EventArgs e)
        {

        }

        private void lname_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void phnum_TextChanged(object sender, EventArgs e)
        {

        }

        private void passcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Declare variables outside the if blocks
                string firstName = fname.Text;
                string lastName = lname.Text;
                string customerEmail = email.Text;
                string Phone = phnum.Text;
                string password = passcode.Text;

                // Establish a database connection
                string connectionString = "Data Source=SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (mode == FormMode.Register)
                    {
                        // Registration logic
                        int newCustomerId;

                        // Retrieve the current maximum customer ID
                        int maxCustomerId = GetMaxCustomerId(connection);

                        // Increment the max customer ID by 1 to assign a new ID
                        newCustomerId = maxCustomerId + 1;

                        // Execute an INSERT SQL query to add the new customer to the database
                        string query = "INSERT INTO Customers (CustomerID, FirstName, LastName, Email, Phone, Passcode) " +
                                       "VALUES (@CustomerID, @FirstName, @LastName, @Email, @Phone, @Passcode)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CustomerID", newCustomerId);
                            command.Parameters.AddWithValue("@FirstName", firstName);
                            command.Parameters.AddWithValue("@LastName", lastName);
                            command.Parameters.AddWithValue("@Email", customerEmail);
                            command.Parameters.AddWithValue("@Phone", Phone);
                            command.Parameters.AddWithValue("@Passcode", password);

                            command.ExecuteNonQuery();

                            MessageBox.Show("Registration successful!");

                            this.Close();
                            CustomerMenu customerMenu = new CustomerMenu(newCustomerId);
                            customerMenu.Show();
                        }
                    }
                    else if (mode == FormMode.EditProfile)
                    {
                        // Retrieve the modified values from the textboxes
                        string updatedFirstName = fname.Text;
                        string updatedLastName = lname.Text;
                        string updatedEmail = email.Text;
                        string updatedPhone = phnum.Text;
                        string updatedPasscode = passcode.Text;

                        // Update the customer information in the database
                        UpdateCustomerData(customerId, updatedFirstName, updatedLastName, updatedEmail, updatedPhone, updatedPasscode);

                        // Display a success message
                        MessageBox.Show("Customer information updated successfully!", "Success");

                        // Revert label and button text
                        label1.Text = "Register";
                        button1.Text = "Customer Information";

                        // Close the current form
                        this.Close();

                        CustomerMenu customerMenu = new CustomerMenu(customerId);
                        customerMenu.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetMaxCustomerId(SqlConnection connection)
        {
            // Execute a SQL query to retrieve the maximum customer ID
            string maxIdQuery = "SELECT ISNULL(MAX(CustomerID), 0) FROM Customers";

            using (SqlCommand command = new SqlCommand(maxIdQuery, connection))
            {
                return (int)command.ExecuteScalar();
            }
        }
        private void UpdateCustomerData(int customerId, string firstName, string lastName, string email, string phone, string passcode)
        {
            string connectionString = "Data Source= SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Passcode = @Passcode WHERE CustomerID = @CustomerId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Passcode", passcode);

                    command.ExecuteNonQuery();
                }
            }
        }
        private void back_Click(object sender, EventArgs e)  // back to login page
        {
            this.Close();
            CustomerMenu customerMenu = new CustomerMenu(customerId);
            customerMenu.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
