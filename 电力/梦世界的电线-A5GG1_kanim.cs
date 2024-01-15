using System;
using HarmonyLib;
using PeterHan.PLib.Options;
using UnityEngine;
using static KAnim;

namespace 吐泡泡的小鱼的缺氧模组.电力
{
    [HarmonyPatch(typeof(WireConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public static class 梦世界的电线
    {
        private static BuildingDef Postfix(BuildingDef def)
        {
            bool 启用梦世界的电线 = SingletonOptions<控制台>.Instance.梦世界的电线;
            if (启用梦世界的电线)
            {
                def.AnimFiles = new KAnimFile[]
                {
                    Assets.GetAnim("A5GG1_kanim")
                };
            }
            return def;
        }
    }
}
