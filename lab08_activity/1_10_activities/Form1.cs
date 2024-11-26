using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Event triggered when the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            // Optionally load data into the DataGridView
            LoadCustomerData();
        }

        // Event triggered when the "Preview" button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            // Collect input from form controls
            string name = textBox1.Text;
            string country = comboBox1.SelectedItem.ToString();
            string gender = radioMale.Checked ? "Male" : "Female";
            string maritalStatus = radioButton3.Checked ? "Married" : "Unmarried";
            string hobbies = "";

            if (checkBox1.Checked) hobbies += "Reading ";
            if (checkBox3.Checked) hobbies += "Writing";

            // Show a preview message box with the collected data
            MessageBox.Show($"Name: {name}\nCountry: {country}\nGender: {gender}\nMarital Status: {maritalStatus}\nHobbies: {hobbies}");
        }

        // Event triggered when the "Add" button is clicked
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Collect input from form controls
            string name = textBox1.Text;
            string country = comboBox1.SelectedItem.ToString();
            string gender = radioMale.Checked ? "Male" : "Female";
            string maritalStatus = radioButton3.Checked ? "Married" : "Unmarried";
            string hobbies = "";

            if (checkBox1.Checked) hobbies += "Reading ";
            if (checkBox3.Checked) hobbies += "Writing";

            // Insert data into the database
            InsertDataIntoDatabase(name, country, gender, maritalStatus, hobbies);

            // Load the updated customer data into the DataGridView
            LoadCustomerData();
        }

        // Event triggered when the "Delete" button is clicked
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Collect the customer name to delete
            string name = textBox1.Text;  // Assuming name is used to delete (you can adapt to use any unique identifier)

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter the name of the customer to delete.");
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show($"Are you sure you want to delete customer '{name}'?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Delete data from the database
                DeleteDataFromDatabase(name);

                // Load the updated customer data into the DataGridView
                LoadCustomerData();
            }
        }

        // Event triggered when the "Update" button is clicked
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Collect input from form controls
            string name = textBox1.Text;
            string country = comboBox1.SelectedItem.ToString();
            string gender = radioMale.Checked ? "Male" : "Female";
            string maritalStatus = radioButton3.Checked ? "Married" : "Unmarried";
            string hobbies = "";

            if (checkBox1.Checked) hobbies += "Reading ";
            if (checkBox3.Checked) hobbies += "Writing";

            // Ensure the customer name is entered before updating
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter the customer name to update.");
                return;
            }

            // Call method to update data in the database
            UpdateCustomerData(name, country, gender, maritalStatus, hobbies);

            // Load the updated customer data into the DataGridView
            LoadCustomerData();
        }

        // Method to load customer data into the DataGridView
        private void LoadCustomerData()
        {
            // Define the connection string for SQL Server
            string strConnection = "Data Source=DESKTOP-06NJIOH\\SQLEXPRESS;Initial Catalog=CustomerDB1;Integrated Security=True";
            SqlConnection objConnection = new SqlConnection(strConnection);

            try
            {
                // Open the connection
                objConnection.Open();

                // Define the SQL query to fetch customer data
                string strQuery = "SELECT CustomerName, Country, Gender, MaritalStatus, Hobbies FROM CustomerTable";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(strQuery, objConnection);
                DataTable CustomerTable = new DataTable();
                dataAdapter.Fill(CustomerTable);

                // Bind the data to the DataGridView
                dtgCustomer.DataSource = CustomerTable;
            }
            catch (Exception ex)
            {
                // Show error message if there's an issue with the database connection
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                objConnection.Close();
            }
        }

        // Method to insert customer data into the database
        private void InsertDataIntoDatabase(string name, string country, string gender, string maritalStatus, string hobbies)
        {
            // Define the connection string for SQL Server
            string strConnection = "Data Source=DESKTOP-06NJIOH\\SQLEXPRESS;Initial Catalog=CustomerDB1;Integrated Security=True";
            SqlConnection objConnection = new SqlConnection(strConnection);

            try
            {
                // Open the connection
                objConnection.Open();

                // Create the SQL query to insert customer data
                string strCommand = "INSERT INTO CustomerTable (CustomerName, Country, Gender, MaritalStatus, Hobbies) " +
                                    "VALUES (@Name, @Country, @Gender, @MaritalStatus, @Hobbies)";
                SqlCommand objCommand = new SqlCommand(strCommand, objConnection);

                // Use parameters to prevent SQL injection
                objCommand.Parameters.AddWithValue("@Name", name);
                objCommand.Parameters.AddWithValue("@Country", country);
                objCommand.Parameters.AddWithValue("@Gender", gender);
                objCommand.Parameters.AddWithValue("@MaritalStatus", maritalStatus);
                objCommand.Parameters.AddWithValue("@Hobbies", hobbies);

                // Execute the insert command
                objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Show error message if there's an issue with the database operation
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                objConnection.Close();
            }
        }

        // Method to delete customer data from the database
        private void DeleteDataFromDatabase(string name)
        {
            // Define the connection string for SQL Server
            string strConnection = "Data Source=DESKTOP-06NJIOH\\SQLEXPRESS;Initial Catalog=CustomerDB1;Integrated Security=True";
            SqlConnection objConnection = new SqlConnection(strConnection);

            try
            {
                // Open the connection
                objConnection.Open();

                // Create the SQL query to delete customer data
                string strCommand = "DELETE FROM CustomerTable WHERE CustomerName = @Name";
                SqlCommand objCommand = new SqlCommand(strCommand, objConnection);

                // Use parameter to prevent SQL injection
                objCommand.Parameters.AddWithValue("@Name", name);

                // Execute the delete command
                objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Show error message if there's an issue with the database operation
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                objConnection.Close();
            }
        }

        // Method to update customer data in the database
        private void UpdateCustomerData(string name, string country, string gender, string maritalStatus, string hobbies)
        {
            // Define the connection string for SQL Server
            string strConnection = "Data Source=DESKTOP-06NJIOH\\SQLEXPRESS;Initial Catalog=CustomerDB1;Integrated Security=True";
            SqlConnection objConnection = new SqlConnection(strConnection);

            try
            {
                // Open the connection
                objConnection.Open();

                // Create the SQL query to update customer data
                string strCommand = "UPDATE CustomerTable SET Country = @Country, Gender = @Gender, MaritalStatus = @MaritalStatus, Hobbies = @Hobbies WHERE CustomerName = @Name";
                SqlCommand objCommand = new SqlCommand(strCommand, objConnection);

                // Use parameters to prevent SQL injection
                objCommand.Parameters.AddWithValue("@Country", country);
                objCommand.Parameters.AddWithValue("@Gender", gender);
                objCommand.Parameters.AddWithValue("@MaritalStatus", maritalStatus);
                objCommand.Parameters.AddWithValue("@Hobbies", hobbies);
                objCommand.Parameters.AddWithValue("@Name", name);

                // Execute the update command
                objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Show error message if there's an issue with the database operation
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                objConnection.Close();
            }
        }
    }
}
