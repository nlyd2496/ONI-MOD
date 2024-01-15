using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.精炼
{
    public class A67GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A67GG1";
            int width = 4;
            int height = 4;
            string anim = "geyser_oil_cap_kanim";
            int hitpoints = 100;
            float construction_time = 120f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
            string[] refined_METALS = MATERIALS.REFINED_METALS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER2;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, refined_METALS, melting_point, build_location_rule, BUILDINGS.DECOR.NONE, tier2, 0.2f);
            BuildingTemplates.CreateElectricalBuildingDef(buildingDef);
            buildingDef.SceneLayer = Grid.SceneLayer.BuildingFront;
            buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
            buildingDef.EnergyConsumptionWhenActive = 240f;
            buildingDef.SelfHeatKilowattsWhenActive = 2f;
            buildingDef.InputConduitType = ConduitType.Liquid;
            buildingDef.UtilityInputOffset = new CellOffset(0, 1);
            buildingDef.PowerInputOffset = new CellOffset(1, 1);
            buildingDef.OverheatTemperature = 2273.15f;
            buildingDef.Floodable = false;
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
            buildingDef.AttachmentSlotTag = GameTags.OilWell;
            buildingDef.BuildLocationRule = BuildLocationRule.BuildingAttachPoint;
            buildingDef.ObjectLayer = ObjectLayer.AttachableBuilding;
            //--------------------------
            if (控制台.Instance.石油井) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }

        // Token: 0x06000F0C RID: 3852 RVA: 0x000B0A1C File Offset: 0x000AEC1C
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<LoopingSounds>();
            BuildingTemplates.CreateDefaultStorage(go, false).showInUI = true;
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Liquid;
            conduitConsumer.consumptionRate = 2f;
            conduitConsumer.capacityKG = 10f;
            conduitConsumer.capacityTag = A67GG1.INPUT_WATER_TAG;
            conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Dump;
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
            new ElementConverter.ConsumedElement(A67GG1.INPUT_WATER_TAG, 1f,true)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[]
            {
            new ElementConverter.OutputElement(10f, SimHashes.Petroleum, 363.15f, false, false, 2f, 1.5f, 0f, byte.MaxValue, 0,true)
            };
            OilWellCap oilWelll = go.AddOrGet<OilWellCap>();
            oilWelll.gasElement = SimHashes.Methane;
            oilWelll.gasTemperature = 573.15f;
            oilWelll.addGasRate = 0f;
            oilWelll.maxGasPressure = 80.00001f;
            oilWelll.releaseGasRate = 0.44444448f;
        }

        // Token: 0x06000F0D RID: 3853 RVA: 0x000071F4 File Offset: 0x000053F4
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
        }

        // Token: 0x04000966 RID: 2406
        private const float WATER_INTAKE_RATE = 1f;

        // Token: 0x04000967 RID: 2407
        private const float WATER_TO_OIL_RATIO = 10f;

        // Token: 0x04000968 RID: 2408
        private const float LIQUID_STORAGE = 10f;

        // Token: 0x04000969 RID: 2409
        private const float GAS_RATE = 0f;

        // Token: 0x0400096A RID: 2410
        private const float OVERPRESSURE_TIME = 2400f;

        // Token: 0x0400096B RID: 2411
        private const float PRESSURE_RELEASE_TIME = 180f;

        // Token: 0x0400096C RID: 2412
        private const float PRESSURE_RELEASE_RATE = 0.44444448f;

        // Token: 0x0400096D RID: 2413
        private static readonly Tag INPUT_WATER_TAG = SimHashes.Water.CreateTag();

        // Token: 0x0400096E RID: 2414
        public const string ID = "A67GG1";
    }
}
