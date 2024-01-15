using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.控制器;

namespace 吐泡泡的小鱼的缺氧模组.运输
{
    //--------------------------
    [HarmonyPatch(typeof(AutoMinerConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public static class 超级矿机之一
    {
        public static void Postfix(GameObject go)
        {
            bool 超级矿机 = SingletonOptions<控制台>.Instance.超级矿机;
            if (超级矿机)
            {
                go.AddOrGet<A74GG1_KZQ>();
            }
        }
    }
    //--------------------------
    [HarmonyPatch(typeof(AutoMinerConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 超级矿机之二
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 超级矿机 = SingletonOptions<控制台>.Instance.超级矿机;
            if (超级矿机)
            {
                __result.Overheatable = false;
                __result.Floodable = false;
            }
        }
    }
    //--------------------------
    [HarmonyPatch(typeof(AutoMiner))]
    [HarmonyPatch("DigBlockingCB")]
    public static class 超级矿机之三
    {
        private static void Postfix(int cell, ref bool __result)
        {
            bool 超级矿机 = SingletonOptions<控制台>.Instance.超级矿机;
            if (超级矿机)
            {
                __result = (Grid.Foundation[cell] || Grid.Element[cell].hardness >= byte.MaxValue);
            }
        }
    }
    //--------------------------
    [HarmonyPatch(typeof(AutoMiner))]
    [HarmonyPatch("ValidDigCell")]
    public static class 超级矿机之四
    {
        private static void Postfix(int cell, ref bool __result)
        {
            bool 超级矿机 = SingletonOptions<控制台>.Instance.超级矿机;
            if (超级矿机)
            {
                __result = (Grid.Solid[cell] && !Grid.Foundation[cell] && Grid.Element[cell].hardness < byte.MaxValue);
            }
        }
    }
    //--------------------------
}
