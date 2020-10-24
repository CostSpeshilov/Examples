using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.ISP.Bad
{
    class Player
    {
        Configuration conf;
        public Player()
        {
            conf.LoadPlayerConf();
        }
    }
}
