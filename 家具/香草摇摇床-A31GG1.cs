using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    public class A31GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A31GG1";
            int width = 2;
            int height = 2;
            string anim = "A31GG1_kanim";
            int hitpoints = 10;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, any_BUILDABLE, melting_point, build_location_rule, BUILDINGS.DECOR.BONUS.TIER2, none, 0.2f);
            buildingDef.Overheatable = false;
            buildingDef.AudioCategory = "Metal";
            buildingDef.AudioCategory = "Metal";
            //--------------------------
            if (控制台.Instance.香草摇摇床) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<LoopingSounds>();
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.BedType, false);// 为游戏对象go的KPrefabID组件添加床类型的标签，表示它是一种床
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.LuxuryBedType, false);// 为游戏对象go的KPrefabID组件添加豪华床类型的标签，表示它是一种豪华床
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
        public const string ID = "A31GG1";
    }
}
