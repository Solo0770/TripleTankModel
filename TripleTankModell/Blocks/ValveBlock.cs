using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTankModell.Blocks;

namespace TripleTankModell.Blocks
{
    public class ValveBlock : BaseBlock
    {
        public double OpenPercent { get; set; }
        public double Input1 { get; set; }
        public double Input2 { get; set; }

        private readonly GainBlock gainBlock;

        public static readonly double g = 9.81;
        public static readonly double Cd = 0.6;
        public static readonly double Area = 0.05;

        public ValveBlock()
        {
            gainBlock = new GainBlock(Cd * Area * Math.Sqrt(2 * g));
        }

        public override void Update(double deltaTime)
        {
            double deltaZ = Input1 - Input2;

            if (deltaZ <= 0)
            {
                Output = 0;
                return;
            }

            gainBlock.Input = Math.Sqrt(deltaZ);
            gainBlock.Update(deltaTime);

            Output = OpenPercent * gainBlock.Output;
        }
    }
}






