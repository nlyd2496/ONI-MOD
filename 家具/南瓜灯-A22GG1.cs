using PeterHan.PLib.Options;
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
    public class A22GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A22GG1";
            int width = 1;
            int height = 1;
            string anim = "A22GG1_kanim";
            int hitpoints = 10;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER1;
            string[] all_METALS = MATERIALS.ALL_METALS;
            float melting_point = 800f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef
                (id, width, height, anim, hitpoints, construction_time, tier,
                all_METALS, melting_point, build_location_rule,
                BUILDINGS.DECOR.BONUS.TIER1, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.Entombable = false;
            buildingDef.Overheatable = false;
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = 10f;
            buildingDef.SelfHeatKilowattsWhenActive = 0.1f;
            buildingDef.ViewMode = OverlayModes.Light.ID;
            buildingDef.AudioCategory = "Metal";
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
            //--------------------------
            if (控制台.Instance.南瓜灯) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
            LightShapePreview lightShapePreview = go.AddComponent<LightShapePreview>();
            lightShapePreview.lux = 1000;
            lightShapePreview.radius = 6f;
            lightShapePreview.shape = global::LightShape.Circle;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.LightSource, false);
            go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration, false);
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LoopingSounds>();

            Light2D light2D = go.AddOrGet<Light2D>();
            light2D.overlayColour = LIGHT2D.CEILINGLIGHT_OVERLAYCOLOR;
            light2D.Color = new Color
                (
                10f,
                0f,
                10f,
                1f);
            light2D.Range = 6f;
            light2D.Angle = 4f;
            light2D.Direction = new Vector2(0f, 1f);
            light2D.Offset = LIGHT2D.CEILINGLIGHT_OFFSET;
            light2D.shape = global::LightShape.Circle;
            light2D.drawOverlay = true;
            light2D.Lux = 800;
            go.AddOrGetDef<LightController.Def>();
            go.AddOrGet<A18GG1_KZQ>();//能量控制器
            go.AddOrGet<EnergyConsumer>();//能量控制器
            go.AddOrGet<LogicOperationalController>();//信号控制器
        }
        public const string ID = "A22GG1";
    }
}
