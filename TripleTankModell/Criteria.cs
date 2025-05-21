using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TripleTankModell.Model;
using TripleTankModell.Blocks;

namespace TripleTankModell.Optimization
{
    public static class Criteria
    {
        public static double dt = 0.1;
        public static double maxTime = 500;
        public static double alpha = 0;

        public static double I2Criteria(double[] vars)
        {
            double sum = 0;
            double time = 0;
            if (vars[0] <= 0 || vars[1] <= 0 || vars[2] < 0)
                return double.MaxValue;
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

            int steps = (int)(maxTime / dt);
            for (int i = 0; i < steps; i++)
            {
                pid.Feedback = model.Tank1.Level;
                pid.Update(dt);
                model.ValveIn.OpenPercent = pid.Output;
                model.Update(dt);
                double error = pid.SetPoint - model.Tank1.Level;
                sum += Math.Pow(time, alpha) * error * error * dt;
                time += dt;
            }

            return sum;
        }
    }
}

