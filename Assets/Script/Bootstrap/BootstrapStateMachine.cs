﻿using CofyEngine;
using CofyEngine.Util;

namespace CofyDev.AnimalDefender.Bootstrap
{
    public class BootstrapStateMachine : Instance<BootstrapStateMachine>
    {
        private StateMachine<BootStateId> sm;

        public BootstrapStateMachine()
        {
            sm = new StateMachine<BootStateId>(true);
            sm.RegisterState(new LoadLocalState());
            sm.RegisterState(new AtlasLoadState());
            sm.RegisterState(new UILoadStateImpl());
            sm.RegisterState(new LoginState());
            sm.RegisterState(new TerminateState(GameStateMachineImpl.instance));
        }

        public void Init()
        {
            sm.GoToState(BootStateId.LoadLocal);
        }
    }
}