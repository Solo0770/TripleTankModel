using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTankModell.Blocks;

namespace TripleTankModell.Model
{
    using TripleTankModell.Blocks;

    public class ObjectModel
    {
        public TankBlock Tank1 { get; }
        public TankBlock Tank2 { get; }
        public TankBlock Tank3 { get; }

        public ValveBlock ValveIn { get; }
        public ValveBlock Valve12 { get; }
        public ValveBlock ValveOut { get; }

        private double dt = 0.1;
        /*private const double SourceLevel = 10000.0;*/

        private SourceLevelBlock sourceBlock;


        public ObjectModel()
        {
            Tank1 = new TankBlock(dt);
            Tank2 = new TankBlock(dt);
            Tank3 = new TankBlock(dt);

            ValveIn = new ValveBlock();
            Valve12 = new ValveBlock();
            ValveOut = new ValveBlock();

            sourceBlock = new SourceLevelBlock();

        }

        public void Update(double deltaTime)
        {
            /*ValveIn.Input1 = SourceLevel;*/

            sourceBlock.Update(deltaTime);
            ValveIn.Input1 = sourceBlock.Output;

            ValveIn.Input2 = Tank1.Level;
            ValveIn.Update(deltaTime);

            Valve12.Input1 = Tank1.Level;
            Valve12.Input2 = Tank2.Level;
            Valve12.Update(deltaTime);

            ValveOut.Input1 = Tank3.Level;
            ValveOut.Input2 = 0;
            ValveOut.Update(deltaTime);

            Tank1.Inflow = ValveIn.Output;
            Tank1.Outflow = Valve12.Output;
            Tank1.Update(deltaTime);

            double inflowPerTank = Valve12.Output / 2.0;

            double deltaZ23 = Tank2.Level - Tank3.Level;
            double flow23 = 0;
            if (deltaZ23 > 0)
            {
                flow23 = ValveBlock.Cd * ValveBlock.Area * Math.Sqrt(2 * ValveBlock.g * deltaZ23);
            }

            Tank1.Inflow = ValveIn.Output;
            Tank1.Outflow = Valve12.Output;
            Tank1.Update(deltaTime);

            Tank2.Inflow = inflowPerTank;
            Tank2.Outflow = flow23;
            Tank2.Update(deltaTime);

            Tank3.Inflow = inflowPerTank + flow23;
            Tank3.Outflow = ValveOut.Output;
            Tank3.Update(deltaTime);



            Tank2.Update(deltaTime);
            Tank3.Update(deltaTime);
        }
    }
}
