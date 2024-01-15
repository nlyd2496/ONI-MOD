using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.食物.植物
{
    //自然状态辐射设置
    //磷矿消耗
    [HarmonyPatch(typeof(ColdBreatherConfig))]
    [HarmonyPatch("CreatePrefab")]
    public static class 冰霜萝卜磷矿消耗
    {
        public static void Postfix(GameObject __result)
        {
            bool 冰霜萝卜 = SingletonOptions<控制台>.Instance.冰霜萝卜;
            if (冰霜萝卜)
            {
                __result.GetComponent<RadiationEmitter>().emitRads = SingletonOptions<控制台>.Instance.冰霜萝卜辐射;
                EntityTemplates.ExtendPlantToFertilizable(__result, new PlantElementAbsorber.ConsumeInfo[]
                {
                   new PlantElementAbsorber.ConsumeInfo
                   {
                       tag = SimHashes.Phosphorite.CreateTag(),
                       massConsumptionRate = SingletonOptions<控制台>.Instance.冰霜萝卜磷矿
                    }
                });
                __result.AddOrGet<TemperatureVulnerable>().Configure(173.15f, 123.15f, 373.15f, 423.15f);
            }

        }
        [HarmonyPatch(typeof(ColdBreather))]
        [HarmonyPatch("OnReplanted")]
        public static class 冰霜萝卜种植状态辐射设置
        {
            internal static void Postfix(ColdBreather __instance)
            {
                bool 冰霜萝卜 = SingletonOptions<控制台>.Instance.冰霜萝卜;
                if (冰霜萝卜)
                {
                    RadiationEmitter radiationEmitter = __instance.GetComponent<RadiationEmitter>();
                    if (radiationEmitter != null)
                    {
                        radiationEmitter.emitRads = SingletonOptions<控制台>.Instance.冰霜萝卜辐射;
                        radiationEmitter.Refresh();
                    }
                }

            }
        }
    }
}
