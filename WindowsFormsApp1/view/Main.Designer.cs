namespace WindowsFormsApp1
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTask = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAnnouncements = new System.Windows.Forms.Label();
            this.lblEID = new System.Windows.Forms.Label();
            this.txtAnouncements = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiView});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiView
            // 
            this.tsmiView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiInventory,
            this.tsmiTask,
            this.tsmiSystem});
            this.tsmiView.Name = "tsmiView";
            this.tsmiView.Size = new System.Drawing.Size(43, 20);
            this.tsmiView.Text = "view";
            // 
            // tsmiInventory
            // 
            this.tsmiInventory.Name = "tsmiInventory";
            this.tsmiInventory.Size = new System.Drawing.Size(124, 22);
            this.tsmiInventory.Text = "Inventory";
            this.tsmiInventory.Click += new System.EventHandler(this.tsmiInventory_Click);
            // 
            // tsmiTask
            // 
            this.tsmiTask.Name = "tsmiTask";
            this.tsmiTask.Size = new System.Drawing.Size(124, 22);
            this.tsmiTask.Text = "Task";
            this.tsmiTask.Click += new System.EventHandler(this.tsmiTask_Click);
            // 
            // tsmiSystem
            // 
            this.tsmiSystem.Name = "tsmiSystem";
            this.tsmiSystem.Size = new System.Drawing.Size(124, 22);
            this.tsmiSystem.Text = "System";
            this.tsmiSystem.Click += new System.EventHandler(this.tsmiSystem_Click);
            // 
            // lblAnnouncements
            // 
            this.lblAnnouncements.AutoSize = true;
            this.lblAnnouncements.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnnouncements.Location = new System.Drawing.Point(250, 36);
            this.lblAnnouncements.Name = "lblAnnouncements";
            this.lblAnnouncements.Size = new System.Drawing.Size(268, 39);
            this.lblAnnouncements.TabIndex = 1;
            this.lblAnnouncements.Text = "Announcements";
            // 
            // lblEID
            // 
            this.lblEID.AutoSize = true;
            this.lblEID.Location = new System.Drawing.Point(653, 10);
            this.lblEID.Name = "lblEID";
            this.lblEID.Size = new System.Drawing.Size(28, 13);
            this.lblEID.TabIndex = 2;
            this.lblEID.Text = "EID:";
            // 
            // txtAnouncements
            // 
            this.txtAnouncements.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnouncements.Location = new System.Drawing.Point(174, 90);
            this.txtAnouncements.Multiline = true;
            this.txtAnouncements.Name = "txtAnouncements";
            this.txtAnouncements.ReadOnly = true;
            this.txtAnouncements.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAnouncements.Size = new System.Drawing.Size(441, 263);
            this.txtAnouncements.TabIndex = 3;
            this.txtAnouncements.Text = "Testing text";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtAnouncements);
            this.Controls.Add(this.lblEID);
            this.Controls.Add(this.lblAnnouncements);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiInventory;
        private System.Windows.Forms.ToolStripMenuItem tsmiTask;
        private System.Windows.Forms.ToolStripMenuItem tsmiSystem;
        private System.Windows.Forms.Label lblAnnouncements;
        private System.Windows.Forms.Label lblEID;
        private System.Windows.Forms.TextBox txtAnouncements;
    }
}