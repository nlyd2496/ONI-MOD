using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static 吐泡泡的小鱼的缺氧模组.STRINGS.CREATURES.SPECIES;

namespace 吐泡泡的小鱼的缺氧模组.B_植物
{
    [HarmonyPatch(typeof(OxyfernConfig))]
    [HarmonyPatch("CreatePrefab")]
    public static class 氧齿阙吸收二氧化碳排放氧气修改1
    {
        public static void Postfix(GameObject __result)
        {
            bool B001GG1 = SingletonOptions<控制台>.Instance.B001GG1;
            if (B001GG1)
            {
                Storage storage = __result.AddOrGet<Storage>();
                storage.capacityKg = 1f;

                ElementConsumer elementConsumer = __result.AddOrGet<ElementConsumer>();
                elementConsumer.consumptionRate = 0.006f;

                ElementConverter elementConverter = __result.AddOrGet<ElementConverter>();
                elementConverter.OutputMultiplier = 1;
                elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
                {
            new ElementConverter.ConsumedElement(SimHashes.CarbonDioxide.ToString().ToTag(), 0.006f, true)
                };
                elementConverter.outputElements = new ElementConverter.OutputElement[]
                {
            new ElementConverter.OutputElement(0.006f, SimHashes.Oxygen, 0f, true, false, 0f, 1f, 0.75f, byte.MaxValue, 0, true)
                };

                // 生长温度修改
                float temperature_lethal_low = 123.15f;//死亡低温-150
                float temperature_warning_low = 173.15f;//宜温下限-100
                float temperature_warning_high = 373.15f;//宜温上限100
                float temperature_lethal_high = 423.15f;//死亡高温150
                EntityTemplates.ExtendEntityToBasicPlant(__result,
                    temperature_lethal_low, temperature_warning_low, temperature_warning_high, temperature_lethal_high, new SimHashes[]
                    {
                SimHashes.Oxygen,//氧气
                SimHashes.ContaminatedOxygen,//污染氧
                SimHashes.CarbonDioxide,//二氧化碳
                SimHashes.Hydrogen,//氢气
                SimHashes.Methane,//甲烷
                SimHashes.ChlorineGas//氯气
                    }
                     , true, 0f, 0.025f, null, true, false, true, false, 2400f, 0f, 6000f, "OxyfernOriginal", STRINGS.CREATURES.SPECIES.B001GG1.NAME);


            }
        }
    }
    [HarmonyPatch(typeof(Oxyfern))]
    [HarmonyPatch("SetConsumptionRate")]
    public static class 氧齿阙吸收二氧化碳排放氧气修改2
    {
        internal static void Postfix(Oxyfern __instance)
        {
            bool B001GG1 = SingletonOptions<控制台>.Instance.B001GG1;
            if (B001GG1)
            {
                // 将游戏代码添加到这里

                // 使用反射来获取 Oxyfern 的私有字段
                var receptacleMonitor = typeof(Oxyfern).GetField("receptacleMonitor", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(__instance) as ReceptacleMonitor;
                var elementConsumer = typeof(Oxyfern).GetField("elementConsumer", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(__instance) as ElementConsumer;

                if (receptacleMonitor.Replanted)
                {
                    elementConsumer.consumptionRate = 0.006f;
                    return;
                }
                elementConsumer.consumptionRate = 0.006f;
            }
        }
    }
}
