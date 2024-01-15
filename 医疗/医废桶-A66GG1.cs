using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.医疗
{
    public class A66GG1 : IBuildingConfig
    {
        //-------------------------------
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A66GG1";
            int width = 1;
            int height = 1;
            string anim = "A66GG1_kanim";
            int hitpoints = 30;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
            string[] raw_MINERALS = MATERIALS.RAW_MINERALS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, raw_MINERALS, melting_point, build_location_rule, new EffectorValues
            {
                amount = 1,
                radius = 1
            }, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.AudioCategory = "Metal";
            buildingDef.Overheatable = false;
            //--------------------------
            if (控制台.Instance.医废桶) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        //-------------------------------
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            SoundEventVolumeCache.instance.AddVolume("storagelocker_kanim", "StorageLocker_Hit_metallic_low", NOISE_POLLUTION.NOISY.TIER1);
            Prioritizable.AddRef(go);
            Storage storage = go.AddOrGet<Storage>();
            storage.capacityKg = 10f;
            storage.showInUI = true;
            storage.allowItemRemoval = true;
            storage.showDescriptor = true;
            storage.storageFilters = new List<Tag>
            {
                GameTags.MedicalSupplies,GameTags.Medicine
            };
            storage.storageFullMargin = STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
            storage.fetchCategory = Storage.FetchCategory.GeneralStorage;
            go.AddOrGet<CopyBuildingSettings>().copyGroupTag = GameTags.StorageLocker;
            go.AddOrGet<StorageLocker>();
            go.AddOrGet<A66GG0>();
        }
        //-------------------------------
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGetDef<StorageController.Def>();

        }
        //-------------------------------
        public const string ID = "A66GG1";
        //-------------------------------
    }
    public class A66GG0 : KMonoBehaviour, ISim1000ms
    {
        //-------------------------------
        public void Sim1000ms(float dt)
        {

            foreach (GameObject go in this.storage.items)
            {
                go.DeleteObject();
            }
        }
        //-------------------------------
        protected override void OnSpawn()
        {
            base.OnSpawn();
        }
        //-------------------------------
        [MyCmpGet]
        internal Storage storage;
        //-------------------------------
    }
}
