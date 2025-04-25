using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTankModell.Blocks;

namespace TripleTankModell.Model
{
    public class Model
    {
        public Tank1Model Tank1 { get; }
        public Tank2Model Tank2 { get; }
        public Tank3Model Tank3 { get; }

        public ValveModel Valve12 { get; }
        public ValveModel Valve23 { get; }
        public ValveWithPressure ValveOut { get; }
        public ValveInWithPressure ValveIn { get; }

        private double dt = 0.1;
        public double ValveOutControl { get; set; } = 0.0;

        public double Pout => ValveOutControl * 10.0;



        public Model()
        {
            Tank1 = new Tank1Model(area: 1.0, dt);
            Tank2 = new Tank2Model(area: 1.0, dt);
            Tank3 = new Tank3Model(area: 1.0, dt);

            ValveIn = new ValveInWithPressure(Tank1, 0.0, 1.0);
            Valve12 = new ValveModel(Tank1, Tank2, 1.0);
            Valve23 = new ValveModel(Tank2, Tank3, 1.0);
            ValveOut = new ValveWithPressure(Tank3, 1.0);
        }

        public double Pin
        {
            get => ValveIn.Pin;
            set => ValveIn.SetPressure(value);
        }

        public void Update(double deltaTime)
        {
            ValveOut.Pout = Pout; 


            ValveOut.Update(deltaTime);
            Tank3.Outflow = ValveOut.Output;

            ValveIn.Update(deltaTime);
            Valve12.Update(deltaTime);
            Valve23.Update(deltaTime);
           
            Tank1.Inflow = ValveIn.Output;
            Tank1.Outflow = Valve12.Output;

            Tank2.Inflow = Valve12.Output;
            Tank2.Outflow = Valve23.Output;

            Tank3.Inflow = Valve23.Output;
            
            Tank1.Update(deltaTime);
            Tank2.Update(deltaTime);
            Tank3.Update(deltaTime);
      

        }
    }
}


