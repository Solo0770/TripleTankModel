using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTankModell.Blocks
{
    public class IntBlock : BaseBlock
    {
        private double prev = 0;
        private double dt;
        private double sum = 0;
        public double Input { get; set; }

        public IntBlock(double dt)
        {
            this.dt = dt;
        }

        public override void Update(double deltaTime)
        {
            sum += (prev + Input) * dt / 2;
            prev = Input;
            Output = sum;
        }
    }
}
