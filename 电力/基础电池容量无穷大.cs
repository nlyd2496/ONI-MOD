using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.电力
{
    [HarmonyPatch(typeof(BatteryConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 基础电池容量无穷大
    {
        private static void Postfix(GameObject go)
        {
            bool 基础电池容量无穷大 = SingletonOptions<控制台>.Instance.基础电池容量无穷大;
            if (基础电池容量无穷大)
            {
                Battery battery = go.AddOrGet<Battery>();
                battery.capacity = float.PositiveInfinity;//容量
                battery.joulesLostPerSecond = 0f;//电力损失
            }
        }
    }
}