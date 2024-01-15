using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.管道
{
    [HarmonyPatch(typeof(InsulatedGasConduitConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class Patch_a
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool C001GG1 = SingletonOptions<控制台>.Instance.C001GG1;
            if (C001GG1)
            {
                __result.ThermalConductivity = 0f;
            }
        }
    }
    //--------------------------------------------------------------------------------------------------------------------
    //隔热液体管道导热系数=0
    [HarmonyPatch(typeof(InsulatedLiquidConduitConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class Patch_b
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool C001GG1 = SingletonOptions<控制台>.Instance.C001GG1;
            if (C001GG1)
            {
                __result.ThermalConductivity = 0f;
            }
        }
    }
}
