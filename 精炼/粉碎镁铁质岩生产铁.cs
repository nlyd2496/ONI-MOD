using HarmonyLib;
using PeterHan.PLib.Options;
using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.精炼
{
    [HarmonyPatch(typeof(RockCrusherConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 粉碎镁铁质岩生产铁
    {
        public static void Postfix()
        {
            bool 粉碎镁铁质岩生产铁 = SingletonOptions<控制台>.Instance.粉碎镁铁质岩生产铁;
            if (粉碎镁铁质岩生产铁)
            {
                // 通过哈希值找到铁元素
                Element element = ElementLoader.FindElementByHash(SimHashes.Iron);
                // 定义一个复杂配方的输入元素数组，包含一百份玄武岩
                //-----------------------------------array21-----------------------------------
                ComplexRecipe.RecipeElement[] array21 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(ElementLoader.FindElementByHash(SimHashes.MaficRock).tag, 100f)
                };
                // 定义一个复杂配方的输出元素数组，包含四十份铁和六十份沙子，温度为输入元素的平均值
                //-----------------------------------array22-----------------------------------
                ComplexRecipe.RecipeElement[] array22 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(ElementLoader.FindElementByHash(SimHashes.Iron).tag, 40f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                    new ComplexRecipe.RecipeElement(ElementLoader.FindElementByHash(SimHashes.Sand).tag, 60f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
                };
                // 创建一个复杂配方，使用RockCrusher将玄武岩转化为铁和沙子
                //-----------------------------------array21/array22-----------------------------------
                ComplexRecipe complexRecipe5 = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("RockCrusher", array21, array22), array21, array22);
                // 设置配方的时间为40秒
                complexRecipe5.time = 40f;
                // 设置配方的描述，使用字符串格式化和标签名称
                complexRecipe5.description = string.Format(STRINGS.BUILDINGS.PREFABS.A63GG1.A63GG0, SimHashes.Iron.CreateTag().ProperName(), ITEMS.INDUSTRIAL_PRODUCTS.CRAB_SHELL.NAME);
                // 设置配方的显示方式为输入元素到输出元素
                complexRecipe5.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;
                // 设置配方的制造器为RockCrusher
                complexRecipe5.fabricators = new List<Tag>
                {
                    TagManager.Create("RockCrusher")
                };
                //同步修改array21+array22
            }
        }
    }
}
