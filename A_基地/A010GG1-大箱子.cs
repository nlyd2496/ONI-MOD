using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.A_基地
{
    //存储箱容量设置
    [HarmonyPatch(typeof(StorageLockerConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 存储箱容量设置
    {
        private static void Postfix(GameObject go)
        {
            bool A010GG1 = SingletonOptions<控制台>.Instance.A010GG1;
            if (A010GG1)
            {
                Storage storage = go.AddOrGet<Storage>();
                storage.capacityKg = SingletonOptions<控制台>.Instance.A010GG2;
            }
        }
    }

    //智能存储箱容量设置
    [HarmonyPatch(typeof(StorageLockerSmartConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 智能存储箱容量设置
    {
        private static void Postfix(GameObject go)
        {
            bool A010GG1 = SingletonOptions<控制台>.Instance.A010GG1;
            if (A010GG1)
            {
                go.AddOrGet<Storage>().capacityKg = SingletonOptions<控制台>.Instance.A010GG3;
            }
        }
    }

        //储液库容量设置
        [HarmonyPatch(typeof(LiquidReservoirConfig))]
        [HarmonyPatch("ConfigureBuildingTemplate")]
        public class 储液库容量设置
        {
            private static void Postfix(GameObject go, Tag prefab_tag)
            {
                bool A010GG1 = SingletonOptions<控制台>.Instance.A010GG1;
                if (A010GG1)
                {
                    Storage storage = go.AddOrGet<Storage>();
                    storage.capacityKg = SingletonOptions<控制台>.Instance.A010GG4;
                    ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                    conduitConsumer.capacityKG = SingletonOptions<控制台>.Instance.A010GG4;
                }
            }
        }
            //--------------------------------------------------------------------------------------------------
            //储气库容量设置
            [HarmonyPatch(typeof(GasReservoirConfig))]
            [HarmonyPatch("ConfigureBuildingTemplate")]
            public class 储气库容量设置
            {
                private static void Postfix(GameObject go)
                {
                    bool A010GG1 = SingletonOptions<控制台>.Instance.A010GG1;
                    if (A010GG1)
                    {
                        Storage storage = go.AddOrGet<Storage>();
                        storage.capacityKg = SingletonOptions<控制台>.Instance.A010GG5;

                        ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                        conduitConsumer.capacityKG = SingletonOptions<控制台>.Instance.A010GG5;
                    }
                }
            }
}
