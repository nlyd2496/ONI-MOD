using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.A_基地
{
    public class A008GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A008GG1";
            int width = 1;
            int height = 1;
            string anim = "A008GG1_kanim";
            int hitpoints = 30;
            float construction_time = 10f;
            float[] tier = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time,
                tier, any_BUILDABLE, melting_point, build_location_rule, TUNING.BUILDINGS.DECOR.NONE, none, 1f);
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.Entombable = false;
            buildingDef.AudioCategory = "Metal";
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            buildingDef.ViewMode = OverlayModes.Logic.ID;
            buildingDef.AlwaysOperational = true;
            //--------------------------
            if (控制台.Instance.A008GG1) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }      
        public override void DoPostConfigureComplete(GameObject go)
        {

            go.GetComponent<KPrefabID>().AddTag(GameTags.OverlayInFrontOfConduits, false);
            go.AddOrGet<FakeFloorAdder>().floorOffsets = new CellOffset[]
            {
                new CellOffset(0, -1)
            };
        }
    }
}
