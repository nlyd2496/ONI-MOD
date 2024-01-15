using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.电力
{
    public class A2GG1 : BaseBatteryConfig
    {
        public override string[] GetDlcIds()
        {
            return DlcManager.AVAILABLE_EXPANSION1_ONLY;
        }
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A2GG1";
            int width = 3;
            int height = 2;
            string anim = "rocket_battery_pack_kanim";
            int hitpoints = 100;
            float construction_time = 30f;
            float[] hollow_TIER = BUILDINGS.ROCKETRY_MASS_KG.HOLLOW_TIER2;
            string[] raw_METALS = MATERIALS.RAW_METALS;
            float melting_point = 800f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloorOrBuildingAttachPoint;
            EffectorValues tier = NOISE_POLLUTION.NOISY.TIER2;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim,
                hitpoints, construction_time, hollow_TIER, raw_METALS, melting_point, build_location_rule,
                new EffectorValues
                {
                    amount = 3,
                    radius = 3
                }, none, 0.2f);
            buildingDef.DefaultAnimState = "grounded";
            buildingDef.attachablePosition = new CellOffset(0, 0);
            buildingDef.OverheatTemperature = 573.15f;
            buildingDef.Floodable = false;
            buildingDef.ObjectLayer = ObjectLayer.Building;
            buildingDef.RequiresPowerOutput = true;
            buildingDef.UseWhitePowerOutputConnectorColour = true;
            buildingDef.AttachmentSlotTag = "A2GG1";
            // 如果控制台的实例的a1属性为真，执行以下代码
            if (控制台.Instance.民用电池组)
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
            Battery battery = go.AddOrGet<Battery>();
            battery.capacity = SingletonOptions<控制台>.Instance.民用电池组容量;//容量
            battery.joulesLostPerSecond = SingletonOptions<控制台>.Instance.民用电池组损耗;//损耗
            base.DoPostConfigureComplete(go);
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<BuildingAttachPoint>().points = new BuildingAttachPoint.HardPoint[]
            {
            new BuildingAttachPoint.HardPoint(new CellOffset(0, 2), "A2GG1", null)
            };
        }
        public const string ID = "A2GG1";
    }
}
