using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTankModell.Blocks
{
    public class SubBlock : BaseBlock
    {
        public double Input1 { get; set; }
        public double Input2 { get; set; }

        public override void Update(double deltaTime)
        {
            Output = Input1 - Input2;
        }
    }
}
