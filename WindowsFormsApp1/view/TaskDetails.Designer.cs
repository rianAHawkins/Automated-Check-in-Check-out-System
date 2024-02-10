namespace WindowsFormsApp1.view
{
    partial class TaskDetails
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
            this.lblTaskID = new System.Windows.Forms.Label();
            this.cbBuilding = new System.Windows.Forms.ComboBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbSkill = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTaskID
            // 
            this.lblTaskID.AutoSize = true;
            this.lblTaskID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskID.Location = new System.Drawing.Point(149, 7);
            this.lblTaskID.Name = "lblTaskID";
            this.lblTaskID.Size = new System.Drawing.Size(43, 20);
            this.lblTaskID.TabIndex = 0;
            this.lblTaskID.Text = "Task";
            // 
            // cbBuilding
            // 
            this.cbBuilding.FormattingEnabled = true;
            this.cbBuilding.Location = new System.Drawing.Point(40, 30);
            this.cbBuilding.Name = "cbBuilding";
            this.cbBuilding.Size = new System.Drawing.Size(121, 21);
            this.cbBuilding.TabIndex = 7;
            this.cbBuilding.Tag = "";
            this.cbBuilding.Text = "Select Building";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(131, 71);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(89, 20);
            this.lblDesc.TabIndex = 8;
            this.lblDesc.Text = "Description";
            // 
            // txtDesc
            // 
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(40, 94);
            this.txtDesc.MaxLength = 100;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(307, 163);
            this.txtDesc.TabIndex = 9;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(231, 339);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(116, 43);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(110, 281);
            this.txtAddress.MaxLength = 50;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(237, 26);
            this.txtAddress.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Address";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(40, 339);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 43);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbSkill
            // 
            this.cbSkill.FormattingEnabled = true;
            this.cbSkill.Location = new System.Drawing.Point(226, 30);
            this.cbSkill.Name = "cbSkill";
            this.cbSkill.Size = new System.Drawing.Size(121, 21);
            this.cbSkill.TabIndex = 14;
            this.cbSkill.Tag = "";
            this.cbSkill.Text = "Select Skill";
            // 
            // TaskDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 409);
            this.Controls.Add(this.cbSkill);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.cbBuilding);
            this.Controls.Add(this.lblTaskID);
            this.Name = "TaskDetails";
            this.Text = "TaskDetails";
            this.Load += new System.EventHandler(this.TaskDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTaskID;
        private System.Windows.Forms.ComboBox cbBuilding;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbSkill;
    }
}