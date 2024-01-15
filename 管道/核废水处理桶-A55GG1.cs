using Database;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.管道
{
    public class A55GG1 : IBuildingConfig
    {
        //-------------------------------
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A55GG1";//MM+日期+序号
            int width = 1;
            int height = 1;
            string anim = "A55GG1_kanim";//MM+日期+序号+UI+序号
            int hitpoints = 30;
            float construction_time = 3f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            string[] raw_MINERALS = MATERIALS.RAW_MINERALS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, raw_MINERALS, melting_point, build_location_rule, new EffectorValues
            {
                amount = -6,
                radius = 2
            }, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.InputConduitType = ConduitType.Liquid;
            buildingDef.UtilityInputOffset = new CellOffset(0, 0);
            buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            //--------------------------
            if (控制台.Instance.核废水处理桶) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        //-------------------------------
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            Storage storage = go.AddOrGet<Storage>();
            storage.showInUI = true;
            storage.capacityKg = 100f;
            storage.allowItemRemoval = true;
            storage.showDescriptor = true;
            storage.storageFullMargin = STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
            storage.fetchCategory = Storage.FetchCategory.GeneralStorage;
            storage.storageFilters = STORAGEFILTERS.LIQUIDS;
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Liquid;
            conduitConsumer.capacityTag = GameTagExtensions.Create(SimHashes.NuclearWaste);
            conduitConsumer.ignoreMinMassCheck = true;
            conduitConsumer.forceAlwaysSatisfied = true;
            conduitConsumer.alwaysConsume = true;
            conduitConsumer.capacityKG = 100f;
            go.AddOrGet<A55GG0>();
            go.AddOrGet<StorageLocker>();
        }
        //-------------------------------
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGetDef<StorageController.Def>();
        }
        //-------------------------------
        public const string ID = "A55GG1";
        //-------------------------------
    }
    [HarmonyPatch(typeof(BuildingFacades), MethodType.Constructor, new Type[] { typeof(ResourceSet) })]
    public static class 蓝图系统A55GG2
    {
        public static void Postfix(BuildingFacades __instance)
        {
            __instance.Add("A55GG2",
                STRINGS.BUILDINGS.PREFABS.A55GG2.NAME, STRINGS.BUILDINGS.PREFABS.A55GG2.EFFECT, PermitRarity.Universal,
                "A55GG1", "A55GG2_kanim", null);
        }
    }



    public class A55GG0 : KMonoBehaviour, ISim1000ms
    {
        //-------------------------------
        public void Sim1000ms(float dt)
        {

            foreach (GameObject go in this.storage.items)
            {
                go.DeleteObject();
            }
        }
        //-------------------------------
        protected override void OnSpawn()
        {
            base.OnSpawn();
        }
        //-------------------------------
        [MyCmpGet]
        internal Storage storage;
        //-------------------------------
    }
}
