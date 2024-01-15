using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;
using static CaiLib.Utils.CarePackagesUtils;
using static CaiLib.Utils.PlantUtils;
using static CaiLib.Utils.RecipeUtils;
using static CaiLib.Utils.StringUtils;

namespace 吐泡泡的小鱼的缺氧模组.食物
{
    public class B0GG0 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "B0GG0";
            int width = 3;
            int height = 3;
            string anim = "B0GG0_kanim";
            int hitpoints = 1000;
            float construction_time = 60f;
            float[] construction_mass = new float[] { 200f };
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 9999f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues tier = NOISE_POLLUTION.NOISY.TIER2;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, construction_mass, any_BUILDABLE, melting_point, build_location_rule, new EffectorValues
            {
                amount = 2,
                radius = 2
            }, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = 100f;
            buildingDef.ExhaustKilowattsWhenActive = 0.1f;
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
            return buildingDef;
        }
        private void ConfigureRecipes()
        {

            //------------------------------------------------------------辣椒------------------------------------------------------------
            AddComplexRecipe(
                input:  new[] { new ComplexRecipe.RecipeElement(BasicPlantFoodConfig.ID.ToTag(), 3f) },//米風木
                output: new[] { new ComplexRecipe.RecipeElement(TagManager.Create("B1GG1"), 1f) },
                fabricatorId: "B0GG0",//配方制造器ID
                productionTime: 50f,//制作时间（s）
                recipeDescription: STRINGS.CREATURES.SPECIES.B1GG1.B8,//配方描述
                nameDisplayType: ComplexRecipe.RecipeNameDisplay.Result,//配方显示类型
                sortOrder: 1//配方排序顺序
            );

        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
            go.AddOrGet<DropAllWorkable>();
            go.AddOrGet<BuildingComplete>().isManuallyOperated = false;
            ComplexFabricator complexFabricator = go.AddOrGet<ComplexFabricator>();
            complexFabricator.heatedTemperature = 353.15f;
            complexFabricator.duplicantOperated = false;
            complexFabricator.showProgressBar = true;
            complexFabricator.sideScreenStyle = ComplexFabricatorSideScreen.StyleSetting.ListQueueHybrid;
            go.AddOrGet<FabricatorIngredientStatusManager>();
            go.AddOrGet<CopyBuildingSettings>();
            BuildingTemplates.CreateComplexFabricatorStorage(go, complexFabricator);
            this.ConfigureRecipes();
            Prioritizable.AddRef(go);
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
            SymbolOverrideControllerUtil.AddToPrefab(go);
        }
    }
}
