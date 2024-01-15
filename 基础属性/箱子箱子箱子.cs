using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.基础属性
{
    [HarmonyPatch(typeof(StorageLockerConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 存储箱隔热密封
    {
        private static void Postfix(GameObject go)
        {
            bool 箱子隔热密封 = SingletonOptions<控制台>.Instance.箱子隔热密封;
            if (箱子隔热密封)
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
    [HarmonyPatch(typeof(StorageLockerSmartConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 智能存储箱隔热密封
    {
        private static void Postfix(GameObject go)
        {
            bool 箱子隔热密封 = SingletonOptions<控制台>.Instance.箱子隔热密封;
            if (箱子隔热密封)
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
