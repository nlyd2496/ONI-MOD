using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TUNING;

namespace 吐泡泡的小鱼的缺氧模组.火箭
{
    
    //辐射粒子引擎
    [HarmonyPatch(typeof(HEPEngineConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 辐射粒子引擎
    {
        public static void Postfix(GameObject go)
        {
            bool 超级辐射粒子引擎 = SingletonOptions<控制台>.Instance.超级辐射粒子引擎;
            if (超级辐射粒子引擎)
            {
                go.AddOrGet<RocketEngineCluster>().maxHeight = (int)SingletonOptions<控制台>.Instance.辐射粒子引擎火箭高度;
                go.AddOrGet<RocketEngineCluster>().efficiency = 100;
                BuildingTemplates.ExtendBuildingToRocketModuleCluster(go, null, (int)SingletonOptions<控制台>.Instance.辐射粒子引擎负担, SingletonOptions<控制台>.Instance.辐射粒子引擎功率, SingletonOptions<控制台>.Instance.辐射粒子火箭每格燃料消耗 / 600f);
            }
        }
    }
    
    //二氧化碳引擎
    [HarmonyPatch(typeof(CO2EngineConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 二氧化碳引擎
    {
        public static void Postfix(GameObject go)
        {
            bool 超级二氧化碳引擎 = SingletonOptions<控制台>.Instance.超级二氧化碳引擎;
            if (超级二氧化碳引擎)
            {
                go.AddOrGet<RocketEngineCluster>().maxHeight = (int)SingletonOptions<控制台>.Instance.二氧化碳引擎火箭高度;
                go.AddOrGet<RocketEngineCluster>().efficiency = 100;
                BuildingTemplates.ExtendBuildingToRocketModuleCluster(go, null, (int)SingletonOptions<控制台>.Instance.二氧化碳引擎负担, SingletonOptions<控制台>.Instance.二氧化碳引擎功率, SingletonOptions<控制台>.Instance.二氧化碳火箭每格燃料消耗 / 600f);
            }
        }
    }
    
    //糖素引擎
    [HarmonyPatch(typeof(SugarEngineConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 糖素引擎
    {
        public static void Postfix(GameObject go)
        {
            bool 超级糖素引擎 = SingletonOptions<控制台>.Instance.超级糖素引擎;
            if (超级糖素引擎)
            {
                go.AddOrGet<RocketEngineCluster>().maxHeight = (int)SingletonOptions<控制台>.Instance.糖素引擎火箭高度;
                go.AddOrGet<RocketEngineCluster>().efficiency = 100;
                BuildingTemplates.ExtendBuildingToRocketModuleCluster(go, null, (int)SingletonOptions<控制台>.Instance.糖素引擎负担, SingletonOptions<控制台>.Instance.糖素引擎功率, SingletonOptions<控制台>.Instance.糖素火箭每格燃料消耗 / 600f);
            }
        }
    }
    
    //蒸汽引擎
    [HarmonyPatch(typeof(SteamEngineClusterConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 蒸汽引擎
    {
        public static void Postfix(GameObject go)
        {
            bool 超级蒸汽引擎 = SingletonOptions<控制台>.Instance.超级蒸汽引擎;
            if (超级蒸汽引擎)
            {
                go.AddOrGet<RocketEngineCluster>().maxHeight = (int)SingletonOptions<控制台>.Instance.蒸汽引擎火箭高度;
                go.AddOrGet<RocketEngineCluster>().efficiency = 100;
                BuildingTemplates.ExtendBuildingToRocketModuleCluster(go, null, (int)SingletonOptions<控制台>.Instance.蒸汽引擎负担, SingletonOptions<控制台>.Instance.蒸汽引擎功率, SingletonOptions<控制台>.Instance.蒸汽火箭每格燃料消耗 / 600f);
            }
        }
    }
    
    //小型石油引擎
    [HarmonyPatch(typeof(KeroseneEngineClusterSmallConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 小型石油引擎
    {
        public static void Postfix(GameObject go)
        {
            bool 超级小型石油引擎 = SingletonOptions<控制台>.Instance.超级小型石油引擎;
            if (超级小型石油引擎)
            {
                go.AddOrGet<RocketEngineCluster>().maxHeight = (int)SingletonOptions<控制台>.Instance.小型石油引擎火箭高度;
                go.AddOrGet<RocketEngineCluster>().efficiency = 100;
                BuildingTemplates.ExtendBuildingToRocketModuleCluster(go, null, (int)SingletonOptions<控制台>.Instance.小型石油引擎负担, SingletonOptions<控制台>.Instance.小型石油引擎功率, SingletonOptions<控制台>.Instance.小型石油火箭每格燃料消耗 / 600f);
            }
        }
    }
    
    //石油引擎
    [HarmonyPatch(typeof(KeroseneEngineClusterConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 石油引擎
    {
        public static void Postfix(GameObject go)
        {
            bool 超级石油引擎 = SingletonOptions<控制台>.Instance.超级石油引擎;
            if (超级石油引擎)
            {
                go.AddOrGet<RocketEngineCluster>().maxHeight = (int)SingletonOptions<控制台>.Instance.石油引擎火箭高度;
                go.AddOrGet<RocketEngineCluster>().efficiency = 100;
                BuildingTemplates.ExtendBuildingToRocketModuleCluster(go, null, (int)SingletonOptions<控制台>.Instance.石油引擎负担, SingletonOptions<控制台>.Instance.石油引擎功率, SingletonOptions<控制台>.Instance.石油火箭每格燃料消耗 / 600f);
            }
        }
    }
    
    //液氢引擎
    [HarmonyPatch(typeof(HydrogenEngineClusterConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 液氢引擎
    {
        public static void Postfix(GameObject go)
        {
            bool 超级液氢引擎 = SingletonOptions<控制台>.Instance.超级液氢引擎;
            if (超级液氢引擎)
            {
                go.AddOrGet<RocketEngineCluster>().maxHeight = (int)SingletonOptions<控制台>.Instance.液氢引擎火箭高度;
                go.AddOrGet<RocketEngineCluster>().efficiency = 100;
                BuildingTemplates.ExtendBuildingToRocketModuleCluster(go, null, (int)SingletonOptions<控制台>.Instance.液氢引擎负担, SingletonOptions<控制台>.Instance.液氢引擎功率, SingletonOptions<控制台>.Instance.液氢火箭每格燃料消耗 / 600f);
            }
        }
    }
}
//go.AddOrGet<RocketEngineCluster>().maxHeight = 50; 支持火箭高度
//go.AddOrGet<RocketEngineCluster>().efficiency = 100; 发动机效率
//BuildingTemplates.ExtendBuildingToRocketModuleCluster(go, null, ROCKETRY.BURDEN.INSIGNIFICANT, (float)ROCKETRY.ENGINE_POWER.LATE_VERY_STRONG, ROCKETRY.FUEL_COST_PER_DISTANCE.GAS_VERY_LOW);
//负担、引擎功率、每单位燃料（一格=600单位）
//火箭速度=引擎功率/负担