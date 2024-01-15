using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.基础属性
{
    [HarmonyPatch(typeof(CameraController))]
    [HarmonyPatch("OnPrefabInit")]
    internal class 无限缩放
    {
        private static void Prefix(CameraController __instance)
        {
            bool 无限缩放 = SingletonOptions<控制台>.Instance.无限缩放;
            if (无限缩放)
            {
                Traverse.Create(__instance).Field("maxOrthographicSize").SetValue(200);
            }
            Traverse.Create(__instance).Field("maxOrthographicSize").SetValue(200);
        }
    }
}
