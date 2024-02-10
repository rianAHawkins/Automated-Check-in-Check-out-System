using System;
using System.Windows.Forms;
using WindowsFormsApp1.ADO;

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
            using (Entity db = new Entity())
            {
                Employee employee = db.Employees.Find(txtEmployeeID.Text);
                if (employee != null)
                {
                    // PasswordHasher<Employee> passwordHasher = new PasswordHasher<Employee>();
                    // String HashedPWD = passwordHasher.HashPassword(employee, employee.Password);

                    if (employee.Password.Trim() == txtPassword.Text.Trim())
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
