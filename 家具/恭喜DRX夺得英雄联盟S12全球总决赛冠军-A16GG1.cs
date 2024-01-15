using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    public class A16GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A16GG1";
            int width = 1;
            int height = 1;
            string anim = "A16GG1_kanim";
            int hitpoints = 10;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 9999f;//过热温度9999度
            BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;//任意位置可建造
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, any_BUILDABLE, melting_point, build_location_rule,
                //-----------------------------------------------------
                new EffectorValues//装饰度加成
                {
                    amount = 12,
                    radius = 12
                }, none, 0.2f);
            //-----------------------------------------------------
            buildingDef.Overheatable = false;//不会过热
            buildingDef.Floodable = false;//不会淹没
            //-----------------------------------------------------
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = 12f;
            //-----------------------------------------------------
            buildingDef.ViewMode = OverlayModes.Light.ID;
            buildingDef.AudioCategory = "Metal";
            // 如果控制台的实例的a1属性为真，执行以下代码
            if (控制台.Instance.DRX)
            {
                // 将buildingDef对象的Deprecated属性设置为false
                buildingDef.Deprecated = false;
            }
            // 否则，执行以下代码
            else
            {
                // 将buildingDef对象的Deprecated属性设置为true
                buildingDef.Deprecated = true;
            }
            return buildingDef;
        }
        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
            LightShapePreview lightShapePreview = go.AddComponent<LightShapePreview>();
            lightShapePreview.lux = 2022;
            lightShapePreview.radius = 12f;
            lightShapePreview.shape = global::LightShape.Circle;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.LightSource, false);
            go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration, false);
            //-----------------------------------------------------
            //-----------------------------------------------------
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LoopingSounds>();
            Light2D light2D = go.AddOrGet<Light2D>();
            light2D.overlayColour = LIGHT2D.CEILINGLIGHT_OVERLAYCOLOR;
            light2D.Color = LIGHT2D.CEILINGLIGHT_COLOR;
            light2D.Range = 12f;
            light2D.Angle = 2.6f;
            light2D.Direction = LIGHT2D.CEILINGLIGHT_DIRECTION;
            light2D.Offset = LIGHT2D.CEILINGLIGHT_OFFSET;
            light2D.shape = global::LightShape.Circle;
            light2D.drawOverlay = true;
            light2D.Lux = 2022;
            go.AddOrGetDef<LightController.Def>();
            //-----------------------------------------------------
            //-----------------------------------------------------
        }
        public const string ID = "A16GG1";
    }
}
