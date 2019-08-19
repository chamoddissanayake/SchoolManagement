namespace SchoolManagementSystem
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            this.helloMsg = new System.Windows.Forms.Label();
            this.logOut = new System.Windows.Forms.Button();
            this.Admin_Manage_Results = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Admin_Student_Management = new System.Windows.Forms.Button();
            this.Admin_Subject_Management = new System.Windows.Forms.Button();
            this.Admin_Staff_Management = new System.Windows.Forms.Button();
            this.Admin_Event_Management = new System.Windows.Forms.Button();
            this.Admin_OB_Management = new System.Windows.Forms.Button();
            this.Admin_Library_Management = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // helloMsg
            // 
            this.helloMsg.AutoSize = true;
            this.helloMsg.BackColor = System.Drawing.Color.Transparent;
            this.helloMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helloMsg.Location = new System.Drawing.Point(229, 129);
            this.helloMsg.Name = "helloMsg";
            this.helloMsg.Size = new System.Drawing.Size(48, 20);
            this.helloMsg.TabIndex = 0;
            this.helloMsg.Text = "Hello";
            // 
            // logOut
            // 
            this.logOut.BackColor = System.Drawing.Color.Chocolate;
            this.logOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOut.ForeColor = System.Drawing.Color.Goldenrod;
            this.logOut.Location = new System.Drawing.Point(827, 41);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(92, 30);
            this.logOut.TabIndex = 1;
            this.logOut.Text = "Log Out";
            this.logOut.UseVisualStyleBackColor = false;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // Admin_Manage_Results
            // 
            this.Admin_Manage_Results.BackColor = System.Drawing.Color.Transparent;
            this.Admin_Manage_Results.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Admin_Manage_Results.BackgroundImage")));
            this.Admin_Manage_Results.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Admin_Manage_Results.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Admin_Manage_Results.Font = new System.Drawing.Font("Mistral", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Admin_Manage_Results.Location = new System.Drawing.Point(279, 207);
            this.Admin_Manage_Results.Name = "Admin_Manage_Results";
            this.Admin_Manage_Results.Size = new System.Drawing.Size(157, 130);
            this.Admin_Manage_Results.TabIndex = 2;
            this.Admin_Manage_Results.UseVisualStyleBackColor = false;
            this.Admin_Manage_Results.Click += new System.EventHandler(this.Admin_Manage_Results_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 653);
            this.panel1.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Goldenrod;
            this.label11.Location = new System.Drawing.Point(5, 305);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "Admin Dashboard >";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 195);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.logOut);
            this.panel2.Location = new System.Drawing.Point(199, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(940, 100);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(151, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(536, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asoka College - School Management System";
            // 
            // Admin_Student_Management
            // 
            this.Admin_Student_Management.BackColor = System.Drawing.Color.Transparent;
            this.Admin_Student_Management.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Admin_Student_Management.BackgroundImage")));
            this.Admin_Student_Management.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Admin_Student_Management.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Admin_Student_Management.Font = new System.Drawing.Font("Mistral", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Admin_Student_Management.Location = new System.Drawing.Point(587, 129);
            this.Admin_Student_Management.Name = "Admin_Student_Management";
            this.Admin_Student_Management.Size = new System.Drawing.Size(157, 130);
            this.Admin_Student_Management.TabIndex = 5;
            this.Admin_Student_Management.UseVisualStyleBackColor = false;
            // 
            // Admin_Subject_Management
            // 
            this.Admin_Subject_Management.BackColor = System.Drawing.Color.Transparent;
            this.Admin_Subject_Management.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Admin_Subject_Management.BackgroundImage")));
            this.Admin_Subject_Management.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Admin_Subject_Management.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Admin_Subject_Management.Font = new System.Drawing.Font("Mistral", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Admin_Subject_Management.Location = new System.Drawing.Point(874, 207);
            this.Admin_Subject_Management.Name = "Admin_Subject_Management";
            this.Admin_Subject_Management.Size = new System.Drawing.Size(157, 130);
            this.Admin_Subject_Management.TabIndex = 6;
            this.Admin_Subject_Management.UseVisualStyleBackColor = false;
            // 
            // Admin_Staff_Management
            // 
            this.Admin_Staff_Management.BackColor = System.Drawing.Color.Transparent;
            this.Admin_Staff_Management.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Admin_Staff_Management.BackgroundImage")));
            this.Admin_Staff_Management.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Admin_Staff_Management.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Admin_Staff_Management.Font = new System.Drawing.Font("Mistral", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Admin_Staff_Management.Location = new System.Drawing.Point(279, 410);
            this.Admin_Staff_Management.Name = "Admin_Staff_Management";
            this.Admin_Staff_Management.Size = new System.Drawing.Size(157, 130);
            this.Admin_Staff_Management.TabIndex = 7;
            this.Admin_Staff_Management.UseVisualStyleBackColor = false;
            // 
            // Admin_Event_Management
            // 
            this.Admin_Event_Management.BackColor = System.Drawing.Color.Transparent;
            this.Admin_Event_Management.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Admin_Event_Management.BackgroundImage")));
            this.Admin_Event_Management.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Admin_Event_Management.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Admin_Event_Management.Font = new System.Drawing.Font("Mistral", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Admin_Event_Management.Location = new System.Drawing.Point(883, 388);
            this.Admin_Event_Management.Name = "Admin_Event_Management";
            this.Admin_Event_Management.Size = new System.Drawing.Size(157, 130);
            this.Admin_Event_Management.TabIndex = 8;
            this.Admin_Event_Management.UseVisualStyleBackColor = false;
            // 
            // Admin_OB_Management
            // 
            this.Admin_OB_Management.BackColor = System.Drawing.Color.Transparent;
            this.Admin_OB_Management.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Admin_OB_Management.BackgroundImage")));
            this.Admin_OB_Management.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Admin_OB_Management.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Admin_OB_Management.Font = new System.Drawing.Font("Mistral", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Admin_OB_Management.Location = new System.Drawing.Point(587, 458);
            this.Admin_OB_Management.Name = "Admin_OB_Management";
            this.Admin_OB_Management.Size = new System.Drawing.Size(157, 130);
            this.Admin_OB_Management.TabIndex = 9;
            this.Admin_OB_Management.UseVisualStyleBackColor = false;
            // 
            // Admin_Library_Management
            // 
            this.Admin_Library_Management.BackColor = System.Drawing.Color.Transparent;
            this.Admin_Library_Management.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Admin_Library_Management.BackgroundImage")));
            this.Admin_Library_Management.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Admin_Library_Management.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Admin_Library_Management.Font = new System.Drawing.Font("Mistral", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Admin_Library_Management.Location = new System.Drawing.Point(587, 287);
            this.Admin_Library_Management.Name = "Admin_Library_Management";
            this.Admin_Library_Management.Size = new System.Drawing.Size(157, 130);
            this.Admin_Library_Management.TabIndex = 10;
            this.Admin_Library_Management.UseVisualStyleBackColor = false;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1138, 649);
            this.Controls.Add(this.Admin_Library_Management);
            this.Controls.Add(this.Admin_OB_Management);
            this.Controls.Add(this.Admin_Event_Management);
            this.Controls.Add(this.Admin_Staff_Management);
            this.Controls.Add(this.Admin_Subject_Management);
            this.Controls.Add(this.Admin_Student_Management);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Admin_Manage_Results);
            this.Controls.Add(this.helloMsg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label helloMsg;
        private System.Windows.Forms.Button logOut;
        private System.Windows.Forms.Button Admin_Manage_Results;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Admin_Student_Management;
        private System.Windows.Forms.Button Admin_Subject_Management;
        private System.Windows.Forms.Button Admin_Staff_Management;
        private System.Windows.Forms.Button Admin_Event_Management;
        private System.Windows.Forms.Button Admin_OB_Management;
        private System.Windows.Forms.Button Admin_Library_Management;
    }
}