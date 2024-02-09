using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ADO;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using(Entity db = new Entity())
            {
                Employee employee = db.Employees.Find(txtEmployeeID.Text);
                if (employee != null)
                {
                    if(employee.Password.Trim() == txtPassword.Text.Trim())
                    {
                        MessageBox.Show("Loggin in :)");
                        this.Hide();
                        var main = new Main();
                        main.SetEmployee(employee);
                        main.Closed += (s, args) => this.Close();
                        main.Show();
                    }
                }
            }
            /*
            if (auth())
            {
                MessageBox.Show("Loggin in :)");
                this.Hide();
                var main = new Main();
                main.SetEmployee(employee);
                main.Closed += (s, args) => this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("Employee ID or password was not found");
            }
            Console.WriteLine(auth());
            */
        }

        /*
        private bool auth()
        {
            employee = new EmployeeModel(txtEmployeeID.Text);
            return employee.getDBEmployee(txtPassword.Text);
        }
        */
    }
}
