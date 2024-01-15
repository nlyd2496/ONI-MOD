using Database;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    public class A11GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A11GG1";
            int width = 4;
            int height = 3;
            string anim = "A11GG1_kanim";
            int hitpoints = 10;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
            string[] plastics = MATERIALS.PLASTICS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, plastics, melting_point, build_location_rule, BUILDINGS.DECOR.BONUS.TIER2, none, 0.2f);
            buildingDef.Overheatable = false;
            buildingDef.AudioCategory = "Metal";
            // 如果控制台的实例的a1属性为真，执行以下代码
            if (控制台.Instance.喵喵床)
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
            go.AddOrGet<LoopingSounds>();
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.BedType, false);
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.LuxuryBedType, false);
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.GetComponent<KAnimControllerBase>().initialAnim = "off";
            Bed bed = go.AddOrGet<Bed>();
            bed.effects = new string[]
            {
            "LuxuryBedStamina",
            "BedHealth"
            };
            bed.workLayer = Grid.SceneLayer.BuildingFront;
            Sleepable sleepable = go.AddOrGet<Sleepable>();
            sleepable.overrideAnims = new KAnimFile[]
            {
            Assets.GetAnim("anim_sleep_bed_kanim")
            };
            sleepable.workLayer = Grid.SceneLayer.BuildingFront;
            go.AddOrGet<Ownable>().slotID = Db.Get().AssignableSlots.Bed.Id;
            go.AddOrGetDef<RocketUsageRestriction.Def>();
        }
        public static string ID = "A11GG1";
    }
    [HarmonyPatch(typeof(BuildingFacades), MethodType.Constructor, new Type[] { typeof(ResourceSet) })]
    public static class 蓝图系统A11GG2
    {
        public static void Postfix(BuildingFacades __instance)
        {
            __instance.Add("A11GG2",
                STRINGS.BUILDINGS.PREFABS.A11GG2.NAME, STRINGS.BUILDINGS.PREFABS.A11GG2.EFFECT, PermitRarity.Universal,
                "A11GG1", "A11GG2_kanim", null);
        }
    }
}
