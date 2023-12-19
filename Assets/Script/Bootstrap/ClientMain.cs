using System;
using System.Collections.Generic;
using CofyEngine;
using CofyEngine.Core;
using CofyEngine.Editor;
using UnityEditor;
using UnityEngine;

namespace CofyDev.AnimalDefender.Bootstrap
{
    public class ClientMain : MonoInstance<ClientMain>
    {
        [CofyAssetObject(typeof(SceneAsset))] 
        public List<string> persistentScenes;
        
        [SerializeField] private ConfigSO config;

        void Start()
        {
            ConfigSO.inst = config;
            
            BootstrapStateMachine.instance.Init();
            LevelManager.instance.SetPersistent(persistentScenes);
        }

        private void Update()
        {
            MainThreadExecutor.instance.OnUpdate();
        }

        private void OnDestroy()
        {
            MainThreadExecutor.instance.Dispose();
        }
    }
}