﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.氧气
{
    public class A42GG1 : IBuildingConfig
    {
        //----------------------------------------------------------------------------------------------------------------
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A42GG1";
            int width = 4;
            int height = 3;
            string anim = "A42GG1_kanim";
            int hitpoints = 100;
            float construction_time = 30f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
            string[] all_METALS = MATERIALS.ALL_METALS;
            float melting_point = 800f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER3;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints,
                construction_time, tier, all_METALS, melting_point, build_location_rule,
                new EffectorValues
                {
                    amount = 3,
                    radius = 3
                }, none, 0.2f);
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = 120f;
            buildingDef.ExhaustKilowattsWhenActive = 0f;
            buildingDef.SelfHeatKilowattsWhenActive = 4f;
            buildingDef.InputConduitType = ConduitType.Liquid;
            buildingDef.OutputConduitType = ConduitType.Liquid;
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(-1, 0));
            buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
            buildingDef.AudioCategory = "HollowMetal";
            buildingDef.PowerInputOffset = new CellOffset(-1, 0);
            buildingDef.UtilityInputOffset = new CellOffset(-1, 2);
            buildingDef.UtilityOutputOffset = new CellOffset(2, 2);
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.LiquidVentIDs, "WaterPurifier");
            //--------------------------
            if (控制台.Instance.淘金热) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
            Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
            storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
            go.AddOrGet<WaterPurifier>();
            Prioritizable.AddRef(go);
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
            new ElementConverter.ConsumedElement(new Tag("Filter"), 1f, true),
            new ElementConverter.ConsumedElement(new Tag("DirtyWater"), 5f, true)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[]
            {
            new ElementConverter.OutputElement(5f, SimHashes.Water, 0f, false, true, 0f, 0.5f, 0.75f, byte.MaxValue, 0, true),
            new ElementConverter.OutputElement(0.2f, SimHashes.ToxicSand, 0f, true, false, 0f, 0.5f, 0.25f, byte.MaxValue, 0, true),
            new ElementConverter.OutputElement(0.002f, SimHashes.Gold, 0f, true, false, 0f, 0.5f, 0.25f, byte.MaxValue, 0, true),
            new ElementConverter.OutputElement(0.888f, SimHashes.ContaminatedOxygen, 343.15f, true, false, 0f, 0.5f, 0.25f, byte.MaxValue, 0, true),
            new ElementConverter.OutputElement(0.111f, SimHashes.Hydrogen, 343.15f, true, false, 0f, 0.5f, 0.25f, byte.MaxValue, 0, true)
            };
            ElementDropper elementDropper = go.AddComponent<ElementDropper>();
            elementDropper.emitMass = 10f;
            elementDropper.emitTag = new Tag("Gold");
            elementDropper.emitOffset = new Vector3(-1f, 1f, 0f);
            ManualDeliveryKG manualDeliveryKG = go.AddComponent<ManualDeliveryKG>();
            manualDeliveryKG.SetStorage(storage);
            manualDeliveryKG.RequestedItemTag = new Tag("Filter");
            manualDeliveryKG.capacity = 1200f;
            manualDeliveryKG.refillMass = 300f;
            manualDeliveryKG.choreTypeIDHash = Db.Get().ChoreTypes.FetchCritical.IdHash;
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Liquid;
            conduitConsumer.consumptionRate = 10f;
            conduitConsumer.capacityKG = 20f;
            conduitConsumer.capacityTag = GameTags.AnyWater;
            conduitConsumer.forceAlwaysSatisfied = true;
            conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Store;
            ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
            conduitDispenser.conduitType = ConduitType.Liquid;
            conduitDispenser.invertElementFilter = true;
            conduitDispenser.elementFilter = new SimHashes[]
            {
            SimHashes.DirtyWater
            };
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
            go.GetComponent<KPrefabID>().AddTag(GameTags.OverlayBehindConduits, false);
        }
        public const string ID = "A42GG1";
        private const float FILTER_INPUT_RATE = 1f;
        private const float DIRTY_WATER_INPUT_RATE = 5f;
        private const float FILTER_CAPACITY = 1200f;
        private const float USED_FILTER_OUTPUT_RATE = 0.2f;
        private const float CLEAN_WATER_OUTPUT_RATE = 5f;
        private const float TARGET_OUTPUT_TEMPERATURE = 313.15f;
    }
}
