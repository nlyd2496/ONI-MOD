using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.精炼
{
    public class A61GG1 : BaseBatteryConfig
    {
        //------------------------------------------------------------------------------------------------
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A61GG1";
            int width = 2;
            int height = 2;
            string anim = "A61GG1_kanim";
            int hitpoints = 10;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id,
                width, height, anim, hitpoints, construction_time, tier,
                any_BUILDABLE, melting_point, build_location_rule,
                 new EffectorValues
                 {
                     amount = 10,
                     radius = 4
                 }, none, 0.2f);
            BuildingTemplates.CreateLadderDef(buildingDef);
            buildingDef.Floodable = true;//淹没真
            buildingDef.DragBuild = false;//拖动生成假
            buildingDef.Entombable = false;//可燃的假
            buildingDef.AudioSize = "small";//音频小
            buildingDef.Overheatable = false;//过热假
            buildingDef.AudioCategory = "Metal";//音频类别金属
            buildingDef.RequiresPowerInput = true;
            buildingDef.PowerInputOffset = new CellOffset(0, 0);
            buildingDef.EnergyConsumptionWhenActive = 120f;
            buildingDef.ExhaustKilowattsWhenActive = 1f;
            buildingDef.SelfHeatKilowattsWhenActive = 3f;
            buildingDef.PermittedRotations = PermittedRotations.FlipH;//水平旋转
            buildingDef.InputConduitType = ConduitType.Liquid;//液体管道
            buildingDef.UtilityInputOffset = new CellOffset(0, 0);//液体管道输出位置（0,0）
            buildingDef.OutputConduitType = ConduitType.Gas;//气体管道
            buildingDef.UtilityOutputOffset = new CellOffset(0, 0);//气体管道输出位置（0,0)
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));//信号接口
            //--------------------------
            if (控制台.Instance.石油裂解器) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        //------------------------------------------------------------------------------------------------
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
            conduitDispenser.conduitType = ConduitType.Gas;
            conduitDispenser.invertElementFilter = false;
            conduitDispenser.elementFilter = new SimHashes[]
            {
                SimHashes.Methane
            };
            CellOffset cellOffset = new CellOffset(0, 1);//天然气管道（0,1)
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
            Electrolyzer electrolyzer = go.AddOrGet<Electrolyzer>();
            electrolyzer.maxMass = float.PositiveInfinity;
            electrolyzer.hasMeter = true;
            electrolyzer.emissionOffset = cellOffset;
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Liquid;
            conduitConsumer.consumptionRate = 1f;
            conduitConsumer.capacityTag = ElementLoader.FindElementByHash(SimHashes.Petroleum).tag;//液体类型石油
            conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Dump;
            Storage storage = go.AddOrGet<Storage>();
            storage.capacityKg = 20f;
            storage.showInUI = true;
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
                new ElementConverter.ConsumedElement(new Tag("Petroleum"), 1f, true)//输入石油
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[]
            {
                new ElementConverter.OutputElement(0.15f, SimHashes.Methane, 343.15f, true, false, (float)cellOffset.x, (float)cellOffset.y, 1f, byte.MaxValue, 0, true),//排出天然气
                new ElementConverter.OutputElement(0.85f, SimHashes.Graphite, 343.15f, false, false, (float)cellOffset.x, (float)cellOffset.y, 1f, byte.MaxValue, 0, true)//掉落石墨
            };
            ElementDropper elementDropper = go.AddComponent<ElementDropper>();
            elementDropper.emitMass = 10f;
            elementDropper.emitTag = new Tag("Graphite");
            elementDropper.emitOffset = new Vector3(0f, 1f, 0f);
            Prioritizable.AddRef(go);
        }
        //------------------------------------------------------------------------------------------------
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
        }
        //------------------------------------------------------------------------------------------------
        public const string ID = "A61GG1";
        //------------------------------------------------------------------------------------------------
    }
}
