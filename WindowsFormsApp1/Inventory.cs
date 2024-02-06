using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class Inventory : Form
    {
        EmployeeModel employee;
        InventoryModel inventory;
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("name["+employee.fname+"]");
            //lblName.Text = employee.fname +" "+ employee.lname;
            inventory = new InventoryModel();
            loadData();
        }

        private void loadData()
        {
            // loadStatus
            foreach (ItemStatusModel itemStatus in inventory.itemStatuses)
            {
                cbStatus.Items.Add(itemStatus.getStatus());
            }

            // loadTypes
            foreach (ItemTypeModel itemType in inventory.itemTypes)
            {
                cbType.Items.Add(itemType.Name);
            }

        }

        private void loadBuilding()
        {

        }

        public void SetEmployee(EmployeeModel employee) => this.employee = employee;

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(cbType.SelectedIndex+" "+ inventory.itemTypes[cbType.SelectedIndex].Name);
        }
    }
}
