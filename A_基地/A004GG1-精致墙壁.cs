using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.A_基地
{
    [HarmonyPatch(typeof(ThermalBlockConfig), "CreateBuildingDef")]
    public static class 导热板装饰度修改
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool A004GG1 = SingletonOptions<控制台>.Instance.A004GG1;
            if (A004GG1)
            {
                __result.BaseDecor = 10;
                __result.BaseDecorRadius = 4;
            }
        }
    }

    [HarmonyPatch(typeof(ExteriorWallConfig), "CreateBuildingDef")]
    public static class 干板墙装饰度修改
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool A004GG1 = SingletonOptions<控制台>.Instance.A004GG1;
            if (A004GG1)
            {
                __result.BaseDecor = 5;
                __result.BaseDecorRadius = 2;
            }
        }
    }
}
