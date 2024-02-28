using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.State
{
    internal class SmallMarioState : IMarioState
    {
        private readonly Mario _mario;

        public SmallMarioState(Mario mario)
        {
            _mario = mario;
        }

        public void EatMushroom()
        {
            _mario.SetNextState(new BigMarioState(_mario));
        }

        public void MeetTurtle()
        {
            Console.WriteLine("Игра окончена");
        }
    }
}
