using System.Collections.Generic;
using CofyEngine;
using CofyEngine.Editor;

namespace CofyDev.AnimalDefender.Bootstrap
{
    public class ClientMain : MonoInstance<ClientMain>
    {
        [CofyScene] public List<string> persistentScenes;
        public ConfigInfoSO config;

        void Start()
        {
            BootstrapStateMachine.instance.Init();
            LevelManager.instance.SetPersistent(persistentScenes);
        }
    }
}