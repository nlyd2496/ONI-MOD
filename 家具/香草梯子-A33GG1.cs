using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    public class A33GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A33GG1";
            int width = 1;
            int height = 1;
            string anim = "A33GG1_kanim";
            int hitpoints = 10;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, any_BUILDABLE, melting_point, build_location_rule, BUILDINGS.DECOR.BONUS.TIER2, none, 0.2f);
            BuildingTemplates.CreateLadderDef(buildingDef);
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.Entombable = false;
            buildingDef.AudioCategory = "Metal";
            buildingDef.AudioSize = "small";
            buildingDef.BaseTimeUntilRepair = -1f;
            buildingDef.DragBuild = true;
            //--------------------------
            if (控制台.Instance.香草梯子) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            GeneratedBuildings.MakeBuildingAlwaysOperational(go);
            Ladder ladder = go.AddOrGet<Ladder>();
            ladder.upwardsMovementSpeedMultiplier = SingletonOptions<控制台>.Instance.爬香草梯子的速度;
            ladder.downwardsMovementSpeedMultiplier = SingletonOptions<控制台>.Instance.爬香草梯子的速度;
            go.AddOrGet<AnimTileable>();
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
        }
        public const string ID = "A33GG1";
    }
}
