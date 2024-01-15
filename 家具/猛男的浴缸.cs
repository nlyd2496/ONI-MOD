using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    [HarmonyPatch(typeof(HotTubConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 猛男的浴缸
    {
        public static void Postfix(GameObject go, Tag prefab_tag)
        {
            bool 猛男的浴缸 = SingletonOptions<控制台>.Instance.猛男的浴缸;
            if (猛男的浴缸)
            {
                go.GetComponent<ManualDeliveryKG>().RequestedItemTag = new Tag("Steel");
            }
        }
    }
}
