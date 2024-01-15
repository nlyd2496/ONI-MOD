using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    public class A79GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A79GG1";
            int width = 2;
            int height = 1;
            string anim = "A79GG1_kanim";
            int hitpoints = 30;
            float construction_time = 3f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER1;
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 3200f;
            BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, any_BUILDABLE, melting_point, build_location_rule, new EffectorValues
            {
                amount = 13,
                radius = 13
            }, none, 0.2f);
            buildingDef.Entombable = false;
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.ThermalConductivity = 2f;
            buildingDef.PermittedRotations = PermittedRotations.R360;
            //--------------------------
            if (控制台.Instance.恭喜faker拿下第四个S赛冠军) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration, false);
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
        }
        public const string ID = "A79GG1";
    }
}
