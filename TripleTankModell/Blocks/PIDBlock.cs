using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTankModell.Blocks
{
    using System;

    namespace TripleTankModell.Blocks
    {
        public class PIDBlock : BaseBlock
        {
            public double Setpoint { get; set; }
            public double Feedback { get; set; }

            public double Kp { get; set; } = 1.0;
            public double Ti { get; set; } = 1.0; 
            public double Td { get; set; } = 0.0; 

            public double MinOutput { get; set; } = 0.0;
            public double MaxOutput { get; set; } = 1.0;

            public bool AutoMode { get; set; } = true;
            public double ManualOutput { get; set; } = 0.0;

            private double integral = 0.0;
            private double previousError = 0.0;

            public void ResetIntegrator()
            {
                integral = 0;
            }

            public override void Update(double dt)
            {
                double error = Setpoint - Feedback;

                if (AutoMode)
                {
                    
                    integral += error * dt;
                    double iTerm = integral / Ti;

                    double pTerm = Kp * error;

                    double output = pTerm + iTerm;

                    
                    if (output > MaxOutput)
                    {
                        output = MaxOutput;
                        
                        integral -= error * dt;
                    }
                    else if (output < MinOutput)
                    {
                        output = MinOutput;
                        integral -= error * dt;
                    }

                    Output = output;
                }
                else
                {
                    
                    Output = ManualOutput;
                    
                    integral = (ManualOutput - Kp * error) * Ti;
                }

                previousError = error;
            }
        }
    }

}
