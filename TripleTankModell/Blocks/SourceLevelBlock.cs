using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTankModell.Blocks
{
    public class SourceLevelBlock : BaseBlock
    {
        private readonly GainBlock gain;
        private readonly LimitBlock limit;

        public SourceLevelBlock()
        {
            
            gain = new GainBlock(1000.0);
            limit = new LimitBlock(0, 100000.0);
        }

        public override void Update(double deltaTime)
        {
            gain.Input = 1;
            gain.Update(deltaTime);

            limit.Input = gain.Output;
            limit.Update(deltaTime);

            Output = limit.Output;
        }
    }
}

