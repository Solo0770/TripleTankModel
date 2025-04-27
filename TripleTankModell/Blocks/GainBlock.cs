using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTankModell.Blocks
{
    public class GainBlock : BaseBlock
    {
        public double Input { get; set; }
        public double Gain { get; set; }

        public GainBlock(double gain)
        {
            Gain = gain;
        }

        public override void Update(double deltaTime)
        {
            Output = Gain * Input;
        }
    }
}


