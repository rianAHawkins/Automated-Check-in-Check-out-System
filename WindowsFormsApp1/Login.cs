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
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        Employee employee;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
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
        }

        private bool auth()
        {
            employee = new Employee(txtEmployeeID.Text);
            return employee.getDBEmployee(txtPassword.Text);
        }
    }
}
