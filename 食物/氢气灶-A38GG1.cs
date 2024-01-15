using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.食物
{
    public class A38GG1 : IBuildingConfig
    {
        public override string[] GetDlcIds()
        {
            return DlcManager.AVAILABLE_EXPANSION1_ONLY;
        }
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A38GG1";
            int width = 3;
            int height = 3;
            string anim = "A38GG1_kanim";
            int hitpoints = 30;
            float construction_time = 30f;
            float[] tier = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
            string[] all_METALS = MATERIALS.ALL_METALS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues tier2 = NOISE_POLLUTION.NOISY.TIER3;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, all_METALS, melting_point, build_location_rule, TUNING.BUILDINGS.DECOR.NONE, tier2, 0.2f);
            BuildingTemplates.CreateElectricalBuildingDef(buildingDef);
            buildingDef.AudioCategory = "Metal";
            buildingDef.AudioSize = "large";
            buildingDef.RequiresPowerInput = true;

            buildingDef.EnergyConsumptionWhenActive = 240f;
            buildingDef.ExhaustKilowattsWhenActive = 1f;
            buildingDef.SelfHeatKilowattsWhenActive = 8f;
            buildingDef.InputConduitType = ConduitType.Gas;
            buildingDef.UtilityInputOffset = new CellOffset(0, 0);
            buildingDef.PowerInputOffset = new CellOffset(0, 0);
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
            //--------------------------
            if (控制台.Instance.氢气灶) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<DropAllWorkable>();
            go.AddOrGet<BuildingComplete>().isManuallyOperated = false;
            GourmetCookingStation gourmetCookingStation1 = go.AddOrGet<GourmetCookingStation>();
            gourmetCookingStation1.heatedTemperature = 368.15f;//食品加热温度
            gourmetCookingStation1.duplicantOperated = false;//小白鼠操作
            gourmetCookingStation1.sideScreenStyle = ComplexFabricatorSideScreen.StyleSetting.ListQueueHybrid;
            go.AddOrGet<FabricatorIngredientStatusManager>();
            go.AddOrGet<CopyBuildingSettings>();
            go.AddOrGet<ComplexFabricatorWorkable>();
            BuildingTemplates.CreateComplexFabricatorStorage(go, gourmetCookingStation1);
            gourmetCookingStation1.fuelTag = this.FUEL_TAG;
            gourmetCookingStation1.outStorage.capacityKg = 10f;
            gourmetCookingStation1.inStorage.SetDefaultStoredItemModifiers(A38GG1.GourmetCookingStationStoredItemModifiers);
            gourmetCookingStation1.buildStorage.SetDefaultStoredItemModifiers(A38GG1.GourmetCookingStationStoredItemModifiers);
            gourmetCookingStation1.outStorage.SetDefaultStoredItemModifiers(A38GG1.GourmetCookingStationStoredItemModifiers);
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.capacityTag = this.FUEL_TAG;
            conduitConsumer.capacityKG = 10f;
            conduitConsumer.alwaysConsume = true;
            conduitConsumer.storage = gourmetCookingStation1.inStorage;
            conduitConsumer.forceAlwaysSatisfied = true;
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
            new ElementConverter.ConsumedElement(this.FUEL_TAG, 0.1f,true)
            };
            this.ConfigureRecipes();
            Prioritizable.AddRef(go);
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.CookTop, false);
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveStoppableController.Def>();
            go.GetComponent<KPrefabID>().prefabSpawnFn += delegate (GameObject game_object)
            {
                ComplexFabricatorWorkable component = game_object.GetComponent<ComplexFabricatorWorkable>();
                component.AttributeConverter = Db.Get().AttributeConverters.CookingSpeed;
                component.AttributeExperienceMultiplier = DUPLICANTSTATS.ATTRIBUTE_LEVELING.PART_DAY_EXPERIENCE;
                component.SkillExperienceSkillGroup = Db.Get().SkillGroups.Cooking.Id;
                component.SkillExperienceMultiplier = SKILLS.PART_DAY_EXPERIENCE;
            };
        }
        private void ConfigureRecipes()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
            new ComplexRecipe.RecipeElement("GrilledPrickleFruit", 2f),
            new ComplexRecipe.RecipeElement(SpiceNutConfig.ID, 2f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
            new ComplexRecipe.RecipeElement("Salsa", 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false)
            };
            SalsaConfig.recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation1", array, array2), array, array2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = ITEMS.FOOD.SALSA.RECIPEDESC,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>
            {
                "GourmetCookingStation1"
            },
                sortOrder = 300
            };
            ComplexRecipe.RecipeElement[] array3 = new ComplexRecipe.RecipeElement[]
            {
            new ComplexRecipe.RecipeElement("FriedMushroom", 1f),
            new ComplexRecipe.RecipeElement("Lettuce", 4f)
            };
            ComplexRecipe.RecipeElement[] array4 = new ComplexRecipe.RecipeElement[]
            {
            new ComplexRecipe.RecipeElement("MushroomWrap", 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false)
            };
            MushroomWrapConfig.recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation1", array3, array4), array3, array4)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = ITEMS.FOOD.MUSHROOMWRAP.RECIPEDESC,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>
            {
                "GourmetCookingStation1"
            },
                sortOrder = 400
            };
            ComplexRecipe.RecipeElement[] array5 = new ComplexRecipe.RecipeElement[]
            {
            new ComplexRecipe.RecipeElement("CookedMeat", 1f),
            new ComplexRecipe.RecipeElement("CookedFish", 1f)
            };
            ComplexRecipe.RecipeElement[] array6 = new ComplexRecipe.RecipeElement[]
            {
            new ComplexRecipe.RecipeElement("SurfAndTurf", 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false)
            };
            SurfAndTurfConfig.recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation1", array5, array6), array5, array6)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = ITEMS.FOOD.SURFANDTURF.RECIPEDESC,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>
            {
                "GourmetCookingStation1"
            },
                sortOrder = 500
            };
            ComplexRecipe.RecipeElement[] array7 = new ComplexRecipe.RecipeElement[]
            {
            new ComplexRecipe.RecipeElement("ColdWheatSeed", 10f),
            new ComplexRecipe.RecipeElement(SpiceNutConfig.ID, 1f)
            };
            ComplexRecipe.RecipeElement[] array8 = new ComplexRecipe.RecipeElement[]
            {
            new ComplexRecipe.RecipeElement("SpiceBread", 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false)
            };
            SpiceBreadConfig.recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation1", array7, array8), array7, array8)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = ITEMS.FOOD.SPICEBREAD.RECIPEDESC,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>
            {
                "GourmetCookingStation1"
            },
                sortOrder = 600
            };
            ComplexRecipe.RecipeElement[] array9 = new ComplexRecipe.RecipeElement[]
            {
            new ComplexRecipe.RecipeElement("Tofu", 1f),
            new ComplexRecipe.RecipeElement(SpiceNutConfig.ID, 1f)
            };
            ComplexRecipe.RecipeElement[] array10 = new ComplexRecipe.RecipeElement[]
            {
            new ComplexRecipe.RecipeElement("SpicyTofu", 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false)
            };
            SpicyTofuConfig.recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation1", array9, array10), array9, array10)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = ITEMS.FOOD.SPICYTOFU.RECIPEDESC,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>
            {
                "GourmetCookingStation1"
            },
                sortOrder = 800
            };
            ComplexRecipe.RecipeElement[] array11 = new ComplexRecipe.RecipeElement[]
            {
            new ComplexRecipe.RecipeElement(GingerConfig.ID, 4f),
            new ComplexRecipe.RecipeElement("BeanPlantSeed", 4f)
            };
            ComplexRecipe.RecipeElement[] array12 = new ComplexRecipe.RecipeElement[]
            {
            new ComplexRecipe.RecipeElement("Curry", 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false)
            };
            SpicyTofuConfig.recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation1", array11, array12), array11, array12)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = ITEMS.FOOD.CURRY.RECIPEDESC,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>
            {
                "GourmetCookingStation1"
            },
                sortOrder = 800
            };
            ComplexRecipe.RecipeElement[] array13 = new ComplexRecipe.RecipeElement[]
            {
            new ComplexRecipe.RecipeElement("ColdWheatBread", 1f),
            new ComplexRecipe.RecipeElement("Lettuce", 1f),
            new ComplexRecipe.RecipeElement("CookedMeat", 1f)
            };
            ComplexRecipe.RecipeElement[] array14 = new ComplexRecipe.RecipeElement[]
            {
            new ComplexRecipe.RecipeElement("Burger", 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false)
            };
            BurgerConfig.recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation1", array13, array14), array13, array14)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = ITEMS.FOOD.BURGER.RECIPEDESC,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>
            {
                "GourmetCookingStation1"
            },
                sortOrder = 900
            };
            if (DlcManager.IsExpansion1Active())
            {
                ComplexRecipe.RecipeElement[] array15 = new ComplexRecipe.RecipeElement[]
                {
                new ComplexRecipe.RecipeElement("ColdWheatSeed", 3f),
                new ComplexRecipe.RecipeElement("WormSuperFruit", 4f),
                new ComplexRecipe.RecipeElement("GrilledPrickleFruit", 1f)
                };
                ComplexRecipe.RecipeElement[] array16 = new ComplexRecipe.RecipeElement[]
                {
                new ComplexRecipe.RecipeElement("BerryPie", 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false)
                };
                BerryPieConfig.recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation1", array15, array16), array15, array16)
                {
                    time = FOOD.RECIPES.STANDARD_COOK_TIME,
                    description = ITEMS.FOOD.BERRYPIE.RECIPEDESC,
                    nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                    fabricators = new List<Tag>
                {
                    "GourmetCookingStation1"
                },
                    sortOrder = 900
                };
            }
        }
        public const string ID = "A38GG1";
        private const float FUEL_STORE_CAPACITY = 10f;
        private Tag FUEL_TAG = new Tag("Hydrogen");
        private static readonly List<Storage.StoredItemModifier> GourmetCookingStationStoredItemModifiers = new List<Storage.StoredItemModifier>
        {
        Storage.StoredItemModifier.Hide,
        Storage.StoredItemModifier.Preserve,
        Storage.StoredItemModifier.Insulate,
        Storage.StoredItemModifier.Seal
        };
    }
}
