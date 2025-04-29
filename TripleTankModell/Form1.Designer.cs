namespace TripleTankModell
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btnStart = new Button();
            btnStop = new Button();
            btnSpeed = new Button();
            lblInflow = new Label();
            tbInflow = new TextBox();
            btnInflowDown = new Button();
            btnInflowUp = new Button();
            pictureBox1 = new PictureBox();
            modelTimer = new System.Windows.Forms.Timer(components);
            tbZ1 = new TextBox();
            tbZ3 = new TextBox();
            tbZ2 = new TextBox();
            lblZ1 = new Label();
            lblZ2 = new Label();
            lblZ3 = new Label();
            btnReset = new Button();
            tbValveOut = new TextBox();
            btnValveOutDown = new Button();
            btnValveOutUp = new Button();
            lblValveOut = new Label();
            tbValve12 = new TextBox();
            lblValve12 = new Label();
            btnValve12Down = new Button();
            btnValve12Up = new Button();
            tbKp = new TextBox();
            tbTi = new TextBox();
            tbKd = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbSetPoint = new TextBox();
            label4 = new Label();
            btnMode = new Button();
            ((System.ComponentModel.ISupportInitialize)chartMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // chartMain
            // 
            chartArea1.Name = "ChartArea1";
            chartMain.ChartAreas.Add(chartArea1);
            chartMain.Dock = DockStyle.Top;
            legend1.Name = "Legend1";
            chartMain.Legends.Add(legend1);
            chartMain.Location = new Point(0, 0);
            chartMain.Name = "chartMain";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "z1";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "z2";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "z3";
            chartMain.Series.Add(series1);
            chartMain.Series.Add(series2);
            chartMain.Series.Add(series3);
            chartMain.Size = new Size(1698, 434);
            chartMain.TabIndex = 0;
            chartMain.Text = "chartMain";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(527, 462);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(131, 40);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(800, 462);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(131, 40);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnSpeed
            // 
            btnSpeed.Location = new Point(693, 462);
            btnSpeed.Name = "btnSpeed";
            btnSpeed.Size = new Size(77, 40);
            btnSpeed.TabIndex = 3;
            btnSpeed.Text = "x10";
            btnSpeed.UseVisualStyleBackColor = true;
            btnSpeed.Click += btnSpeed_Click;
            // 
            // lblInflow
            // 
            lblInflow.AutoSize = true;
            lblInflow.Location = new Point(358, 790);
            lblInflow.Name = "lblInflow";
            lblInflow.Size = new Size(42, 30);
            lblInflow.TabIndex = 4;
            lblInflow.Text = " X1";
            // 
            // tbInflow
            // 
            tbInflow.Location = new Point(290, 819);
            tbInflow.Name = "tbInflow";
            tbInflow.ReadOnly = true;
            tbInflow.Size = new Size(175, 35);
            tbInflow.TabIndex = 5;
            tbInflow.Text = "1.00";
            tbInflow.TextAlign = HorizontalAlignment.Center;
            // 
            // btnInflowDown
            // 
            btnInflowDown.Location = new Point(227, 812);
            btnInflowDown.Name = "btnInflowDown";
            btnInflowDown.Size = new Size(57, 42);
            btnInflowDown.TabIndex = 6;
            btnInflowDown.Text = "<";
            btnInflowDown.UseVisualStyleBackColor = true;
            btnInflowDown.Click += btnInflowDown_Click;
            // 
            // btnInflowUp
            // 
            btnInflowUp.Location = new Point(471, 812);
            btnInflowUp.Name = "btnInflowUp";
            btnInflowUp.Size = new Size(57, 42);
            btnInflowUp.TabIndex = 7;
            btnInflowUp.Text = ">";
            btnInflowUp.UseVisualStyleBackColor = true;
            btnInflowUp.Click += btnInflowUp_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.TripleTank;
            pictureBox1.Location = new Point(307, 552);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(944, 235);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // tbZ1
            // 
            tbZ1.Location = new Point(62, 470);
            tbZ1.Name = "tbZ1";
            tbZ1.ReadOnly = true;
            tbZ1.Size = new Size(175, 35);
            tbZ1.TabIndex = 9;
            tbZ1.TextAlign = HorizontalAlignment.Center;
            // 
            // tbZ3
            // 
            tbZ3.Location = new Point(62, 663);
            tbZ3.Name = "tbZ3";
            tbZ3.ReadOnly = true;
            tbZ3.Size = new Size(175, 35);
            tbZ3.TabIndex = 10;
            tbZ3.TextAlign = HorizontalAlignment.Center;
            // 
            // tbZ2
            // 
            tbZ2.Location = new Point(62, 568);
            tbZ2.Name = "tbZ2";
            tbZ2.ReadOnly = true;
            tbZ2.Size = new Size(175, 35);
            tbZ2.TabIndex = 11;
            tbZ2.TextAlign = HorizontalAlignment.Center;
            // 
            // lblZ1
            // 
            lblZ1.AutoSize = true;
            lblZ1.Location = new Point(132, 437);
            lblZ1.Name = "lblZ1";
            lblZ1.Size = new Size(34, 30);
            lblZ1.TabIndex = 12;
            lblZ1.Text = "z1";
            // 
            // lblZ2
            // 
            lblZ2.AutoSize = true;
            lblZ2.Location = new Point(132, 526);
            lblZ2.Name = "lblZ2";
            lblZ2.Size = new Size(34, 30);
            lblZ2.TabIndex = 13;
            lblZ2.Text = "z2";
            // 
            // lblZ3
            // 
            lblZ3.AutoSize = true;
            lblZ3.Location = new Point(132, 621);
            lblZ3.Name = "lblZ3";
            lblZ3.Size = new Size(34, 30);
            lblZ3.TabIndex = 14;
            lblZ3.Text = "z3";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(1058, 462);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(131, 40);
            btnReset.TabIndex = 15;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // tbValveOut
            // 
            tbValveOut.Location = new Point(953, 823);
            tbValveOut.Name = "tbValveOut";
            tbValveOut.ReadOnly = true;
            tbValveOut.Size = new Size(175, 35);
            tbValveOut.TabIndex = 16;
            tbValveOut.TextAlign = HorizontalAlignment.Center;
            // 
            // btnValveOutDown
            // 
            btnValveOutDown.Location = new Point(903, 818);
            btnValveOutDown.Name = "btnValveOutDown";
            btnValveOutDown.Size = new Size(44, 40);
            btnValveOutDown.TabIndex = 17;
            btnValveOutDown.Text = "<";
            btnValveOutDown.UseVisualStyleBackColor = true;
            btnValveOutDown.Click += btnValveOutDown_Click;
            // 
            // btnValveOutUp
            // 
            btnValveOutUp.Location = new Point(1134, 818);
            btnValveOutUp.Name = "btnValveOutUp";
            btnValveOutUp.Size = new Size(44, 40);
            btnValveOutUp.TabIndex = 18;
            btnValveOutUp.Text = ">";
            btnValveOutUp.UseVisualStyleBackColor = true;
            btnValveOutUp.Click += btnValveOutUp_Click;
            // 
            // lblValveOut
            // 
            lblValveOut.AutoSize = true;
            lblValveOut.Location = new Point(1017, 790);
            lblValveOut.Name = "lblValveOut";
            lblValveOut.Size = new Size(56, 30);
            lblValveOut.TabIndex = 19;
            lblValveOut.Text = "Xout";
            // 
            // tbValve12
            // 
            tbValve12.Location = new Point(610, 823);
            tbValve12.Name = "tbValve12";
            tbValve12.ReadOnly = true;
            tbValve12.Size = new Size(175, 35);
            tbValve12.TabIndex = 20;
            tbValve12.TextAlign = HorizontalAlignment.Center;
            // 
            // lblValve12
            // 
            lblValve12.AutoSize = true;
            lblValve12.Location = new Point(669, 790);
            lblValve12.Name = "lblValve12";
            lblValve12.Size = new Size(55, 30);
            lblValve12.TabIndex = 23;
            lblValve12.Text = "X1-2";
            // 
            // btnValve12Down
            // 
            btnValve12Down.Location = new Point(560, 819);
            btnValve12Down.Name = "btnValve12Down";
            btnValve12Down.Size = new Size(44, 39);
            btnValve12Down.TabIndex = 24;
            btnValve12Down.Text = "<";
            btnValve12Down.UseVisualStyleBackColor = true;
            btnValve12Down.Click += btnValve12Down_Click;
            // 
            // btnValve12Up
            // 
            btnValve12Up.Location = new Point(791, 818);
            btnValve12Up.Name = "btnValve12Up";
            btnValve12Up.Size = new Size(44, 40);
            btnValve12Up.TabIndex = 25;
            btnValve12Up.Text = ">";
            btnValve12Up.UseVisualStyleBackColor = true;
            btnValve12Up.Click += btnValve12Up_Click;
            // 
            // tbKp
            // 
            tbKp.Location = new Point(1460, 632);
            tbKp.Name = "tbKp";
            tbKp.Size = new Size(175, 35);
            tbKp.TabIndex = 26;
            // 
            // tbTi
            // 
            tbTi.Location = new Point(1460, 702);
            tbTi.Name = "tbTi";
            tbTi.Size = new Size(175, 35);
            tbTi.TabIndex = 27;
            // 
            // tbKd
            // 
            tbKd.Location = new Point(1460, 773);
            tbKd.Name = "tbKd";
            tbKd.Size = new Size(175, 35);
            tbKd.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1377, 637);
            label1.Name = "label1";
            label1.Size = new Size(37, 30);
            label1.TabIndex = 29;
            label1.Text = "Kp";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1377, 707);
            label2.Name = "label2";
            label2.Size = new Size(29, 30);
            label2.TabIndex = 30;
            label2.Text = "Ti";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1377, 778);
            label3.Name = "label3";
            label3.Size = new Size(37, 30);
            label3.TabIndex = 31;
            label3.Text = "Kd";
            // 
            // tbSetPoint
            // 
            tbSetPoint.Location = new Point(1460, 552);
            tbSetPoint.Name = "tbSetPoint";
            tbSetPoint.Size = new Size(175, 35);
            tbSetPoint.TabIndex = 32;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1349, 557);
            label4.Name = "label4";
            label4.Size = new Size(89, 30);
            label4.TabIndex = 33;
            label4.Text = "SetPoint";
            // 
            // btnMode
            // 
            btnMode.Location = new Point(1340, 462);
            btnMode.Name = "btnMode";
            btnMode.Size = new Size(131, 40);
            btnMode.TabIndex = 34;
            btnMode.Text = "Auto";
            btnMode.UseVisualStyleBackColor = true;
            btnMode.Click += btnMode_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1698, 911);
            Controls.Add(btnMode);
            Controls.Add(label4);
            Controls.Add(tbSetPoint);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbKd);
            Controls.Add(tbTi);
            Controls.Add(tbKp);
            Controls.Add(btnValve12Up);
            Controls.Add(btnValve12Down);
            Controls.Add(lblValve12);
            Controls.Add(tbValve12);
            Controls.Add(lblValveOut);
            Controls.Add(btnValveOutUp);
            Controls.Add(btnValveOutDown);
            Controls.Add(tbValveOut);
            Controls.Add(btnReset);
            Controls.Add(lblZ3);
            Controls.Add(lblZ2);
            Controls.Add(lblZ1);
            Controls.Add(tbZ2);
            Controls.Add(tbZ3);
            Controls.Add(tbZ1);
            Controls.Add(pictureBox1);
            Controls.Add(btnInflowUp);
            Controls.Add(btnInflowDown);
            Controls.Add(tbInflow);
            Controls.Add(lblInflow);
            Controls.Add(btnSpeed);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(chartMain);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)chartMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
        private Button btnStart;
        private Button btnStop;
        private Button btnSpeed;
        private Label lblInflow;
        private TextBox tbInflow;
        private Button btnInflowDown;
        private Button btnInflowUp;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer modelTimer;
        private TextBox tbZ1;
        private TextBox tbZ3;
        private TextBox tbZ2;
        private Label lblZ1;
        private Label lblZ2;
        private Label lblZ3;
        private Button btnReset;
        private TextBox tbValveOut;
        private Button btnValveOutDown;
        private Button btnValveOutUp;
        private Label lblValveOut;
        private TextBox tbValve12;
        private Button btnMode;
        private Button button2;
        private Label lblValve12;
        private Button btnValve12Down;
        private Button btnValve12Up;
        private TextBox tbKp;
        private TextBox tbTi;
        private TextBox tbKd;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbSetPoint;
        private Label label4;
    }
}
