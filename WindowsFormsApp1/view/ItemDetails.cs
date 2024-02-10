using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.ADO;

namespace WindowsFormsApp1
{
    public partial class ItemDetails : Form
    {
        List<Building> lsBuilding = new List<Building>();
        List<ItemStatu> lsItemStatus = new List<ItemStatu>();
        List<ItemType> lsItemTypes = new List<ItemType>();
        Item item;
        public ItemDetails(List<Building> buildings, List<ItemStatu> itemStatuses, List<ItemType> itemTypes, Item item)
        {
            InitializeComponent();
            lsBuilding = buildings;
            lsItemStatus = itemStatuses;
            lsItemTypes = itemTypes;
            this.item = item;
        }

        public ItemDetails(List<Building> buildings, List<ItemStatu> itemStatuses, List<ItemType> itemTypes)
        {
            InitializeComponent();
            lsBuilding = buildings;
            lsItemStatus = itemStatuses;
            lsItemTypes = itemTypes;
            btnUpdate.Text = "ORDER";
        }

        private void ItemDetails_Load(object sender, EventArgs e)
        {
            loadData();
            if (item != null)
            {
                lblItemID.Text = "ItemID: " + item.ID;
                cbBuilding.SelectedIndex = (int)item.BuildingID;
                cbStatus.SelectedIndex = (int)item.itemStatusID;
                cbType.SelectedIndex = (int)item.itemTypeID;
            }
            else
            {
                cbStatus.SelectedIndex = 0;
                cbStatus.Enabled = false;
            }
        }

        private void loadData()
        {

            // loadBuilding
            foreach (Building building in lsBuilding)
            {
                cbBuilding.Items.Add(building.Name.Trim());
            }

            // loadStatus
            foreach (ItemStatu itemStatus in lsItemStatus)
            {
                cbStatus.Items.Add(itemStatus.Status.Trim());
            }

            // loadTypes
            foreach (ItemType itemType in lsItemTypes)
            {
                cbType.Items.Add(itemType.name.Trim());
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
                bool create = false;
                if (item == null)
                {
                    item = db.Items.Create();
                    create = true;
                }
                else
                {
                    item = db.Items.Find(item.ID);
                }

                if (item != null)
                {
                    if (cbBuilding.SelectedIndex != -1) { item.BuildingID = cbBuilding.SelectedIndex; }
                    if (cbStatus.SelectedIndex != -1) { item.itemStatusID = cbStatus.SelectedIndex; }
                    if (cbType.SelectedIndex != -1) { item.itemTypeID = cbType.SelectedIndex; }
                    if (create)
                    {
                        db.Items.Add(item);
                    }
                    db.SaveChanges();
                }
            }
            MessageBox.Show("SAVED");
            btnCancel.Text = "Exit";
        }
    }
}
