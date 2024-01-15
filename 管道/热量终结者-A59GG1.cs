using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static STRINGS.BUILDINGS.PREFABS;
using TUNING;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.控制器;

namespace 吐泡泡的小鱼的缺氧模组.管道
{
    public class A59GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A59GG1";
            int width = 2;
            int height = 2;
            string anim = "liquidconditioner_kanim";
            int hitpoints = 100;
            float construction_time = 120f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER6;
            string[] all_METALS = MATERIALS.ALL_METALS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER2;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, all_METALS, melting_point, build_location_rule, BUILDINGS.DECOR.NONE, tier2, 0.2f);
            BuildingTemplates.CreateElectricalBuildingDef(buildingDef);
            buildingDef.EnergyConsumptionWhenActive = 333f;
            buildingDef.SelfHeatKilowattsWhenActive = 0f;
            buildingDef.Overheatable = false;
            buildingDef.InputConduitType = ConduitType.Liquid;
            buildingDef.OutputConduitType = ConduitType.Liquid;
            buildingDef.Floodable = false;
            buildingDef.PowerInputOffset = new CellOffset(1, 0);
            buildingDef.UtilityInputOffset = new CellOffset(0, 0);
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            buildingDef.RequiresPowerInput = true;

            buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(1, 1));
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.LiquidVentIDs, "A59GG1");
            //--------------------------
            if (控制台.Instance.热量终结者) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<A59GG1_KZQ>();
            go.AddOrGet<LoopingSounds>();
            A59GG0 airConditionerr = go.AddOrGet<A59GG0>();
            airConditionerr.temperatureDelta = -20f;
            airConditionerr.maxEnvironmentDelta = -200f;
            airConditionerr.isLiquidConditioner = true;
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Liquid;
            conduitConsumer.consumptionRate = 100f;
            Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
            storage.showInUI = true;
            storage.capacityKg = 2f * conduitConsumer.consumptionRate;
            storage.SetDefaultStoredItemModifiers(A59GG1.StoredItemModifiers);
            go.AddOrGet<MinimumOperatingTemperature>().minimumTemperature = 3f;//最低温度，单位K

        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
            go.GetComponent<KPrefabID>().AddTag(GameTags.OverlayBehindConduits, false);
        }
        public const string ID = "A59GG1";
        private static readonly List<Storage.StoredItemModifier> StoredItemModifiers = new List<Storage.StoredItemModifier>
        {
            Storage.StoredItemModifier.Hide,
            Storage.StoredItemModifier.Insulate,
            Storage.StoredItemModifier.Seal
        };
    }
    public class A59GG2 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A59GG2";
            int width = 2;
            int height = 2;
            string anim = "airconditioner_kanim";
            int hitpoints = 100;
            float construction_time = 120f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
            string[] all_METALS = MATERIALS.ALL_METALS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER2;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, all_METALS, melting_point, build_location_rule, BUILDINGS.DECOR.NONE, tier2, 0.2f);
            BuildingTemplates.CreateElectricalBuildingDef(buildingDef);
            buildingDef.EnergyConsumptionWhenActive = 333f;
            buildingDef.SelfHeatKilowattsWhenActive = 0f;
            buildingDef.RequiresPowerInput = true;

            //-----------------------------
            //导热系数0

            //-----------------------------
            //不会过热
            buildingDef.Overheatable = false;
            //-----------------------------
            buildingDef.InputConduitType = ConduitType.Gas;
            buildingDef.OutputConduitType = ConduitType.Gas;
            buildingDef.PowerInputOffset = new CellOffset(1, 0);
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            buildingDef.ViewMode = OverlayModes.GasConduits.ID;
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 1));
            //--------------------------
            if (控制台.Instance.热量终结者) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        //-------------------------------------------------------------------------------------------
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            //-----------------------------
            //链接到温度控制
            go.AddOrGet<A59GG2_KZQ>();
            //-----------------------------
            go.AddOrGet<LoopingSounds>();
            A59GG0 airConditioner = go.AddOrGet<A59GG0>();
            airConditioner.temperatureDelta = -20f;
            airConditioner.maxEnvironmentDelta = -200f;
            Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
            storage.showInUI = true;
            storage.SetDefaultStoredItemModifiers(new List<Storage.StoredItemModifier>
            {
                Storage.StoredItemModifier.Hide,
                Storage.StoredItemModifier.Seal,
                Storage.StoredItemModifier.Insulate
            });
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Gas;
            conduitConsumer.consumptionRate = 10f;
            go.AddOrGet<MinimumOperatingTemperature>().minimumTemperature = 3f;//最低温度，单位K
        }
        //-------------------------------------------------------------------------------------------
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
        }
        public const string ID = "A59GG2";
    }
}
