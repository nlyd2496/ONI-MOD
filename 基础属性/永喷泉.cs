using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.基础属性
{
    //喷发质量倍数
    [HarmonyPatch(typeof(GeyserConfigurator.GeyserInstanceConfiguration))]
    [HarmonyPatch("GetEmitRate")]
    public static class 喷发质量倍数
    {
        private static void Postfix(ref float __result)
        {
            bool 永喷泉 = SingletonOptions<控制台>.Instance.永喷泉;
            if (永喷泉)
            {
                __result *= SingletonOptions<控制台>.Instance.喷发质量倍数;
            }
        }
    }
    //喷泉喷发期
    [HarmonyPatch(typeof(GeyserConfigurator.GeyserInstanceConfiguration))]
    [HarmonyPatch("GetIterationPercent")]//获取迭代百分百
    public static class 喷泉喷发期
    {
        public static void Postfix(ref float __result)
        {
            bool 永喷泉 = SingletonOptions<控制台>.Instance.永喷泉;
            if (永喷泉)
            {
                __result = 1f;
            }
        }
    }
    //喷泉活跃期
    [HarmonyPatch(typeof(GeyserConfigurator.GeyserInstanceConfiguration))]
    [HarmonyPatch("GetYearPercent")]//获取年度百分百
    public static class 喷泉活跃期
    {
        private static void Postfix(ref float __result)
        {
            bool 永喷泉 = SingletonOptions<控制台>.Instance.永喷泉;
            if (永喷泉)
            {
                __result = 1f;
            }
        }
    }
}
