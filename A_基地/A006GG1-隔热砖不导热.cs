using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.A_基地
{
    [HarmonyPatch(typeof(InsulationTileConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 隔热砖不导热
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool A006GG1 = SingletonOptions<控制台>.Instance.A006GG1;
            if (A006GG1)
            {
                __result.ThermalConductivity = 0f;
            }
        }
    }
}
