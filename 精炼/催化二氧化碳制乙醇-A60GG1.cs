using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.精炼
{
    public class A60GG1 : IBuildingConfig
    {
        //----------------------------------------------------------------------------------------------------------------------
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A60GG1";
            int width = 2;
            int height = 2;
            string anim = "A60GG1_kanim";
            int hitpoints = 30;
            float construction_time = 30f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            string[] raw_METALS = MATERIALS.RAW_METALS;
            float melting_point = 800f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER3;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, raw_METALS, melting_point, build_location_rule, BUILDINGS.DECOR.PENALTY.TIER1, tier2, 0.2f);
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = 111f;
            buildingDef.SelfHeatKilowattsWhenActive = 1f;
            buildingDef.InputConduitType = ConduitType.Liquid;
            buildingDef.OutputConduitType = ConduitType.Gas;
            buildingDef.ViewMode = OverlayModes.Oxygen.ID;
            buildingDef.AudioCategory = "Metal";
            buildingDef.AudioSize = "large";
            buildingDef.UtilityInputOffset = new CellOffset(0, 0);
            buildingDef.UtilityOutputOffset = new CellOffset(1, 0);
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
            //--------------------------
            if (控制台.Instance.催化二氧化碳制乙醇) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        //----------------------------------------------------------------------------------------------------------------------
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<LoopingSounds>();
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
            Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
            storage.showInUI = true;
            storage.capacityKg = 30000f;
            storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
            go.AddOrGet<AirFilter>().filterTag = GameTagExtensions.Create(SimHashes.Water);
            PassiveElementConsumer passiveElementConsumer = go.AddOrGet<PassiveElementConsumer>();
            passiveElementConsumer.elementToConsume = SimHashes.CarbonDioxide;
            passiveElementConsumer.consumptionRate = 1f;
            passiveElementConsumer.capacityKG = 1f;
            passiveElementConsumer.consumptionRadius = 3;
            passiveElementConsumer.showInStatusPanel = true;
            passiveElementConsumer.sampleCellOffset = new Vector3(0f, 0f, 0f);
            passiveElementConsumer.isRequired = false;
            passiveElementConsumer.storeOnConsume = true;
            passiveElementConsumer.showDescriptor = false;
            passiveElementConsumer.ignoreActiveChanged = true;
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
            new ElementConverter.ConsumedElement(GameTagExtensions.Create(SimHashes.Water), 0.5f, true),
            new ElementConverter.ConsumedElement(GameTagExtensions.Create(SimHashes.CarbonDioxide), 0.5f, true)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[]
            {
            new ElementConverter.OutputElement(0.5f, SimHashes.Ethanol, 0f, false, false, 0f, 0.5f, 1f, byte.MaxValue, 0, true),
            new ElementConverter.OutputElement(0.5f, SimHashes.Oxygen, 0f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0, true)
            };
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Liquid;
            conduitConsumer.consumptionRate = 1f;
            conduitConsumer.capacityKG = 1f;
            conduitConsumer.capacityTag = ElementLoader.FindElementByHash(SimHashes.Water).tag;
            conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Store;
            conduitConsumer.forceAlwaysSatisfied = true;
            ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
            conduitDispenser.conduitType = ConduitType.Gas;
            conduitDispenser.invertElementFilter = false;
            conduitDispenser.elementFilter = new SimHashes[]
            {
            SimHashes.Oxygen
            };
            go.AddOrGet<KBatchedAnimController>().randomiseLoopedOffset = true;
        }
        //----------------------------------------------------------------------------------------------------------------------
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
        }
        //----------------------------------------------------------------------------------------------------------------------
        public const string ID = "A60GG1";
        //----------------------------------------------------------------------------------------------------------------------
    }
}
