﻿namespace SchoolManagementSystem
{
    partial class Admin_ManageResults_Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_ManageResults_Dashboard));
            this.helloMsg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.addResult_class = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addResult_subject = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.addResult_student = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addResult_Year = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addResult_ExamID = new System.Windows.Forms.ComboBox();
            this.addResult_Term = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.addResult_mark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.addMark = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.SearchStudent = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.deleteRes = new System.Windows.Forms.Button();
            this.updateRes = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // helloMsg
            // 
            this.helloMsg.AutoSize = true;
            this.helloMsg.BackColor = System.Drawing.Color.Transparent;
            this.helloMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helloMsg.Location = new System.Drawing.Point(216, 124);
            this.helloMsg.Name = "helloMsg";
            this.helloMsg.Size = new System.Drawing.Size(48, 20);
            this.helloMsg.TabIndex = 0;
            this.helloMsg.Text = "Hello";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(275, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Student Results";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Chocolate;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Goldenrod;
            this.button1.Location = new System.Drawing.Point(791, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "< Go Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addResult_class
            // 
            this.addResult_class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addResult_class.FormattingEnabled = true;
            this.addResult_class.Location = new System.Drawing.Point(322, 258);
            this.addResult_class.Name = "addResult_class";
            this.addResult_class.Size = new System.Drawing.Size(142, 24);
            this.addResult_class.TabIndex = 3;
            this.addResult_class.SelectedIndexChanged += new System.EventHandler(this.addResult_class_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(231, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Class";
            // 
            // addResult_subject
            // 
            this.addResult_subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addResult_subject.FormattingEnabled = true;
            this.addResult_subject.Location = new System.Drawing.Point(322, 298);
            this.addResult_subject.Name = "addResult_subject";
            this.addResult_subject.Size = new System.Drawing.Size(142, 24);
            this.addResult_subject.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(218, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Select Subject";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(216, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Select Student";
            // 
            // addResult_student
            // 
            this.addResult_student.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addResult_student.FormattingEnabled = true;
            this.addResult_student.Location = new System.Drawing.Point(325, 458);
            this.addResult_student.Name = "addResult_student";
            this.addResult_student.Size = new System.Drawing.Size(139, 24);
            this.addResult_student.TabIndex = 8;
            this.addResult_student.SelectedIndexChanged += new System.EventHandler(this.addResult_student_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(278, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Year";
            // 
            // addResult_Year
            // 
            this.addResult_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addResult_Year.FormattingEnabled = true;
            this.addResult_Year.Location = new System.Drawing.Point(325, 332);
            this.addResult_Year.Name = "addResult_Year";
            this.addResult_Year.Size = new System.Drawing.Size(139, 24);
            this.addResult_Year.TabIndex = 10;
            this.addResult_Year.SelectedIndexChanged += new System.EventHandler(this.addResult_Year_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(257, 374);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Exam ID";
            // 
            // addResult_ExamID
            // 
            this.addResult_ExamID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addResult_ExamID.FormattingEnabled = true;
            this.addResult_ExamID.Location = new System.Drawing.Point(325, 371);
            this.addResult_ExamID.Name = "addResult_ExamID";
            this.addResult_ExamID.Size = new System.Drawing.Size(139, 24);
            this.addResult_ExamID.TabIndex = 12;
            // 
            // addResult_Term
            // 
            this.addResult_Term.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addResult_Term.FormattingEnabled = true;
            this.addResult_Term.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.addResult_Term.Location = new System.Drawing.Point(325, 414);
            this.addResult_Term.Name = "addResult_Term";
            this.addResult_Term.Size = new System.Drawing.Size(139, 24);
            this.addResult_Term.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(275, 414);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Term";
            // 
            // addResult_mark
            // 
            this.addResult_mark.Location = new System.Drawing.Point(325, 500);
            this.addResult_mark.Name = "addResult_mark";
            this.addResult_mark.Size = new System.Drawing.Size(139, 22);
            this.addResult_mark.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.Location = new System.Drawing.Point(273, 500);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Mark";
            // 
            // addMark
            // 
            this.addMark.BackColor = System.Drawing.Color.Maroon;
            this.addMark.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addMark.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addMark.Location = new System.Drawing.Point(307, 546);
            this.addMark.Name = "addMark";
            this.addMark.Size = new System.Drawing.Size(157, 43);
            this.addMark.TabIndex = 17;
            this.addMark.Text = "Submit Result";
            this.addMark.UseVisualStyleBackColor = false;
            this.addMark.Click += new System.EventHandler(this.addMark_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(570, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Search Result";
            // 
            // SearchStudent
            // 
            this.SearchStudent.BackColor = System.Drawing.Color.Maroon;
            this.SearchStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchStudent.ForeColor = System.Drawing.Color.White;
            this.SearchStudent.Location = new System.Drawing.Point(523, 258);
            this.SearchStudent.Name = "SearchStudent";
            this.SearchStudent.Size = new System.Drawing.Size(294, 34);
            this.SearchStudent.TabIndex = 21;
            this.SearchStudent.Text = "Search Result of a Student ";
            this.SearchStudent.UseVisualStyleBackColor = false;
            this.SearchStudent.Click += new System.EventHandler(this.SearchStudent_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 653);
            this.panel1.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Goldenrod;
            this.label10.Location = new System.Drawing.Point(0, 335);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 18);
            this.label10.TabIndex = 7;
            this.label10.Text = "Results Management";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Goldenrod;
            this.label11.Location = new System.Drawing.Point(0, 311);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "Admin Dashboard >";
            this.label11.Click += new System.EventHandler(this.label11_Click);
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
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(940, 100);
            this.panel2.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Goldenrod;
            this.label12.Location = new System.Drawing.Point(151, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(536, 29);
            this.label12.TabIndex = 0;
            this.label12.Text = "Asoka College - School Management System";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(560, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(257, 29);
            this.label13.TabIndex = 24;
            this.label13.Text = "Results Management";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList3
            // 
            this.imageList3.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList3.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(826, 113);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.TabIndex = 26;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(495, 115);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(523, 306);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(585, 283);
            this.dataGridView1.TabIndex = 28;
            // 
            // deleteRes
            // 
            this.deleteRes.BackColor = System.Drawing.Color.Maroon;
            this.deleteRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteRes.ForeColor = System.Drawing.Color.White;
            this.deleteRes.Location = new System.Drawing.Point(535, 604);
            this.deleteRes.Name = "deleteRes";
            this.deleteRes.Size = new System.Drawing.Size(290, 35);
            this.deleteRes.TabIndex = 29;
            this.deleteRes.Text = "Delete Results of Selected Student";
            this.deleteRes.UseVisualStyleBackColor = false;
            this.deleteRes.Click += new System.EventHandler(this.deleteRes_Click);
            // 
            // updateRes
            // 
            this.updateRes.BackColor = System.Drawing.Color.Maroon;
            this.updateRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateRes.ForeColor = System.Drawing.Color.White;
            this.updateRes.Location = new System.Drawing.Point(832, 604);
            this.updateRes.Name = "updateRes";
            this.updateRes.Size = new System.Drawing.Size(276, 35);
            this.updateRes.TabIndex = 30;
            this.updateRes.Text = "Update Results of Selected Student";
            this.updateRes.UseVisualStyleBackColor = false;
            this.updateRes.Click += new System.EventHandler(this.updateRes_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(1071, 265);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 35);
            this.button2.TabIndex = 31;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Admin_ManageResults_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1141, 651);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.updateRes);
            this.Controls.Add(this.deleteRes);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SearchStudent);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.addMark);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.addResult_mark);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.addResult_Term);
            this.Controls.Add(this.addResult_ExamID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.addResult_Year);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addResult_student);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addResult_subject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addResult_class);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.helloMsg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin_ManageResults_Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin-ManageResults";
            this.Load += new System.EventHandler(this.Admin_ManageResults_Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label helloMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox addResult_class;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox addResult_subject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox addResult_student;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox addResult_Year;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox addResult_ExamID;
        private System.Windows.Forms.ComboBox addResult_Term;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox addResult_mark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button addMark;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button SearchStudent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button deleteRes;
        private System.Windows.Forms.Button updateRes;
        private System.Windows.Forms.Button button2;
        // private System.Windows.Forms.PictureBox refresh;
    }
}