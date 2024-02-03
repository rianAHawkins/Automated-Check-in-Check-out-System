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
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (auth())
            {
                MessageBox.Show("Loggin in :)");
                this.Hide();
                var main = new Main();
                main.Closed += (s, args) => this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("Employee ID or password was not found");
            }
            Console.WriteLine(auth());
        }

        private bool auth()
        {
            //GB_ManufacturingTablesTableAdapters.EmployeeTableAdapter
            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=\"GB Manufacturing\";Integrated Security=True"))
            {
                string queryString = "SELECT * FROM Employee WHERE EmployeeID = @EmployeeID";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        String passWord = reader["Password"].ToString().Trim();
                        Console.WriteLine(passWord);// etc
                        if(passWord == txtPassword.Text)
                        {
                            return true;
                        }
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
                return false;
        }
    }
}
