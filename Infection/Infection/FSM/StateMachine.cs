using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infection
{
    enum StateEnum
    {
        SANE, NEARINFECTED, INFECTED, LAST
    }

    class StateMachine
    {
        private Dictionary<StateEnum, State> states;
        public State Current { get; private set; }

        public StateMachine()
        {
            states = new Dictionary<StateEnum, State>();
            Current = null;
        }

        public void AddState(StateEnum key, State value)
        {
            states[key] = value;
            value.SetStateMachine(this);
        }

        public void GoTo(StateEnum key)
        {
            if(Current != null)
            {
                Current.OnExit();
            }

            Current = states[key];
            Current.OnEnter();
        }

        public void Update()
        {
            Current.Update();
        }
    }
}
