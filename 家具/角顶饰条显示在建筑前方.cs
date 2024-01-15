using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    [HarmonyPatch(typeof(CrownMouldingConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 角饰条在建筑前方
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 角顶饰条在建筑前方 = SingletonOptions<控制台>.Instance.角顶饰条在建筑前方;
            if (角顶饰条在建筑前方)
            {
                __result.SceneLayer = Grid.SceneLayer.BuildingFront;
                __result.ObjectLayer = ObjectLayer.Plants;
            }
        }
    }
    [HarmonyPatch(typeof(CornerMouldingConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 顶饰条在建筑前方
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 角顶饰条在建筑前方 = SingletonOptions<控制台>.Instance.角顶饰条在建筑前方;
            if (角顶饰条在建筑前方)
            {
                __result.SceneLayer = Grid.SceneLayer.BuildingFront;
            __result.ObjectLayer = ObjectLayer.Plants;
        } 
    }
    }
}
