using System;
using System.Collections.Generic;
using System.IO;
using CofyEngine;
using CofyEngine.Core;
using CofyEngine.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

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
            LevelManager.instance.SetPersistent(persistentScenes);
            
            //Except for ui load from local, e.g. loading_ui_panel, asset loader will not used
            UIPanel.assetLoader = path => 
                AssetManager.instance.LoadAsset<VisualTreeAsset>(Path.Combine(ConfigSO.inst.uiDirectory, path));
            
            BootstrapStateMachine.instance.Init();
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