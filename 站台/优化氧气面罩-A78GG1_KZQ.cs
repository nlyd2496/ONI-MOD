using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.控制器;

namespace 吐泡泡的小鱼的缺氧模组.站台
{
    [HarmonyPatch(typeof(OxygenMaskConfig))]
    [HarmonyPatch("DoPostConfigure")]
    public class 氧气面罩容量修改
    {
        public static void Postfix(GameObject go)
        {
            bool 优化氧气面罩 = SingletonOptions<控制台>.Instance.优化氧气面罩;
            if (优化氧气面罩)
            {
                go.AddOrGet<A78GG1_KZQ>();
            }
        }
    }
    [HarmonyPatch(typeof(OxygenMaskLockerConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 氧气面罩存放柜容量和氧气运输速率修改
    {
        public static void Postfix(GameObject go)
        {
            bool 优化氧气面罩 = SingletonOptions<控制台>.Instance.优化氧气面罩;
            if (优化氧气面罩)
            {
                ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                conduitConsumer.consumptionRate = 10f; //氧气运输速率
                conduitConsumer.capacityKG = 100f; //容量
            }
        }
    }
}
