using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.食物
{

    //------------------------------------------------------------植物+种子------------------------------------------------------------

    public class B1GG1 : IEntityConfig
    {
        //--------------------------
        public const string SeedId = "B1GG1";// 种子ID
        public static string SeedName = STRINGS.CREATURES.SPECIES.B1GG1.B1;// 种子名称
        public static string SeedDescription = STRINGS.CREATURES.SPECIES.B1GG1.B2;// 种子描述
        private const string AnimNameSeed = "B1GG1_kanim";// 种子动画
        public const string Id = "B1GG2";// 植物ID
        public static string Name = STRINGS.CREATURES.SPECIES.B1GG1.B3;// 植物名字
        public static string Description = STRINGS.CREATURES.SPECIES.B1GG1.B4;// 植物描述1
        public static string DomesticatedDescription = STRINGS.CREATURES.SPECIES.B1GG1.B5;// 植物描述2
        private const string AnimName = "B1GG2_kanim";// 植物动画
        //--------------------------
        // 创建植物
        public GameObject CreatePrefab()
        {

            var placedEntity = EntityTemplates.CreatePlacedEntity(
                id: Id, //植物ID
                name: Name, //植物名称
                desc: Description, //植物STRINGS.BUILDINGS.PREFABS
                mass: 1f, // 植物质量
                anim: Assets.GetAnim(AnimName), // 植物动画
                initialAnim: "idle_loop", // 植物初始动画
                sceneLayer: Grid.SceneLayer.BuildingFront, // 植物场景层
                width: 1, // 植物宽度
                height: 2, // 植物高度
                decor: DECOR.BONUS.TIER1, // 植物装饰值
                defaultTemperature: 298.15f); // 植物默认温度 ---   25°
            EntityTemplates.ExtendEntityToBasicPlant
                (
                template: placedEntity, // 植物模板
                temperature_lethal_low: 263.15f, // 致死低温  ---   -10°
                temperature_warning_low: 273.15f, // 生长低温 ---   0°
                temperature_warning_high: 348.15f, // 生长高温---   75°
                temperature_lethal_high: 373.15f, // 致死高温 ---   100°
                safe_elements: new[]
                {
                    SimHashes.Oxygen, // 生长于氧气
                    SimHashes.ContaminatedOxygen, // 生长于污染氧
                    SimHashes.CarbonDioxide // 生长于二氧化碳
                },
                pressure_sensitive: true, // 是否压力敏感
                pressure_lethal_low: 0f, //致命低压（kg）
                pressure_warning_low: 0.001f, // 低压警告（kg）
                                              // 高温限制暂时修改不了
                should_grow_old: false,// 是否会变老
                max_age: 2400f,// 最大寿命（秒）
                min_radiation: 0f, //最低辐射
                max_radiation: 10000f, //最大辐射
                crop_id: "B1GG3", // 果实ID
                baseTraitId: $"{Id}Original", // 植物基本特性ID
                baseTraitName: Name //植物名称
                );
            // 添加到标准作物
            placedEntity.AddOrGet<StandardCropPlant>();
            var consumer = placedEntity.AddOrGet<ElementConsumer>();
            consumer.elementToConsume = SimHashes.CarbonDioxide; // 消耗的元素
            consumer.consumptionRate = 0.001f; // 消耗的速率
            // 给实体添加ElementEmitter组件，使其能够释放元素
            var emitter = placedEntity.AddOrGet<ElementEmitter>();
            emitter.outputElement = new ElementConverter.OutputElement(0.001f, SimHashes.Oxygen, 0f, true, false, 0f, 2f); // 释放的元素
            emitter.maxPressure = 10f; // 最大压力
            // 添加植物种子
            var seed = EntityTemplates.CreateAndRegisterSeedForPlant(
                plant: placedEntity, // 植物的预制体
                id: SeedId, // 种子ID
                name: SeedName, // 种子名称
                desc: SeedDescription, // 种子STRINGS.BUILDINGS.PREFABS
                productionType: SeedProducer.ProductionType.Sterile, // 种子生产类型
                anim: Assets.GetAnim(AnimNameSeed), // 种子动画
                numberOfSeeds: 0, // 种子数量
                additionalTags: new List<Tag> { GameTags.CropSeed }, // 种子额外标签
                sortOrder: 7, // 种子排序顺序
                domesticatedDescription: DomesticatedDescription, // 种子STRINGS.BUILDINGS.PREFABS1
                width: 0.5f, // 种子宽度
                height: 0.5f); // 种子高度
            // 为种子创建并注册预览
            EntityTemplates.CreateAndRegisterPreviewForPlant
                (
                seed: seed, // 种子的预制体
                id: "PalmeraTree_preview", // 预览的ID
                anim: Assets.GetAnim(AnimName), // 预览的动画
                initialAnim: "place", // 预览的初始动画
                width: 1, // 预览植物宽度
                height: 1
                ); // 预览植物高度

            // 给实体添加声音事件的音量
            SoundEventVolumeCache.instance.AddVolume("bristleblossom_kanim", "PrickleFlower_harvest", NOISE_POLLUTION.CREATURES.TIER1);
            // 返回实体的预制体
            
            return placedEntity;
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

    //------------------------------------------------------------果实------------------------------------------------------------

    public class B1GG3 : IEntityConfig
    {
        //--------------------------
        public static string Id = "B1GG3";// 果实ID
        public static string Name = STRINGS.CREATURES.SPECIES.B1GG1.B6;// 果实名称
        public static string Description = STRINGS.CREATURES.SPECIES.B1GG1.B7;// 果实名称
        private const string AnimName = "B1GG3_kanim";// 果实动画
        //--------------------------
        // 创建果实
        public GameObject CreatePrefab()
        {
            var entity = EntityTemplates.CreateLooseEntity(
                id: Id, // 果实ID
                name: Name, // 果实名称
                desc: Description, // 果实STRINGS.BUILDINGS.PREFABS
                mass: 1f, // 果实质量
                unitMass: false, // 果实单位质量
                anim: Assets.GetAnim(AnimName), // 果实动画
                initialAnim: "object", // 果实初始动画
                sceneLayer: Grid.SceneLayer.Front, // 果实场景层
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE, // 果实碰撞形状
                width: 1f, // 果实宽度
                height: 1f, // 果实高度
                isPickupable: true); // 果实是否可拾取
        
            // 创建食物信息
            var foodInfo = new EdiblesManager.FoodInfo(
                id: Id, // 果实ID
                dlcId: DlcManager.VANILLA_ID, // 果实DLC ID
                caloriesPerUnit: 100000f, // 果实每单位卡路里   ---   100 000
                quality: 1, // 果实质量
                preserveTemperatue: 263.15f, // 果实保存温度  ---   -10°
                rotTemperature: 283.15f, // 果实腐烂温度  ---   10°
                spoilTime: TUNING.FOOD.SPOIL_TIME.SLOW, // 果实腐烂时间
                can_rot: true); // 果实是否可腐烂
            var foodEntity = EntityTemplates.ExtendEntityToFood(entity, foodInfo);

            /*
            // 给食物添加Sublimates组件，使其能够升华为气体
            var sublimates = foodEntity.AddOrGet<Sublimates>();
            sublimates.spawnFXHash = SpawnFXHashes.OxygenEmissionBubbles; // 升华的特效
            sublimates.info = new Sublimates.Info(
                rate: 0.001f, // 升华的速率
                min_amount: 0f, // 升华的最小量
                max_destination_mass: 1.8f, // 升华的最大目标质量
                mass_power: 0.0f, // 升华的质量指数
                element: SimHashes.Oxygen); // 升华的元素
            */


            // 返回食物的预制体
            return foodEntity;
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
    /*
    grow = "grow"，表示植物正在生长的状态
    grow_pst = "grow_pst"，表示植物生长完成的状态
    idle_full = "idle_full"，表示植物处于满产的状态
    wilt_base = "wilt"，表示植物开始枯萎的状态
    harvest = "harvest"，表示植物被收获的状态
    waning = "waning"，表示植物逐渐消失的状态
    */
}
