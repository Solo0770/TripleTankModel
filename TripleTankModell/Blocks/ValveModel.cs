using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTankModell.Blocks
{
    public class ValveModel : BaseBlock
    {
        private readonly SubBlock headDiff;
        private readonly SqrtBlock sqrt;
        private readonly GainBlock gain;

        private readonly Tank1Model from;
        private readonly Tank1Model to;

        public ValveModel(BaseBlock fromTank, BaseBlock toTank, double coefficient)
        {
            from = (Tank1Model)fromTank;
            to = (Tank1Model)toTank;

            headDiff = new SubBlock();
            sqrt = new SqrtBlock();
            gain = new GainBlock(coefficient);
        }

        public override void Update(double deltaTime)
        {
            headDiff.Input1 = from.Level;
            headDiff.Input2 = to.Level;
            headDiff.Update(deltaTime);

            sqrt.Input = Math.Max(0, headDiff.Output);
            sqrt.Update(deltaTime);

            gain.Input = sqrt.Output;
            gain.Update(deltaTime);

            Output = gain.Output;
        }
    }
}
