using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StateMachine
{
    public class StateMachine : IStateMachine
    {
        private IState _currentState;

        public void Initialize(IState startingState)
        {
            _currentState = startingState;
            _currentState.Enter();
        }
        public void ChangeState(IState newState)
        {
            _currentState.Exit();
            _currentState = newState;
            _currentState.Enter();
        }
    }
}
