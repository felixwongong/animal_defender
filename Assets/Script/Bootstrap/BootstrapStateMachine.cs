using CofyEngine;
using CofyEngine.Util;

namespace CofyDev.AnimalDefender.Bootstrap
{
    public class BootstrapStateMachine : Instance<BootstrapStateMachine>
    {
        private StateMachine<BootStateId> sm;

        public BootstrapStateMachine()
        {
            sm = new StateMachine<BootStateId>(true);
            sm.RegisterState(new BootstrapUIImpl());
            sm.RegisterState(new BootstrapUGS());
            sm.RegisterState(new TerminateState(GameStateMachineImpl.instance));
        }

        public void Init()
        {
            sm.GoToState(BootStateId.UI);
        }
    }
}