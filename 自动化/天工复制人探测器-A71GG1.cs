using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using STRINGS;
using TUNING;
using UnityEngine;
using Database;
using HarmonyLib;

namespace 吐泡泡的小鱼的缺氧模组.自动化
{
    [HarmonyPatch(typeof(BuildingFacades), MethodType.Constructor, new Type[] { typeof(ResourceSet) })]
    public static class 蓝图系统A71GG1
    {
        public static void Postfix(BuildingFacades __instance)
        {
            bool 天工复制人探测器 = SingletonOptions<控制台>.Instance.天工复制人探测器;
            if (天工复制人探测器)
            {
                __instance.Add("A71GG1",
                STRINGS.BUILDINGS.PREFABS.A71GG1.NAME, STRINGS.BUILDINGS.PREFABS.A71GG1.EFFECT, PermitRarity.Universal,
                "LogicDuplicantSensor", "A71GG1_kanim", null);
            }
        }
    }
}
