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
    public class A011GG1 : IBuildingConfig
    {
        
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A011GG1";//MM+日期+序号
            int width = 1;
            int height = 1;
            string anim = "A011GG1_kanim";//MM+日期+序号+UI+序号
            int hitpoints = 30;
            float construction_time = 3f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            string[] raw_MINERALS = MATERIALS.RAW_MINERALS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, raw_MINERALS, melting_point, build_location_rule, new EffectorValues
            {
                amount = 3,
                radius = 2
            }, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.AudioCategory = "Metal";
            buildingDef.Overheatable = false;
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            //--------------------------
            if (控制台.Instance.A011GG1) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            SoundEventVolumeCache.instance.AddVolume("storagelocker_kanim", "StorageLocker_Hit_metallic_low", NOISE_POLLUTION.NOISY.TIER1);
            Prioritizable.AddRef(go);
            Storage storage = go.AddOrGet<Storage>();
            storage.showInUI = true;
            storage.allowItemRemoval = true;
            storage.showDescriptor = true;
            storage.storageFilters = STORAGEFILTERS.NOT_EDIBLE_SOLIDS;
            storage.storageFullMargin = STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
            storage.fetchCategory = Storage.FetchCategory.GeneralStorage;
            go.AddOrGet<CopyBuildingSettings>().copyGroupTag = GameTags.StorageLocker;
            go.AddOrGet<A011GG0>();
            go.AddOrGet<StorageLocker>();
        }
        
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGetDef<StorageController.Def>();
        }
        
        public const string ID = "A011GG1";
        
    }
    [HarmonyPatch(typeof(BuildingFacades), MethodType.Constructor, new Type[] { typeof(ResourceSet) })]
    public static class 蓝图系统A011GG1
    {
        public static void Postfix(BuildingFacades __instance)
        {
            __instance.Add("A011GG2",
                STRINGS.BUILDINGS.PREFABS.A011GG2.NAME, STRINGS.BUILDINGS.PREFABS.A011GG2.EFFECT, PermitRarity.Universal,
                "A011GG1", "A011GG2_kanim", null);
            __instance.Add("A011GG3",
                STRINGS.BUILDINGS.PREFABS.A011GG3.NAME, STRINGS.BUILDINGS.PREFABS.A011GG3.EFFECT, PermitRarity.Universal,
                "A011GG1", "A011GG3_kanim", null);
            __instance.Add("A011GG4",
                STRINGS.BUILDINGS.PREFABS.A011GG4.NAME, STRINGS.BUILDINGS.PREFABS.A011GG4.EFFECT, PermitRarity.Universal,
                "A011GG1", "A011GG4_kanim", null);
        }
    }
}
