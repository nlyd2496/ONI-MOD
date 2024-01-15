using System;
using HarmonyLib;
using PeterHan.PLib.Options;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.基础属性
{
    [HarmonyPatch(typeof(BuildingLoader))]
    [HarmonyPatch("CreateBuildingComplete")]
    public class 永不淹没
    {
        public static void Prefix(ref BuildingDef def)
        {
            bool 永不淹没 = SingletonOptions<控制台>.Instance.永不淹没;
            if (永不淹没)
            {
                def.Floodable = false;//不会被淹没
            }
        }
    }
}

