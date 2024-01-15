using Database;
using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.医疗
{
    public class A77GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A77GG1";
            int width = 2;
            int height = 2;
            string anim = "A77GG1_kanim";
            int hitpoints = 30;
            float construction_time = 30f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 1800f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, any_BUILDABLE, melting_point, build_location_rule, BUILDINGS.DECOR.BONUS.TIER2, none, 0.2f);
            buildingDef.Overheatable = false;
            buildingDef.Floodable = false;
            SoundEventVolumeCache.instance.AddVolume("handsanitizer_kanim", "HandSanitizer_tongue_out", NOISE_POLLUTION.NOISY.TIER0);
            SoundEventVolumeCache.instance.AddVolume("handsanitizer_kanim", "HandSanitizer_tongue_in", NOISE_POLLUTION.NOISY.TIER0);
            SoundEventVolumeCache.instance.AddVolume("handsanitizer_kanim", "HandSanitizer_tongue_slurp", NOISE_POLLUTION.NOISY.TIER0);
            //--------------------------
            if (控制台.Instance.饥荒入侵计划) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            HandSanitizer handSanitizer = go.AddOrGet<HandSanitizer>();
            handSanitizer.massConsumedPerUse = 0f;
            handSanitizer.consumedElement = SimHashes.Gold;
            handSanitizer.diseaseRemovalCount = 1000000;
            HandSanitizer.Work work = go.AddOrGet<HandSanitizer.Work>();
            work.workTime = 10f;
            work.trackUses = true;
            Storage storage = go.AddOrGet<Storage>();
            storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
            go.AddOrGet<DirectionControl>();
            ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
            manualDeliveryKG.SetStorage(storage);
            manualDeliveryKG.RequestedItemTag = GameTagExtensions.Create(SimHashes.Gold);
            manualDeliveryKG.capacity = 100f;
            manualDeliveryKG.refillMass = 3f;
            manualDeliveryKG.choreTypeIDHash = Db.Get().ChoreTypes.FetchCritical.IdHash;
            manualDeliveryKG.operationalRequirement = Operational.State.Functional;
            go.AddOrGetDef<RocketUsageRestriction.Def>();
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
        }
        public const string ID = "A77GG1";
    }
    [HarmonyPatch(typeof(BuildingFacades), MethodType.Constructor, new Type[] { typeof(ResourceSet) })]
    public static class 蓝图系统A77GG1
    {
        public static void Postfix(BuildingFacades __instance)
        {
            __instance.Add("A77GG2", STRINGS.BUILDINGS.PREFABS.A77GG2.NAME, STRINGS.BUILDINGS.PREFABS.A77GG2.EFFECT, PermitRarity.Universal, "A77GG1", "A77GG2_kanim", null);
            __instance.Add("A77GG3", STRINGS.BUILDINGS.PREFABS.A77GG3.NAME, STRINGS.BUILDINGS.PREFABS.A77GG3.EFFECT, PermitRarity.Universal, "A77GG1", "A77GG3_kanim", null);
            __instance.Add("A77GG4", STRINGS.BUILDINGS.PREFABS.A77GG4.NAME, STRINGS.BUILDINGS.PREFABS.A77GG4.EFFECT, PermitRarity.Universal, "A77GG1", "A77GG4_kanim", null);
            __instance.Add("A77GG5", STRINGS.BUILDINGS.PREFABS.A77GG5.NAME, STRINGS.BUILDINGS.PREFABS.A77GG5.EFFECT, PermitRarity.Universal, "A77GG1", "A77GG5_kanim", null);
            __instance.Add("A77GG6", STRINGS.BUILDINGS.PREFABS.A77GG6.NAME, STRINGS.BUILDINGS.PREFABS.A77GG6.EFFECT, PermitRarity.Universal, "A77GG1", "A77GG6_kanim", null);
        }
    }
}
