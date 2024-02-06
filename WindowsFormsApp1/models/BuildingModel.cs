using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.models
{
    public class BuildingModel
    {
        int id;
        String name;
        String address;
        public BuildingModel() { }

        public BuildingModel(int id, String name, String address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }

        // properties
        public int getId() { return id; }
        public String getName() { return name; }
        public String getAddress() { return address; }


    }
}
