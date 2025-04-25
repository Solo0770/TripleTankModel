using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTankModell.Blocks
{
    public class SqrtBlock : BaseBlock
    {
        public double Input { get; set; }

        public override void Update(double deltaTime)
        {
            Output = Math.Sqrt(Input);
        }
    }
}
