using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsApp1.models
{

    public class AnnouncementModel
    {    
        private List<int> id = new List<int>();
        private List<String> EmployeeID = new List<string>();
        private List<String> val = new List<string>();
        private List<DateTime> created = new List<DateTime>();

        public AnnouncementModel()
        {

        }



        public void getAnnouncement()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=\"GB Manufacturing\";Integrated Security=True"))
            {
                string queryString = "SELECT * FROM [GB Manufacturing].[dbo].[Announcement]" +
                    "WHERE DATEPART(m, created) = DATEPART(m, DATEADD(m, -0, getdate()))"+
                    "AND DATEPART(yyyy, created) = DATEPART(yyyy, DATEADD(m, -0, getdate()))";

                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        //Console.WriteLine(reader["EmployeeID"].ToString().Trim());
                        id.Add((int) reader["id"]);
                        EmployeeID.Add(reader["EmployeeID"].ToString().Trim());
                        val.Add(reader["val"].ToString().Trim());
                        created.Add( (DateTime)reader["created"]);
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
        }

        public List<int> Id { get => id; set => id = value; }
        public List<string> EmployeeIDs { get => EmployeeID; set => EmployeeID = value; }
        public List<string> Val { get => val; set => val = value; }
        public List<DateTime> Created { get => created; set => created = value; }
    }
}
