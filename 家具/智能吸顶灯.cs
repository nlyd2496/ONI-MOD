using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.控制器;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    [HarmonyPatch(typeof(CeilingLightConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 智能吸顶灯
    {
        public static void Postfix(GameObject go)
        {
            bool 启用点唱机 = SingletonOptions<控制台>.Instance.智能吸顶灯;
            if (启用点唱机)
            {
                go.AddOrGet<A17GG1_KZQ>();
            }
        }
    }
}
