using HarmonyLib;
using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TUNING;
//--------------------------------------------------无需更改--------------------------------------------------
namespace CaiLib.Utils
{
    public static class BuildingUtils
    {
        public static void AddBuildingToPlanScreen(HashedString category, string buildingId, string subCategory = "uncategorized", string addAfterBuildingId = null)
        {
            ModUtil.AddBuildingToPlanScreen(category, buildingId, subCategory, addAfterBuildingId, ModUtil.BuildingOrdering.After);
        }
        public static void AddBuildingToTechnology(string techId, string buildingId)
        {
            Db.Get().Techs.Get(techId).unlockedItemIDs.Add(buildingId);
        }
    }
    public class CarePackagesUtils
    {
        public static void AddCarePackage(ref Immigration immigration, string objectId, float amount, Func<bool> requirement = null)
        {
            Traverse traverse = Traverse.Create(immigration).Field("carePackages");
            List<CarePackageInfo> list = traverse.GetValue<CarePackageInfo[]>().ToList<CarePackageInfo>();
            list.Add(new CarePackageInfo(objectId, amount, requirement));
            traverse.SetValue(list.ToArray());
        }
        public static bool CycleCondition(int cycle)
        {
            return GameClock.Instance.GetCycle() >= cycle;
        }
        public static bool DiscoveredCondition(Tag tag)
        {
            return DiscoveredResources.Instance.IsDiscovered(tag);
        }
    }
    public class CritterDietUtils
    {
        public static void AddToDiet(List<Diet.Info> dietInfos, HashSet<Tag> consumedTags, Tag poopTag, float dailyCalories, float dailyKilograms, float conversionRate = 1f, string diseaseId = "", float diseasePerKg = 0f)
        {
            dietInfos.Add(string.IsNullOrEmpty(diseaseId) ? new Diet.Info(consumedTags, poopTag, dailyCalories / dailyKilograms, conversionRate, null, 0f, false, false) : new Diet.Info(consumedTags, poopTag, dailyCalories / dailyKilograms, conversionRate, diseaseId, diseasePerKg, false, false));
        }
        public static void AddToDiet(List<Diet.Info> dietInfos, Tag consumedTag, Tag poopTag, float dailyCalories, float dailyKilograms, float conversionRate = 1f, string diseaseId = "", float diseasePerKg = 0f)
        {
            CritterDietUtils.AddToDiet(dietInfos, new HashSet<Tag>(new Tag[]
            {
                consumedTag
            }), poopTag, dailyCalories, dailyKilograms, conversionRate, diseaseId, diseasePerKg);
        }
        public static void AddToDiet(List<Diet.Info> dietInfos, EdiblesManager.FoodInfo foodInfo, Tag poopTag, float dailyCalories, float howManyKgOfPoopForDailyCalories = 0f, string diseaseId = "", float diseasePerKg = 0f)
        {
            float caloriesPerUnit = foodInfo.CaloriesPerUnit;
            float num = dailyCalories / caloriesPerUnit;
            float produced_conversion_rate = 1f / (num / howManyKgOfPoopForDailyCalories);
            dietInfos.Add(string.IsNullOrEmpty(diseaseId) ? new Diet.Info(new HashSet<Tag>(new Tag[]
            {
                new Tag(foodInfo.Id)
            }), poopTag, caloriesPerUnit, produced_conversion_rate, null, 0f, false, false) : new Diet.Info(new HashSet<Tag>(new Tag[]
            {
                new Tag(foodInfo.Id)
            }), poopTag, caloriesPerUnit, produced_conversion_rate, diseaseId, diseasePerKg, false, false));
        }
        public static GameObject SetupPooplessDiet(GameObject prefab, List<Diet.Info> dietInfos)
        {
            Diet diet = new Diet(dietInfos.ToArray());
            prefab.AddOrGetDef<CreatureCalorieMonitor.Def>().diet = diet;
            prefab.AddOrGetDef<SolidConsumerMonitor.Def>().diet = diet;
            return prefab;
        }
        public static GameObject SetupDiet(GameObject prefab, List<Diet.Info> dietInfos, float referenceCaloriesPerKg, float minPoopSizeInKg)
        {
            Diet diet = new Diet(dietInfos.ToArray());
            CreatureCalorieMonitor.Def def = prefab.AddOrGetDef<CreatureCalorieMonitor.Def>();
            def.diet = diet;
            def.minPoopSizeInCalories = referenceCaloriesPerKg * minPoopSizeInKg;
            prefab.AddOrGetDef<SolidConsumerMonitor.Def>().diet = diet;
            return prefab;
        }
        public static List<Diet.Info> CreateFoodDiet(Tag poopTag, float calPerDay, float poopKgPerDay)
        {
            List<Diet.Info> list = new List<Diet.Info>();
            foreach (EdiblesManager.FoodInfo foodInfo in EdiblesManager.GetAllFoodTypes())
            {
                bool flag = (double)foodInfo.CaloriesPerUnit > 0.0;
                if (flag)
                {
                    CritterDietUtils.AddToDiet(list, foodInfo, poopTag, calPerDay, poopKgPerDay, "", 0f);
                }
            }
            return list;
        }
    }
    public static class GameStrings
    {
        public static class PlanMenuCategory
        {
            // Token: 0x04000029 RID: 41
            public const string Base = "Base";

