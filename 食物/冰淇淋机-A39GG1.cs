using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.食物
{
    public class A39GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string text = "A39GG1";
            int num = 2;
            int num2 = 2;
            string text2 = "A39GG1_kanim";
            int num3 = 30;
            float num4 = 30f;
            float[] tier = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
            string[] all_METALS = MATERIALS.ALL_METALS;
            float num5 = 800f;
            BuildLocationRule buildLocationRule = BuildLocationRule.OnFloor;
            EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER3;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(text, num, num2, text2, num3, num4, tier, all_METALS, num5, buildLocationRule, BUILDINGS.DECOR.BONUS.TIER1, tier2, 0.2f);
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = 80f;
            buildingDef.ExhaustKilowattsWhenActive = 0.5f;
            buildingDef.SelfHeatKilowattsWhenActive = 0f;
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.AudioCategory = "Glass";
            buildingDef.AudioSize = "large";
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<DropAllWorkable>();
            Prioritizable.AddRef(go);
            go.AddOrGet<BuildingComplete>().isManuallyOperated = true;
            go.AddOrGet<ConduitConsumer>().conduitType = ConduitType.Liquid;
            MicrobeMusher microbeMusher = go.AddOrGet<MicrobeMusher>();
            microbeMusher.mushbarSpawnOffset = new Vector3(1f, 0f, 0f);
            go.AddOrGet<FabricatorIngredientStatusManager>();
            go.AddOrGet<CopyBuildingSettings>();
            go.AddOrGet<ComplexFabricatorWorkable>().overrideAnims = new KAnimFile[]
            {
            Assets.GetAnim("anim_interacts_musher_kanim")
            };
            microbeMusher.sideScreenStyle = ComplexFabricatorSideScreen.StyleSetting.ListQueueHybrid;
            BuildingTemplates.CreateComplexFabricatorStorage(go, microbeMusher);
            this.ConfigureRecipes();
            go.AddOrGetDef<PoweredController.Def>();
        }
        private void ConfigureRecipes()
        {
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
        }
        public const string ID = "A39GG1";
    }
}
