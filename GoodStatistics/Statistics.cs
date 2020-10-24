using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.ISP.Good
{
    class Statistics
    {
        IStatisticsConfiguration conf;
        public Statistics()
        {
            conf.LoadStatisticConf();
        }
    }
}
