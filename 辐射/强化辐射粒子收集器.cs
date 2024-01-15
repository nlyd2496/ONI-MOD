using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.辐射
{
    [HarmonyPatch(typeof(HighEnergyParticleStorage))]
    [HarmonyPatch("Store")]
    public class 辐射粒子收集器粒子收集倍率
    {
        public static void Postfix(HighEnergyParticleStorage __instance, float amount)
        {
            bool 强化辐射粒子收集器 = SingletonOptions<控制台>.Instance.强化辐射粒子收集器;
            if (强化辐射粒子收集器)
            {
                float num = __instance.Particles * SingletonOptions<控制台>.Instance.辐射粒子收集器收集倍率 * 0.1f;
                if (num <= 0f)
                {
                    num = 0f;
                }
                Helper.SetPrivateValue<HighEnergyParticleStorage>(__instance, "particles", num);
            }
        }
    }
    [HarmonyPatch(typeof(HighEnergyParticleSpawnerConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 辐射粒子收集器功率和发热
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 强化辐射粒子收集器 = SingletonOptions<控制台>.Instance.强化辐射粒子收集器;
            if (强化辐射粒子收集器)
            {
                __result.EnergyConsumptionWhenActive = SingletonOptions<控制台>.Instance.辐射粒子收集器功率;//功率
                __result.SelfHeatKilowattsWhenActive = SingletonOptions<控制台>.Instance.辐射粒子收集器发热;//发热
                __result.ExhaustKilowattsWhenActive = 0f;//喷气功率0
            }
        }
    }
    [HarmonyPatch(typeof(HighEnergyParticleSpawnerConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 辐射粒子收集器发射间隔
    {
        public static void Postfix(GameObject go)
        {
            bool 强化辐射粒子收集器 = SingletonOptions<控制台>.Instance.强化辐射粒子收集器;
            if (强化辐射粒子收集器)
            {
                go.AddOrGet<HighEnergyParticleSpawner>().minLaunchInterval = SingletonOptions<控制台>.Instance.辐射粒子收集器发射间隔;//发射间隔
                go.AddOrGet<HighEnergyParticleStorage>().capacity = 1000f;//粒子最大储量
                go.AddOrGet<HighEnergyParticleSpawner>().maxSlider = 1000;//粒子储量
            }
        }
    }
}
