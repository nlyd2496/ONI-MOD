using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.控制器;

namespace 吐泡泡的小鱼的缺氧模组.实用
{
    [HarmonyPatch(typeof(SpaceHeaterConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public static class 智能空间加热器
    {
        public static void Postfix(GameObject go)
        {
            bool 智能空间加热器 = SingletonOptions<控制台>.Instance.智能空间加热器;
            if (智能空间加热器)
            {
                go.AddOrGet<A81GG1_KZQ>();
                go.AddOrGet<MinimumOperatingTemperature>().minimumTemperature = 13.15f;//最低工作温度30K
            }
        }
    }
    
    [HarmonyPatch(typeof(SpaceHeaterConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 智能空间加热器常规属性更改
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 智能空间加热器 = SingletonOptions<控制台>.Instance.智能空间加热器;
            if (智能空间加热器)
            {
                __result.OverheatTemperature = 873.15f;
                __result.EnergyConsumptionWhenActive = 130f;
                __result.ExhaustKilowattsWhenActive = 3f;
            }
        }
    }
}
