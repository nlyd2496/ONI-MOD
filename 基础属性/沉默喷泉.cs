using System;
using HarmonyLib;
using UnityEngine;
using TUNING;
using PeterHan.PLib.Options;

namespace 吐泡泡的小鱼的缺氧模组.基础属性
{
    [HarmonyPatch(typeof(GeyserConfigurator.GeyserInstanceConfiguration))]
    [HarmonyPatch("GetIterationPercent")]//获取迭代百分百
    public static class 喷泉喷发期为零
    {
        public static void Postfix(ref float __result)
        {
            bool 沉默喷泉 = SingletonOptions<控制台>.Instance.沉默喷泉;
            if (沉默喷泉)
            {
                __result = 0f;
            }
        }
    }
    //--------------------------
    [HarmonyPatch(typeof(GeyserConfigurator.GeyserInstanceConfiguration))]
    [HarmonyPatch("GetYearPercent")]//获取年度百分百
    public static class 喷泉活跃期为零
    {
        private static void Postfix(ref float __result)
        {
            bool 沉默喷泉 = SingletonOptions<控制台>.Instance.沉默喷泉;
            if (沉默喷泉)
            {
                __result = 0f;
            }
        }
    }
}
