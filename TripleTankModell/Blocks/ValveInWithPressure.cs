using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTankModell.Blocks
{
    public class ValveInWithPressure : BaseBlock
    {
        private readonly SubBlock headDiff;
        private readonly SqrtBlock sqrt;
        private readonly GainBlock gain;

        private readonly Tank1Model to;
        public double Pin { get; private set; }

        public ValveInWithPressure(BaseBlock toTank, double pIn, double coefficient)
        {
            to = (Tank1Model)toTank;
            Pin = pIn;

            headDiff = new SubBlock();
            sqrt = new SqrtBlock();
            gain = new GainBlock(coefficient);
        }

        public void SetPressure(double value)
        {
            Pin = value;
        }

        public override void Update(double deltaTime)
        {
            headDiff.Input1 = Pin;
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

