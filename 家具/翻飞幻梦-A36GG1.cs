using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    public class A36GG1 : IBuildingConfig
    {
        //----------------------------------------------------------------------------------------
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A36GG1";
            int width = 2;
            int height = 3;
            string anim = "A36GG1_kanim";
            int hitpoints = 1000;
            float construction_time = 60f;
            float[] construction_mass = new float[]
            {
                200f
            };
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 9999f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues tier = NOISE_POLLUTION.NOISY.TIER2;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, construction_mass, any_BUILDABLE, melting_point, build_location_rule, new EffectorValues
            {
                amount = 6,
                radius = 6
            }, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.OverheatTemperature = 2273.15f;
            buildingDef.ObjectLayer = ObjectLayer.Building;
            buildingDef.SceneLayer = Grid.SceneLayer.Building;
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            //--------------------------
            if (控制台.Instance.翻飞幻梦) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        //----------------------------------------------------------------------------------------
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.RecBuilding, false);
            /*
             * 建筑类型
             * RecRoom PrivateBedroom PowerPlant PlumbedBathroom Park Neutral NatureReserve	MessHall MassageClinic MachineShop Latrine Laboratory Kitchen Hospital GreatHall Farm CreaturePen Bedroom Barracks
             * 娱乐室  私人卧室	      发电厂	 有水管的浴室	 公园 中立	  自然保护区	食堂	 按摩诊所	   机械车间	   厕所	   实验室	  厨房	  医院	   大厅	     农场 动物围栏 	  卧室	  兵营
             */
        }
        //----------------------------------------------------------------------------------------
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<SelectableSign>().AnimationNames = new List<string>
            {
                "00",
                "01",
                "02",
                "03",
                "04",
                "05",
                "06",
                "07",
                "08",
                "09",
                "10",
                "11",
                "12",
                "13",
                "14",
                "15",
                "16",
                "17",
                "18",
                "19",
                "20",
                "21",
                "22",
                "23",
                "24",
                "25",
                "26",
                "27",
            };
        }
        //----------------------------------------------------------------------------------------
        public const string ID = "A36GG1";
        //----------------------------------------------------------------------------------------
    }
}
