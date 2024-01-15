using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using TUNING;

namespace 吐泡泡的小鱼的缺氧模组.精炼
{
    [HarmonyPatch(typeof(GourmetCookingStationConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 精炼镁铁质岩生产铁
    {
        public static void Postfix()
        {
            bool 精炼镁铁质岩生产铁 = SingletonOptions<控制台>.Instance.精炼镁铁质岩生产铁;
            if (精炼镁铁质岩生产铁)
            {
                //目标产物：Steel
                Element element2 = ElementLoader.FindElementByHash(SimHashes.Steel);
                ComplexRecipe.RecipeElement[] array5 = new ComplexRecipe.RecipeElement[]//------array5
                {
                    //配方原料1：MaficRock
                    new ComplexRecipe.RecipeElement(ElementLoader.FindElementByHash(SimHashes.MaficRock).tag, 100f),
                    //配方原料2：RefinedCarbon
                     new ComplexRecipe.RecipeElement(ElementLoader.FindElementByHash(SimHashes.RefinedCarbon).tag, 10f),
                };
                ComplexRecipe.RecipeElement[] array6 = new ComplexRecipe.RecipeElement[]//------array6
                {
                    //目标产物产量：Steel
                    new ComplexRecipe.RecipeElement(ElementLoader.FindElementByHash(SimHashes.Steel).tag, 40f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
                };
                string obsolete_id3 = ComplexRecipeManager.MakeObsoleteRecipeID("MetalRefinery", element2.tag);//------id3
                string text3 = ComplexRecipeManager.MakeRecipeID("MetalRefinery", array5, array6);//------txt3
                ComplexRecipe complexRecipe2 = new ComplexRecipe(text3, array5, array6);
                //操作时间：40
                complexRecipe2.time = 40f;
                complexRecipe2.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;
                //配方显示：原料MaficRock-Steel
                complexRecipe2.description = string.Format(STRINGS.BUILDINGS.PREFABS.A63GG1.A63GG0,
                    ElementLoader.FindElementByHash(SimHashes.Steel).name,
                    ElementLoader.FindElementByHash(SimHashes.MaficRock).name);
                complexRecipe2.fabricators = new List<Tag>
                {
                    TagManager.Create("MetalRefinery")
                };
                ComplexRecipeManager.Get().AddObsoleteIDMapping(obsolete_id3, text3);
            }
            //根据您的配方和已知配方，修改“array+数值”、“txt+数值”、“id+数值”
        }
    }
}
