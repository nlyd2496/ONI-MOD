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
    [HarmonyPatch(typeof(AtmoSuitConfig))]
    [HarmonyPatch("DoPostConfigure")]
    public class 气压服氧气容量修改
    {
        public static void Postfix(GameObject go)
        {
            bool 气压服氧气容量修改 = SingletonOptions<控制台>.Instance.气压服氧气容量修改;
            if (气压服氧气容量修改)
            {
                go.AddOrGet<A78GG2_KZQ>();
            }
        }
    }
    [HarmonyPatch(typeof(SuitLockerConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 气压服存放柜容量和氧气运输速率修改
    {
        public static void Postfix(GameObject go)
        {
            bool 气压服氧气容量修改 = SingletonOptions<控制台>.Instance.气压服氧气容量修改;
            if (气压服氧气容量修改)
            {
                ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                conduitConsumer.consumptionRate = 10f; //运输速率
                conduitConsumer.capacityKG = 200f; //容量
            }
        }
    }
    [HarmonyPatch(typeof(JetSuitConfig))]
    [HarmonyPatch("DoPostConfigure")]
    public class 喷气服氧气容量修改
    {
        public static void Postfix(GameObject go)
        {
            bool 喷气服氧气容量修改 = SingletonOptions<控制台>.Instance.喷气服氧气容量修改;
            if (喷气服氧气容量修改)
            {
                go.AddOrGet<A78GG3_KZQ>();
            }
        }
    }
    [HarmonyPatch(typeof(JetSuitLockerConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 喷气服存放柜容量和氧气运输速率修改
    {
        public static void Postfix(GameObject go)
        {
            bool 喷气服氧气容量修改 = SingletonOptions<控制台>.Instance.喷气服氧气容量修改;
            if (喷气服氧气容量修改)
            {
                ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                conduitConsumer.consumptionRate = 10f; //运输速率
                conduitConsumer.capacityKG = 200f; //容量
            }
        }
    }
    [HarmonyPatch(typeof(LeadSuitConfig))]
    [HarmonyPatch("DoPostConfigure")]
    public class 铅服氧气容量修改
    {
        public static void Postfix(GameObject go)
        {
            bool 铅服氧气容量修改 = SingletonOptions<控制台>.Instance.铅服氧气容量修改;
            if (铅服氧气容量修改)
            {
                go.AddOrGet<A78GG4_KZQ>();
            }
        }
    }
    [HarmonyPatch(typeof(LeadSuitLockerConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 铅服存放柜容量和氧气运输速率修改
    {
        public static void Postfix(GameObject go)
        {
            bool 铅服氧气容量修改 = SingletonOptions<控制台>.Instance.铅服氧气容量修改;
            if (铅服氧气容量修改)
            {
                ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                conduitConsumer.consumptionRate = 10f; //运输速率
                conduitConsumer.capacityKG = 200f; //容量
            }
        }
    }
}