            // Token: 0x0400002A RID: 42
            public const string Oxygen = "Oxygen";

            // Token: 0x0400002B RID: 43
            public const string Power = "Power";

            // Token: 0x0400002C RID: 44
            public const string Food = "Food";

            // Token: 0x0400002D RID: 45
            public const string Plumbing = "Plumbing";

            // Token: 0x0400002E RID: 46
            public const string Ventilation = "HVAC";

            // Token: 0x0400002F RID: 47
            public const string Refinement = "Refining";

            // Token: 0x04000030 RID: 48
            public const string Medicine = "Medical";

            // Token: 0x04000031 RID: 49
            public const string Furniture = "Furniture";

            // Token: 0x04000032 RID: 50
            public const string Stations = "Equipment";

            // Token: 0x04000033 RID: 51
            public const string Utilities = "Utilities";

            // Token: 0x04000034 RID: 52
            public const string Automation = "Automation";

            // Token: 0x04000035 RID: 53
            public const string Shipping = "Conveyance";

            // Token: 0x04000036 RID: 54
            public const string Rocketry = "Rocketry";
        }

        // Token: 0x0200001A RID: 26
        public static class Technology
        {
            // Token: 0x0200001E RID: 30
            public static class Food
            {
                // Token: 0x04000051 RID: 81
                public const string BasicFarming = "FarmingTech";

                // Token: 0x04000052 RID: 82
                public const string MealPreparation = "FineDining";

                // Token: 0x04000053 RID: 83
                public const string GourmetMealPreparation = "FinerDining";

                // Token: 0x04000054 RID: 84
                public const string FoodRepurposing = "FoodRepurposing";

                // Token: 0x04000055 RID: 85
                public const string Agriculture = "Agriculture";

                // Token: 0x04000056 RID: 86
                public const string Ranching = "Ranching";

                // Token: 0x04000057 RID: 87
                public const string AnimalControl = "AnimalControl";

                // Token: 0x04000058 RID: 88
                public const string GourmetMealPrep = "FinerDining";

                // Token: 0x04000059 RID: 89
                public const string Bioengineering = "Bioengineering";
            }

            // Token: 0x0200001F RID: 31
            public static class Power
            {
                // Token: 0x0400005A RID: 90
                public const string PowerRegulation = "PowerRegulation";

                // Token: 0x0400005B RID: 91
                public const string InternalCombustion = "Combustion";

                // Token: 0x0400005C RID: 92
                public const string FossilFuels = "ImprovedCombustion";

                // Token: 0x0400005D RID: 93
                public const string SoundAmplifiers = "Acoustics";

                // Token: 0x0400005E RID: 94
                public const string AdvancedPowerRegulation = "AdvancedPowerRegulation";

                // Token: 0x0400005F RID: 95
                public const string PlasticManufacturing = "Plastics";

                // Token: 0x04000060 RID: 96
                public const string LowResistanceConductors = "PrettyGoodConductors";

