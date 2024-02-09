using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ADO;
using WindowsFormsApp1.models;

namespace WindowsFormsApp1
{
    public partial class Inventory : Form
    {
        Employee employee;
        List<Building> lsBuilding = new List<Building>();
        List<ItemStatus> lsItemStatus = new List<ItemStatus>();
        List<ItemType> lsItemTypes = new List<ItemType>();
        InventoryModel inventory;
        public Inventory(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
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
            using (Entity db = new Entity())
            {
                // loadBuilding
                lsBuilding = db.Buildings.ToList();
                foreach (Building building in lsBuilding)
                {
                    cbBuilding.Items.Add(building.Name.Trim());                    
                }

                // loadStatus
                lsItemStatus = db.ItemStatus.ToList();
                foreach (ItemStatus itemStatus in lsItemStatus)
                {
                    cbStatus.Items.Add(itemStatus.Status.Trim());
                }

                // loadTypes
                lsItemTypes = db.ItemTypes.ToList();
                foreach (ItemType itemType in lsItemTypes)
                {
                    cbType.Items.Add(itemType.name.Trim());
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbBuilding.SelectedIndex = -1;
            cbBuilding.Text = "Select Building";
            cbStatus.SelectedIndex = -1;
            cbStatus.Text = "Select Status";
            cbType.SelectedIndex = -1;
            cbType.Text = "Select Type";
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(cbType.SelectedIndex+" "+ inventory.itemTypes[cbType.SelectedIndex].Name);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            flpInventory.Controls.Clear();
            using (Entity db = new Entity())
            {
                //DateTime oneMonthAgo = DateTime.Today.AddMonths(-1);
                List<Item> AList = new List<Item>();

                AList = db.Items.Where(a =>
                (a.BuildingID == cbBuilding.SelectedIndex || cbBuilding.SelectedIndex == -1)
                &&
                (a.itemStatusID == cbStatus.SelectedIndex || cbStatus.SelectedIndex==-1) 
                && 
                (a.itemTypeID == cbType.SelectedIndex || cbType.SelectedIndex == -1)
                ).ToList();
                bool bl = false;
                foreach (Item item in AList)
                {
                    itemLoad(item, bl);
                    bl = !bl;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Item sitem = ((SmartButton) sender).sitem;
            var itemEdit = new ItemDetails(lsBuilding,lsItemStatus,lsItemTypes, sitem);
            //itemEdit.Closed += (s, args) => this.Close();            
            itemEdit.Show();
        }

        private void itemLoad(Item item, bool blue)
        {
            FlowLayoutPanel pnl = new FlowLayoutPanel();
            pnl.Width= 740;
            pnl.Height= 40;
            pnl.BackColor = Color.MintCream;
            if (blue){pnl.BackColor = Color.LightGreen;}

            Button btn = new SmartButton(item);
            btn.Text = "Edit";
            btn.Click += btnEdit_Click;
            pnl.Controls.Add(btn);

            pnl.Controls.Add(easyLabel("ID: " + item.ID));            
            pnl.Controls.Add(easyLabel("Building: " + item.Building.Name));
            pnl.Controls.Add(easyLabel("Type: " + lsItemTypes[(int)item.itemTypeID].name));
            pnl.Controls.Add(easyLabel("Status: " + lsItemStatus[(int)item.itemStatusID].Status));

            flpInventory.Controls.Add(pnl);
        }

        protected class SmartButton:Button
        {
            public Item sitem;
            public SmartButton(Item item):base(){
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
            var itemEdit = new ItemDetails(lsBuilding, lsItemStatus, lsItemTypes);
            itemEdit.Closed += (s, args) => this.loadData();            
            itemEdit.Show();
        }
    }
}
