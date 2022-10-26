namespace LPR281ASS1
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chr1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnConstraints = new System.Windows.Forms.Button();
            this.btnArea = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dgvConstraints = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMinMax = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCx = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCy = new System.Windows.Forms.Label();
            this.lblOptimalZ = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.dgvPoints = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtx1 = new System.Windows.Forms.RichTextBox();
            this.btnRefactor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudC1 = new System.Windows.Forms.NumericUpDown();
            this.nudC2 = new System.Windows.Forms.NumericUpDown();
            this.labY = new System.Windows.Forms.Label();
            this.labOptimal = new System.Windows.Forms.Label();
            this.labC2 = new System.Windows.Forms.Label();
            this.LabX = new System.Windows.Forms.Label();
            this.labC1 = new System.Windows.Forms.Label();
            this.labZ = new System.Windows.Forms.Label();
            this.labType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstraints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudC1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudC2)).BeginInit();
            this.SuspendLayout();
            // 
            // chr1
            // 
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chr1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chr1.Legends.Add(legend1);
            this.chr1.Location = new System.Drawing.Point(13, 10);
            this.chr1.Name = "chr1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chr1.Series.Add(series1);
            this.chr1.Size = new System.Drawing.Size(780, 423);
            this.chr1.TabIndex = 0;
            this.chr1.Text = "chart1";
            // 
            // btnConstraints
            // 
            this.btnConstraints.Enabled = false;
            this.btnConstraints.Location = new System.Drawing.Point(135, 439);
            this.btnConstraints.Name = "btnConstraints";
            this.btnConstraints.Size = new System.Drawing.Size(102, 38);
            this.btnConstraints.TabIndex = 1;
            this.btnConstraints.Text = "Plot Constraints";
            this.btnConstraints.UseVisualStyleBackColor = true;
            this.btnConstraints.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnArea
            // 
            this.btnArea.Enabled = false;
            this.btnArea.Location = new System.Drawing.Point(243, 439);
            this.btnArea.Name = "btnArea";
            this.btnArea.Size = new System.Drawing.Size(118, 38);
            this.btnArea.TabIndex = 3;
            this.btnArea.Text = "Plot Feasible Area";
            this.btnArea.UseVisualStyleBackColor = true;
            this.btnArea.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Enabled = false;
            this.btnSolve.Location = new System.Drawing.Point(367, 439);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(137, 38);
            this.btnSolve.TabIndex = 4;
            this.btnSolve.Text = "Plot ISO and Solve LP";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(9, 439);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 38);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Select File and Load LP";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgvConstraints
            // 
            this.dgvConstraints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConstraints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y,
            this.Sign,
            this.RHS});
            this.dgvConstraints.Location = new System.Drawing.Point(802, 118);
            this.dgvConstraints.Name = "dgvConstraints";
            this.dgvConstraints.Size = new System.Drawing.Size(246, 150);
            this.dgvConstraints.TabIndex = 6;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.Width = 50;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.Width = 50;
            // 
            // Sign
            // 
            this.Sign.HeaderText = "Sign";
            this.Sign.Name = "Sign";
            this.Sign.Width = 50;
            // 
            // RHS
            // 
            this.RHS.HeaderText = "RHS";
            this.RHS.Name = "RHS";
            this.RHS.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(799, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Objective Function";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(802, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Constraints";
            // 
            // lblMinMax
            // 
            this.lblMinMax.AutoSize = true;
            this.lblMinMax.Location = new System.Drawing.Point(802, 30);
            this.lblMinMax.Name = "lblMinMax";
            this.lblMinMax.Size = new System.Drawing.Size(24, 13);
            this.lblMinMax.TabIndex = 9;
            this.lblMinMax.Text = "Min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(832, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Z =";
            // 
            // lblCx
            // 
            this.lblCx.AutoSize = true;
            this.lblCx.Location = new System.Drawing.Point(882, 30);
            this.lblCx.Name = "lblCx";
            this.lblCx.Size = new System.Drawing.Size(13, 13);
            this.lblCx.TabIndex = 11;
            this.lblCx.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(922, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "X +";
            // 
            // lblCy
            // 
            this.lblCy.AutoSize = true;
            this.lblCy.Location = new System.Drawing.Point(966, 30);
            this.lblCy.Name = "lblCy";
            this.lblCy.Size = new System.Drawing.Size(13, 13);
            this.lblCy.TabIndex = 13;
            this.lblCy.Text = "0";
            // 
            // lblOptimalZ
            // 
            this.lblOptimalZ.AutoSize = true;
            this.lblOptimalZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptimalZ.Location = new System.Drawing.Point(804, 43);
            this.lblOptimalZ.Name = "lblOptimalZ";
            this.lblOptimalZ.Size = new System.Drawing.Size(19, 20);
            this.lblOptimalZ.TabIndex = 14;
            this.lblOptimalZ.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1014, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Y =";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Location = new System.Drawing.Point(805, 275);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(43, 13);
            this.lblPoints.TabIndex = 16;
            this.lblPoints.Text = "Corners";
            // 
            // dgvPoints
            // 
            this.dgvPoints.AllowUserToAddRows = false;
            this.dgvPoints.AllowUserToDeleteRows = false;
            this.dgvPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvPoints.Location = new System.Drawing.Point(800, 292);
            this.dgvPoints.Name = "dgvPoints";
            this.dgvPoints.ReadOnly = true;
            this.dgvPoints.Size = new System.Drawing.Size(248, 186);
            this.dgvPoints.TabIndex = 17;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "X";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Y";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // rtx1
            // 
            this.rtx1.Location = new System.Drawing.Point(15, 483);
            this.rtx1.Name = "rtx1";
            this.rtx1.Size = new System.Drawing.Size(777, 126);
            this.rtx1.TabIndex = 18;
            this.rtx1.Text = "";
            // 
            // btnRefactor
            // 
            this.btnRefactor.Enabled = false;
            this.btnRefactor.Location = new System.Drawing.Point(510, 439);
            this.btnRefactor.Name = "btnRefactor";
            this.btnRefactor.Size = new System.Drawing.Size(154, 38);
            this.btnRefactor.TabIndex = 19;
            this.btnRefactor.Text = "Recalculate with alternative C1 and C2 as:";
            this.btnRefactor.UseVisualStyleBackColor = true;
            this.btnRefactor.Click += new System.EventHandler(this.btnRefactor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(671, 439);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "C1:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(671, 458);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "C2:";
            // 
            // nudC1
            // 
            this.nudC1.Enabled = false;
            this.nudC1.Location = new System.Drawing.Point(700, 437);
            this.nudC1.Name = "nudC1";
            this.nudC1.Size = new System.Drawing.Size(92, 20);
            this.nudC1.TabIndex = 22;
            // 
            // nudC2
            // 
            this.nudC2.Enabled = false;
            this.nudC2.Location = new System.Drawing.Point(700, 458);
            this.nudC2.Name = "nudC2";
            this.nudC2.Size = new System.Drawing.Size(92, 20);
            this.nudC2.TabIndex = 23;
            // 
            // labY
            // 
            this.labY.AutoSize = true;
            this.labY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labY.Location = new System.Drawing.Point(1014, 64);
            this.labY.Name = "labY";
            this.labY.Size = new System.Drawing.Size(23, 13);
            this.labY.TabIndex = 30;
            this.labY.Text = "Y =";
            this.labY.Visible = false;
            // 
            // labOptimal
            // 
            this.labOptimal.AutoSize = true;
            this.labOptimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labOptimal.Location = new System.Drawing.Point(804, 77);
            this.labOptimal.Name = "labOptimal";
            this.labOptimal.Size = new System.Drawing.Size(19, 20);
            this.labOptimal.TabIndex = 29;
            this.labOptimal.Text = "0";
            this.labOptimal.Visible = false;
            // 
            // labC2
            // 
            this.labC2.AutoSize = true;
            this.labC2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labC2.Location = new System.Drawing.Point(966, 64);
            this.labC2.Name = "labC2";
            this.labC2.Size = new System.Drawing.Size(13, 13);
            this.labC2.TabIndex = 28;
            this.labC2.Text = "0";
            this.labC2.Visible = false;
            // 
            // LabX
            // 
            this.LabX.AutoSize = true;
            this.LabX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabX.Location = new System.Drawing.Point(922, 64);
            this.LabX.Name = "LabX";
            this.LabX.Size = new System.Drawing.Size(23, 13);
            this.LabX.TabIndex = 27;
            this.LabX.Text = "X +";
            this.LabX.Visible = false;
            // 
            // labC1
            // 
            this.labC1.AutoSize = true;
            this.labC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labC1.Location = new System.Drawing.Point(882, 64);
            this.labC1.Name = "labC1";
            this.labC1.Size = new System.Drawing.Size(13, 13);
            this.labC1.TabIndex = 26;
            this.labC1.Text = "0";
            this.labC1.Visible = false;
            // 
            // labZ
            // 
            this.labZ.AutoSize = true;
            this.labZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labZ.Location = new System.Drawing.Point(832, 64);
            this.labZ.Name = "labZ";
            this.labZ.Size = new System.Drawing.Size(23, 13);
            this.labZ.TabIndex = 25;
            this.labZ.Text = "Z =";
            this.labZ.Visible = false;
            // 
            // labType
            // 
            this.labType.AutoSize = true;
            this.labType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labType.Location = new System.Drawing.Point(802, 64);
            this.labType.Name = "labType";
            this.labType.Size = new System.Drawing.Size(24, 13);
            this.labType.TabIndex = 24;
            this.labType.Text = "Min";
            this.labType.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 661);
            this.Controls.Add(this.labY);
            this.Controls.Add(this.labOptimal);
            this.Controls.Add(this.labC2);
            this.Controls.Add(this.LabX);
            this.Controls.Add(this.labC1);
            this.Controls.Add(this.labZ);
            this.Controls.Add(this.labType);
            this.Controls.Add(this.nudC2);
            this.Controls.Add(this.nudC1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRefactor);
            this.Controls.Add(this.rtx1);
            this.Controls.Add(this.dgvPoints);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblOptimalZ);
            this.Controls.Add(this.lblCy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblMinMax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvConstraints);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.btnArea);
            this.Controls.Add(this.btnConstraints);
            this.Controls.Add(this.chr1);
            this.Name = "Form1";
            this.Text = "memo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstraints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudC1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudC2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chr1;
        private System.Windows.Forms.Button btnConstraints;
        private System.Windows.Forms.Button btnArea;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dgvConstraints;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sign;
        private System.Windows.Forms.DataGridViewTextBoxColumn RHS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMinMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCy;
        private System.Windows.Forms.Label lblOptimalZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.DataGridView dgvPoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.RichTextBox rtx1;
        private System.Windows.Forms.Button btnRefactor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudC1;
        private System.Windows.Forms.NumericUpDown nudC2;
        private System.Windows.Forms.Label labY;
        private System.Windows.Forms.Label labOptimal;
        private System.Windows.Forms.Label labC2;
        private System.Windows.Forms.Label LabX;
        private System.Windows.Forms.Label labC1;
        private System.Windows.Forms.Label labZ;
        private System.Windows.Forms.Label labType;
    }
}

