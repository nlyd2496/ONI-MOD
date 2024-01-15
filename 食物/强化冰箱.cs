using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.控制器;

namespace 吐泡泡的小鱼的缺氧模组.食物
{
    [HarmonyPatch(typeof(RefrigeratorConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 冰箱基础属性
    {
        private static void Postfix(BuildingDef __result)
        {
            bool 强化冰箱 = SingletonOptions<控制台>.Instance.强化冰箱;
            if (强化冰箱)
            {
                __result.BaseDecor = 10f;//装饰度
                __result.BaseDecorRadius = 3f;//装饰范围  
                __result.EnergyConsumptionWhenActive = 0.01f * SingletonOptions<控制台>.Instance.冰箱容量;//功率 Power
                __result.SelfHeatKilowattsWhenActive = 0.1f;//激活时发热量 Heat at activation
            }  
        }
    }
    [HarmonyPatch(typeof(RefrigeratorConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 冰箱高级属性
    {
        private static void Postfix(GameObject go)
        {
            bool 强化冰箱 = SingletonOptions<控制台>.Instance.强化冰箱;
            if (强化冰箱)
            {
                go.AddOrGet<Storage>().capacityKg = SingletonOptions<控制台>.Instance.冰箱容量;//容量 Capacity
                RefrigeratorController.Def def = go.AddOrGetDef<RefrigeratorController.Def>();
                def.powerSaverEnergyUsage = 10f;//待机功率
                def.coolingHeatKW = 0.1f;//冷却热量

            }
        }
    }
    [HarmonyPatch(typeof(RefrigeratorController.Def))]
    [HarmonyPatch(MethodType.Constructor)]
    public class 冷藏温度
    {
        private static void Postfix(ref float ___simulatedInternalTemperature)
        {
            bool 强化冰箱 = SingletonOptions<控制台>.Instance.强化冰箱;
            if (强化冰箱)
            {
                ___simulatedInternalTemperature = 207.15f;//冷藏温度-66度
            }
        }
    }
}
