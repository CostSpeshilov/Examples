using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.ISP.Good
{
    class Physics
    {
        IPhysicsConfiguration conf;
        public Physics()
        {
            conf.LoadPhysicsConf();
        }
    }
}
