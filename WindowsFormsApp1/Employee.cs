using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Employee
    {
        private String EmployeeID;
        private String Fname;
        private String Lname;
        private DateTime HireDate;
        private List<String> roles;

        public Employee(String EmployeeID)
        {
            this.EmployeeID = EmployeeID;
        }

        public Boolean getDBEmployee(String pass)
        {
            //GB_ManufacturingTablesTableAdapters.EmployeeTableAdapter
            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=\"GB Manufacturing\";Integrated Security=True"))
            {
                string queryString = "SELECT * FROM Employee WHERE EmployeeID = @EmployeeID";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        String passWord = reader["Password"].ToString().Trim();
                        Console.WriteLine(passWord);// etc
                        if (passWord == pass)
                        {
                            Fname = reader["Fname"].ToString().Trim();
                            Lname = reader["Lname"].ToString().Trim();
                            HireDate = (DateTime)reader["HireDate"];
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
    
        public void refreshRoles()
        {
            roles.Clear();
            //GB_ManufacturingTablesTableAdapters.EmployeeTableAdapter
            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=\"GB Manufacturing\";Integrated Security=True"))
            {
                string queryString = "SELECT * FROM Roles WHERE EmployeeID = @EmployeeID";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        //String passWord = reader["Password"].ToString().Trim();
                        //Console.WriteLine(passWord);// etc
                        roles.Add(reader["Role"].ToString().Trim());
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
        }
    }
}
