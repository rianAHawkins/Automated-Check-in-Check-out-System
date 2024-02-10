using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.ADO;
using WindowsFormsApp1.view;

namespace WindowsFormsApp1
{
    public partial class Work : Form
    {
        Employee employee;
        List<Building> lsBuilding = new List<Building>();
        List<Skill> lsSkill = new List<Skill>();
        List<TaskStatu> lsStatus = new List<TaskStatu>();
        public Work(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
        }

        private void Work_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("name["+employee.fname+"]");
            //lblName.Text = employee.fname +" "+ employee.lname;            
            loadData();
        }
        private void clearData()
        {
            lsBuilding.Clear();
            cbBuilding.Items.Clear();

            lsSkill.Clear();
            cbSkill.Items.Clear();

            lsStatus.Clear();
            cbStatus.Items.Clear();
        }

        private void loadData()
        {
            clearData();
            using (Entity db = new Entity())
            {
                // loadBuilding
                lsBuilding = db.Buildings.ToList();
                foreach (Building building in lsBuilding)
                {
                    cbBuilding.Items.Add(building.Name.Trim());
                }

                lsSkill = db.Skills.ToList();
                foreach (Skill skill in lsSkill)
                {
                    cbSkill.Items.Add(skill.Name.Trim());
                }

                lsStatus = db.TaskStatus.ToList();
                foreach (TaskStatu status in lsStatus)
                {
                    cbStatus.Items.Add(status.Name.Trim());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbBuilding.SelectedIndex = -1;
            cbBuilding.Text = "Select Building";

            cbSkill.SelectedIndex = -1;
            cbSkill.Text = "Select Skill";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            flpInventory.Controls.Clear();
            using (Entity db = new Entity())
            {
                //DateTime oneMonthAgo = DateTime.Today.AddMonths(-1);
                List<Task> AList = new List<Task>();
                AList = db.Tasks.Where(a =>
                 (a.BuildingID == cbBuilding.SelectedIndex || cbBuilding.SelectedIndex == -1) &&
                 (a.SkillID == cbSkill.SelectedIndex || cbSkill.SelectedIndex == -1) &&
                 (a.StatusID == cbStatus.SelectedIndex || cbStatus.SelectedIndex == -1)
                 ).ToList();
                bool bl = false;
                foreach (Task task in AList)
                {
                    taskLoad(task, bl);
                    bl = !bl;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Task sitem = ((SmartButton)sender).sitem;
            var taskEdit = new TaskDetails(lsBuilding, lsSkill, sitem);
            //taskEdit.Closed += (s, args) => this.Close();
            taskEdit.Show();
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            Task sitem = ((SmartButton)sender).sitem;
            var taskItem = new TaskItems(sitem);
            //taskEdit.Closed += (s, args) => this.Close();
            taskItem.Show();
        }


        private void taskLoad(Task task, bool blue)
        {
            FlowLayoutPanel pnl = new FlowLayoutPanel();
            pnl.Width = 615;
            pnl.Height = 80;
            pnl.BackColor = Color.MintCream;
            if (blue) { pnl.BackColor = Color.LightGreen; }

            FlowLayoutPanel groupBox = new FlowLayoutPanel();
            groupBox.Width = 615;
            groupBox.Height = 40;

            Button btnEdit = new SmartButton(task);
            btnEdit.Text = "Edit";
            btnEdit.Click += btnEdit_Click;
            groupBox.Controls.Add(btnEdit);

            Button btnItem = new SmartButton(task);
            btnItem.Text = "Items";
            btnItem.Click += btnItem_Click;
            groupBox.Controls.Add(btnItem);

            pnl.Controls.Add(groupBox);

            pnl.Controls.Add(easyLabel("ID: " + task.ID));
            pnl.Controls.Add(easyLabel("Building: " + task.Building.Name.Trim()));
            pnl.Controls.Add(easyLabel("Desc: " + task.Description.Trim()));
            pnl.Controls.Add(easyLabel("Skill: " + task.Skill.Name.Trim()));
            pnl.Controls.Add(easyLabel("Status: " + task.TaskStatu.Name.Trim()));

            flpInventory.Controls.Add(pnl);
        }

        protected class SmartButton : Button
        {
            public Task sitem;
            public SmartButton(Task item) : base()
            {
                this.sitem = item;
            }
        }

        private Label easyLabel(String text)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.AutoSize = true;
            return lbl;
        }

        private void BtnMainPage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            var itemTypeView = new ItemTypeView();
            itemTypeView.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            var taskEdit = new TaskDetails(lsBuilding,lsSkill);
            taskEdit.Closed += (s, args) => this.loadData();
            taskEdit.Show();
        }
    }
}
