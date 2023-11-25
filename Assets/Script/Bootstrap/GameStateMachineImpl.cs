using CofyEngine;

namespace CofyDev.AnimalDefender.Bootstrap
{
    public class GameStateMachineImpl: GameStateMachine
    {
        private static GameStateMachineImpl _instance;
        public static GameStateMachineImpl instance => _instance ??= MonoUtils.createDDOL<GameStateMachineImpl>();
    }
}