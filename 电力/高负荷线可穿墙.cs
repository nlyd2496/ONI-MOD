using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.电力
{
    [HarmonyPatch(typeof(WireRefinedHighWattageConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 高负荷导线可穿墙
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 高负荷导线可穿墙 = SingletonOptions<控制台>.Instance.高负荷导线可穿墙;
            if (高负荷导线可穿墙)
            {
                __result.BuildLocationRule = BuildLocationRule.Anywhere;
            }
        }
    }
    [HarmonyPatch(typeof(WireHighWattageConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 高负荷电线可穿墙
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 高负荷电线可穿墙 = SingletonOptions<控制台>.Instance.高负荷电线可穿墙;
            if (高负荷电线可穿墙)
            {
                __result.BuildLocationRule = BuildLocationRule.Anywhere;
            }
        }
    }
}
