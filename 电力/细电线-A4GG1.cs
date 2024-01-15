using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.电力
{
    public class A4GG1 : BaseWireConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A4GG1";
            int width = 1;
            int height = 1;
            string anim = "A4GG1_kanim";
            int hitpoints = 10;
            float construction_time = 3f;
            float[] construction_mass = new float[]
            {
                10f,
                10f
            };
            string[] construction_materials = new string[]
            {
                "RefinedMetal",
                "Plastic"
            };
            float melting_point = 600f;
            BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, construction_mass, construction_materials, melting_point, build_location_rule, new EffectorValues
            {
                amount = 1,
                radius = 1
            }, none, 0.2f);
            buildingDef.Overheatable = false;
            buildingDef.Entombable = false;
            buildingDef.Floodable = false;
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.ObjectLayer = ObjectLayer.Wire;
            buildingDef.TileLayer = ObjectLayer.WireTile;
            buildingDef.ReplacementLayer = ObjectLayer.ReplacementWire;
            buildingDef.AudioCategory = "Metal";
            buildingDef.AudioSize = "small";
            buildingDef.BaseTimeUntilRepair = -1f;
            buildingDef.SceneLayer = Grid.SceneLayer.Wires;
            buildingDef.isKAnimTile = true;
            buildingDef.isUtility = true;
            buildingDef.DragBuild = true;
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.WireIDs, id);
            // 如果控制台的实例的a1属性为真，执行以下代码
            if (控制台.Instance.细电线)
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
        public override void DoPostConfigureComplete(GameObject go)
        {
            base.DoPostConfigureComplete(Wire.WattageRating.Max1000, go);
        }
        public const string ID = "A4GG1";
    }
}
