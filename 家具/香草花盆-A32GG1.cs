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
    public class A32GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A32GG1";
            int width = 1;
            int height = 1;
            string anim = "A32GG1_kanim";
            int hitpoints = 10;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER1;
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 800f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, any_BUILDABLE, melting_point, build_location_rule, BUILDINGS.DECOR.BONUS.TIER2, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.ViewMode = OverlayModes.Decor.ID;
            buildingDef.AudioCategory = "Glass";
            buildingDef.AudioSize = "large";
            //--------------------------
            if (控制台.Instance.香草花盆) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<Storage>();
            Prioritizable.AddRef(go);
            go.AddOrGet<PlantablePlot>().AddDepositTag(GameTags.DecorSeed);
            go.AddOrGet<FlowerVase>();
            go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration, false);
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
        }
        public const string ID = "A32GG1";
    }
    [HarmonyPatch(typeof(BuildingFacades), MethodType.Constructor, new Type[] { typeof(ResourceSet) })]
    public static class 蓝图系统A32GG2
    {
        public static void Postfix(BuildingFacades __instance)
        {
            __instance.Add("A32GG2",
                STRINGS.BUILDINGS.PREFABS.A32GG2.NAME, STRINGS.BUILDINGS.PREFABS.A32GG2.EFFECT, PermitRarity.Universal,
                "A32GG1", "A32GG2_kanim", null);
            __instance.Add("A32GG3",
                STRINGS.BUILDINGS.PREFABS.A32GG3.NAME, STRINGS.BUILDINGS.PREFABS.A32GG3.EFFECT, PermitRarity.Universal,
                "A32GG1", "A32GG3_kanim", null);
            __instance.Add("A32GG4",
                STRINGS.BUILDINGS.PREFABS.A32GG4.NAME, STRINGS.BUILDINGS.PREFABS.A32GG4.EFFECT, PermitRarity.Universal,
                "A32GG1", "A32GG4_kanim", null);
        }
    }
}
