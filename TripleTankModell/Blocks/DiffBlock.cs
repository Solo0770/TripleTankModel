using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTankModell.Blocks
{
    public class DiffBlock : BaseBlock
    {
        private double prevInput = 0.0;
        private readonly double dt;

        public double Input { get; set; }

        public DiffBlock(double dt)
        {
            this.dt = dt;
        }

        public override void Update(double deltaTime)
        {
            double diff = (Input - prevInput) / dt;
            prevInput = Input;
            Output = diff;
        }

        public void Reset()
        {
            prevInput = 0.0;
            Output = 0.0;
        }
    }
}


