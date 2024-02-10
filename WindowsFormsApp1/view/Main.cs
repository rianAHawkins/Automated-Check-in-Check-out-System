using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.ADO;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        Employee employee;
        AnnouncementModel announcement;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // employee.refreshRoles();
            // db.get roles
            lblEID.Text = "EID: " + employee.EmployeeID.ToString().Trim().ToUpper();

            using (Entity db = new Entity())
            {
                DateTime oneMonthAgo = DateTime.Today.AddMonths(-1);
                var AList = db.Announcements.Where(a => a.created > oneMonthAgo)
                .ToList();
                String strAnnounce = "";
                foreach (Announcement announcement in AList)
                {
                    strAnnounce += "BY: " + announcement.EmployeeID.Trim();
                    strAnnounce += "\n [" + announcement.val.Trim() + "] ";
                    strAnnounce += "\nCreated on: " + announcement.created + "\n\n";
                }
                txtAnouncements.Text = strAnnounce;
            }

            /*
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
            */
        }

        /*
        private void getAnnouncements()
        {
            announcement= new AnnouncementModel();
            announcement.getAnnouncement();            
        }
        */

        private void View_Visibile(List<String> roles)
        {
            foreach (String role in roles)
            {
                if (role.ToUpper().Contains("INVENTORY"))
                {
                    tsmiInventory.Visible = true;
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

        public void SetEmployee(Employee employee) => this.employee = employee;

        private void tsmiInventory_Click(object sender, EventArgs e)
        {
            nextView(0);
        }

        private void tsmiTask_Click(object sender, EventArgs e)
        {
            nextView(1);
        }

        private void tsmiSystem_Click(object sender, EventArgs e)
        {
            nextView(2);
        }


        private void nextView(int i)
        {
            this.Hide();
            Form nextForm;
            switch (i)
            {
                case 0:
                    nextForm = new Inventory(employee);
                    break;
                case 1: nextForm = new Work(employee); break;
                case 2: nextForm = new EmployeeDetails(employee); break;
                default:
                    nextForm = new Form();
                    break;
            }
            nextForm.Closed += (s, args) => this.Show();
            nextForm.Show();
        }


    }
}
