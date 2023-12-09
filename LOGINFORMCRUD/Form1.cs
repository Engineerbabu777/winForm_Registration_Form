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

namespace LOGINFORMCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // CREATING THE INSTANCE OF DATABASE CONNECTION SO WE CAN USE IT LATER!
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-Q2S09P8;Initial Catalog=StudentDatabase;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            // ON FORM LOAD GET ALL STUDENTS!
            getStudents();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        // Method to retrieve and display data from the 'registered_students_table'
        private void getStudents()
        {
            // Open a connection to the database
            connection.Open();

            // Create a SQL command to select all (*) columns from the 'registered_students_table'
            // Note: Using '*' in SELECT retrieves all columns; consider specifying specific columns for better performance
            SqlCommand command = new SqlCommand("select * from registered_students_table", connection);

            // Create a data adapter to execute the command and fill a DataTable with the results
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            // Create a DataTable to hold the retrieved data
            DataTable dataTable = new DataTable();

            // Fill the DataTable with data from the SQL command
            adapter.Fill(dataTable);

            // Set the DataGridView's data source to the filled DataTable, displaying the data
            dataGridView1.DataSource = dataTable;

            // Close the database connection
            connection.Close();
        }

        // FUNCTION TO ADD NEW STUDENT!!
        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: VALIDATE ALL FIELDS!!
            // You should add validation logic here to ensure the data entered is valid.

            // Open a connection to the database
            connection.Open();

            // Create a SQL command to insert a new row into the 'registered_students_table'
            // Note: It's susceptible to SQL injection; consider using parameterized queries to enhance security
            SqlCommand command = new SqlCommand("insert into registered_students_table values ('" + int.Parse(textBox3.Text) + "','" + textBox2.Text + "','" + textBox1.Text + "','" + int.Parse(textBox4.Text) + "')", connection);

            // Execute the SQL command to insert the new record into the database
            command.ExecuteNonQuery();

            // Display a success message to the user
            MessageBox.Show("Registered Success.");

            // Close the database connection
            connection.Close();

            // Retrieve and display the updated data in the DataGridView
            getStudents();
        }


        // FUNCTION TO UPDATE STUDENT RECORD !!
        private void button3_Click(object sender, EventArgs e)
        {
            // TODO:: VALIDATE THE DATA!!
            // CREATE A CONNECTION !!
            connection.Open();

            // MAKE A SQL COMMAND !!
            SqlCommand command = new SqlCommand("update registered_students_table set FatherName='"+textBox2.Text+"', StudentName='"+textBox1.Text+"', Semester='"+int.Parse(textBox4.Text)+"' where RollNumber='"+int.Parse(textBox3.Text)+"'", connection);
            command.ExecuteNonQuery();

            // GIVE ME MESSAGE THAT UPADTED!
            MessageBox.Show("Updated Success.");

            // CLOSE THE CONNECTION!
            connection.Close();

            // REFRESH DATA!
            getStudents();
        }

        // FUNCTION TO DELETE STUDENT!!
        private void button2_Click(object sender, EventArgs e)
        {
            // TODO:: VALIDATE THE DATA!!
            // CREATE A CONNECTION !!
            connection.Open();

            // MAKE A SQL COMMAND !!
            SqlCommand command = new SqlCommand("delete from registered_students_table where RollNumber='" + int.Parse(textBox3.Text)+ "'", connection);
            command.ExecuteNonQuery();

            // GIVE ME MESSAGE THAT UPADTED!
            MessageBox.Show("Deleted Success.");

            // CLOSE THE CONNECTION!
            connection.Close();

            // REFRESH DATA!
            getStudents();
        }

        // FUNCTION TO SEARCH STUDENT!!
        private void button4_Click(object sender, EventArgs e)
        {
            // TODO:: VALIDATE THE DATA!!
            // CREATE A CONNECTION !!
            connection.Open();

            // MAKE A SQL COMMAND !!
            SqlCommand command = new SqlCommand("select * from registered_students_table where RollNumber='" + int.Parse(textBox3.Text) + "'", connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            // CLOSE THE CONNECTION!
            connection.Close();

           
        }
    }
}
