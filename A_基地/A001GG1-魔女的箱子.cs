using Database;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.控制器;

namespace 吐泡泡的小鱼的缺氧模组.A_基地
{
    public class A001GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A001GG1";
            string anim = "A001GG1_kanim";
            int width = 1;
            int height = 1;
            int hitpoints = 30;
            float melting_point = 1600f;
            float construction_time = 10f;
            EffectorValues none = NOISE_POLLUTION.NONE;
            string[] raw_MINERALS = MATERIALS.REFINED_METALS;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, raw_MINERALS, melting_point, build_location_rule, BUILDINGS.DECOR.BONUS.TIER2, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.AudioCategory = "Metal";
            //--------------------------
            if (控制台.Instance.A001GG1) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            SoundEventVolumeCache.instance.AddVolume("storagelocker_kanim", "StorageLocker_Hit_metallic_low", NOISE_POLLUTION.NOISY.TIER1);
            Prioritizable.AddRef(go);
            Storage storage = go.AddOrGet<Storage>();
            storage.showInUI = true;
            storage.capacityKg = 2000000f;
            storage.showDescriptor = true;
            storage.allowItemRemoval = true;
            storage.showCapacityStatusItem = true;
            storage.showCapacityAsMainStatus = true;
            storage.storageFilters = STORAGEFILTERS.NOT_EDIBLE_SOLIDS;
            storage.fetchCategory = Storage.FetchCategory.GeneralStorage;
            storage.storageFullMargin = STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
            storage.SetDefaultStoredItemModifiers(new List<Storage.StoredItemModifier>
            {Storage.StoredItemModifier.Hide,Storage.StoredItemModifier.Seal,Storage.StoredItemModifier.Insulate});
            go.AddOrGet<UserNameable>();
            go.AddOrGet<A001GG1_KZQ>();
            go.AddOrGetDef<RocketUsageRestriction.Def>();
            go.AddOrGet<CopyBuildingSettings>().copyGroupTag = GameTags.StorageLocker;
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGetDef<StorageController.Def>();
        }
        public const string ID = "A001GG1";
    }

    [HarmonyPatch(typeof(BuildingFacades), MethodType.Constructor, new Type[] { typeof(ResourceSet) })]
    public static class 蓝图系统A001GG1
    {
        public static void Postfix(BuildingFacades __instance)
        {
            __instance.Add("A001GG2",
                STRINGS.BUILDINGS.PREFABS.A001GG2.NAME, STRINGS.BUILDINGS.PREFABS.A001GG2.EFFECT, PermitRarity.Universal,
                "A001GG1", "A001GG2_kanim", null);
        }
    }
}

