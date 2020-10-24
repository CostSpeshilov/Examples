using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.ISP.Good
{
    class Player
    {
        IPlayerConfiguration conf;
        public Player()
        {
            conf.LoadPlayerConf();
        }
    }
}
