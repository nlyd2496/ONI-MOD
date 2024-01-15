using STRINGS;
using System.Collections.Generic;
using UnityEngine;
using static CaiLib.Utils.RecipeUtils;
using CaiLib.Utils;

namespace 吐泡泡的小鱼的缺氧模组.食物
{
    public class D1GG2 : IEntityConfig
    {
        //--------------------------
        public const string Id = "D1GG2";// 食物ID
        public static string Name =   STRINGS.CREATURES.SPECIES.D1GG2.D1;// 食物名称
        public static string EFFECT = STRINGS.CREATURES.SPECIES.D1GG1.D2;// 食物描述
        public static string DESC =   STRINGS.CREATURES.SPECIES.D1GG1.D3;// 配方描述
        private const string AnimName = "D1GG2_kanim";// 食物动画
        //--------------------------
        public ComplexRecipe Recipe;
        public GameObject CreatePrefab()
        {
            var entity = EntityTemplates.CreateLooseEntity(
                id: Id, // 食物ID
                name: Name, // 食物名称
                desc: EFFECT, // 食物STRINGS.BUILDINGS.PREFABS
                mass: 1f, // 食物质量
                unitMass: false, // 食物的单位质量
                anim: Assets.GetAnim(AnimName), // 食物动画
                initialAnim: "object", // 食物初始动画
                sceneLayer: Grid.SceneLayer.Front, // 食物场景层
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE, // 食物碰撞形状
                width: 0.8f, // 食物宽度
                height: 0.7f, // 食物高度
                isPickupable: true); // 食物是否可拾取

            // 创建食物信息
            var foodInfo = new EdiblesManager.FoodInfo(
                    id: Id, // 食物ID
                    dlcId: DlcManager.VANILLA_ID, // 食物的DLC ID
                    caloriesPerUnit: 800000f, // 食物每单位卡路里   ---   300 000
                    quality: 3, // 食物质量
                    preserveTemperatue: 255.15f, // 食物保存温度
                    rotTemperature: 277.15f, // 食物腐烂温度
                    spoilTime: TUNING.FOOD.SPOIL_TIME.SLOW, // 食物腐烂时间
                    can_rot: true); // 食物是否可腐烂
            // foodInfo.AddEffects(new List<string> { "GoodEats" }, DlcManager.AVAILABLE_EXPANSION1_ONLY);  // 灵魂食物
            var food = EntityTemplates.ExtendEntityToFood(entity, foodInfo);
            Recipe = AddComplexRecipe
            (
                input: new[]
                {
                 new ComplexRecipe.RecipeElement("Ice", 50f),//冰
                new ComplexRecipe.RecipeElement("Milk", 4f),//咸乳  200
                }, // 配方输入
                output: new[]
                {
                    new ComplexRecipe.RecipeElement(D1GG2.Id, 1f)
                }, // 配方输出
                fabricatorId: A39GG1.ID, // 配方的制造器ID
                productionTime: 100f,
                recipeDescription: DESC,
                nameDisplayType: ComplexRecipe.RecipeNameDisplay.Result,
                sortOrder: 120
            );
            return food;
        }
        public string[] GetDlcIds()
        {
            return DlcManager.AVAILABLE_ALL_VERSIONS;
        }
        public void OnPrefabInit(GameObject inst)
        {
        }
        public void OnSpawn(GameObject inst)
        {
        }
    }
}
