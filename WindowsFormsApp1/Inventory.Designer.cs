namespace WindowsFormsApp1
{
    partial class Inventory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.flpInventory = new System.Windows.Forms.FlowLayoutPanel();
            this.cbBuilding = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.BtnMainPage = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnType = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(468, 39);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 21);
            this.cbStatus.TabIndex = 2;
            this.cbStatus.Text = "Select Status";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(318, 39);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 21);
            this.cbType.TabIndex = 3;
            this.cbType.Text = "Select Type";
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(621, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // flpInventory
            // 
            this.flpInventory.AutoScroll = true;
            this.flpInventory.Location = new System.Drawing.Point(23, 83);
            this.flpInventory.Name = "flpInventory";
            this.flpInventory.Size = new System.Drawing.Size(765, 314);
            this.flpInventory.TabIndex = 5;
            // 
            // cbBuilding
            // 
            this.cbBuilding.FormattingEnabled = true;
            this.cbBuilding.Location = new System.Drawing.Point(172, 39);
            this.cbBuilding.Name = "cbBuilding";
            this.cbBuilding.Size = new System.Drawing.Size(121, 21);
            this.cbBuilding.TabIndex = 6;
            this.cbBuilding.Tag = "";
            this.cbBuilding.Text = "Select Building";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(172, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear Filter";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnMainPage
            // 
            this.BtnMainPage.Location = new System.Drawing.Point(23, 37);
            this.BtnMainPage.Name = "BtnMainPage";
            this.BtnMainPage.Size = new System.Drawing.Size(75, 23);
            this.BtnMainPage.TabIndex = 8;
            this.BtnMainPage.Text = "Main Page";
            this.BtnMainPage.UseVisualStyleBackColor = true;
            this.BtnMainPage.Click += new System.EventHandler(this.BtnMainPage_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(713, 37);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 9;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnType
            // 
            this.btnType.Location = new System.Drawing.Point(713, 8);
            this.btnType.Name = "btnType";
            this.btnType.Size = new System.Drawing.Size(75, 23);
            this.btnType.TabIndex = 10;
            this.btnType.Text = "New Type";
            this.btnType.UseVisualStyleBackColor = true;
            this.btnType.Click += new System.EventHandler(this.btnType_Click);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnType);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.BtnMainPage);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cbBuilding);
            this.Controls.Add(this.flpInventory);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.cbStatus);
            this.Name = "Inventory";
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel flpInventory;
        private System.Windows.Forms.ComboBox cbBuilding;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button BtnMainPage;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnType;
    }
}