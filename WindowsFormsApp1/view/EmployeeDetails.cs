using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.ADO;

namespace WindowsFormsApp1
{
    public partial class EmployeeDetails : Form
    {
        List<Role> roles = new List<Role>();
        List<RoleCB> checkboxes = new List<RoleCB>();
        List<EmployeeRole> employeeRoles = new List<EmployeeRole>();
        Employee employee = null;
        public EmployeeDetails()
        {
            InitializeComponent();
        }

        public EmployeeDetails(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
        }

        private void EmployeeDetails_Load(object sender, EventArgs e)
        {
            getRoles();
            getEmployeeRoles();
        }

        private void getRoles()
        {
            using (Entity db = new Entity())
            {
                // loadBuilding
                roles = db.Roles.ToList();
                for (int i = 0; i < roles.Count; i++)
                {
                    Role role = roles[i];
                    RoleCB roleCB = new RoleCB(role.id, role.role1);                    
                    checkboxes.Add(roleCB);
                    flpRoles.Controls.Add(checkboxes[i]);
                }
            }
        }

        private void getEmployeeRoles()
        {
            using (Entity db = new Entity())
            {
                employeeRoles = db.EmployeeRoles.Where(a => (a.EmployeeID == employee.EmployeeID)).ToList();
                for (int i = 0; i < checkboxes.Count; i++)
                {
                    for (int j = 0; j < employeeRoles.Count; j++)
                    {
                        if (checkboxes[i].RoleID == employeeRoles[j].RoleID)
                        {
                            checkboxes[i].Checked = true;
                        }
                    }
                }
            }
        }

        protected class RoleCB : CheckBox
        {
            public int RoleID;
            public RoleCB(int RoleID, String Text) : base()
            {
                this.RoleID = RoleID;
                this.Font = new Font(this.Font.Name, 10f, this.Font.Style, this.Font.Unit);
                this.Text = Text;
                this.AutoSize = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (Entity db = new Entity())
            {
                Employee emp = db.Employees.Find(employee.EmployeeID);
                PasswordHasher<Employee> passwordHasher = new PasswordHasher<Employee>();
                String HashedPWD = passwordHasher.HashPassword(emp, emp.Password);
                emp.Password = HashedPWD;
                db.SaveChanges();
            }
            MessageBox.Show("SAVED");
            btnCancel.Text = "Exit";
        }
    }
}
