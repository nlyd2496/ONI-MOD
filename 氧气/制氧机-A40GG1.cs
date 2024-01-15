using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.控制器;

namespace 吐泡泡的小鱼的缺氧模组.氧气
{
    public class A40GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A40GG1";
            int width = 2;
            int height = 2;
            string anim = "electrolyzer_kanim";
            int hitpoints = 30;
            float construction_time = 30f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
            string[] all_METALS = MATERIALS.ALL_METALS;
            float melting_point = 800f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER3;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, all_METALS, melting_point, build_location_rule, BUILDINGS.DECOR.PENALTY.TIER1, tier2, 0.2f);
            buildingDef.RequiresPowerInput = true;
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.PowerInputOffset = new CellOffset(0, 0);
            buildingDef.EnergyConsumptionWhenActive = 120f;
            buildingDef.ExhaustKilowattsWhenActive = 0.25f;
            buildingDef.SelfHeatKilowattsWhenActive = 1f;
            buildingDef.ViewMode = OverlayModes.Oxygen.ID;
            buildingDef.AudioCategory = "HollowMetal";
            buildingDef.InputConduitType = ConduitType.Liquid;
            buildingDef.UtilityInputOffset = new CellOffset(0, 0);
            buildingDef.OutputConduitType = ConduitType.Gas;
            buildingDef.UtilityOutputOffset = new CellOffset(0, 0);
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
            //--------------------------
            if (控制台.Instance.智能制氧机) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<A40GG1_KZQ>();
            ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
            conduitDispenser.conduitType = ConduitType.Gas;
            conduitDispenser.invertElementFilter = false;
            conduitDispenser.elementFilter = new SimHashes[]
            {
                SimHashes.Hydrogen
            };
            CellOffset cellOffset = new CellOffset(0, 1);
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
            Electrolyzer electrolyzer1 = go.AddOrGet<Electrolyzer>();
            electrolyzer1.maxMass = 10f;
            electrolyzer1.hasMeter = true;
            electrolyzer1.emissionOffset = cellOffset;
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Liquid;
            conduitConsumer.consumptionRate = 1f;
            conduitConsumer.capacityTag = ElementLoader.FindElementByHash(SimHashes.Water).tag;
            conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Dump;
            Storage storage = go.AddOrGet<Storage>();
            storage.capacityKg = 2f;
            storage.showInUI = true;
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
            new ElementConverter.ConsumedElement(new Tag("Water"), 1f,true)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[]
            {
            new ElementConverter.OutputElement(SingletonOptions<控制台>.Instance.智能制氧机输出氧气, SimHashes.Oxygen, 293.15f, true, false, (float)cellOffset.x, (float)cellOffset.y, 1f, byte.MaxValue, 0,true),
            new ElementConverter.OutputElement(SingletonOptions<控制台>.Instance.智能制氧机输出氢气, SimHashes.Hydrogen, 293.15f, true, true, (float)cellOffset.x, (float)cellOffset.y, 1f, byte.MaxValue, 0,true)
            };
            Prioritizable.AddRef(go);
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
        }
    }
}
