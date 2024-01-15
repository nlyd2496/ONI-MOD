using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    public class A80GG2 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A80GG2";
            int width = 1;
            int height = 1;
            string anim = "A80GG2_kanim";
            int hitpoints = 30;
            float construction_time = 10f;
            float[] tier = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            string[] all_METALS = MATERIALS.ALL_METALS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.BuildingAttachPoint;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, all_METALS, melting_point, build_location_rule, TUNING.BUILDINGS.DECOR.NONE, none, 1f);
            buildingDef.Entombable = true;
            buildingDef.Floodable = false;
            buildingDef.IsFoundation = false;
            buildingDef.AudioCategory = "Metal";
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            //-------------------------------
            buildingDef.SceneLayer = Grid.SceneLayer.Backwall;
            buildingDef.ObjectLayer = ObjectLayer.Backwall;
            //-------------------------------
            buildingDef.AttachmentSlotTag = "A80GG2";
            buildingDef.attachablePosition = new CellOffset(0, 0);
            //-------------------------------
            //--------------------------
            if (控制台.Instance.警示牌) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
            go.AddOrGet<LoopingSounds>();
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<SelectableSign>().AnimationNames = new List<string>
            {
                "01",
                "02",
                "03",
                "04",
                "05",
                "06",
            };
        }
        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
        }
        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
        }
    }


    public class A80GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A80GG1";
            int width = 1;
            int height = 3;
            string anim = "A80GG1_kanim";
            int hitpoints = 30;
            float construction_time = 10f;
            float[] tier = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            string[] all_METALS = MATERIALS.ALL_METALS;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.OnFloor;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, all_METALS, melting_point, build_location_rule, TUNING.BUILDINGS.DECOR.NONE, none, 1f);
            buildingDef.Entombable = true;
            buildingDef.Floodable = false;
            buildingDef.IsFoundation = false;
            buildingDef.AudioCategory = "Metal";
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            //-------------------------------
            buildingDef.SceneLayer = Grid.SceneLayer.BuildingFront;
            buildingDef.ObjectLayer = ObjectLayer.Building;
            buildingDef.attachablePosition = new CellOffset(0, 0);
            buildingDef.AttachmentSlotTag = "Warningsigncontrol";
            //-------------------------------
            buildingDef.LogicInputPorts = DoorConfig.CreateSingleInputPortList(new CellOffset(0, 0));
            SoundEventVolumeCache.instance.AddVolume("door_internal_kanim", "Open_DoorInternal", NOISE_POLLUTION.NOISY.TIER2);
            SoundEventVolumeCache.instance.AddVolume("door_internal_kanim", "Close_DoorInternal", NOISE_POLLUTION.NOISY.TIER2);
            //--------------------------
            if (控制台.Instance.警示牌) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public static List<LogicPorts.Port> CreateSingleInputPortList(CellOffset offset)
        {
            return new List<LogicPorts.Port>
            {
           LogicPorts.Port.InputPort(Door.OPEN_CLOSE_PORT_ID, offset, "", "", "", false, false)
            };
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
            go.AddOrGet<LoopingSounds>();
            go.AddOrGet<BuildingAttachPoint>().points = new BuildingAttachPoint.HardPoint[]
            {
                new BuildingAttachPoint.HardPoint(new CellOffset(0, 2), "A80GG2", null)
            };
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            Door door = go.AddOrGet<Door>();
            door.unpoweredAnimSpeed = 10f;
            door.doorType = Door.DoorType.Internal;
            door.doorOpeningSoundEventName = "Open_DoorInternal";
            door.doorClosingSoundEventName = "Close_DoorInternal";
            go.AddOrGet<AccessControl>().controlEnabled = true;
            go.AddOrGet<CopyBuildingSettings>().copyGroupTag = GameTags.Door;
            go.AddOrGet<Workable>().workTime = 3f;
            go.GetComponent<KBatchedAnimController>().initialAnim = "closed";
            go.AddOrGet<ZoneTile>();
            go.AddOrGet<KBoxCollider2D>();
            Prioritizable.AddRef(go);
            UnityEngine.Object.DestroyImmediate(go.GetComponent<BuildingEnabledButton>());
        }
        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
        }
    }
}
