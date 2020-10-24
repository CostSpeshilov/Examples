using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.ISP.Bad
{
    class Statistics
    {
        Configuration conf;
        public Statistics()
        {
            conf.LoadStatisticConf();
        }
    }
}
