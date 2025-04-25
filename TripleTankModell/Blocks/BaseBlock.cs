using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTankModell.Blocks
{
    public abstract class BaseBlock
    {
        public double Output { get; protected set; }

        public abstract void Update(double deltaTime);
    }
}

