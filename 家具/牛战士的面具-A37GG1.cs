using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.控制器;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    public class A37GG1 : IBuildingConfig
    {
        //-------------------------------
        //以下为建筑通用属性
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A37GG1";
            int width = 1;
            int height = 1;
            string anim = "A37GG1_kanim";
            int hitpoints = 1000;
            float construction_time = 60f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
            string[] raw_METALS = MATERIALS.RAW_METALS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef
                (id, width, height, anim, hitpoints, construction_time, tier, raw_METALS,
                melting_point, build_location_rule, new EffectorValues
                {
                    amount = 6,
                    radius = 6
                }, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.SceneLayer = Grid.SceneLayer.BuildingFront;
            buildingDef.PermittedRotations = PermittedRotations.R360;
            //--------------------------
            if (控制台.Instance.牛战士的面具) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
            go.AddOrGet<LoopingSounds>();
            go.AddOrGet<A37GG1_KZQ>();//将CSKZMM20230828GG1的功能添加到GasBottlerConfig中
                                                 //this.MakeSmaller(go);//+
            go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration, false);

        }
        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
        }
        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<SelectableSign>().AnimationNames = new List<string>
            {
                "1",//造型2
                "2",//造型3
                "3",
                "4",
            };
        }
        public const string ID = "A37GG1";
    }
}
