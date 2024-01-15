using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    public class A50GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A50GG1";
            int width = 1;
            int height = 1;
            string anim = "A50GG1_kanim";
            int hitpoints = 10;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, any_BUILDABLE, melting_point, build_location_rule, BUILDINGS.DECOR.BONUS.TIER2, none, 0.2f);
            buildingDef.WorkTime = 20f;
            buildingDef.Overheatable = false;
            buildingDef.AudioCategory = "Metal";
            //--------------------------
            if (控制台.Instance.香草餐桌) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<LoopingSounds>();
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.MessTable, false);
            go.AddOrGet<MessStation>();
            go.AddOrGet<AnimTileable>();
            go.AddOrGetDef<RocketUsageRestriction.Def>();
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.GetComponent<KAnimControllerBase>().initialAnim = "off";
            go.AddOrGet<Ownable>().slotID = Db.Get().AssignableSlots.MessStation.Id;
            Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
            storage.showInUI = true;
            storage.capacityKg = TableSaltTuning.SALTSHAKERSTORAGEMASS;
            ManualDeliveryKG manualDeliveryKG = go.AddOrGet<ManualDeliveryKG>();
            manualDeliveryKG.SetStorage(storage);
            manualDeliveryKG.RequestedItemTag = TableSaltConfig.ID.ToTag();
            manualDeliveryKG.capacity = TableSaltTuning.SALTSHAKERSTORAGEMASS;
            manualDeliveryKG.refillMass = TableSaltTuning.CONSUMABLE_RATE;
            manualDeliveryKG.choreTypeIDHash = Db.Get().ChoreTypes.FoodFetch.IdHash;
            manualDeliveryKG.ShowStatusItem = false;
        }
        public const string ID = "A50GG1";
    }
}