                // Token: 0x04000061 RID: 97
                public const string ValveMiniaturization = "ValveMiniaturization";

                // Token: 0x04000062 RID: 98
                public const string RenewableEnergy = "RenewableEnergy";

                // Token: 0x04000063 RID: 99
                public const string SpacePower = "SpacePower";

                // Token: 0x04000064 RID: 100
                public const string HydrocarbonPropulsion = "HydrocarbonPropulsion";

                // Token: 0x04000065 RID: 101
                public const string ImprovedHydrocarbonPropulsion = "BetterHydroCarbonPropulsion";

                // Token: 0x04000066 RID: 102
                public const string AdvancedCombustion = "SpaceCombustion";
            }

            // Token: 0x02000020 RID: 32
            public static class SolidMaterial
            {
                // Token: 0x04000067 RID: 103
                public const string BruteForceRefinement = "BasicRefinement";

                // Token: 0x04000068 RID: 104
                public const string RefinedRenovations = "RefinedObjects";

                // Token: 0x04000069 RID: 105
                public const string SmartStorage = "SmartStorage";

                // Token: 0x0400006A RID: 106
                public const string Smelting = "Smelting";

                // Token: 0x0400006B RID: 107
                public const string SolidTransport = "SolidTransport";

                // Token: 0x0400006C RID: 108
                public const string SuperheatedForging = "HighTempForging";

                // Token: 0x0400006D RID: 109
                public const string PressurizedForging = "HighPressureForging";

                // Token: 0x0400006E RID: 110
                public const string SolidSpaceTransport = "SolidSpace";

                // Token: 0x0400006F RID: 111
                public const string SolidManagement = "SolidManagement";

                // Token: 0x04000070 RID: 112
                public const string HighVelocityTransport = "HighVelocityTransport";

                // Token: 0x04000071 RID: 113
                public const string HighVelocityDestruction = "HighVelocityDestruction";
            }

            // Token: 0x02000021 RID: 33
            public static class ColonyDevelopment
            {
                // Token: 0x04000072 RID: 114
                public const string Employment = "Jobs";

                // Token: 0x04000073 RID: 115
                public const string AdvancedResearch = "AdvancedResearch";

                // Token: 0x04000074 RID: 116
                public const string RadiationRefinement = "NuclearRefinement";

                // Token: 0x04000075 RID: 117
                public const string CryoFuelPropulsion = "CryoFuelPropulsion";

                // Token: 0x04000076 RID: 118
                public const string SpaceProgram = "SpaceProgram";

                // Token: 0x04000077 RID: 119
                public const string CrashPlan = "CrashPlan";

                // Token: 0x04000078 RID: 120
                public const string DurableLifeSupport = "DurableLifeSupport";

                // Token: 0x04000079 RID: 121
                public const string AtomicResearch = "NuclearResearch";

                // Token: 0x0400007A RID: 122
                public const string RadboltPropulsion = "NuclearPropulsion";

                // Token: 0x0400007B RID: 123
                public const string NotificationSystems = "NotificationSystems";

                // Token: 0x0400007C RID: 124
                public const string ArtificialFriends = "ArtificialFriends";

                // Token: 0x0400007D RID: 125
                public const string RoboticTools = "RoboticTools";
            }

            // Token: 0x02000022 RID: 34
            public static class Medicine
            {
                // Token: 0x0400007E RID: 126
                public const string Pharmacology = "MedicineI";

                // Token: 0x0400007F RID: 127
                public const string MedicalEquipment = "MedicineII";

                // Token: 0x04000080 RID: 128
                public const string PathogenDiagnostics = "MedicineIII";

                // Token: 0x04000081 RID: 129
                public const string MicroTargetedMedicine = "MedicineIV";

                // Token: 0x04000082 RID: 130
                public const string RadiationProtection = "RadiationProtection";
            }

            // Token: 0x02000023 RID: 35
            public static class Liquids
            {
                // Token: 0x04000083 RID: 131
                public const string Plumbing = "LiquidPiping";

                // Token: 0x04000084 RID: 132
                public const string AirSystems = "ImprovedOxygen";

