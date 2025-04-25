using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TripleTankModell.Blocks
{
    public class Tank1Model : BaseBlock
    {
        public double Inflow { get; set; }
        public double Outflow { get; set; }
        public double Level => Output;

        

        private readonly LimitBlock limiter;
        private readonly SubBlock sub;
        private readonly GainBlock gain;
        private readonly IntBlock integrator;

        private readonly LimitBlock limiterLevel;



        public Tank1Model(double area, double dt)
        {
            limiter = new LimitBlock { Min = 0, Max = 1 };
            sub = new SubBlock();
            gain = new GainBlock(1.0 / area);
            integrator = new IntBlock(dt);
            limiterLevel = new LimitBlock { Min = 0, Max = 1000 };
        }

        public override void Update(double deltaTime)
        {
            limiter.Input = Inflow;
            limiter.Update(deltaTime);

            sub.Input1 = limiter.Output;
            sub.Input2 = Outflow;
            sub.Update(deltaTime);

            gain.Input = sub.Output;
            gain.Update(deltaTime);

            integrator.Input = gain.Output;
            integrator.Update(deltaTime);

            limiterLevel.Input = integrator.Output;
            limiterLevel.Update(deltaTime);

            Output = limiterLevel.Output;

        }
    }
}



