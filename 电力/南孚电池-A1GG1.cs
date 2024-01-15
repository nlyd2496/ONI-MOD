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
    public class A1GG1 : BaseBatteryConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A1GG1";
            int width = 1;
            int height = 2;
            int hitpoints = 30;
            string anim = "A1GG1_kanim";
            float construction_time = 30f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
            string[] all_METALS = MATERIALS.ALL_METALS;
            float melting_point = 800f;
            float exhaust_temperature_active = 0.25f;
            float self_heat_kilowatts_active = 1f;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = base.CreateBuildingDef(id, width, height, hitpoints, anim, construction_time, tier, all_METALS, melting_point, exhaust_temperature_active, self_heat_kilowatts_active, BUILDINGS.DECOR.BONUS.TIER1, none);
            buildingDef.Breakable = true;
            SoundEventVolumeCache.instance.AddVolume("batterysm_kanim", "Battery_rattle", NOISE_POLLUTION.NOISY.TIER1);
            // 如果控制台的实例的a1属性为真，执行以下代码
            if (控制台.Instance.南孚电池)
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
            battery.capacity = SingletonOptions<控制台>.Instance.南孚电池容量;//容量
            battery.joulesLostPerSecond = SingletonOptions<控制台>.Instance.南孚电池损耗;//损耗
            base.DoPostConfigureComplete(go);
        }
        public const string ID = "A1GG1";
    }
}
