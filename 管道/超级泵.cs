using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.管道
{
    //气泵
    [HarmonyPatch(typeof(GasPumpConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 超级气泵
    {
        public static void Postfix(GameObject go)
        {
            bool 超级泵 = SingletonOptions<控制台>.Instance.超级泵;
            if (超级泵)
            {
                go.AddOrGet<Storage>().capacityKg = 20f;
                ElementConsumer elementConsumer = go.AddOrGet<ElementConsumer>();
                elementConsumer.consumptionRate = 10f;
            }
        }
    }
        //----------------------------------------------------------------------------------------------
        //迷你气泵
        [HarmonyPatch(typeof(GasMiniPumpConfig))]
        [HarmonyPatch("DoPostConfigureComplete")]
        public class 超级迷你气泵
        {
            public static void Postfix(GameObject go)
            {
                bool 超级泵 = SingletonOptions<控制台>.Instance.超级泵;
                if (超级泵)
                {
                    go.AddOrGet<Storage>().capacityKg = 10f;
                    ElementConsumer elementConsumer = go.AddOrGet<ElementConsumer>();
                    elementConsumer.consumptionRate = 5f;
                }
            }
        }
            //----------------------------------------------------------------------------------------------
            //液泵
            [HarmonyPatch(typeof(LiquidPumpConfig))]
            [HarmonyPatch("DoPostConfigureComplete")]
            public class 超级液泵
            {
                public static void Postfix(GameObject go)
                {
                    bool 超级泵 = SingletonOptions<控制台>.Instance.超级泵;
                    if (超级泵)
                    {
                        go.AddOrGet<Storage>().capacityKg = 200f;
                        ElementConsumer elementConsumer = go.AddOrGet<ElementConsumer>();
                        elementConsumer.consumptionRate = 100f;
                    }
                }
            }
            //----------------------------------------------------------------------------------------------
            //迷你液泵
            [HarmonyPatch(typeof(LiquidMiniPumpConfig))]
            [HarmonyPatch("DoPostConfigureComplete")]
            public class 超级迷你液泵
            {
                public static void Postfix(GameObject go)
                {
                    bool 超级泵 = SingletonOptions<控制台>.Instance.超级泵;
                    if (超级泵)
                    {
                        go.AddOrGet<Storage>().capacityKg = 100f;
                        ElementConsumer elementConsumer = go.AddOrGet<ElementConsumer>();
                        elementConsumer.consumptionRate = 50f;
                    }
                }
            }
        }
