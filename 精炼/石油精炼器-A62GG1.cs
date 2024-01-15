using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.精炼
{
    public class A62GG1 : IBuildingConfig
    {
        //----------------------------------------------------------------------------------------------------------------------
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A62GG1";
            int width = 2;
            int height = 2;
            string anim = "A62GG1_kanim";
            int hitpoints = 10;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, any_BUILDABLE, melting_point, build_location_rule, new EffectorValues
            {
                amount = 10,
                radius = 4
            }, none, 0.2f);
            BuildingTemplates.CreateLadderDef(buildingDef);
            buildingDef.Floodable = true;
            buildingDef.DragBuild = false;
            buildingDef.Entombable = false;
            buildingDef.AudioSize = "small";
            buildingDef.Overheatable = false;
            buildingDef.AudioCategory = "Metal";
            buildingDef.RequiresPowerInput = true;
            buildingDef.PowerInputOffset = new CellOffset(0, 0);
            buildingDef.EnergyConsumptionWhenActive = 120f;
            buildingDef.ExhaustKilowattsWhenActive = 1f;
            buildingDef.SelfHeatKilowattsWhenActive = 3f;
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            buildingDef.InputConduitType = ConduitType.Liquid;
            buildingDef.UtilityInputOffset = new CellOffset(0, 0);
            buildingDef.OutputConduitType = ConduitType.Gas;
            buildingDef.UtilityOutputOffset = new CellOffset(0, 0);
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
            //--------------------------
            if (控制台.Instance.石油精炼器) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        //----------------------------------------------------------------------------------------------------------------------
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
            conduitDispenser.conduitType = ConduitType.Gas;
            conduitDispenser.invertElementFilter = false;
            conduitDispenser.elementFilter = new SimHashes[]
            {
                SimHashes.Methane
            };
            CellOffset cellOffset = new CellOffset(0, 1);
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
            Electrolyzer electrolyzer = go.AddOrGet<Electrolyzer>();
            electrolyzer.maxMass = float.PositiveInfinity;
            electrolyzer.hasMeter = true;
            electrolyzer.emissionOffset = cellOffset;
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Liquid;
            conduitConsumer.consumptionRate = 1f;
            conduitConsumer.capacityTag = ElementLoader.FindElementByHash(SimHashes.Petroleum).tag;
            conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Dump;
            Storage storage = go.AddOrGet<Storage>();
            storage.capacityKg = 20f;
            storage.showInUI = true;
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
                new ElementConverter.ConsumedElement(new Tag("Petroleum"), 1f, true)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[]
            {
                new ElementConverter.OutputElement(0.1f, SimHashes.Methane, 343.15f, false, true, (float)cellOffset.x, (float)cellOffset.y, 1f, byte.MaxValue, 0, true),
                new ElementConverter.OutputElement(0.8f, SimHashes.RefinedCarbon, 343.15f, false, false, (float)cellOffset.x, (float)cellOffset.y, 1f, byte.MaxValue, 0, true)
            };
            ElementDropper elementDropper = go.AddComponent<ElementDropper>();
            elementDropper.emitMass = 100f;
            elementDropper.emitTag = new Tag("RefinedCarbon");
            elementDropper.emitOffset = new Vector3(1f, 1f, 0f);
            Prioritizable.AddRef(go);
        }
        //----------------------------------------------------------------------------------------------------------------------
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
        }
        //----------------------------------------------------------------------------------------------------------------------
        public const string ID = "A62GG1";
        //----------------------------------------------------------------------------------------------------------------------
    }
}
