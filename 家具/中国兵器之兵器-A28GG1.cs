using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    public class A28GG2 : IBuildingConfig
    {
        //-------------------------------
        //以下为建筑通用属性
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A28GG2";
            int width = 1;
            int height = 1;
            string anim = "A28GG2_kanim";
            int hitpoints = 1000;
            float construction_time = 60f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
            string[] raw_METALS = MATERIALS.RAW_METALS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.BuildingAttachPoint;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef
                (id, width, height, anim, hitpoints, construction_time, tier, raw_METALS,
                melting_point, build_location_rule, new EffectorValues
                {
                    amount = 3,
                    radius = 3
                }, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.SceneLayer = Grid.SceneLayer.BuildingBack;
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            //-------------------------------
            buildingDef.AttachmentSlotTag = "A28GG2";
            buildingDef.attachablePosition = new CellOffset(0, 0);
            //-------------------------------
            //--------------------------
            if (控制台.Instance.中国兵器) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        //-------------------------------
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
            go.AddOrGet<LoopingSounds>();
            go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration, false);

        }
        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
        }
        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
        }
        //-------------------------------
        //以下为建筑添加更多造型，动画软件内项目请看“Spriter动画项目命名”
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<SelectableSign>().AnimationNames = new List<string>
            {
                //"00",//造型1
                "01",//造型2
                "02",//造型3
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
                "18"
            };
        }
        //-------------------------------
        public const string ID = "A28GG2";
    }
}
