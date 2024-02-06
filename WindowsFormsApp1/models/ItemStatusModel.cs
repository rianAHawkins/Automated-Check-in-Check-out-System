using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsApp1.models
{
    public class ItemStatusModel
    {
        private int id;
        private string status;

        public ItemStatusModel(int id, string status)
        {
            this.id = id;
            this.status = status;
        }

        // properties
        public int getId() { return id; }
        public String getStatus() { return status; }
    }
}
