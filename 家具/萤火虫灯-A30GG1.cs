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
    public class A30GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A30GG1";
            int width = 1;
            int height = 1;
            string anim = "A30GG1_kanim";
            int hitpoints = 10;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER1;
            string[] all_METALS = MATERIALS.REFINED_METALS;
            float melting_point = 800f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnCeiling;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, all_METALS, melting_point, build_location_rule, BUILDINGS.DECOR.BONUS.TIER2, none, 0.2f);
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = 10f;
            buildingDef.SelfHeatKilowattsWhenActive = 0.1f;
            buildingDef.ViewMode = OverlayModes.Light.ID;
            buildingDef.AudioCategory = "Metal";
            //--------------------------
            if (控制台.Instance.萤火虫灯) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
            LightShapePreview lightShapePreview = go.AddComponent<LightShapePreview>();
            lightShapePreview.lux = 6800;
            lightShapePreview.radius = 8f;
            lightShapePreview.shape = global::LightShape.Cone;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.LightSource, false);
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            LightShapePreview lightShapePreview = go.AddComponent<LightShapePreview>();
            lightShapePreview.shape = global::LightShape.Cone;
            lightShapePreview.offset = new CellOffset((int)LIGHT2D.CEILINGLIGHT_OFFSET.x, (int)LIGHT2D.CEILINGLIGHT_OFFSET.y);

            go.AddOrGet<LoopingSounds>();
            Light2D light2D = go.AddOrGet<Light2D>();
            light2D.overlayColour = LIGHT2D.CEILINGLIGHT_OVERLAYCOLOR;
            light2D.Color = LIGHT2D.CEILINGLIGHT_COLOR;
            light2D.Range = 8f;
            light2D.Angle = 2.6f;
            light2D.Direction = LIGHT2D.CEILINGLIGHT_DIRECTION;
            light2D.Offset = LIGHT2D.CEILINGLIGHT_OFFSET;
            light2D.shape = global::LightShape.Cone;
            light2D.drawOverlay = true;
            //light2D.Lux = 1800;
            //light2D.Lux = (int)((light2D.Range)*100f);
            go.AddOrGetDef<A30GG1_DHKZQ.Def>();
            go.AddOrGet<A30GG1_KZQ>();
            LightShapePreview lsp = go.GetComponent<LightShapePreview>();
            lsp.radius = light2D.Range;
            lsp.lux = light2D.Lux;
        }
        public const string ID = "A30GG1";
    }
}
