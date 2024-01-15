using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.管道
{
    [HarmonyPatch(typeof(ConduitSensorConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 管道检测器可穿墙
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 管道检测器可穿墙 = SingletonOptions<控制台>.Instance.管道检测器可穿墙;
            if (管道检测器可穿墙)
            {
                __result.BuildLocationRule = BuildLocationRule.Conduit;
            }
        }
    }
}
