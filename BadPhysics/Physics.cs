using Solid.ISP.Bad;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.ISP
{
    class Physics
    {
        Configuration conf;
        public Physics()
        {
            conf.LoadPhysicsConf();
        }
    }
}
