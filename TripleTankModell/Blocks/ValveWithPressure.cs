using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTankModell.Blocks
{
    public class ValveWithPressure : BaseBlock
    {
        private readonly SubBlock headDiff;
        private readonly SqrtBlock sqrt;
        private readonly GainBlock gain;

        private readonly Tank1Model from;
        public double Pout { get; set; } = 0;

/*
        public double Coefficient
        {
            get => gain.Gain;
            set => gain.Gain = value;
        }*/

        public ValveWithPressure(BaseBlock fromTank, double coefficient)
        {
            from = (Tank1Model)fromTank;

            headDiff = new SubBlock();
            sqrt = new SqrtBlock();
            gain = new GainBlock(coefficient);
        }

        public override void Update(double deltaTime)
        {
            headDiff.Input1 = from.Level;
            headDiff.Input2 = Pout;

            headDiff.Update(deltaTime);

            sqrt.Input = Math.Max(0, headDiff.Output);
            sqrt.Update(deltaTime);

            gain.Input = sqrt.Output;
            gain.Update(deltaTime);

            Output = gain.Output;
        }
        
    }
}

