using System;
using HarmonyLib;
using PeterHan.PLib.Options;
using UnityEngine;
using TUNING;
using 吐泡泡的小鱼的缺氧模组;


namespace 吐泡泡的小鱼的缺氧模组.基础属性
{
    [HarmonyPatch(typeof(BuildingTemplates))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 超级装饰
    {
        private static void Postfix(BuildingDef __result)
        {
            bool 超级装饰 = SingletonOptions<控制台>.Instance.超级装饰;
            if (超级装饰)
            {
                __result.BaseDecor = SingletonOptions<控制台>.Instance.装饰度;//装饰度
                __result.BaseDecorRadius = SingletonOptions<控制台>.Instance.装饰半径;//装饰半径
            }
        }
    }
}
