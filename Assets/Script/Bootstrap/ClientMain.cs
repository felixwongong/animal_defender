using System.Collections.Generic;
using CofyEngine;
using CofyEngine.Editor;
using UnityEngine;

namespace CofyDev.AnimalDefender.Bootstrap
{
    public class ClientMain : MonoInstance<ClientMain>
    {
        [CofyScene] public List<string> persistentScenes;
        [SerializeField] private ConfigSO config;

        void Start()
        {
            ConfigSO.inst = config;
            
            BootstrapStateMachine.instance.Init();
            LevelManager.instance.SetPersistent(persistentScenes);
        }
    }
}