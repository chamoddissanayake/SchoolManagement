namespace SchoolManagementSystem
{
    partial class Academic_Staff_Summary_Of_Results
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Academic_Staff_Summary_Of_Results));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.helloMsg = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.goBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.term = new System.Windows.Forms.ComboBox();
            this.year = new System.Windows.Forms.ComboBox();
            this.generateSummary = new System.Windows.Forms.Button();
            this.AverageBySubjectChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AverageBySubjectChart)).BeginInit();
            this.SuspendLayout();
            // 
            // helloMsg
            // 
            this.helloMsg.AutoSize = true;
            this.helloMsg.BackColor = System.Drawing.Color.Transparent;
            this.helloMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helloMsg.Location = new System.Drawing.Point(224, 146);
            this.helloMsg.Name = "helloMsg";
            this.helloMsg.Size = new System.Drawing.Size(48, 20);
            this.helloMsg.TabIndex = 1;
            this.helloMsg.Text = "Hello";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Controls.Add(this.goBack);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(198, 1);
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
            this.goBack.Location = new System.Drawing.Point(784, 30);
            this.goBack.Name = "goBack";
            this.goBack.Size = new System.Drawing.Size(117, 29);
            this.goBack.TabIndex = 8;
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
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 653);
            this.panel1.TabIndex = 8;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Maroon;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Goldenrod;
            this.label5.Location = new System.Drawing.Point(4, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Summary of Results >";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(450, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(336, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Summary Of Results in your class";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Maroon;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Goldenrod;
            this.label11.Location = new System.Drawing.Point(6, 295);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Academic Staff ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Maroon;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Goldenrod;
            this.label7.Location = new System.Drawing.Point(7, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Manage Results  >";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Maroon;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Goldenrod;
            this.label9.Location = new System.Drawing.Point(6, 317);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Dashboard >";
            // 
            // term
            // 
            this.term.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.term.FormattingEnabled = true;
            this.term.Location = new System.Drawing.Point(534, 182);
            this.term.Name = "term";
            this.term.Size = new System.Drawing.Size(121, 24);
            this.term.TabIndex = 24;
            // 
            // year
            // 
            this.year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.year.FormattingEnabled = true;
            this.year.Location = new System.Drawing.Point(745, 182);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(121, 24);
            this.year.TabIndex = 25;
            this.year.SelectedIndexChanged += new System.EventHandler(this.year_SelectedIndexChanged);
            // 
            // generateSummary
            // 
            this.generateSummary.BackColor = System.Drawing.Color.SandyBrown;
            this.generateSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateSummary.Location = new System.Drawing.Point(918, 182);
            this.generateSummary.Name = "generateSummary";
            this.generateSummary.Size = new System.Drawing.Size(181, 35);
            this.generateSummary.TabIndex = 26;
            this.generateSummary.Text = "Generate Summary";
            this.generateSummary.UseVisualStyleBackColor = false;
            this.generateSummary.Click += new System.EventHandler(this.generateSummary_Click);
            // 
            // AverageBySubjectChart
            // 
            this.AverageBySubjectChart.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LabelStyle.Angle = 90;
            chartArea1.Name = "ChartArea1";
            this.AverageBySubjectChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.AverageBySubjectChart.Legends.Add(legend1);
            this.AverageBySubjectChart.Location = new System.Drawing.Point(205, 250);
            this.AverageBySubjectChart.Name = "AverageBySubjectChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "AverageMark";
            this.AverageBySubjectChart.Series.Add(series1);
            this.AverageBySubjectChart.Size = new System.Drawing.Size(920, 377);
            this.AverageBySubjectChart.TabIndex = 27;
            this.AverageBySubjectChart.Click += new System.EventHandler(this.AverageBySubjectChart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(482, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Term :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(697, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Year :";
            // 
            // Academic_Staff_Summary_Of_Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1137, 653);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AverageBySubjectChart);
            this.Controls.Add(this.generateSummary);
            this.Controls.Add(this.year);
            this.Controls.Add(this.term);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.helloMsg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Academic_Staff_Summary_Of_Results";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Academic_Staff_Summary_Of_Results";
            this.Load += new System.EventHandler(this.Academic_Staff_Summary_Of_Results_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AverageBySubjectChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label helloMsg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button goBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox term;
        private System.Windows.Forms.ComboBox year;
        private System.Windows.Forms.Button generateSummary;
        private System.Windows.Forms.DataVisualization.Charting.Chart AverageBySubjectChart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}