using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.火箭
{   
    //钻头前锥效率更改+钻头前锥钻石容量更改
    [HarmonyPatch(typeof(NoseconeHarvestConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 高效钻头前锥
    {
        public static void Postfix(GameObject go, Tag prefab_tag)
        {
            bool 高效钻头前锥 = SingletonOptions<控制台>.Instance.高效钻头前锥;
            if (高效钻头前锥)
            {
                ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
                manualDeliveryKG.capacity = SingletonOptions<控制台>.Instance.钻头前锥容量;
                go.AddOrGetDef<ResourceHarvestModule.Def>().harvestSpeed = SingletonOptions<控制台>.Instance.钻头前锥挖掘速度;

            }
        }
    }
}
