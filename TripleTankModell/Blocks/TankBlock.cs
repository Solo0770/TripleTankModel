using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTankModell.Blocks;

namespace TripleTankModell.Blocks
{
    public class TankBlock : BaseBlock
    {
        private readonly IntBlock integrator;
        private readonly LimitBlock limiter;

        public double Inflow { get; set; }
        public double Outflow { get; set; }

        public TankBlock(double dt)
        {
            integrator = new IntBlock(dt);
            limiter = new LimitBlock(0, 100000);
        }

        public override void Update(double deltaTime)
        {
            integrator.Input = Inflow - Outflow;
            integrator.Update(deltaTime);

            limiter.Input = integrator.Output;
            limiter.Update(deltaTime);

            Output = limiter.Output;
        }

        public void SetLevel(double level)
        {
            integrator.SetInitial(level);
            limiter.Input = level;
            limiter.Update(0);
            Output = limiter.Output;
        }


        public double Level => Output;
    }
}






