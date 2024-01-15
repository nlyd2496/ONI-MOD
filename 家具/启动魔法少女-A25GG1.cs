using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    public class A25GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A25GG1";
            int width = 1;
            int height = 1;
            string anim = "A25GG1_kanim";
            int hitpoints = 10;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER1;
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef
                (id, width, height, anim, hitpoints, construction_time, tier,
                any_BUILDABLE, melting_point, build_location_rule,
            new EffectorValues
            {
                amount = 6,//装饰度1
                radius = 6//装饰范围1
            }, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.Entombable = false;
            buildingDef.Overheatable = false;

            buildingDef.AudioCategory = "Metal";
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
            //--------------------------
            if (控制台.Instance.启动魔法少女) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {

        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.RecBuilding, false);
            go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration, false);
            /*
             * 建筑类型
             * RecRoom PrivateBedroom PowerPlant PlumbedBathroom Park Neutral NatureReserve	MessHall MassageClinic MachineShop Latrine Laboratory Kitchen Hospital GreatHall Farm CreaturePen Bedroom Barracks
             * 娱乐室  私人卧室	      发电厂	 有水管的浴室	 公园 中立	  自然保护区	食堂	 按摩诊所	   机械车间	   厕所	   实验室	  厨房	  医院	   大厅	     农场 动物围栏 	  卧室	  兵营
             */
            RoomTracker roomTracker = go.AddOrGet<RoomTracker>();
            roomTracker.requiredRoomType = Db.Get().RoomTypes.RecRoom.Id;
            roomTracker.requirement = RoomTracker.Requirement.Recommended;
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LoopingSounds>();

            go.AddOrGet<LogicOperationalController>();//信号控制器
            
            go.AddOrGetDef<OperationalController.Def>();
            
        }
        public const string ID = "A25GG1";
 
    }
}
