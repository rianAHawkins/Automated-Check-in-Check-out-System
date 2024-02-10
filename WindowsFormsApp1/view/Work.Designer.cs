namespace WindowsFormsApp1
{
    partial class Work
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.flpInventory = new System.Windows.Forms.FlowLayoutPanel();
            this.cbBuilding = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.BtnMainPage = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.cbSkill = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(546, 35);
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
            this.flpInventory.Size = new System.Drawing.Size(617, 314);
            this.flpInventory.TabIndex = 5;
            // 
            // cbBuilding
            // 
            this.cbBuilding.FormattingEnabled = true;
            this.cbBuilding.Location = new System.Drawing.Point(143, 37);
            this.cbBuilding.Name = "cbBuilding";
            this.cbBuilding.Size = new System.Drawing.Size(121, 21);
            this.cbBuilding.TabIndex = 6;
            this.cbBuilding.Tag = "";
            this.cbBuilding.Text = "Select Building";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(143, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear Filter";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnMainPage
            // 
            this.BtnMainPage.Location = new System.Drawing.Point(23, 8);
            this.BtnMainPage.Name = "BtnMainPage";
            this.BtnMainPage.Size = new System.Drawing.Size(75, 23);
            this.BtnMainPage.TabIndex = 8;
            this.BtnMainPage.Text = "Main Page";
            this.BtnMainPage.UseVisualStyleBackColor = true;
            this.BtnMainPage.Click += new System.EventHandler(this.BtnMainPage_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(546, 8);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 9;
            this.btnOrder.Text = "New Task";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // cbSkill
            // 
            this.cbSkill.FormattingEnabled = true;
            this.cbSkill.Location = new System.Drawing.Point(279, 37);
            this.cbSkill.Name = "cbSkill";
            this.cbSkill.Size = new System.Drawing.Size(121, 21);
            this.cbSkill.TabIndex = 10;
            this.cbSkill.Tag = "";
            this.cbSkill.Text = "Select Skill";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(419, 37);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 21);
            this.cbStatus.TabIndex = 11;
            this.cbStatus.Tag = "";
            this.cbStatus.Text = "Select Status";
            // 
            // Work
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 450);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cbSkill);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.BtnMainPage);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cbBuilding);
            this.Controls.Add(this.flpInventory);
            this.Controls.Add(this.btnSearch);
            this.Name = "Work";
            this.Text = "Work";
            this.Load += new System.EventHandler(this.Work_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel flpInventory;
        private System.Windows.Forms.ComboBox cbBuilding;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button BtnMainPage;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.ComboBox cbSkill;
        private System.Windows.Forms.ComboBox cbStatus;
    }
}