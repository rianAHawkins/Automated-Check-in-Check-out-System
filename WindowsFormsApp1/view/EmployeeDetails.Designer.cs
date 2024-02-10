namespace WindowsFormsApp1
{
    partial class EmployeeDetails
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
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.txtPass1 = new System.Windows.Forms.TextBox();
            this.lblPass1 = new System.Windows.Forms.Label();
            this.txtPass2 = new System.Windows.Forms.TextBox();
            this.lblPass2 = new System.Windows.Forms.Label();
            this.flpRoles = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeID.Location = new System.Drawing.Point(23, 42);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(96, 20);
            this.lblEmployeeID.TabIndex = 0;
            this.lblEmployeeID.Text = "EmployeeID";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeID.Location = new System.Drawing.Point(27, 66);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(236, 26);
            this.txtEmployeeID.TabIndex = 1;
            // 
            // txtPass1
            // 
            this.txtPass1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass1.Location = new System.Drawing.Point(27, 135);
            this.txtPass1.Name = "txtPass1";
            this.txtPass1.Size = new System.Drawing.Size(236, 26);
            this.txtPass1.TabIndex = 3;
            // 
            // lblPass1
            // 
            this.lblPass1.AutoSize = true;
            this.lblPass1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass1.Location = new System.Drawing.Point(23, 111);
            this.lblPass1.Name = "lblPass1";
            this.lblPass1.Size = new System.Drawing.Size(78, 20);
            this.lblPass1.TabIndex = 2;
            this.lblPass1.Text = "Password";
            // 
            // txtPass2
            // 
            this.txtPass2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass2.Location = new System.Drawing.Point(27, 206);
            this.txtPass2.Name = "txtPass2";
            this.txtPass2.Size = new System.Drawing.Size(236, 26);
            this.txtPass2.TabIndex = 5;
            // 
            // lblPass2
            // 
            this.lblPass2.AutoSize = true;
            this.lblPass2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass2.Location = new System.Drawing.Point(23, 182);
            this.lblPass2.Name = "lblPass2";
            this.lblPass2.Size = new System.Drawing.Size(113, 20);
            this.lblPass2.TabIndex = 4;
            this.lblPass2.Text = "New Password";
            // 
            // flpRoles
            // 
            this.flpRoles.Location = new System.Drawing.Point(302, 66);
            this.flpRoles.Name = "flpRoles";
            this.flpRoles.Size = new System.Drawing.Size(186, 301);
            this.flpRoles.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(27, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 40);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(165, 287);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(98, 40);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // EmployeeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 379);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.flpRoles);
            this.Controls.Add(this.txtPass2);
            this.Controls.Add(this.lblPass2);
            this.Controls.Add(this.txtPass1);
            this.Controls.Add(this.lblPass1);
            this.Controls.Add(this.txtEmployeeID);
            this.Controls.Add(this.lblEmployeeID);
            this.Name = "EmployeeDetails";
            this.Text = "EmployeeDetails";
            this.Load += new System.EventHandler(this.EmployeeDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.TextBox txtPass1;
        private System.Windows.Forms.Label lblPass1;
        private System.Windows.Forms.TextBox txtPass2;
        private System.Windows.Forms.Label lblPass2;
        private System.Windows.Forms.FlowLayoutPanel flpRoles;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
    }
}