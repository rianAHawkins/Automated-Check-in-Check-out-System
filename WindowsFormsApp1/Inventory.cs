using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Inventory : Form
    {
        EmployeeModel employee;        
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("name["+employee.fname+"]");
            //lblName.Text = employee.fname +" "+ employee.lname;
        }

        private void loadBuilding()
        {

        }

        public void SetEmployee(EmployeeModel employee) => this.employee = employee;
    }
}
