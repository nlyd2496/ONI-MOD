using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.运输
{
    [HarmonyPatch(typeof(DevPumpSolidConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    internal class 超级开发者固体泵
    {
        public static void Postfix(BuildingDef __result)
        {
            bool 超级开发者固体泵 = SingletonOptions<控制台>.Instance.超级开发者固体泵;
            if (超级开发者固体泵)
            {
                __result.DebugOnly = false;//正常模式可使用
                __result.Floodable = false;//可被淹没
                __result.Overheatable = false;//不会过热
                __result.ThermalConductivity = 0f;//导热系数为0
                __result.UseStructureTemperature = false;//使用结构温度
            }
        }
    }
}
