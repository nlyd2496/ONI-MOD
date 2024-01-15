using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.管道
{

        public class A49GG1 : IBuildingConfig
        {
            public override BuildingDef CreateBuildingDef()
            {
                string id = "A49GG1";
                int width = 2;
                int height = 3;
                string anim = "A49GG1_kanim";
                int hitpoints = 30;
                float construction_time = 30f;
                float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
                string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
                float melting_point = 800f;
                BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
                EffectorValues none = NOISE_POLLUTION.NONE;
                BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, any_BUILDABLE, melting_point, build_location_rule, BUILDINGS.DECOR.BONUS.TIER1, none, 0.2f);
                buildingDef.Overheatable = false;
                buildingDef.ExhaustKilowattsWhenActive = 0.25f;
                buildingDef.SelfHeatKilowattsWhenActive = 0f;
                buildingDef.InputConduitType = ConduitType.Liquid;
                buildingDef.OutputConduitType = ConduitType.Liquid;
                buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
                buildingDef.DiseaseCellVisName = "FoodPoisoning";
                buildingDef.AudioCategory = "Metal";
                buildingDef.UtilityInputOffset = new CellOffset(0, 0);
                buildingDef.UtilityOutputOffset = new CellOffset(1, 1);
                buildingDef.PermittedRotations = PermittedRotations.FlipH;
                SoundEventVolumeCache.instance.AddVolume("toiletflush_kanim", "Lavatory_flush", NOISE_POLLUTION.NOISY.TIER3);
                SoundEventVolumeCache.instance.AddVolume("toiletflush_kanim", "Lavatory_door_close", NOISE_POLLUTION.NOISY.TIER1);
                SoundEventVolumeCache.instance.AddVolume("toiletflush_kanim", "Lavatory_door_open", NOISE_POLLUTION.NOISY.TIER1);
            //--------------------------
            if (控制台.Instance.香草抽水马桶) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
            }
            public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
            {
                go.AddOrGet<LoopingSounds>();
                go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.ToiletType, false);
                go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.FlushToiletType, false);
                FlushToilet flushToilet = go.AddOrGet<FlushToilet>(); // 为游戏对象go添加或获取FlushToilet组件
                flushToilet.massConsumedPerUse = 5f; // 每次使用消耗的水量，单位为千克
                flushToilet.massEmittedPerUse = 11.7f; // 每次使用排放的污水量，单位为千克
                flushToilet.newPeeTemperature = 310.15f; // 排放的污水的温度，单位为开尔文
                flushToilet.diseaseId = "FoodPoisoning"; // 排放的污水携带的疾病种类
                flushToilet.diseasePerFlush = 50000; // 排放的污水携带的疾病数量，单位为个体数
                flushToilet.diseaseOnDupePerFlush = 2500; // 每次使用对使用者造成的疾病数量，单位为个体数
                flushToilet.requireOutput = true; // 是否需要有输出管道连接才能使用
                KAnimFile[] overrideAnims = new KAnimFile[]
                {
                    Assets.GetAnim("anim_interacts_toiletflush_kanim")
                };
                ToiletWorkableUse toiletWorkableUse = go.AddOrGet<ToiletWorkableUse>();
                toiletWorkableUse.overrideAnims = overrideAnims;
                toiletWorkableUse.workLayer = Grid.SceneLayer.BuildingFront;
                toiletWorkableUse.resetProgressOnStop = true;
                ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
                conduitConsumer.conduitType = ConduitType.Liquid;
                conduitConsumer.capacityTag = ElementLoader.FindElementByHash(SimHashes.Water).tag;
                conduitConsumer.capacityKG = 5f;
                conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Store;
                ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
                conduitDispenser.conduitType = ConduitType.Liquid;
                conduitDispenser.invertElementFilter = true;
                conduitDispenser.elementFilter = new SimHashes[]
                {
                    SimHashes.Water
                };
                Storage storage = go.AddOrGet<Storage>();
                storage.capacityKg = 25f;
                storage.doDiseaseTransfer = false;
                storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
                Ownable ownable = go.AddOrGet<Ownable>();
                ownable.slotID = Db.Get().AssignableSlots.Toilet.Id;
                ownable.canBePublic = true;
                go.AddOrGet<RequireOutputs>().ignoreFullPipe = true;
                go.AddOrGetDef<RocketUsageRestriction.Def>();
            }
            public override void DoPostConfigureComplete(GameObject go)
            {
            }
            private const float WATER_USAGE = 5f;
            public const string ID = "A49GG1";
        }
    
}
