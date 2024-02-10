using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public class EmployeeModel
    {
        private String EmployeeID;
        private String Fname;
        private String Lname;
        private DateTime HireDate;
        private List<String> Roles;

        public EmployeeModel(String EmployeeID)
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
            Roles.Clear();
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
                        Roles.Add(reader["Role"].ToString().Trim());
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
        }


        // properties

        public string employeeID
        {
            get { return EmployeeID; }
            set { EmployeeID = value; }
        }
        public string fname
        {
            get { return Fname; }
            set { Fname = value; }
        }
        public string lname
        {
            get { return Lname; }
            set { Lname = value; }
        }
        public DateTime hireDate
        {
            get { return HireDate; }
            set { HireDate = value; }
        }
        public List<String> roles
        {
            get { return Roles; }
            set { Roles = value; }
        }

    }
}
