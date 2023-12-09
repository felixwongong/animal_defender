using System.Collections.Generic;
using CofyEngine;
using UnityEngine;

namespace CofyDev.AnimalDefender.Bootstrap
{
    public class BootstrapUIImpl: BootstrapUI
    {
        protected override Future<List<GameObject>> LoadAll()
        {
            List<Future<GameObject>> loadPromise = new List<Future<GameObject>>();

            
            return loadPromise.Group();
        }
    }
}