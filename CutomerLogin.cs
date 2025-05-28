using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;


namespace Project
{
    public partial class CutomerLogin : Form
    {
        private int customerId;

        private bool ValidateCustomer(string email, string passcode)
        {
            string connectionString = "Data Source=SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Customers WHERE Email = @Email AND Passcode = @Passcode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Passcode", passcode);

                    int count = (int)command.ExecuteScalar();

                    return count > 0; // If count is greater than 0, the customer is valid
                }
            }


        }

        public CutomerLogin()
        {
            InitializeComponent();
            textBoxPasscode.PasswordChar = '*';
            textBoxPasscode.Text = "****";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text.Trim();
            string passcode = textBoxPasscode.Text.Trim();

            if (true/*ValidateCustomer(email, passcode)*/)
            {
                MessageBox.Show("Login successful!");

                // Retrieve the customer ID here (replace this with your logic)
                customerId = GetCustomerId(email);

                this.Hide();
                CustomerMenu customerMenu = new CustomerMenu(customerId);
                customerMenu.Show();

            }
            else
            {
                MessageBox.Show("Invalid email or passcode. Please try again.");
            }
        }

        // Replace this with your logic to get the customer ID from the database
        private int GetCustomerId(string email)
        {
            // Example: retrieve the customer ID from the database based on email
            // Replace this with your actual logic
            string connectionString = "Data Source=SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT CustomerID FROM Customers WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    // ExecuteScalar is used assuming the query returns a single value
                    object result = command.ExecuteScalar();

                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Hide();

            // Open a new form
            customerRegister CustomerRegister = new customerRegister(FormMode.Register, customerId);
            CustomerRegister.Show();

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void CutomerLogin_Load(object sender, EventArgs e)
        {

        }

        private void textBoxPasscode_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            CutomerLogin CutomerLogin = new CutomerLogin();
            CutomerLogin.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loginstaff loginstaffForm = new loginstaff();
            loginstaffForm.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
