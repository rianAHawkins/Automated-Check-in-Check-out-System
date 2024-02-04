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
    public partial class Main : Form
    {
        EmployeeModel employee;
        AnnouncementModel announcement;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // employee.refreshRoles();
            // db.get roles
            lblEID.Text = "EID: "+ employee.employeeID.ToString().Trim().ToUpper();
            getAnnouncements();
            String announce = "";
            for (int i =0; i < announcement.Id.Count; i++)
            {                
                announce += "BY: "+ announcement.EmployeeIDs[i];
                announce += "\n [" + announcement.Val[i]+"] ";
                announce += "\nCreated on: " + announcement.Created[i] + "\n\n";

            }
            txtAnouncements.Text = announce;
            //lblAnnouncements.Text = "HI "+ employee.fname+ "\n Announcements";
        }

        private void getAnnouncements()
        {
            announcement= new AnnouncementModel();
            announcement.getAnnouncement();            
        }

        private void View_Visibile(List<String> roles)
        {
            foreach (String role in roles)
            {
                if (role.ToUpper().Contains("INVENTORY"))
                {
                    tsmiInventory.Visible= true;
                }
                if (role.ToUpper().Contains("TASK"))
                {
                    tsmiTask.Visible = true;
                }
                if (role.ToUpper().Contains("SYSTEM"))
                {
                    tsmiSystem.Visible = true;
                }
            }
        }

        public void SetEmployee(EmployeeModel employee) => this.employee = employee;

        private void tsmiInventory_Click(object sender, EventArgs e)
        {
            this.Hide();
            var nextForm = new Inventory();
            nextForm.SetEmployee(employee);
            nextForm.Closed += (s, args) => this.Show();
            nextForm.Show();
        }

        private void tsmiTask_Click(object sender, EventArgs e)
        {

        }

        private void tsmiSystem_Click(object sender, EventArgs e)
        {

        }

    }
}
