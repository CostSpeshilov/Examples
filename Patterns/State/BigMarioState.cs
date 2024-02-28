using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.State
{
    internal class BigMarioState : IMarioState
    {
        private readonly Mario _mario;

        public BigMarioState(Mario mario)
        {
            _mario = mario;
        }

        public void EatMushroom()
        {
            
        }

        public void MeetTurtle()
        {
            _mario.SetNextState(new SmallMarioState(_mario));
        }
    }
}
