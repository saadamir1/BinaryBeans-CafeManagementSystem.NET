using Microsoft.SqlServer.Server;
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
    public partial class loginstaff : Form
    {
        private string connectionString = "Data Source=SAAD-DESKTOP\\SQLEXPRESS;Integrated Security=True";
        private string userType;
        public loginstaff()
        {
            InitializeComponent();
            textBoxPasscode.PasswordChar = '*';
            textBoxPasscode.Text = "****";
            login.Enabled = false;
            login.BackColor = SystemColors.Control;

            // Set the Tag for each user type button
            cafeManagerLogin.Tag = "CafeManager";
            InvManagerLogin.Tag = "InventoryManager";
            cashierLogin.Tag = "Cashier";
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void cafeManagerLogin_Click(object sender, EventArgs e)
        {
            userType = "CafeManager";
            ChangeButtonAppearance(userType);          // highlight the pressed button     
        }

        private void InvManagerLogin_Click(object sender, EventArgs e)
        {

            userType = "InventoryManager";
            ChangeButtonAppearance(userType);
            
        }

        private void cashierLogin_Click(object sender, EventArgs e)
        {
            userType = "Cashier";
            ChangeButtonAppearance(userType);
            
        }

        private void AuthenticateAndOpenMenu(string userType)
        {

            if (true/*AuthenticateUser(userType, textBoxEmail.Text, textBoxPasscode.Text)*/)
            {
                MessageBox.Show("Login successful!");
                OpenMenuForm(userType);
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
        private void ChangeButtonAppearance(string selectedUserType)
        {
            // Reset appearance for all user type buttons
            cafeManagerLogin.BackColor = SystemColors.Control;
            InvManagerLogin.BackColor = SystemColors.Control;
            cashierLogin.BackColor = SystemColors.Control;

            // Enable login button when a user type button is selected
            login.Enabled = true;
            login.BackColor = Color.Khaki;

            switch (selectedUserType)
            {
                case "CafeManager":
                    cafeManagerLogin.BackColor = Color.Green;  // Change the color as needed
                    break;

                case "InventoryManager":
                    InvManagerLogin.BackColor = Color.Green;  // Change the color as needed
                    break;

                case "Cashier":
                    cashierLogin.BackColor = Color.Green;  // Change the color as needed
                    break;
            }
        }


        private bool AuthenticateUser(string userType, string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $"SELECT s.StaffID FROM {userType} m " +   //single sql to deal with all three managers
                           "JOIN Staff s ON m.StaffID = s.StaffID " +
                           "WHERE s.Email = @Username AND s.Passcode = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);


                        object result = command.ExecuteScalar();

                        // Check if the credentials are valid
                        if (result != null && result != DBNull.Value)
                        {
                            int staffID = Convert.ToInt32(result);
                            return true;
                        }
                        else
                        {
                            string errorMessage = $"Invalid username or password for {userType}.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display detailed exception message
                string errorMessage = $"Error during authentication: {ex.Message}";

                MessageBox.Show(errorMessage, "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }


        private void OpenMenuForm(string userType)
        {
            // Open the corresponding menu form based on the user type
            switch (userType)
            {
                case "CafeManager":
                    cafeManagerMenu cafeManagerMenu = new cafeManagerMenu();
                    cafeManagerMenu.Show();
                    break;

                case "InventoryManager":
                    InventoryManagerOperations inventoryManagerOperations = new InventoryManagerOperations();
                    inventoryManagerOperations.Show();
                    break;

                case "Cashier":
                    cashierMenu cashierMenu = new cashierMenu();
                    cashierMenu.Show();
                    break;
            }

            // Close the current login form
            this.Hide();
        }


        private void loginstaff_Load(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPasscode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            CutomerLogin CutomerLogin = new CutomerLogin();
            CutomerLogin.Show();
            this.Hide();
        }

        private void login_Click(object sender, EventArgs e)
        {

            AuthenticateAndOpenMenu(userType);
        }
    }
}

