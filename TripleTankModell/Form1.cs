using System;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TripleTankModell.Model;
using TripleTankModell.Blocks;
using TripleTankModell.Optimization;

namespace TripleTankModell
{
    public partial class Form1 : Form
    {
        private ObjectModel model;
        private double dt = 0.1;
        private double time = 0;
        private bool fastMode = false;


        private double Valve12Control = 0;

        private PIDBlock pid;
        private bool isAuto = true;

        public Form1()
        {
            InitializeComponent();
            model = new ObjectModel();
            pid = new PIDBlock(dt);

            modelTimer.Interval = 100;
            modelTimer.Tick += modelTimer_Tick;

            btnSpeed.Text = "x10";

            InitChart();
            UpdateDisplay();
        }

        private void InitChart()
        {
            chartMain.Series.Clear();

            chartMain.Series.Add("z1");
            chartMain.Series.Add("z2");
            chartMain.Series.Add("z3");
            chartMain.Series.Add("E");
            chartMain.Series.Add("Before Optimization");
            chartMain.Series.Add("After Optimization");


            foreach (var s in chartMain.Series)
            {
                s.ChartType = SeriesChartType.Line;
                s.BorderWidth = 2;
                s.LegendText = s.Name;
            }

            chartMain.ChartAreas[0].AxisX.Title = "Час (с)";
            chartMain.ChartAreas[0].AxisY.Title = "Рівень / Помилка";
        }

        private void modelTimer_Tick(object sender, EventArgs e)
        {
            modelUpdate();
        }

        private void modelUpdate()
        {
            double setPoint = 0;

            if (isAuto)
            {
                if (!double.TryParse(tbKp.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double kp)) return;
                if (!double.TryParse(tbTi.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double ti)) return;
                if (!double.TryParse(tbKd.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double kd)) return;
                if (!double.TryParse(tbSetPoint.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out setPoint)) return;

                pid.K = kp;
                pid.Ti = ti;
                pid.Kd = kd;

       
                pid.SetPoint = setPoint;

                pid.Feedback = model.Tank1.Level;

                pid.IsAuto = true;
                pid.Update(dt);

                model.ValveIn.OpenPercent = pid.Output;
            }

            model.Valve12.OpenPercent = Valve12Control;
            model.ValveOut.OpenPercent = model.ValveOut.OpenPercent;

            model.Update(dt);
            time += dt;
            AddChartPoint();
        }



        private void AddChartPoint()
        {
            double z1 = model.Tank1.Level;
            double z2 = model.Tank2.Level;
            double z3 = model.Tank3.Level;
            double error = 0;

            if (double.TryParse(tbSetPoint.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double setPoint))
            {
                error = setPoint - z1;
            }

            chartMain.Series["z1"].Points.AddXY(time, z1);
            chartMain.Series["z2"].Points.AddXY(time, z2);
            chartMain.Series["z3"].Points.AddXY(time, z3);
            chartMain.Series["E"].Points.AddXY(time, error);

            UpdateDisplay();

            const int maxPoints = 10000;
            foreach (var series in chartMain.Series)
            {
                if (series.Points.Count > maxPoints)
                    series.Points.RemoveAt(0);
            }
        }

     

        private void UpdateDisplay()
        {
            tbZ1.Text = model.Tank1.Level.ToString("0.00");
            tbZ2.Text = model.Tank2.Level.ToString("0.00");
            tbZ3.Text = model.Tank3.Level.ToString("0.00");

            tbInflow.Text = (model.ValveIn.OpenPercent * 100).ToString("0") + " %";
            tbValveOut.Text = (model.ValveOut.OpenPercent * 100).ToString("0") + " %";
            tbValve12.Text = (Valve12Control * 100).ToString("0") + " %";
        }

        private void btnStart_Click(object sender, EventArgs e) => modelTimer.Start();
        private void btnStop_Click(object sender, EventArgs e) => modelTimer.Stop();

