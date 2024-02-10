using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public class InventoryModel
    {
        public List<BuildingModel> buildings = new List<BuildingModel>();
        public List<ItemModel> items = new List<ItemModel>();
        public List<ItemStatusModel> itemStatuses = new List<ItemStatusModel>();
        public List<ItemTypeModel> itemTypes = new List<ItemTypeModel>();

        public InventoryModel()
        {
            //getBuildings();
            getitemStatuses();
            getitemTypes();


        }

        public void getBuildings()
        {
            //GB_ManufacturingTablesTableAdapters.EmployeeTableAdapter
            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=\"GB Manufacturing\";Integrated Security=True"))
            {
                string queryString = "SELECT * FROM Building";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["id"]);
                        String Name = Convert.ToString(reader["Name"]);
                        String Address = Convert.ToString(reader["Address"]);
                        buildings.Add(new BuildingModel(ID, Name, Address));
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
        }

        public void getitemStatuses()
        {
            //GB_ManufacturingTablesTableAdapters.EmployeeTableAdapter
            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=\"GB Manufacturing\";Integrated Security=True"))
            {
                string queryString = "SELECT * FROM ItemStatus";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["id"]);
                        String Status = Convert.ToString(reader["Status"]);
                        itemStatuses.Add(new ItemStatusModel(ID, Status));
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
        }

        public void getitemTypes()
        {
            //GB_ManufacturingTablesTableAdapters.EmployeeTableAdapter
            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=\"GB Manufacturing\";Integrated Security=True"))
            {
                string queryString = "SELECT * FROM ItemType";
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["id"]);
                        String name = Convert.ToString(reader["name"]);
                        String description = Convert.ToString(reader["description"]);
                        int min = 0;
                        if (!DBNull.Value.Equals(reader["min"]))
                        {
                            min = Convert.ToInt32(reader["min"]);
                        }
                        itemTypes.Add(new ItemTypeModel(ID, name, description, min));
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
        }

        public void getItems(int BuildingID)
        {
            //GB_ManufacturingTablesTableAdapters.EmployeeTableAdapter
            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=\"GB Manufacturing\";Integrated Security=True"))
            {
                string queryString = "SELECT * FROM Employee WHERE BuildingID = @BuildingID";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@EmployeeID", BuildingID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {

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
