using STRINGS;
using System.Collections.Generic;
using UnityEngine;
using static CaiLib.Utils.RecipeUtils;
using CaiLib.Utils;


namespace 吐泡泡的小鱼的缺氧模组.食物
{
    public class C5GG1 : IEntityConfig
    {
        //--------------------------
        public const string Id = "C5GG1";// 食物ID
        public static string Name = STRINGS.CREATURES.SPECIES.C5GG1.C1;// 食物名称
        public static string EFFECT = STRINGS.CREATURES.SPECIES.C5GG1.C2;// 食物描述
        public static string DESC = STRINGS.CREATURES.SPECIES.C5GG1.C3;// 配方描述
        private const string AnimName = "C5GG1_kanim";// 食物动画
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
                    caloriesPerUnit: 2500000f, // 食物每单位卡路里   ---   300 000
                    quality: 6, // 食物质量
                    preserveTemperatue: 255.15f, // 食物保存温度
                    rotTemperature: 277.15f, // 食物腐烂温度
                    spoilTime: TUNING.FOOD.SPOIL_TIME.SLOW, // 食物腐烂时间
                    can_rot: true); // 食物是否可腐烂
                    foodInfo.AddEffects(new List<string> { "GoodEats" }, DlcManager.AVAILABLE_EXPANSION1_ONLY);
            var food = EntityTemplates.ExtendEntityToFood(entity, foodInfo);
            // 添加配方
            Recipe = AddComplexRecipe
            (
                input: new[] 
                {
                new ComplexRecipe.RecipeElement("BasicPlantFood", 2f),//米虱 600 
                new ComplexRecipe.RecipeElement("BeanPlantSeed", 2f),//小吃豆 600
                new ComplexRecipe.RecipeElement(SpiceNutConfig.ID, 2f),//火椒粒 0
                new ComplexRecipe.RecipeElement(B1GG3.Id, 1f) // 辣椒 100
                }, // 配方输入
                output: new[] 
                {
                    new ComplexRecipe.RecipeElement(C5GG1.Id, 1f) 
                }, // 配方输出
                fabricatorId: GourmetCookingStationConfig.ID, // 配方的制造器ID
                productionTime: 100f, // 配方的生产时间
                recipeDescription: DESC, // 配方描述
                nameDisplayType: ComplexRecipe.RecipeNameDisplay.Result, // 配方名称显示类型
                sortOrder: 120 // 配方的排序顺序
            );
            // 返回食物的预制体
            return food;


        }
        public string[] GetDlcIds()
        {
            return DlcManager.AVAILABLE_ALL_VERSIONS;
            // AVAILABLE_ALL_VERSIONS-------------------------------本体+DLC可用
            //AVAILABLE_VANILLA_ONLY--------------------------------仅本体可用
            //AVAILABLE_EXPANSION1_ONLY-----------------------------仅DLC可用
        }
        public void OnPrefabInit(GameObject inst)
        {
        }
        public void OnSpawn(GameObject inst)
        {
        }
    }
}

