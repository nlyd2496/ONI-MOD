using System;
using HarmonyLib;
using PeterHan.PLib.Options;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.基础属性
{
    [HarmonyPatch(typeof(BuildingLoader))]
    [HarmonyPatch("CreateBuildingComplete")]
    public class 永不过热
    {
        public static void Prefix(ref BuildingDef def)
        {
            bool 永不过热 = SingletonOptions<控制台>.Instance.永不过热;
            if (永不过热)
            {
                def.Overheatable = false;//不会过热
            }
        }
    }
}

