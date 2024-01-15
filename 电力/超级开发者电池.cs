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
    [HarmonyPatch(typeof(DevGeneratorConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    internal class 启用开发者电池
    {
        public static void Postfix(BuildingDef __result)
        {
            bool 启用开发者电池 = SingletonOptions<控制台>.Instance.开发者电池;
            if (启用开发者电池)
            {
                __result.DebugOnly = false;//正常模式可使用
                __result.Floodable = false;//可被淹没
                __result.Overheatable = false;//不会过热
                __result.ThermalConductivity = 0f;//导热系数为0
                __result.UseStructureTemperature = false;//不使用结构温度
                //--------------------------
                bool 开发者电池输出功率及容量 = SingletonOptions<控制台>.Instance.开发者电池输出无穷大;
                if (开发者电池输出功率及容量)
                {
                    __result.GeneratorWattageRating = float.PositiveInfinity;//功率
                    __result.GeneratorBaseCapacity = float.PositiveInfinity;//容量
                }
                //--------------------------
            }
        }
    }
    [HarmonyPatch(typeof(DevGeneratorConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 开发者发电机额定功率
    {
        private static void Postfix(GameObject go)
        {
            bool 开发者发电机额定功率 = SingletonOptions<控制台>.Instance.开发者电池输出无穷大;
            if (开发者发电机额定功率)
            {
                DevGenerator devGenerator = go.AddOrGet<DevGenerator>();
                devGenerator.wattageRating = float.PositiveInfinity;//额定功率
            }
        }
    }
}

