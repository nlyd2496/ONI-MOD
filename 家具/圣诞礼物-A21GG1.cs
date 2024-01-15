using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    public class A21GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A21GG1";
            int width = 1;
            int height = 1;
            string anim = "A21GG1_kanim";
            int hitpoints = 1000;
            float construction_time = 60f;
            float[] construction_mass = new float[]
            {
                23f
            };
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 9999f;
            BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, construction_mass, any_BUILDABLE, melting_point, build_location_rule, new EffectorValues
            {
                amount = 3,
                radius = 3
            }, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.OverheatTemperature = 2273.15f;
            buildingDef.ObjectLayer = ObjectLayer.Plants;
            buildingDef.SceneLayer = Grid.SceneLayer.Creatures;
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            //--------------------------
            if (控制台.Instance.圣诞礼物) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration, false);
        }
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
                "21"
            };
        }
        public const string ID = "A21GG1";
    }
}
