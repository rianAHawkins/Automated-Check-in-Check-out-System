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
    public partial class TaskItems : Form
    {
        Task task;
        List<ItemType> itemType = new List<ItemType>();
        List<TaskItem> taskItems = new List<TaskItem>();
        public TaskItems(Task task)
        {
            InitializeComponent();
            this.task = task;
        }

        private void Items_Load(object sender, EventArgs e)
        {
            getItemTypes();
            getTaskItems();
            loadItems();
            lblTaskID.Text = "Task: "+task.ID;
        }

        private void loadItems()
        {
            foreach (TaskItem TI in taskItems)
            {
                add(TI);
            }

        }

        private void add(TaskItem TI)
        {
            FlowLayoutPanel groupBox = new FlowLayoutPanel();
            groupBox.Width = flpItems.Width;
            groupBox.Height = 40;
            ComboBox comboBox = new ComboBox();
            comboBox.Text = "Item Type";
            foreach (ItemType type in itemType)
            {
                comboBox.Items.Add(type.name.Trim());
            }
            comboBox.SelectedIndex = (int)TI.itemTypeID;
            Label label = new Label();
            label.Text = "Req:";
            TextBox textBox = new TextBox();
            textBox.Text = ""+TI.Required;
            
            groupBox.Controls.Add(comboBox);
            groupBox.Controls.Add(label);
            groupBox.Controls.Add(textBox);
            flpItems.Controls.Add(groupBox);
        }

        private void add()
        {
            FlowLayoutPanel groupBox = new FlowLayoutPanel();
            groupBox.Width = flpItems.Width;
            groupBox.Height = 40;
            ComboBox comboBox = new ComboBox();
            comboBox.Text = "Item Type";
            foreach (ItemType type in itemType)
            {
                comboBox.Items.Add(type.name.Trim());
            }
            Label label = new Label();
            label.Text = "Req:";
            label.AutoSize = true;
            TextBox textBox = new TextBox();
            textBox.Width = 200;

            groupBox.Controls.Add(comboBox);
            groupBox.Controls.Add(label);
            groupBox.Controls.Add(textBox);
            flpItems.Controls.Add(groupBox);
        }

        protected class SmartButton : Button
        {
            public ComboBox cb;
            public SmartButton(ComboBox cb) : base()
            {
                this.cb = cb;
            }
        }

        private void getTaskItems()
        {
            using (Entity db = new Entity())
            {
                taskItems = db.TaskItems.Where(a =>
                (a.TaskID == task.ID)                 
                ).ToList();
            }
        }

        private void getItemTypes()
        {
            using (Entity db = new Entity())
            {
                itemType = db.ItemTypes.ToList();

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            flpItems.Controls.RemoveAt(flpItems.Controls.Count - 1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (Entity db = new Entity())
            {                
                foreach(Control c in flpItems.Controls)
                {
                    int TIType =-1 ;int Req = -1;
                    for(int i = 0; i<c.Controls.Count; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                ComboBox cb = (ComboBox)c.Controls[i];
                                TIType = cb.SelectedIndex;
                                break;
                            case 2:
                                Req = int.Parse(c.Controls[i].Text); 
                                break;
                        }
                    }
                    TaskItem ti;
                    try
                    {
                        ti = db.TaskItems.Single(t =>
                        (t.TaskID == task.ID) &&
                        (t.itemTypeID == TIType)
                        );
                    }
                    catch
                    {
                        ti = null;
                    }

                    if( ti != null)
                    {
                        ti.Required = Req;                        
                        db.SaveChanges();
                    }
                    else
                    {
                        ti = db.TaskItems.Create();
                        ti.TaskID = task.ID;
                        ti.itemTypeID = TIType;
                        ti.Required= Req; 
                        db.TaskItems.Add(ti);
                        db.SaveChanges();
                    }
                }                
            }
            MessageBox.Show("SAVED");
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

        }
    }
}
