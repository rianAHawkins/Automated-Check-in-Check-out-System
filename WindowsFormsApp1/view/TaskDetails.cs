using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.ADO;

namespace WindowsFormsApp1.view
{
    public partial class TaskDetails : Form
    {
        List<Building> lstBuildings = new List<Building>();
        List<Skill> lsSkill = new List<Skill>();
        Task task;
        public TaskDetails(List<Building> lstBuildings, List<Skill> lsSkill)
        {
            InitializeComponent();
            this.lstBuildings = lstBuildings;
            this.lsSkill = lsSkill;
        }

        public TaskDetails(List<Building> lstBuildings, List<Skill> lsSkill, Task task)
        {
            InitializeComponent();
            this.lstBuildings = lstBuildings;
            this.lsSkill = lsSkill;
            this.task = task;
            lblTaskID.Text = "Task: " + task.ID;
            btnSubmit.Text = "Update";
        }

        private void TaskDetails_Load(object sender, EventArgs e)
        {
            foreach (Building building in lstBuildings)
            {
                cbBuilding.Items.Add(building.Name.Trim());
            }

            foreach (Skill skill in lsSkill)
            {
                cbSkill.Items.Add(skill.Name.Trim());
            }

            if (task == null) { return; }
            cbBuilding.SelectedIndex = (int) task.BuildingID;
            cbSkill.SelectedIndex = (int) task.SkillID;
            txtDesc.Text = task.Description.Trim();
            txtAddress.Text = task.Address.Trim();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (Entity db = new Entity())
            {
                bool create = false;
                if (task == null)
                {
                    task = db.Tasks.Create();
                    create = true;
                }
                else
                {
                    task = db.Tasks.Find(task.ID);
                }

                if (task != null)
                {
                    if (cbBuilding.SelectedIndex != -1) { task.BuildingID = cbBuilding.SelectedIndex; }
                    if (cbSkill.SelectedIndex != -1) { task.SkillID = cbSkill.SelectedIndex; }
                    task.Description = txtDesc.Text;
                    task.Address = txtAddress.Text;
                    if (create)
                    {
                        db.Tasks.Add(task);
                    }
                    db.SaveChanges();
                }
            }
            MessageBox.Show("SAVED");
            btnCancel.Text = "Exit";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
