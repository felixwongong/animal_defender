using System.Collections.Generic;
using CofyEngine;
using CofyUI;
using UnityEngine;

namespace CofyDev.AnimalDefender.Bootstrap
{
    public class BootstrapUIImpl: BootstrapUI
    {
        protected override Future<List<GameObject>> LoadAll()
        {
            List<Future<GameObject>> promise = new List<Future<GameObject>>();
            
            promise.Add(UIRoot.instance.Bind<BattleUIPanel>(LoadUI("Battle/battle_panel")));

            return promise.Group();
        }
    }
}