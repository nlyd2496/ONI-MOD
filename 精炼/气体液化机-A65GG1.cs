using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.精炼
{
    public class A65GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A65GG1";
            int width = 3;
            int height = 3;
            string anim = "A65GG1_kanim";
            int hitpoints = 30;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
            string[] raw_METALS = MATERIALS.REFINED_METALS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER1;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, raw_METALS, melting_point, build_location_rule, BUILDINGS.DECOR.PENALTY.TIER0, tier2, 0.2f);
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = 480f;
            buildingDef.SelfHeatKilowattsWhenActive = 30f;
            buildingDef.ExhaustKilowattsWhenActive = 10f;
            buildingDef.InputConduitType = ConduitType.Gas;
            buildingDef.OutputConduitType = ConduitType.Liquid;
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
            buildingDef.AudioCategory = "Metal";
            buildingDef.UtilityInputOffset = new CellOffset(0, 1);
            buildingDef.UtilityOutputOffset = new CellOffset(0, 0);
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            //--------------------------
            if (控制台.Instance.气体液化机) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
            Storage storage = go.AddOrGet<Storage>();
            storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
            storage.showInUI = true;
            go.AddOrGet<Desalinator>();
            ElementConverter elementConverter = go.AddComponent<ElementConverter>();
            //氧气---液氧
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
                     new ElementConverter.ConsumedElement(new Tag("Oxygen"), 0.5f, true)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[]
            {
                     new ElementConverter.OutputElement(0.5f, SimHashes.LiquidOxygen, 0f, true, true, 0f, 0.5f, 0.75f, byte.MaxValue, 0, true),
            };
            //氢气---液氢
            ElementConverter elementConverter2 = go.AddComponent<ElementConverter>();
            elementConverter2.consumedElements = new ElementConverter.ConsumedElement[]
            {
                    new ElementConverter.ConsumedElement(new Tag("Hydrogen"), 0.5f, true)
            };
            elementConverter2.outputElements = new ElementConverter.OutputElement[]
            {
                    new ElementConverter.OutputElement(0.5f, SimHashes.LiquidHydrogen, 0f, false, true, 0f, 0.5f, 0.75f, byte.MaxValue, 0, true),
            };
            //氯气---液氯
            ElementConverter elementConverter3 = go.AddComponent<ElementConverter>();
            elementConverter3.consumedElements = new ElementConverter.ConsumedElement[]
            {
                    new ElementConverter.ConsumedElement(new Tag("ChlorineGas"), 0.5f, true)
            };
            elementConverter3.outputElements = new ElementConverter.OutputElement[]
            {
                    new ElementConverter.OutputElement(0.5f, SimHashes.Chlorine, 0f, false, true, 0f, 0.5f, 0.75f, byte.MaxValue, 0, true),
            };
            //蒸汽---水
            ElementConverter elementConverter4 = go.AddComponent<ElementConverter>();
            elementConverter4.consumedElements = new ElementConverter.ConsumedElement[]
            {
                    new ElementConverter.ConsumedElement(new Tag("Steam"), 0.5f, true)
            };
            elementConverter4.outputElements = new ElementConverter.OutputElement[]
            {
                    new ElementConverter.OutputElement(0.5f, SimHashes.Water, 0f, false, true, 0f, 0.5f, 0.75f, byte.MaxValue, 0, true),
            };
            //气态乙醇---乙醇
            ElementConverter elementConverter5 = go.AddComponent<ElementConverter>();
            elementConverter5.consumedElements = new ElementConverter.ConsumedElement[]
            {
                    new ElementConverter.ConsumedElement(new Tag("EthanolGas"), 0.5f, true)
            };
            elementConverter5.outputElements = new ElementConverter.OutputElement[]
            {
                    new ElementConverter.OutputElement(0.5f, SimHashes.Ethanol, 0f, false, true, 0f, 0.5f, 0.75f, byte.MaxValue, 0, true),
            };
            //天然气---液态甲烷
            ElementConverter elementConverter6 = go.AddComponent<ElementConverter>();
            elementConverter6.consumedElements = new ElementConverter.ConsumedElement[]
            {
                    new ElementConverter.ConsumedElement(new Tag("Methane"), 0.5f, true)
            };
            elementConverter6.outputElements = new ElementConverter.OutputElement[]
            {
                    new ElementConverter.OutputElement(0.5f, SimHashes.LiquidMethane, 0f, false, true, 0f, 0.5f, 0.75f, byte.MaxValue, 0, true),
            };
            //二氧化碳---液态二氧化碳
            ElementConverter elementConverter7 = go.AddComponent<ElementConverter>();
            elementConverter7.consumedElements = new ElementConverter.ConsumedElement[]
            {
                    new ElementConverter.ConsumedElement(new Tag("CarbonDioxide"), 0.5f, true)
            };
            elementConverter7.outputElements = new ElementConverter.OutputElement[]
            {
                    new ElementConverter.OutputElement(0.5f, SimHashes.LiquidCarbonDioxide, 0f, false, true, 0f, 0.5f, 0.75f, byte.MaxValue, 0, true),
            };
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Gas;
            conduitConsumer.consumptionRate = 2f;
            conduitConsumer.capacityKG = 10f;
            conduitConsumer.forceAlwaysSatisfied = true;
            conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Store;
            ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
            conduitDispenser.conduitType = ConduitType.Liquid;
            conduitDispenser.invertElementFilter = true;
            Prioritizable.AddRef(go);
        }
        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
            base.DoPostConfigurePreview(def, go);
        }
        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGetDef<PoweredActiveController.Def>().showWorkingStatus = true;
        }
        public const string ID = "A65GG1";
    }
}
