using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Klei;
using 吐泡泡的小鱼的缺氧模组.控制器;
using PeterHan.PLib.Options;


namespace 吐泡泡的小鱼的缺氧模组.家具
{
    [HarmonyPatch(typeof(MarbleSculptureConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    internal class 闪烁的雕塑
    {
        private static void Postfix(GameObject go)
        {
            bool 闪烁的雕塑 = SingletonOptions<控制台>.Instance.闪烁的雕塑;
            if (闪烁的雕塑)
            {
                
                go.AddOrGet<A76GG1_KZQ>();
                
            }
        }
    }
}
