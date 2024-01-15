using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.电力
{
    [HarmonyPatch(typeof(HydrogenGeneratorConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 启用超级氢气发电机
    {
        public static void Postfix(HydrogenGeneratorConfig __instance, ref BuildingDef __result)
        {
            bool 启用超级氢气发电机 = SingletonOptions<控制台>.Instance.超级氢气发电机;
            if (启用超级氢气发电机)
            {
                __result.GeneratorWattageRating = SingletonOptions<控制台>.Instance.超级氢气发电机功率;//功率
                __result.GeneratorBaseCapacity = 200000f;//容量
                __result.ExhaustKilowattsWhenActive = 0f;//发热
                __result.SelfHeatKilowattsWhenActive = 0f;//发热
                __result.PowerOutputOffset = new CellOffset(-1, 0);//电力输出口
            }
        }
    }
    [HarmonyPatch(typeof(HydrogenGeneratorConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 超级氢气发电机氢气消耗
    {
        public static void Postfix(GameObject go)
        {
            bool 启用超级氢气发电机 = SingletonOptions<控制台>.Instance.超级氢气发电机;
            if (启用超级氢气发电机)
            {
                go.AddOrGet<EnergyGenerator>().formula = EnergyGenerator.CreateSimpleFormula(SimHashes.Hydrogen.CreateTag(), SingletonOptions<控制台>.Instance.超级氢气发电机氢气消耗, 2f, SimHashes.Void, 0f, true, default(CellOffset), 0f);//氢气消耗量

            }
        }
    }
}
