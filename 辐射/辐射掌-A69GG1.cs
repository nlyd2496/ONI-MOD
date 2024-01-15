using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.控制器;

namespace 吐泡泡的小鱼的缺氧模组.辐射
{
    public class A69GG1 : IBuildingConfig
    {
        public override string[] GetDlcIds()
        {
            return DlcManager.AVAILABLE_EXPANSION1_ONLY;
        }
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A69GG1";
            int width = 1;
            int height = 1;
            string anim = "A69GG1_kanim";
            int hitpoints = 10;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER1;
            string[] all_METALS = MATERIALS.ALL_METALS;
            float melting_point = 800f;
            BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, all_METALS, melting_point, build_location_rule, BUILDINGS.DECOR.NONE, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.Entombable = false;
            buildingDef.Overheatable = false;

            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));

            buildingDef.ViewMode = OverlayModes.Radiation.ID;
            buildingDef.AudioCategory = "Metal";
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            //--------------------------
            if (控制台.Instance.辐射掌) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<A69GG1_KZQ>();
            RadiationEmitter radiationEmitter = go.AddComponent<RadiationEmitter>();
            radiationEmitter.emitAngle = 180f;
            radiationEmitter.emitDirection = 0f;
            radiationEmitter.emissionOffset = Vector3.right;
            radiationEmitter.emitType = RadiationEmitter.RadiationEmitterType.Constant;
            radiationEmitter.emitRadiusX = 4;
            radiationEmitter.emitRadiusY = 1;
            radiationEmitter.emitRads = 2f;

        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();//信号控制器
        }
        public const string ID = "A69GG1";   
    }
}
