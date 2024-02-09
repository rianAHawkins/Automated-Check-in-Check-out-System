using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ADO;

namespace WindowsFormsApp1
{
    public partial class ItemTypeView : Form
    {
        private bool validated = false;
        private int min = 0;
        public ItemTypeView()
        {
            InitializeComponent();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                min = int.Parse(txtMin.Text);
                validated= true;
            }
            catch { 
                validated = false;
                MessageBox.Show("Please enter a valid Integer");
                txtMin.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!validated) return;
            using (Entity db = new Entity())
            {
                ItemType itemType = db.ItemTypes.Create();
                itemType.name= txtName.Text;
                itemType.description= txtDescription.Text;
                itemType.min = min;
                db.ItemTypes.Add(itemType);
                db.SaveChanges();
                MessageBox.Show("SAVED");
            }
            
        }
    }
}
