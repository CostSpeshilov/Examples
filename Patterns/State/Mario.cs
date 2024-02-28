using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.State
{
    public class Mario
    {
        private IMarioState _currentState;

        public Mario()
        {
            _currentState = new SmallMarioState(this);
        }

        public void EatMushroom()
        {
            _currentState.EatMushroom();
        }

        public void MeetTurtle()
        {
            _currentState.MeetTurtle();
        }

        internal void SetNextState(IMarioState next)
        {
            _currentState = next;   
        }

        public string CurrentStateName => _currentState.GetType().Name;
    }
}
