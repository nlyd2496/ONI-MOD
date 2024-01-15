using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.电力
{
    public class A9GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A9GG1";
            int width = 5;
            int height = 1;
            string anim = "A9GG1_kanim";
            int hitpoints = 30;
            float construction_time = 3f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER0;
            string[] refined_METALS = MATERIALS.REFINED_METALS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.WireBridge;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, refined_METALS, melting_point, build_location_rule, BUILDINGS.DECOR.PENALTY.TIER0, none, 0.2f);
            buildingDef.Overheatable = false;
            buildingDef.Floodable = false;
            buildingDef.Entombable = false;
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.ObjectLayer = ObjectLayer.WireConnectors;
            buildingDef.SceneLayer = Grid.SceneLayer.WireBridges;
            buildingDef.AudioCategory = "Metal";
            buildingDef.AudioSize = "small";
            buildingDef.BaseTimeUntilRepair = -1f;
            buildingDef.PermittedRotations = PermittedRotations.R360;
            buildingDef.UtilityInputOffset = new CellOffset(0, 0);
            buildingDef.UtilityOutputOffset = new CellOffset(0, 2);
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.WireIDs, "A9GG1");
            // 如果控制台的实例的a1属性为真，执行以下代码
            if (控制台.Instance.跨三格导线桥)
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
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            GeneratedBuildings.MakeBuildingAlwaysOperational(go);
        }
        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
            base.DoPostConfigurePreview(def, go);
            this.AddNetworkLink(go).visualizeOnly = true;
            go.AddOrGet<BuildingCellVisualizer>();
        }
        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
            this.AddNetworkLink(go).visualizeOnly = true;
            go.AddOrGet<BuildingCellVisualizer>();
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            this.AddNetworkLink(go).visualizeOnly = false;
            go.AddOrGet<BuildingCellVisualizer>();
        }
        protected virtual WireUtilityNetworkLink AddNetworkLink(GameObject go)
        {
            WireUtilityNetworkLink wireUtilityNetworkLink = go.AddOrGet<WireUtilityNetworkLink>();
            wireUtilityNetworkLink.maxWattageRating = Wire.WattageRating.Max2000;
            wireUtilityNetworkLink.link1 = new CellOffset(-2, 0);
            wireUtilityNetworkLink.link2 = new CellOffset(2, 0);
            return wireUtilityNetworkLink;
        }
        public const string ID = "A9GG1";
    }
}
