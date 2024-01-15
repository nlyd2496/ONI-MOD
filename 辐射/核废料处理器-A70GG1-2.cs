using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.辐射
{
    //核废料处理
    public class A70GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A70GG1";
            int width = 3;
            int height = 2;
            string anim = "A70GG1_kanim";
            int hitpoints = 30;
            float construction_time = 30f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
            //-------------------------------------------
            string[] all_METALS = MATERIALS.ALL_METALS;
            //-------------------------------------------
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER3;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, all_METALS, melting_point, build_location_rule, BUILDINGS.DECOR.NONE, tier2, 0.2f);
            BuildingTemplates.CreateElectricalBuildingDef(buildingDef);
            buildingDef.AudioCategory = "Metal";
            buildingDef.AudioSize = "large";
            buildingDef.Floodable = false;//不会被淹没
            buildingDef.EnergyConsumptionWhenActive = 100f;
            buildingDef.ExhaustKilowattsWhenActive = 0f;
            buildingDef.RequiresPowerInput = true;

            buildingDef.SelfHeatKilowattsWhenActive = 10f;
            buildingDef.PowerInputOffset = new CellOffset(0, 0);


            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            //--------------------------
            if (控制台.Instance.核废料处理器) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {

            //-------------------------------------------
            //辐射
            RadiationEmitter radiationEmitter = go.AddComponent<RadiationEmitter>();
            radiationEmitter.emitType = RadiationEmitter.RadiationEmitterType.Constant;
            radiationEmitter.emitRadiusX = 4;
            radiationEmitter.emitRadiusY = 4;
            radiationEmitter.emitRads = 20f;
            //-------------------------------------------


            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);

            Polymerizer polymerizer = go.AddOrGet<Polymerizer>();
            polymerizer.emitMass = 30f;
            polymerizer.emitTag = GameTagExtensions.Create(SimHashes.Iron);
            polymerizer.emitOffset = new Vector3(-1.45f, 1f, 0f);

            Storage storage = go.AddOrGet<Storage>();
            storage.capacityKg = 100f;
            storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
            storage.showInUI = true;
            ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
            manualDeliveryKG.SetStorage(storage);
            manualDeliveryKG.RequestedItemTag = new Tag("NuclearWaste");
            manualDeliveryKG.refillMass = 0.1f;
            manualDeliveryKG.capacity = 1f;
            manualDeliveryKG.choreTypeIDHash = Db.Get().ChoreTypes.MachineFetch.IdHash;
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {

            new ElementConverter.ConsumedElement(new Tag("NuclearWaste"), 1f, true)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[]
            {
            new ElementConverter.OutputElement(0.6f, SimHashes.Iron, 303.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0, true)
            };
            go.AddOrGet<DropAllWorkable>();
            Prioritizable.AddRef(go);
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
        }
        public const string ID = "A70GG1";
    }
    //核废水处理
    public class A70GG2 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A70GG2";
            int width = 3;
            int height = 2;
            string anim = "A70GG2_kanim";
            int hitpoints = 30;
            float construction_time = 30f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
            //-------------------------------------------
            string[] all_METALS = MATERIALS.ALL_METALS;
            //-------------------------------------------
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER3;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, all_METALS, melting_point, build_location_rule, BUILDINGS.DECOR.NONE, tier2, 0.2f);
            BuildingTemplates.CreateElectricalBuildingDef(buildingDef);
            buildingDef.AudioCategory = "Metal";
            buildingDef.AudioSize = "large";
            buildingDef.Floodable = false;//不会被淹没
            buildingDef.EnergyConsumptionWhenActive = 100f;
            buildingDef.RequiresPowerInput = true;

            buildingDef.ExhaustKilowattsWhenActive = 0f;
            buildingDef.SelfHeatKilowattsWhenActive = 10f;
            buildingDef.PowerInputOffset = new CellOffset(0, 0);
            buildingDef.InputConduitType = ConduitType.Liquid;
            buildingDef.UtilityInputOffset = new CellOffset(-1, 0);
            buildingDef.OutputConduitType = ConduitType.Liquid;
            buildingDef.UtilityOutputOffset = new CellOffset(1, 0);
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            //--------------------------
            if (控制台.Instance.核废水处理器) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
            Polymerizer polymerizer = go.AddOrGet<Polymerizer>();
            polymerizer.emitMass = 30f;
            polymerizer.emitTag = GameTagExtensions.Create(SimHashes.Iron);
            polymerizer.emitOffset = new Vector3(-1.45f, 1f, 0f);
            //-------------------------------------------
            //辐射
            RadiationEmitter radiationEmitter = go.AddComponent<RadiationEmitter>();
            radiationEmitter.emitType = RadiationEmitter.RadiationEmitterType.Constant;
            radiationEmitter.emitRadiusX = 4;
            radiationEmitter.emitRadiusY = 4;
            radiationEmitter.emitRads = 20f;
            //-------------------------------------------
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Liquid;
            conduitConsumer.consumptionRate = 2f;
            conduitConsumer.capacityTag = GameTagExtensions.Create(SimHashes.NuclearWaste);
            conduitConsumer.capacityKG = 2f;
            conduitConsumer.forceAlwaysSatisfied = true;
            conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Destroy;
            ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
            conduitDispenser.conduitType = ConduitType.Liquid;
            conduitDispenser.invertElementFilter = false;
            conduitDispenser.elementFilter = new SimHashes[]
            {
            SimHashes.DirtyWater
            };
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
            new ElementConverter.ConsumedElement(GameTagExtensions.Create(SimHashes.NuclearWaste), 1f, true)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[]
            {
            new ElementConverter.OutputElement(0.1f, SimHashes.Iron, 363.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0, true),
            new ElementConverter.OutputElement(0.8f, SimHashes.DirtyWater, 363.15f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0, true)
            };
            go.AddOrGet<DropAllWorkable>();
            Prioritizable.AddRef(go);
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
        }
        public const string ID = "A70GG2";
    }
}