        private void btnReset_Click(object sender, EventArgs e)
        {
            modelTimer.Stop();

            foreach (var series in chartMain.Series)
                series.Points.Clear();

            time = 0;

            model = new ObjectModel();
            pid = new PIDBlock(dt);
            pid.Reset();


            model.ValveIn.OpenPercent = 0.0;
            model.Valve12.OpenPercent = 0.0;
            model.ValveOut.OpenPercent = 0.0;
            Valve12Control = 0.0;

            pid.IsAuto = isAuto;

            UpdateDisplay();
        }


        private void btnSpeed_Click(object sender, EventArgs e)
        {
            fastMode = !fastMode;
            modelTimer.Interval = fastMode ? 10 : 100;
            btnSpeed.Text = fastMode ? "x10" : "x1";
        }

        private void btnInflowUp_Click(object sender, EventArgs e)
        {
            if (!isAuto)
            {
                model.ValveIn.OpenPercent = Math.Min(model.ValveIn.OpenPercent + 0.05, 1.0);
                UpdateDisplay();
            }
        }

        private void btnInflowDown_Click(object sender, EventArgs e)
        {
            if (!isAuto)
            {
                model.ValveIn.OpenPercent = Math.Max(model.ValveIn.OpenPercent - 0.05, 0.0);
                UpdateDisplay();
            }
        }


        private void btnValveOutUp_Click(object sender, EventArgs e)
        {
            model.ValveOut.OpenPercent = Math.Min(model.ValveOut.OpenPercent + 0.05, 1.0);
            UpdateDisplay();
        }

        private void btnValveOutDown_Click(object sender, EventArgs e)
        {
            model.ValveOut.OpenPercent = Math.Max(model.ValveOut.OpenPercent - 0.05, 0.0);
            UpdateDisplay();
        }

        private void btnValve12Up_Click(object sender, EventArgs e)
        {
            Valve12Control = Math.Min(Valve12Control + 0.05, 1.0);
            UpdateDisplay();
        }

        private void btnValve12Down_Click(object sender, EventArgs e)
        {
            Valve12Control = Math.Max(Valve12Control - 0.05, 0.0);
            UpdateDisplay();
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            isAuto = !isAuto;
            pid.IsAuto = isAuto;
            btnMode.Text = isAuto ? "Auto" : "Manual";
        }

        private void ShowProcess(double[] vars, int series)
        {
            double maxTime = Criteria.maxTime;
            double dt = Criteria.dt;
            double time = 0;

            ObjectModel model = new ObjectModel();
            var pid = new PIDBlock(dt)
            {
                K = vars[0],
                Ti = vars[1],
                Kd = vars[2],
                SetPoint = 5,
                IsAuto = true
            };

            model.Valve12.OpenPercent = 1;
            model.ValveOut.OpenPercent = 1;

            chartMain.Series[series].Points.Clear();

            int steps = (int)(maxTime / dt);
            for (int i = 0; i < steps; i++)
            {
                pid.Feedback = model.Tank1.Level;
                pid.Update(dt);
                model.ValveIn.OpenPercent = pid.Output;
                model.Update(dt);

                chartMain.Series[series].Points.AddXY(time, model.Tank1.Level);
                time += dt;
            }
        }


        private void btnOptimize_Click(object sender, EventArgs e)
        {
            double[] p = { 1, 100, 0 }; 
            double I1 = Criteria.I2Criteria(p); 
            ShowProcess(p, 4); 

            int steps = Optimizer.HookeJeeves(Criteria.I2Criteria, ref p); 
            ShowProcess(p, 5); 

            double I2 = Criteria.I2Criteria(p); 

            MessageBox.Show($"Kp={p[0]:0.00}, Ti={p[1]:0.00}, Kd={p[2]:0.00}\nI1={I1:0.000} → I2={I2:0.000}\nSteps={steps}");
        }




        private void Form1_Load(object sender, EventArgs e) { }

    }
}
