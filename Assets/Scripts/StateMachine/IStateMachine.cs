using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StateMachine
{
    public interface IStateMachine
    {
        public void Initialize(IState startingState);
        public void ChangeState(IState newState);
    }
}
