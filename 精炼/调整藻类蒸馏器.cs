using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.精炼
{
    [HarmonyPatch(typeof(AlgaeDistilleryConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    internal class 调整藻类蒸馏器
    {
        private static void Postfix(GameObject go, Tag prefab_tag)
        {
            bool 调整藻类蒸馏器 = SingletonOptions<控制台>.Instance.调整藻类蒸馏器;
            if (调整藻类蒸馏器)
            {
                Tag tag = SimHashes.SlimeMold.CreateTag();
                ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
                elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
                {
            new ElementConverter.ConsumedElement(tag, 0.6f, true)
                };
                elementConverter.outputElements = new ElementConverter.OutputElement[]
                {
            new ElementConverter.OutputElement(0.4f, SimHashes.Algae, 303.15f, false, true, 0f, 1f, 1f, byte.MaxValue, 0, true),
            new ElementConverter.OutputElement(0.2f, SimHashes.DirtyWater, 303.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0, true)
                };
            }
        }
    }
}