                // Token: 0x04000085 RID: 133
                public const string Sanitation = "SanitationSciences";

                // Token: 0x04000086 RID: 134
                public const string AdvancedSanitation = "AdvancedSanitation";

                // Token: 0x04000087 RID: 135
                public const string Filtration = "AdvancedFiltration";

                // Token: 0x04000088 RID: 136
                public const string LiquidBasedRefinementProcess = "LiquidFiltering";

                // Token: 0x04000089 RID: 137
                public const string Distillation = "Distillation";

                // Token: 0x0400008A RID: 138
                public const string ImprovedPlumbing = "ImprovedLiquidPiping";

                // Token: 0x0400008B RID: 139
                public const string LiquidTuning = "LiquidTemperature";

                // Token: 0x0400008C RID: 140
                public const string AdvancedCaffeination = "PrecisionPlumbing";

                // Token: 0x0400008D RID: 141
                public const string FlowRedirection = "FlowRedirection";

                // Token: 0x0400008E RID: 142
                public const string LiquidDistribution = "LiquidDistribution";

                // Token: 0x0400008F RID: 143
                public const string Jetpacks = "Jetpacks";
            }

            // Token: 0x02000024 RID: 36
            public static class Gases
            {
                // Token: 0x04000090 RID: 144
                public const string Ventilation = "GasPiping";

                // Token: 0x04000091 RID: 145
                public const string PressureManagement = "PressureManagement";

                // Token: 0x04000092 RID: 146
                public const string TemperatureModulation = "TemperatureModulation";

                // Token: 0x04000093 RID: 147
                public const string Decontamination = "DirectedAirStreams";

                // Token: 0x04000094 RID: 148
                public const string ImprovedVentilation = "ImprovedGasPiping";

                // Token: 0x04000095 RID: 149
                public const string HVAC = "HVAC";

                // Token: 0x04000096 RID: 150
                public const string Catalytics = "Catalytics";

                // Token: 0x04000097 RID: 151
                public const string PortableGasses = "PortableGasses";

                // Token: 0x04000098 RID: 152
                public const string AdvancedGasFlow = "SpaceGas";

                // Token: 0x04000099 RID: 153
                public const string GasDistribution = "GasDistribution";
            }

            // Token: 0x02000025 RID: 37
            public static class Exosuits
            {
                // Token: 0x0400009A RID: 154
                public const string HazardProtection = "Suits";

                // Token: 0x0400009B RID: 155
                public const string TransitTubes = "TravelTubes";
            }

            // Token: 0x02000026 RID: 38
            public static class Decor
            {
                // Token: 0x0400009C RID: 156
                public const string InteriorDecor = "InteriorDecor";

                // Token: 0x0400009D RID: 157
                public const string ArtisticExpression = "Artistry";

                // Token: 0x0400009E RID: 158
                public const string TextileProduction = "Clothing";

                // Token: 0x0400009F RID: 159
                public const string FineArt = "FineArt";

                // Token: 0x040000A0 RID: 160
                public const string HomeLuxuries = "Luxury";

                // Token: 0x040000A1 RID: 161
                public const string HighCulture = "RefractiveDecor";

                // Token: 0x040000A2 RID: 162
                public const string GlassBlowing = "GlassFurnishings";

                // Token: 0x040000A3 RID: 163
                public const string RenaissanceArt = "RenaissanceArt";

                // Token: 0x040000A4 RID: 164
                public const string EnvironmentalAppreciation = "EnvironmentalAppreciation";

                // Token: 0x040000A5 RID: 165
                public const string NewMedia = "Screens";

