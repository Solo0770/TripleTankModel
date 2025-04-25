using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TripleTankModell.Model;

namespace TripleTankModell
{
    public partial class Form1 : Form
    {
        private TripleTankModell.Model.Model model;
        private double dt = 0.1;
        private double time = 0;
        private bool fastMode = false;

        public Form1()
        {
            InitializeComponent();
            model = new TripleTankModell.Model.Model();

            // Ініціалізація початкових значень
            model.Pin = 0;
            modelTimer.Interval = 100;
            modelTimer.Tick += modelTimer_Tick;

            btnSpeed.Text = "x10";
            tbInflow.Text = model.Pin.ToString("0.00");

            tbZ1.Text = model.Tank1.Level.ToString("0.00");
            tbZ2.Text = model.Tank2.Level.ToString("0.00");
            tbZ3.Text = model.Tank3.Level.ToString("0.00");

            InitChart();
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            
            model.Update(dt);
            AddChartPoint();
            modelTimer.Start();

        }

        private void AddChartPoint()
        {

            double z1 = model.Tank1.Level;
            double z2 = model.Tank2.Level;
            double z3 = model.Tank3.Level;

            chartMain.Series["z1"].Points.AddXY(time, z1);
            chartMain.Series["z2"].Points.AddXY(time, z2);
            chartMain.Series["z3"].Points.AddXY(time, z3);

            tbZ1.Text = z1.ToString("0.00");
            tbZ2.Text = z2.ToString("0.00");
            tbZ3.Text = z3.ToString("0.00");

            tbInflow.Text = model.Pin.ToString("0.00");

            const int maxPoints = 10000;
            foreach (var series in chartMain.Series)
            {
                if (series.Points.Count > maxPoints)
                    series.Points.RemoveAt(0);
            }
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            modelTimer.Stop();
        }

        private void modelTimer_Tick(object sender, EventArgs e)
        {
            

            model.Update(dt);
            time += dt;
            AddChartPoint();
            System.Diagnostics.Debug.WriteLine($"In = {model.Tank3.Inflow:F4}, Out = {model.Tank3.Outflow:F4}, Δz = {model.Tank3.Inflow - model.Tank3.Outflow:F4}, z3 = {model.Tank3.Level:F2}");


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
            model.Pin += 0.1;
            if (model.Pin > 10.0)
                model.Pin = 10.0;

            tbInflow.Text = model.Pin.ToString("0.00");
        }

        private void btnInflowDown_Click(object sender, EventArgs e)
        {
            model.Pin -= 0.1;
            if (model.Pin < 0)
                model.Pin = 0;

            tbInflow.Text = model.Pin.ToString("0.00");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            modelTimer.Stop();

            foreach (var series in chartMain.Series)
                series.Points.Clear();

            time = 0;

            model = new TripleTankModell.Model.Model();

            model.Pin = 2.0;
            tbInflow.Text = model.Pin.ToString("0.00");

            tbZ1.Text = model.Tank1.Level.ToString("0.00");
            tbZ2.Text = model.Tank2.Level.ToString("0.00");
            tbZ3.Text = model.Tank3.Level.ToString("0.00");
        }

        private void btnValveOutUp_Click(object sender, EventArgs e)
        {
            model.ValveOutControl += 0.05;
            if (model.ValveOutControl > 1.0)
                model.ValveOutControl = 1.0;

            tbValveOut.Text = (model.ValveOutControl * 100).ToString("0") + " %";
        }

        private void btnValveOutDown_Click(object sender, EventArgs e)
        {
            model.ValveOutControl -= 0.05;
            if (model.ValveOutControl < 0.0)
                model.ValveOutControl = 0.0;

            tbValveOut.Text = (model.ValveOutControl * 100).ToString("0") + " %";
        }


    }
}