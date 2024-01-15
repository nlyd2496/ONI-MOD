using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.A_基地
{
    [HarmonyPatch(typeof(StorageTileConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 存储砖容量更改
    {
        private static void Postfix(GameObject go)
        {
            bool A003GG1 = SingletonOptions<控制台>.Instance.A003GG1;
            if (A003GG1)
            {
                go.AddOrGet<Storage>().capacityKg = 10000f;
                go.AddOrGetDef<StorageTile.Def>().MaxCapacity = 10000f;
            }
        }
    }
    [HarmonyPatch(typeof(StorageTileConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public static class 存储砖装饰度修改
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool A003GG1 = SingletonOptions<控制台>.Instance.A003GG1;
            if (A003GG1)
            {
                __result.BaseDecor = 10;
                __result.BaseDecorRadius = 2;
            }
        }
    }
}
