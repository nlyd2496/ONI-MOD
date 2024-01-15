using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.火箭
{
    [HarmonyPatch(typeof(LiquidCargoBayClusterConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 火箭大型液缸容量
    {
        public static void Postfix(GameObject go)
        {
            bool 火箭更大货仓 = SingletonOptions<控制台>.Instance.火箭更大货仓;
            if (火箭更大货仓)
            {
                go = BuildingTemplates.ExtendBuildingToClusterCargoBay(go, SingletonOptions<控制台>.Instance.火箭货仓容量, STORAGEFILTERS.LIQUIDS, CargoBay.CargoType.Liquids);
            }
        }
    }
    [HarmonyPatch(typeof(LiquidCargoBaySmallConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 火箭小型液缸容量
    {
        public static void Postfix(GameObject go)
        {
            bool 火箭更大货仓 = SingletonOptions<控制台>.Instance.火箭更大货仓;
            if (火箭更大货仓)
            {
                go = BuildingTemplates.ExtendBuildingToClusterCargoBay(go, SingletonOptions<控制台>.Instance.火箭货仓容量, STORAGEFILTERS.LIQUIDS, CargoBay.CargoType.Liquids);
            }
        }
    }
        [HarmonyPatch(typeof(GasCargoBayClusterConfig))]
        [HarmonyPatch("DoPostConfigureComplete")]
        public class 火箭大型气缸容量
    {
            public static void Postfix(GameObject go)
            {
                bool 火箭更大货仓 = SingletonOptions<控制台>.Instance.火箭更大货仓;
                if (火箭更大货仓)
                {
                    go = BuildingTemplates.ExtendBuildingToClusterCargoBay(go, SingletonOptions<控制台>.Instance.火箭货仓容量, STORAGEFILTERS.GASES, CargoBay.CargoType.Gasses);
                }
            }
        }
    [HarmonyPatch(typeof(GasCargoBaySmallConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 火箭小型气缸容量
    {
        public static void Postfix(GameObject go)
        {
            bool 火箭更大货仓 = SingletonOptions<控制台>.Instance.火箭更大货仓;
            if (火箭更大货仓)
            {
                go = BuildingTemplates.ExtendBuildingToClusterCargoBay(go, SingletonOptions<控制台>.Instance.火箭货仓容量, STORAGEFILTERS.GASES, CargoBay.CargoType.Gasses);
            }
        }
    }
    [HarmonyPatch(typeof(SolidCargoBayClusterConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 火箭大型固缸容量
    {
        public static void Postfix(GameObject go)
        {
            bool 火箭更大货仓 = SingletonOptions<控制台>.Instance.火箭更大货仓;
            if (火箭更大货仓)
            {
                go = BuildingTemplates.ExtendBuildingToClusterCargoBay(go, SingletonOptions<控制台>.Instance.火箭货仓容量, STORAGEFILTERS.NOT_EDIBLE_SOLIDS, CargoBay.CargoType.Solids);
            }
        }
    }
    [HarmonyPatch(typeof(SolidCargoBaySmallConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 火箭小型固缸容量
    {
        public static void Postfix(GameObject go)
        {
            bool 火箭更大货仓 = SingletonOptions<控制台>.Instance.火箭更大货仓;
            if (火箭更大货仓)
            {
                go = BuildingTemplates.ExtendBuildingToClusterCargoBay(go, SingletonOptions<控制台>.Instance.火箭货仓容量, STORAGEFILTERS.NOT_EDIBLE_SOLIDS, CargoBay.CargoType.Solids);
            }
        }
    }
}
