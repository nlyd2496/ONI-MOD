using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    public class A29GG2 : IBuildingConfig
    {
        //-------------------------------
        //以下为建筑通用属性
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A29GG2";
            int width = 3;
            int height = 3;
            string anim = "A29GG2_kanim";
            int hitpoints = 1000;
            float construction_time = 60f;
            float[] construction_mass = new float[]
            {
                200f
            };
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 9999f;
            BuildLocationRule build_location_rule = BuildLocationRule.BuildingAttachPoint;
            EffectorValues tier = NOISE_POLLUTION.NOISY.TIER2;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, construction_mass, any_BUILDABLE, melting_point, build_location_rule, new EffectorValues
            {
                amount = 24,
                radius = 24
            }, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            //-------------------------------
            buildingDef.AttachmentSlotTag = "A29GG2";
            buildingDef.attachablePosition = new CellOffset(0, 0);
            //-------------------------------
            //--------------------------
            if (控制台.Instance.ACGN之二次元之魂) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        //-------------------------------
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
            go.AddOrGet<LoopingSounds>();
            go.AddOrGet<BuildingAttachPoint>().points = new BuildingAttachPoint.HardPoint[]
            {
                new BuildingAttachPoint.HardPoint(new CellOffset(0, 3), "A29GG3", null)
            };
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
                "03"
            };
        }
        //-------------------------------
        public const string ID = "A29GG2";
    }
}
