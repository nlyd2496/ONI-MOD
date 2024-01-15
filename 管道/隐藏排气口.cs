using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.管道
{
    [HarmonyPatch(typeof(GasVentConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 隐藏排气口
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 隐藏排气口 = SingletonOptions<控制台>.Instance.隐藏排气口;
            if (隐藏排气口)
            {
                __result.SceneLayer = Grid.SceneLayer.BuildingBack;
                __result.ObjectLayer = ObjectLayer.Critter;//动物层
            }
        }
    }
}
