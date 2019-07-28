﻿namespace SchoolManagementSystem
{
    partial class Administrative_Staff_Marks_CRUD_Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administrative_Staff_Marks_CRUD_Dashboard));
            this.panel2 = new System.Windows.Forms.Panel();
            this.goBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.addMark = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.addResult_mark = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.addResult_Term = new System.Windows.Forms.ComboBox();
            this.addResult_ExamID = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addResult_Year = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.addResult_student = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.addResult_subject = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.addResult_class = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.deleteResult = new System.Windows.Forms.Button();
            this.dataGridView_Results_All_Students = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.SearchResultByStudentID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.refreshDatagridView = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Results_All_Students)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Controls.Add(this.goBack);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(198, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(940, 100);
            this.panel2.TabIndex = 9;
            // 
            // goBack
            // 
            this.goBack.BackColor = System.Drawing.Color.Chocolate;
            this.goBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBack.ForeColor = System.Drawing.Color.Goldenrod;
            this.goBack.Location = new System.Drawing.Point(799, 30);
            this.goBack.Name = "goBack";
            this.goBack.Size = new System.Drawing.Size(117, 29);
            this.goBack.TabIndex = 3;
            this.goBack.Text = "< Go Back";
            this.goBack.UseVisualStyleBackColor = false;
            this.goBack.Click += new System.EventHandler(this.goBack_Click);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 653);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Goldenrod;
            this.label2.Location = new System.Drawing.Point(4, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Search Marks >";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Goldenrod;
            this.label4.Location = new System.Drawing.Point(2, 360);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Add, Update, Delete";
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
            // addMark
            // 
            this.addMark.BackColor = System.Drawing.Color.Maroon;
            this.addMark.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addMark.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addMark.Location = new System.Drawing.Point(295, 489);
            this.addMark.Name = "addMark";
            this.addMark.Size = new System.Drawing.Size(204, 43);
            this.addMark.TabIndex = 33;
            this.addMark.Text = "Add | Update Result";
            this.addMark.UseVisualStyleBackColor = false;
            this.addMark.Click += new System.EventHandler(this.addMark_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.Location = new System.Drawing.Point(287, 442);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 17);
            this.label8.TabIndex = 32;
            this.label8.Text = "Mark";
            // 
            // addResult_mark
            // 
            this.addResult_mark.Location = new System.Drawing.Point(339, 442);
            this.addResult_mark.Name = "addResult_mark";
            this.addResult_mark.Size = new System.Drawing.Size(139, 22);
            this.addResult_mark.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(289, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 30;
            this.label7.Text = "Term";
            // 
            // addResult_Term
            // 
            this.addResult_Term.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addResult_Term.FormattingEnabled = true;
            this.addResult_Term.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.addResult_Term.Location = new System.Drawing.Point(339, 356);
            this.addResult_Term.Name = "addResult_Term";
            this.addResult_Term.Size = new System.Drawing.Size(139, 24);
            this.addResult_Term.TabIndex = 29;
            // 
            // addResult_ExamID
            // 
            this.addResult_ExamID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addResult_ExamID.FormattingEnabled = true;
            this.addResult_ExamID.Location = new System.Drawing.Point(339, 313);
            this.addResult_ExamID.Name = "addResult_ExamID";
            this.addResult_ExamID.Size = new System.Drawing.Size(139, 24);
            this.addResult_ExamID.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(271, 316);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Exam ID";
            // 
            // addResult_Year
            // 
            this.addResult_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addResult_Year.FormattingEnabled = true;
            this.addResult_Year.Location = new System.Drawing.Point(339, 274);
            this.addResult_Year.Name = "addResult_Year";
            this.addResult_Year.Size = new System.Drawing.Size(139, 24);
            this.addResult_Year.TabIndex = 26;
            this.addResult_Year.SelectedIndexChanged += new System.EventHandler(this.addResult_Year_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(292, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 17);
            this.label9.TabIndex = 25;
            this.label9.Text = "Year";
            // 
            // addResult_student
            // 
            this.addResult_student.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addResult_student.FormattingEnabled = true;
            this.addResult_student.Location = new System.Drawing.Point(339, 400);
            this.addResult_student.Name = "addResult_student";
            this.addResult_student.Size = new System.Drawing.Size(139, 24);
            this.addResult_student.TabIndex = 24;
            this.addResult_student.SelectedIndexChanged += new System.EventHandler(this.addResult_student_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(230, 400);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "Select Student";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(232, 243);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "Select Subject";
            // 
            // addResult_subject
            // 
            this.addResult_subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addResult_subject.FormattingEnabled = true;
            this.addResult_subject.Location = new System.Drawing.Point(336, 240);
            this.addResult_subject.Name = "addResult_subject";
            this.addResult_subject.Size = new System.Drawing.Size(142, 24);
            this.addResult_subject.TabIndex = 21;
            this.addResult_subject.SelectedIndexChanged += new System.EventHandler(this.addResult_subject_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(245, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "Select Class";
            // 
            // addResult_class
            // 
            this.addResult_class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addResult_class.FormattingEnabled = true;
            this.addResult_class.Location = new System.Drawing.Point(336, 200);
            this.addResult_class.Name = "addResult_class";
            this.addResult_class.Size = new System.Drawing.Size(142, 24);
            this.addResult_class.TabIndex = 19;
            this.addResult_class.SelectedIndexChanged += new System.EventHandler(this.addResult_class_SelectedIndexChanged);
            this.addResult_class.SelectedValueChanged += new System.EventHandler(this.addResult_class_SelectedValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(256, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(257, 20);
            this.label13.TabIndex = 18;
            this.label13.Text = "Add | Update Student Results";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // deleteResult
            // 
            this.deleteResult.BackColor = System.Drawing.Color.Maroon;
            this.deleteResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteResult.ForeColor = System.Drawing.Color.White;
            this.deleteResult.Location = new System.Drawing.Point(295, 538);
            this.deleteResult.Name = "deleteResult";
            this.deleteResult.Size = new System.Drawing.Size(204, 42);
            this.deleteResult.TabIndex = 34;
            this.deleteResult.Text = "Delete Result";
            this.deleteResult.UseVisualStyleBackColor = false;
            this.deleteResult.Click += new System.EventHandler(this.deleteResult_Click);
            // 
            // dataGridView_Results_All_Students
            // 
            this.dataGridView_Results_All_Students.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Results_All_Students.Location = new System.Drawing.Point(522, 234);
            this.dataGridView_Results_All_Students.Name = "dataGridView_Results_All_Students";
            this.dataGridView_Results_All_Students.RowTemplate.Height = 24;
            this.dataGridView_Results_All_Students.Size = new System.Drawing.Size(592, 346);
            this.dataGridView_Results_All_Students.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(653, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(387, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Search Results Of Any Student In the School";
            // 
            // SearchResultByStudentID
            // 
            this.SearchResultByStudentID.Location = new System.Drawing.Point(756, 195);
            this.SearchResultByStudentID.Name = "SearchResultByStudentID";
            this.SearchResultByStudentID.Size = new System.Drawing.Size(210, 22);
            this.SearchResultByStudentID.TabIndex = 37;
            this.SearchResultByStudentID.TextChanged += new System.EventHandler(this.SearchResultByStudentID_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(668, 200);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 17);
            this.label14.TabIndex = 38;
            this.label14.Text = "Student ID :";
            // 
            // refreshDatagridView
            // 
            this.refreshDatagridView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refreshDatagridView.BackgroundImage")));
            this.refreshDatagridView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshDatagridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshDatagridView.Location = new System.Drawing.Point(1079, 182);
            this.refreshDatagridView.Name = "refreshDatagridView";
            this.refreshDatagridView.Size = new System.Drawing.Size(35, 35);
            this.refreshDatagridView.TabIndex = 39;
            this.refreshDatagridView.UseVisualStyleBackColor = true;
            this.refreshDatagridView.Click += new System.EventHandler(this.refreshDatagridView_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Maroon;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Goldenrod;
            this.label15.Location = new System.Drawing.Point(0, 316);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 18);
            this.label15.TabIndex = 42;
            this.label15.Text = "Dashboard >";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Maroon;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Goldenrod;
            this.label16.Location = new System.Drawing.Point(3, 339);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(144, 18);
            this.label16.TabIndex = 40;
            this.label16.Text = "Manage Results >";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Maroon;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Goldenrod;
            this.label17.Location = new System.Drawing.Point(0, 294);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(153, 18);
            this.label17.TabIndex = 41;
            this.label17.Text = "Administrative Staff";
            // 
            // Administrative_Staff_Marks_CRUD_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1136, 653);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.refreshDatagridView);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.SearchResultByStudentID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView_Results_All_Students);
            this.Controls.Add(this.deleteResult);
            this.Controls.Add(this.addMark);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.addResult_mark);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.addResult_Term);
            this.Controls.Add(this.addResult_ExamID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.addResult_Year);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.addResult_student);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.addResult_subject);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.addResult_class);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Administrative_Staff_Marks_CRUD_Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrative_Staff_Marks_CRUD_Dashboard";
            this.Load += new System.EventHandler(this.Administrative_Staff_Marks_CRUD_Dashboard_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Results_All_Students)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button goBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button addMark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox addResult_mark;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox addResult_Term;
        private System.Windows.Forms.ComboBox addResult_ExamID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox addResult_Year;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox addResult_student;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox addResult_subject;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox addResult_class;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button deleteResult;
        private System.Windows.Forms.DataGridView dataGridView_Results_All_Students;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SearchResultByStudentID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button refreshDatagridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}