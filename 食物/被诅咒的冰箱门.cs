using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.食物
{
    [HarmonyPatch(typeof(RefrigeratorConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    internal class 激活时能耗
    {
        private static void Postfix(GameObject go)
        {
            bool 被诅咒的冰箱门 = SingletonOptions<控制台>.Instance.被诅咒的冰箱门;
            if (被诅咒的冰箱门)
            {
                go.AddOrGetDef<RefrigeratorController.Def>().powerSaverEnergyUsage = 80f;
            }
        }
    }
    [HarmonyPatch(typeof(RefrigeratorConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 待机功率及发热量
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 被诅咒的冰箱门 = SingletonOptions<控制台>.Instance.被诅咒的冰箱门;
            if (被诅咒的冰箱门)
            {
                __result.SelfHeatKilowattsWhenActive = -10f;
                __result.EnergyConsumptionWhenActive = 180f;
            }
        }
    }
    [HarmonyPatch(typeof(RefrigeratorConfig))]//一级目录
    [HarmonyPatch("ConfigureBuildingTemplate")]
    internal class 最低环境制冷温度
    {
        private static void Postfix(GameObject go)
        {
            bool 被诅咒的冰箱门 = SingletonOptions<控制台>.Instance.被诅咒的冰箱门;
            if (被诅咒的冰箱门)
            {
                go.AddOrGet<MinimumOperatingTemperature>().minimumTemperature = 73.15f;//最低温度，单位K
            }
        }
    }
}
