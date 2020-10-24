using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.ISP.Good
{
    class Configuration: IPhysicsConfiguration, IPlayerConfiguration, IStatisticsConfiguration
    {
        public void LoadPhysicsConf()
        {
            throw new NotImplementedException();
        }
        public void LoadPlayerConf()
        {
            throw new NotImplementedException();
        }
        public void LoadStatisticConf()
        {
            throw new NotImplementedException();
        }
    }
}
