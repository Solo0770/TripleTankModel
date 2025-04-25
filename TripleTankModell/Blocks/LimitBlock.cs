using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTankModell.Blocks
{
    public class LimitBlock : BaseBlock
    {
        public double Input { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }

        public override void Update(double deltaTime)
        {
            if (Input < Min)
                Output = Min;
            else if (Input > Max)
                Output = Max;
            else
                Output = Input;
        }
    }
}
