using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTankModell.Blocks
{
    public class PIDBlock : BaseBlock
    {
        private GainBlock pBlock;
        private GainBlock iGainBlock;
        private GainBlock dGainBlock;
        private IntBlock iBlock;
        private double prevFeedback;
        private double filteredDerivative;
        private double dt;
        private double error;

        private double alpha = 0.1; // коефіцієнт фільтрації диференціалу

        public bool IsAuto { get; set; } = true;

        public double K { get => pBlock.Gain; set => pBlock.Gain = value; }
        public double Ki { get => iGainBlock.Gain; set => iGainBlock.Gain = value; }
        public double Ti
        {
            get => Ki == 0 ? double.MaxValue : 1.0 / Ki;
            set => Ki = value != 0 ? 1.0 / value : double.MaxValue;
        }
        public double Kd { get => dGainBlock.Gain; set => dGainBlock.Gain = value; }

        public double OutputMin { get; set; } = 0.0;
        public double OutputMax { get; set; } = 1.0;

        public double SetPoint { get; set; }
        public double Feedback { get; set; }

        public PIDBlock(double dt)
        {
            this.dt = dt;
            pBlock = new GainBlock(1.0);
            iGainBlock = new GainBlock(0.0);
            dGainBlock = new GainBlock(0.0);
            iBlock = new IntBlock(dt);
            prevFeedback = 0.0;
            filteredDerivative = 0.0;
        }

        public override void Update(double deltaTime)
        {
            if (!IsAuto)//авто-ручне керування
                return;

            error = SetPoint - Feedback;

            // Пропорційна складова
            pBlock.Input = error;
            pBlock.Update(dt);

            // Інтегральна складова
            iBlock.Input = error;
            iBlock.Update(dt);
            iGainBlock.Input = iBlock.Output;
            iGainBlock.Update(dt);

            // Диференціальна складова з фільтрацією
            double dRaw = (Feedback - prevFeedback) / dt;
            filteredDerivative = alpha * dRaw + (1 - alpha) * filteredDerivative;
            prevFeedback = Feedback;
            dGainBlock.Input = -filteredDerivative;
            dGainBlock.Update(dt);

            double u = pBlock.Output + iGainBlock.Output + dGainBlock.Output;

            // Лімітування та anti-windup
            bool saturated = false;
            if (u > OutputMax) { u = OutputMax; saturated = true; }
            if (u < OutputMin) { u = OutputMin; saturated = true; }

            if (saturated && Ki > 0)
            {
                double correctedIntegral = (u - pBlock.Output - dGainBlock.Output) / Ki;
                iBlock.SetInitial(correctedIntegral);
            }

            Output = u;
        }

        public void Reset()
        {
            iBlock.SetInitial(0);
            prevFeedback = 0.0;
            filteredDerivative = 0.0;
        }
    }
}


