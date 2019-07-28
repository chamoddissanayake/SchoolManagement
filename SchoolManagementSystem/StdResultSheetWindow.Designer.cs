

namespace SchoolManagementSystem
{
    partial class StdResultSheetWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StdResultSheetWindow));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.SearchResultByStudentID = new System.Windows.Forms.Button();
            this.studentIDForSearchResult = new System.Windows.Forms.TextBox();
            this.studentID = new System.Windows.Forms.Label();
            this.fName = new System.Windows.Forms.Label();
            this.mName = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.Label();
            this.dataGridViewResultSheet = new System.Windows.Forms.DataGridView();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblMName = new System.Windows.Forms.Label();
            this.lblLName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.studentGrade = new System.Windows.Forms.ComboBox();
            this.showChart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.saveResult = new System.Windows.Forms.Button();
            this.term = new System.Windows.Forms.ComboBox();
            this.studentResultChartByGradeAndTerm = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentResultChartByGradeAndTerm)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchResultByStudentID
            // 
            this.SearchResultByStudentID.BackColor = System.Drawing.Color.Chocolate;
            this.SearchResultByStudentID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchResultByStudentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchResultByStudentID.ForeColor = System.Drawing.Color.White;
            this.SearchResultByStudentID.Location = new System.Drawing.Point(468, 213);
            this.SearchResultByStudentID.Name = "SearchResultByStudentID";
            this.SearchResultByStudentID.Size = new System.Drawing.Size(96, 33);
            this.SearchResultByStudentID.TabIndex = 0;
            this.SearchResultByStudentID.Text = "Search";
            this.SearchResultByStudentID.UseVisualStyleBackColor = false;
            this.SearchResultByStudentID.Click += new System.EventHandler(this.SearchResultByStudentID_Click);
            // 
            // studentIDForSearchResult
            // 
            this.studentIDForSearchResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentIDForSearchResult.Location = new System.Drawing.Point(285, 213);
            this.studentIDForSearchResult.Name = "studentIDForSearchResult";
            this.studentIDForSearchResult.Size = new System.Drawing.Size(165, 27);
            this.studentIDForSearchResult.TabIndex = 1;
            this.studentIDForSearchResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.studentIDForSearchResult_KeyDown);
            // 
            // studentID
            // 
            this.studentID.AutoSize = true;
            this.studentID.BackColor = System.Drawing.Color.Transparent;
            this.studentID.ForeColor = System.Drawing.Color.Goldenrod;
            this.studentID.Location = new System.Drawing.Point(228, 253);
            this.studentID.Name = "studentID";
            this.studentID.Size = new System.Drawing.Size(68, 17);
            this.studentID.TabIndex = 2;
            this.studentID.Text = "studentID";
            // 
            // fName
            // 
            this.fName.AutoSize = true;
            this.fName.BackColor = System.Drawing.Color.Transparent;
            this.fName.ForeColor = System.Drawing.Color.Goldenrod;
            this.fName.Location = new System.Drawing.Point(228, 282);
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(49, 17);
            this.fName.TabIndex = 3;
            this.fName.Text = "fName";
            // 
            // mName
            // 
            this.mName.AutoSize = true;
            this.mName.BackColor = System.Drawing.Color.Transparent;
            this.mName.ForeColor = System.Drawing.Color.Goldenrod;
            this.mName.Location = new System.Drawing.Point(228, 314);
            this.mName.Name = "mName";
            this.mName.Size = new System.Drawing.Size(56, 17);
            this.mName.TabIndex = 4;
            this.mName.Text = "mName";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.BackColor = System.Drawing.Color.Transparent;
            this.lName.ForeColor = System.Drawing.Color.Goldenrod;
            this.lName.Location = new System.Drawing.Point(229, 345);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(48, 17);
            this.lName.TabIndex = 5;
            this.lName.Text = "lName";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.BackColor = System.Drawing.Color.Transparent;
            this.email.ForeColor = System.Drawing.Color.Goldenrod;
            this.email.Location = new System.Drawing.Point(229, 376);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(42, 17);
            this.email.TabIndex = 6;
            this.email.Text = "Email";
            // 
            // dataGridViewResultSheet
            // 
            this.dataGridViewResultSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResultSheet.Location = new System.Drawing.Point(16, 409);
            this.dataGridViewResultSheet.Name = "dataGridViewResultSheet";
            this.dataGridViewResultSheet.RowTemplate.Height = 24;
            this.dataGridViewResultSheet.Size = new System.Drawing.Size(849, 233);
            this.dataGridViewResultSheet.TabIndex = 7;
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.BackColor = System.Drawing.Color.Transparent;
            this.lblStudentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentID.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblStudentID.Location = new System.Drawing.Point(71, 253);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(96, 18);
            this.lblStudentID.TabIndex = 8;
            this.lblStudentID.Text = "Student ID :";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblFirstName.Location = new System.Drawing.Point(71, 280);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(101, 18);
            this.lblFirstName.TabIndex = 9;
            this.lblFirstName.Text = "First Name :";
            // 
            // lblMName
            // 
            this.lblMName.AutoSize = true;
            this.lblMName.BackColor = System.Drawing.Color.Transparent;
            this.lblMName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMName.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblMName.Location = new System.Drawing.Point(71, 312);
            this.lblMName.Name = "lblMName";
            this.lblMName.Size = new System.Drawing.Size(116, 18);
            this.lblMName.TabIndex = 10;
            this.lblMName.Text = "Middle Name :";
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.BackColor = System.Drawing.Color.Transparent;
            this.lblLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLName.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblLName.Location = new System.Drawing.Point(71, 343);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(99, 18);
            this.lblLName.TabIndex = 11;
            this.lblLName.Text = "Last Name :";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblEmail.Location = new System.Drawing.Point(71, 374);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(60, 18);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "Email :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(329, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(169, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // studentGrade
            // 
            this.studentGrade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.studentGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.studentGrade.FormattingEnabled = true;
            this.studentGrade.Location = new System.Drawing.Point(11, 659);
            this.studentGrade.Name = "studentGrade";
            this.studentGrade.Size = new System.Drawing.Size(121, 24);
            this.studentGrade.TabIndex = 14;
            this.studentGrade.SelectedIndexChanged += new System.EventHandler(this.studentGrade_SelectedIndexChanged);
            // 
            // showChart
            // 
            this.showChart.BackColor = System.Drawing.Color.Goldenrod;
            this.showChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showChart.ForeColor = System.Drawing.Color.White;
            this.showChart.Location = new System.Drawing.Point(285, 663);
            this.showChart.Name = "showChart";
            this.showChart.Size = new System.Drawing.Size(575, 31);
            this.showChart.TabIndex = 15;
            this.showChart.Text = "Show Summary Of Results In Chart";
            this.showChart.UseVisualStyleBackColor = false;
            this.showChart.Click += new System.EventHandler(this.showChart_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Chocolate;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Goldenrod;
            this.button1.Location = new System.Drawing.Point(748, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 29);
            this.button1.TabIndex = 16;
            this.button1.Text = "< Go Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveResult
            // 
            this.saveResult.BackColor = System.Drawing.Color.Chocolate;
            this.saveResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveResult.ForeColor = System.Drawing.Color.White;
            this.saveResult.Location = new System.Drawing.Point(607, 348);
            this.saveResult.Name = "saveResult";
            this.saveResult.Size = new System.Drawing.Size(253, 33);
            this.saveResult.TabIndex = 17;
            this.saveResult.Text = "Save Result Sheet As PDF";
            this.saveResult.UseVisualStyleBackColor = false;
            this.saveResult.Click += new System.EventHandler(this.saveResult_Click);
            // 
            // term
            // 
            this.term.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.term.FormattingEnabled = true;
            this.term.Location = new System.Drawing.Point(156, 663);
            this.term.Name = "term";
            this.term.Size = new System.Drawing.Size(121, 24);
            this.term.TabIndex = 18;
            // 
            // studentResultChartByGradeAndTerm
            // 
            chartArea1.Name = "ChartArea1";
            this.studentResultChartByGradeAndTerm.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.studentResultChartByGradeAndTerm.Legends.Add(legend1);
            this.studentResultChartByGradeAndTerm.Location = new System.Drawing.Point(51, 717);
            this.studentResultChartByGradeAndTerm.Name = "studentResultChartByGradeAndTerm";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Mark";
            this.studentResultChartByGradeAndTerm.Series.Add(series1);
            this.studentResultChartByGradeAndTerm.Size = new System.Drawing.Size(757, 240);
            this.studentResultChartByGradeAndTerm.TabIndex = 19;
            this.studentResultChartByGradeAndTerm.Text = "chart1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Goldenrod;
            this.label10.Location = new System.Drawing.Point(193, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(202, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Results Management >";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Goldenrod;
            this.label11.Location = new System.Drawing.Point(12, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Admin Dashboard >";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Goldenrod;
            this.label1.Location = new System.Drawing.Point(401, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Student Result Sheet";
            // 
            // StdResultSheetWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(882, 713);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.studentResultChartByGradeAndTerm);
            this.Controls.Add(this.term);
            this.Controls.Add(this.saveResult);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.showChart);
            this.Controls.Add(this.studentGrade);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblLName);
            this.Controls.Add(this.lblMName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.dataGridViewResultSheet);
            this.Controls.Add(this.email);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.mName);
            this.Controls.Add(this.fName);
            this.Controls.Add(this.studentID);
            this.Controls.Add(this.studentIDForSearchResult);
            this.Controls.Add(this.SearchResultByStudentID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StdResultSheetWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Student Result Sheet";
            this.Load += new System.EventHandler(this.StdResultSheetWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentResultChartByGradeAndTerm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SearchResultByStudentID;
        private System.Windows.Forms.TextBox studentIDForSearchResult;
        private System.Windows.Forms.Label studentID;
        private System.Windows.Forms.Label fName;
        private System.Windows.Forms.Label mName;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.DataGridView dataGridViewResultSheet;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblMName;
        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox studentGrade;
        private System.Windows.Forms.Button showChart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button saveResult;
        private System.Windows.Forms.ComboBox term;
        private System.Windows.Forms.DataVisualization.Charting.Chart studentResultChartByGradeAndTerm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
    }
}