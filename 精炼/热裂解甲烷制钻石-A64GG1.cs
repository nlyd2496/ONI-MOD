using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.精炼
{
    public class A64GG1 : IBuildingConfig
    {
        //----------------------------------------------------------------------------------------------------------------------
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A64GG1";//建筑ID
            int width = 4;//宽度4
            int height = 3;//高度3
            string anim = "A64GG1_kanim";//建筑动画文件夹
            int hitpoints = 100;
            float construction_time = 100f;//建造时间
            string[] array = new string[]
{
            "RefinedMetal",//使用精炼金属
            "Copper"//使用铜
};
            float[] construction_mass = new float[]
            {
            BUILDINGS.CONSTRUCTION_MASS_KG.TIER5[0],//精炼金属用量5
            BUILDINGS.CONSTRUCTION_MASS_KG.TIER2[0]//精炼金属用量2
            };
            string[] construction_materials = array;
            float melting_point = 3000f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;//放置在地板上
            EffectorValues tier = NOISE_POLLUTION.NOISY.TIER3;//3级噪音
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, construction_mass, construction_materials, melting_point, build_location_rule, new EffectorValues
            {
                amount = 2,//装饰强度2
                radius = 2//装饰范围2
            }, tier, 0.2f);
            BuildingTemplates.CreateLadderDef(buildingDef);
            buildingDef.Floodable = true;//不被淹没
            buildingDef.DragBuild = false;//不能拖动生成
            buildingDef.Entombable = false;//不易碎
            buildingDef.AudioSize = "small";
            buildingDef.Overheatable = false;//不过热
            buildingDef.AudioCategory = "Metal";
            buildingDef.RequiresPowerInput = true;
            buildingDef.ExhaustKilowattsWhenActive = 1f;
            buildingDef.SelfHeatKilowattsWhenActive = 30; ;//配置热量
            buildingDef.InputConduitType = ConduitType.Gas;//输入管道类型为气管
            buildingDef.ViewMode = OverlayModes.GasConduits.ID;
            buildingDef.AudioCategory = "Metal";
            buildingDef.EnergyConsumptionWhenActive = 1000;//配置电力
            buildingDef.PowerInputOffset = new CellOffset(0, 0);//电力输入0 0
            buildingDef.UtilityInputOffset = new CellOffset(-1, 0);//气体输入-1 0
            buildingDef.PermittedRotations = PermittedRotations.FlipH;//可水平旋转
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));//信号输入0 0
            //--------------------------
            if (控制台.Instance.热裂解甲烷制钻石) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        //----------------------------------------------------------------------------------------------------------------------
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
            //累计30掉落钻石，掉落位置坐标1 1
            Polymerizer polymerizer = go.AddOrGet<Polymerizer>();
            polymerizer.emitMass = 30f;
            polymerizer.emitTag = GameTagExtensions.Create(SimHashes.Diamond);
            polymerizer.emitOffset = new Vector3(2f, 1f, 0f);
            //将输入管道设定为气体管道，分配给天然气，吸收2，储存2，错误元素排出
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Gas;
            conduitConsumer.consumptionRate = 2f;
            conduitConsumer.capacityTag = GameTagExtensions.Create(SimHashes.Methane);
            conduitConsumer.capacityKG = 2f;
            conduitConsumer.forceAlwaysSatisfied = true;
            conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Dump;
            //设定原料及产物
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
                //原料天然气，消耗1
                new ElementConverter.ConsumedElement(GameTagExtensions.Create(SimHashes.Methane), 0.8f, true)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[]
            {
                //产物钻石，非管道运输
                new ElementConverter.OutputElement(SingletonOptions<控制台>.Instance.热裂解制钻石的产物钻石, SimHashes.Diamond, 473.15f, true, true, 0f, 0.5f, 1f, byte.MaxValue, 0, true),
                //产物氢气，非管道运输
                new ElementConverter.OutputElement(SingletonOptions<控制台>.Instance.热裂解制钻石的产物氢气, SimHashes.Hydrogen, 473.15f, true, false, 0f, 0.5f, 1f, byte.MaxValue, 0, true)
            };
            Prioritizable.AddRef(go);
        }
        //----------------------------------------------------------------------------------------------------------------------
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();//信号控制
            //go.AddOrGetDef<OperationalController.Def>();//动画控制
            go.AddOrGetDef<PoweredActiveController.Def>();//电力控制
        }
        //----------------------------------------------------------------------------------------------------------------------
        public const string ID = "A64GG1";
        //----------------------------------------------------------------------------------------------------------------------
    }
}
