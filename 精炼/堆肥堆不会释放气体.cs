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
    [HarmonyPatch(typeof(CompostConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    internal class 堆肥堆不会释放气体
    {
        private static void Postfix(GameObject go)
        {
            bool 堆肥堆不会释放气体 = SingletonOptions<控制台>.Instance.堆肥堆不会释放气体;
            if (堆肥堆不会释放气体)
            {
                Storage storage = go.AddOrGet<Storage>();
                storage.SetDefaultStoredItemModifiers(new List<Storage.StoredItemModifier>
            {
                Storage.StoredItemModifier.Hide,
                Storage.StoredItemModifier.Seal,
                Storage.StoredItemModifier.Insulate
            });
            }
        }
    }
}
