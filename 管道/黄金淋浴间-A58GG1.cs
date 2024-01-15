using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.管道
{
    public class A58GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A58GG1";
            int width = 2;
            int height = 4;
            string anim = "A58GG1_kanim";
            int hitpoints = 30;
            float construction_time = 30f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;

            string[] construction_materials = new string[]
            {
            "Gold"
            };

            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim,
                hitpoints, construction_time, tier, construction_materials, melting_point, build_location_rule,
                new EffectorValues
                {
                    amount = 20,
                    radius = 8
                }, none, 0.2f);

            buildingDef.Overheatable = false;
            buildingDef.ExhaustKilowattsWhenActive = 0.25f;
            buildingDef.InputConduitType = ConduitType.Liquid;
            buildingDef.OutputConduitType = ConduitType.Liquid;
            buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
            buildingDef.AudioCategory = "Metal";
            buildingDef.UtilityInputOffset = new CellOffset(0, 0);
            buildingDef.UtilityOutputOffset = new CellOffset(1, 1);
            //--------------------------
            if (控制台.Instance.黄金淋浴间) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<LoopingSounds>();
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.WashStation, false);
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.AdvancedWashStation, false);
            Shower shower11 = go.AddOrGet<Shower>();
            shower11.overrideAnims = new KAnimFile[]
            {
            Assets.GetAnim("anim_interacts_shower_kanim")
            };
            shower11.workTime = 15f;
            shower11.outputTargetElement = SimHashes.DirtyWater;
            shower11.fractionalDiseaseRemoval = 0.95f;
            shower11.absoluteDiseaseRemoval = -2000;
            shower11.workLayer = Grid.SceneLayer.BuildingFront;
            shower11.trackUses = true;
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Liquid;
            conduitConsumer.capacityTag = ElementLoader.FindElementByHash(SimHashes.Water).tag;
            conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Store;
            conduitConsumer.capacityKG = 5f;
            ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
            conduitDispenser.conduitType = ConduitType.Liquid;
            conduitDispenser.invertElementFilter = true;
            conduitDispenser.elementFilter = new SimHashes[]
            {
            SimHashes.Water
            };
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
            new ElementConverter.ConsumedElement(new Tag("Water"), 1f,true)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[]
            {
            new ElementConverter.OutputElement(1f, SimHashes.DirtyWater, 0f, false, true, 0f, 0.5f, 1f, byte.MaxValue, 0,true)
            };
            Storage storage = go.AddOrGet<Storage>();
            storage.capacityKg = 10f;
            storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
            go.AddOrGet<RequireOutputs>().ignoreFullPipe = true;
            go.AddOrGetDef<RocketUsageRestriction.Def>();
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
        }
        public static string ID = "A58GG1";

    }
}
