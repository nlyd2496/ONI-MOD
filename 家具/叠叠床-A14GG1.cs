﻿using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    public class A14GG1 : IBuildingConfig
    {
        //-------------------------------------------------------------------------------------------------------
        public override string[] GetDlcIds()
        {
            return DlcManager.AVAILABLE_EXPANSION1_ONLY;
        }
        //-------------------------------------------------------------------------------------------------------
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A14GG1";
            int width = 2;
            int height = 1;
            string anim = "ladder_bed_kanim";
            int hitpoints = 10;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
            string[] refined_METALS = MATERIALS.REFINED_METALS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloorOrBuildingAttachPoint;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, refined_METALS, melting_point, build_location_rule, BUILDINGS.DECOR.NONE, none, 0.2f);
            buildingDef.Overheatable = false;
            buildingDef.AudioCategory = "Metal";
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            buildingDef.attachablePosition = new CellOffset(0, 0);
            buildingDef.AttachmentSlotTag = "A14GG1G1";
            buildingDef.ObjectLayer = ObjectLayer.Building;
            // 如果控制台的实例的a1属性为真，执行以下代码
            if (控制台.Instance.叠叠床)
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
        //-------------------------------------------------------------------------------------------------------
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<LoopingSounds>();
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.BedType, false);
            go.AddOrGet<BuildingAttachPoint>().points = new BuildingAttachPoint.HardPoint[]
            {
            new BuildingAttachPoint.HardPoint(new CellOffset(0, 1), "A14GG1G1", null)
            };
            go.AddOrGet<AnimTileable>();
        }
        //-------------------------------------------------------------------------------------------------------
        public override void DoPostConfigureComplete(GameObject go)
        {
            CellOffset[] offsets = new CellOffset[]
            {
            new CellOffset(0, 0),
            new CellOffset(0, 1)
            };
            Ladder ladder = go.AddOrGet<Ladder>();
            ladder.upwardsMovementSpeedMultiplier = SingletonOptions<控制台>.Instance.上叠叠床的速度;
            ladder.downwardsMovementSpeedMultiplier = SingletonOptions<控制台>.Instance.下叠叠床的速度;
            ladder.offsets = offsets;
            go.AddOrGetDef<LadderBed.Def>().offsets = offsets;
            go.GetComponent<KAnimControllerBase>().initialAnim = "off";
            Bed bed = go.AddOrGet<Bed>();
            bed.effects = new string[]
            {
            "LadderBedStamina",
            "BedHealth"
            };
            bed.workLayer = Grid.SceneLayer.BuildingFront;
            Sleepable sleepable = go.AddOrGet<Sleepable>();
            sleepable.overrideAnims = new KAnimFile[]
            {
            Assets.GetAnim("anim_interacts_ladder_bed_kanim")
            };
            sleepable.workLayer = Grid.SceneLayer.BuildingFront;
            go.AddOrGet<Ownable>().slotID = Db.Get().AssignableSlots.Bed.Id;
            go.AddOrGetDef<RocketUsageRestriction.Def>();
        }
        //-------------------------------------------------------------------------------------------------------
        public static string ID = "A14GG1";
        //-------------------------------------------------------------------------------------------------------
    }
}
