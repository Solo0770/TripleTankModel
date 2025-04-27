using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TripleTankModell.Model;

namespace TripleTankModell
{
    public partial class Form1 : Form
    {
        private ObjectModel model;
        private double dt = 0.1;
        private double time = 0;
        private bool fastMode = false;

        private double Valve12Control = 0;

        public Form1()
        {
            InitializeComponent();
            model = new ObjectModel();

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

            foreach (var s in chartMain.Series)
            {
                s.ChartType = SeriesChartType.Line;
                s.BorderWidth = 2;
                s.LegendText = s.Name;
            }

            chartMain.ChartAreas[0].AxisX.Title = "Час (с)";
            chartMain.ChartAreas[0].AxisY.Title = "Рівень";
        }

        private void modelTimer_Tick(object sender, EventArgs e)
        {
            modelUpdate();
        }

        private void modelUpdate()
        {
            model.ValveIn.OpenPercent = model.ValveIn.OpenPercent;
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

            chartMain.Series["z1"].Points.AddXY(time, z1);
            chartMain.Series["z2"].Points.AddXY(time, z2);
            chartMain.Series["z3"].Points.AddXY(time, z3);

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

        private void btnStart_Click(object sender, EventArgs e)
        {
            modelTimer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            modelTimer.Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            modelTimer.Stop();

            foreach (var series in chartMain.Series)
                series.Points.Clear();

            time = 0;
            model = new ObjectModel();
            UpdateDisplay();
        }

        private void btnSpeed_Click(object sender, EventArgs e)
        {
            fastMode = !fastMode;

            if (fastMode)
            {
                modelTimer.Interval = 10;
                btnSpeed.Text = "x10";
            }
            else
            {
                modelTimer.Interval = 100;
                btnSpeed.Text = "x1";
            }
        }

        private void btnInflowUp_Click(object sender, EventArgs e)
        {
            model.ValveIn.OpenPercent += 0.05;
            if (model.ValveIn.OpenPercent > 1.0)
                model.ValveIn.OpenPercent = 1.0;

            UpdateDisplay();
        }

        private void btnInflowDown_Click(object sender, EventArgs e)
        {
            model.ValveIn.OpenPercent -= 0.05;
            if (model.ValveIn.OpenPercent < 0.0)
                model.ValveIn.OpenPercent = 0.0;

            UpdateDisplay();
        }

        private void btnValveOutUp_Click(object sender, EventArgs e)
        {
            model.ValveOut.OpenPercent += 0.05;
            if (model.ValveOut.OpenPercent > 1.0)
                model.ValveOut.OpenPercent = 1.0;

            UpdateDisplay();
        }

        private void btnValveOutDown_Click(object sender, EventArgs e)
        {
            model.ValveOut.OpenPercent -= 0.05;
            if (model.ValveOut.OpenPercent < 0.0)
                model.ValveOut.OpenPercent = 0.0;

            UpdateDisplay();
        }

        private void btnValve12Up_Click(object sender, EventArgs e)
        {
            Valve12Control += 0.05;
            if (Valve12Control > 1.0)
                Valve12Control = 1.0;

            UpdateDisplay();
        }

        private void btnValve12Down_Click(object sender, EventArgs e)
        {
            Valve12Control -= 0.05;
            if (Valve12Control < 0.0)
                Valve12Control = 0.0;

            UpdateDisplay();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