                // Token: 0x040000A6 RID: 166
                public const string Monuments = "Monuments";
            }
            public static class Computers
            {
                public const string SmartHome = "LogicControl";
                public const string GenericSensors = "GenericSensors";
                public const string AdvancedAutomation = "LogicCircuits";
                public const string Computing = "DupeTrafficControl";
                public const string ParallelAutomation = "ParallelAutomation";
                public const string Multiplexing = "Multiplexing";
                public const string SensitiveMicroimaging = "AdvancedScanners";
            }
            public static class Rocketry
            {
                public const string CelestialDetection = "SkyDetectors";
                public const string IntroductoryRocketry = "BasicRocketry";
                public const string SolidFuelCombustion = "EnginesI";
                public const string SolidCargo = "CargoI";
                public const string HydrocarbonCombustion = "EnginesII";
                public const string LiquidAndGasCargo = "CargoII";
                public const string CryofuelCombustion = "EnginesIII";
                public const string UniqueCargo = "CargoIII";
            }
        }
    }
    public class PlantUtils
    {
        public static void AddCropType(string cropId, float domesticatedGrowthTimeInCycles, int producedPerHarvest)
        {
            CROPS.CROP_TYPES.Add(new Crop.CropVal(cropId, domesticatedGrowthTimeInCycles * 600f, producedPerHarvest, true));
        }
    }
    public class RecipeUtils
    {
        public static ComplexRecipe AddComplexRecipe(ComplexRecipe.RecipeElement[] input, ComplexRecipe.RecipeElement[] output, string fabricatorId, float productionTime, string recipeDescription, ComplexRecipe.RecipeNameDisplay nameDisplayType, int sortOrder, string requiredTech = null)
        {
            return new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(fabricatorId, input, output), input, output)
            {
                time = productionTime,
                description = recipeDescription,
                nameDisplay = nameDisplayType,
                fabricators = new List<Tag>
                {
                    fabricatorId
                },
                sortOrder = sortOrder,
                requiredTech = requiredTech
            };
        }
    }
    public static class StringUtils
    {
        public static void AddBuildingStrings(string buildingId, string name, string description, string effect)
        {
            Strings.Add(new string[]
            {
                "STRINGS.BUILDINGS.PREFABS." + buildingId.ToUpperInvariant() + ".NAME",
                UI.FormatAsLink(name, buildingId)
            });
            Strings.Add(new string[]
            {
                "STRINGS.BUILDINGS.PREFABS." + buildingId.ToUpperInvariant() + ".DESC",
                description
            });
            Strings.Add(new string[]
            {
                "STRINGS.BUILDINGS.PREFABS." + buildingId.ToUpperInvariant() + ".EFFECT",
                effect
            });
        }
        public static void AddPlantStrings(string plantId, string name, string description, string domesticatedDescription)
        {
            Strings.Add(new string[]
            {
                "STRINGS.CREATURES.SPECIES." + plantId.ToUpperInvariant() + ".NAME",
                UI.FormatAsLink(name, plantId)
            });
            Strings.Add(new string[]
            {
                "STRINGS.CREATURES.SPECIES." + plantId.ToUpperInvariant() + ".DESC",
                description
            });
            Strings.Add(new string[]
            {
                "STRINGS.CREATURES.SPECIES." + plantId.ToUpperInvariant() + ".DOMESTICATEDDESC",
                domesticatedDescription
            });
        }
        public static void AddPlantSeedStrings(string plantId, string name, string description)
        {
            Strings.Add(new string[]
            {
                "STRINGS.CREATURES.SPECIES.SEEDS." + plantId.ToUpperInvariant() + ".NAME",
                UI.FormatAsLink(name, plantId)
            });
            Strings.Add(new string[]
            {
                "STRINGS.CREATURES.SPECIES.SEEDS." + plantId.ToUpperInvariant() + ".DESC",
                description
            });
        }
        public static void AddFoodStrings(string foodId, string name, string description, string recipeDescription = null)
        {
            Strings.Add(new string[]
            {
                "STRINGS.ITEMS.FOOD." + foodId.ToUpperInvariant() + ".NAME",
                UI.FormatAsLink(name, foodId)
            });
            Strings.Add(new string[]
            {
                "STRINGS.ITEMS.FOOD." + foodId.ToUpperInvariant() + ".DESC",
                description
            });
            bool flag = recipeDescription != null;
            if (flag)
            {
                Strings.Add(new string[]
                {
                    "STRINGS.ITEMS.FOOD." + foodId.ToUpperInvariant() + ".RECIPEDESC",
                    recipeDescription
                });
            }
        }
    }
}
