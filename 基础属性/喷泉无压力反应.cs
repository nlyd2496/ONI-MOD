using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.基础属性
{
    [HarmonyPatch(typeof(GeyserConfigurator.GeyserInstanceConfiguration))]
    [HarmonyPatch("GetMaxPressure")]
    public static class 喷泉无压力反应
    {
        private static void Postfix(ref float __result)
        {
            bool 喷泉无压力反应 = SingletonOptions<控制台>.Instance.喷泉无压力反应;
            if (喷泉无压力反应)
            {
                __result = float.MaxValue;
            }
        }
    }
}
