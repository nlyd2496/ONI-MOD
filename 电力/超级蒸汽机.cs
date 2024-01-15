using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.控制器;

namespace 吐泡泡的小鱼的缺氧模组.电力
{
    [HarmonyPatch(typeof(SteamTurbineConfig2))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 输出温度
    {
        public static void Postfix(GameObject go)
        {
            bool 启用超级蒸汽机 = SingletonOptions<控制台>.Instance.超级蒸汽机;
            if (启用超级蒸汽机)
            {
                SteamTurbine steamTurbine = go.AddOrGet<SteamTurbine>();
                steamTurbine.wasteHeatToTurbinePercent = SingletonOptions<控制台>.Instance.蒸汽机热量转移效率;//热量转移效率
                steamTurbine.minActiveTemperature = SingletonOptions<控制台>.Instance.蒸汽机吸收蒸汽最低温度 + 273.15f;//吸收蒸汽最低温度
                steamTurbine.outputElementTemperature = SingletonOptions<控制台>.Instance.蒸汽机输出液体温度 + 273.15f;//输出液体温度

                steamTurbine.maxBuildingTemperature = 423.15f;//蒸汽机过热温度

                go.AddOrGet<A6GG1_KZQ>();
            }
        }
    }
    [HarmonyPatch(typeof(SteamTurbineConfig2))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 蒸汽机功率上限
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 启用超级蒸汽机 = SingletonOptions<控制台>.Instance.超级蒸汽机;
            if (启用超级蒸汽机)
            {
                __result.GeneratorWattageRating = SingletonOptions<控制台>.Instance.蒸汽机功率上限;//蒸汽机功率上限
                __result.GeneratorBaseCapacity = SingletonOptions<控制台>.Instance.蒸汽机功率上限;//蒸汽机功率上限
            }
        }
    }
}
