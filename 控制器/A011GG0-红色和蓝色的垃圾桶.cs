using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.控制器
{
    public class A011GG0 : KMonoBehaviour, ISim1000ms
    {
        
        public void Sim1000ms(float dt)
        {

            foreach (GameObject go in this.storage.items)
            {
                go.DeleteObject();
            }
        }
        
        protected override void OnSpawn()
        {
            base.OnSpawn();
        }
        
        [MyCmpGet]
        internal Storage storage;
        
    }
}
