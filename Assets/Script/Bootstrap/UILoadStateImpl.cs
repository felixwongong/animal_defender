using System.Collections.Generic;
using CofyDev.AnimalDefender.UI;
using CofyEngine;
using CofyUI;
using UnityEngine;

namespace CofyDev.AnimalDefender.Bootstrap
{
    public class UILoadStateImpl: UILoadState
    {
        protected override Future<List<GameObject>> LoadAll()
        {
            List<Future<GameObject>> promise = new List<Future<GameObject>>();
            
            promise.Add(UIRoot.instance.Bind<BattleUIPanel>(LoadUI("Battle/battle_panel")));
            promise.Add(UIRoot.instance.Bind<ConfirmationPopupPanel>(LoadUI("Popup/confirmation_popup_panel")));

            return promise.Group();
        }
    }
}