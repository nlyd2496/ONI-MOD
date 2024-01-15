﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.管道
{

        public class A54GG1 : IBuildingConfig
        {
            public override BuildingDef CreateBuildingDef()
            {
                string id = "A54GG1";
                int width = 3;
                int height = 1;
                string anim = "A54GG1_kanim";
                int hitpoints = 10;
                float construction_time = 3f;
                float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER1;
                string[] refined_METALS = MATERIALS.REFINED_METALS;
                float melting_point = 3200f;
                BuildLocationRule build_location_rule = BuildLocationRule.Conduit;
                EffectorValues none = NOISE_POLLUTION.NONE;
                BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, refined_METALS, melting_point, build_location_rule, BUILDINGS.DECOR.NONE, none, 0.2f);
                buildingDef.ObjectLayer = ObjectLayer.LiquidConduitConnection;
                buildingDef.SceneLayer = Grid.SceneLayer.LiquidConduitBridges;
                buildingDef.InputConduitType = ConduitType.Liquid;
                buildingDef.OutputConduitType = ConduitType.Liquid;
                buildingDef.ThermalConductivity = 2f;
                buildingDef.Floodable = false;
                buildingDef.Entombable = false;
                buildingDef.Overheatable = false;
                buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
                buildingDef.AudioCategory = "Metal";
                buildingDef.AudioSize = "small";
                buildingDef.BaseTimeUntilRepair = -1f;
                buildingDef.PermittedRotations = PermittedRotations.R360;
                buildingDef.UtilityInputOffset = new CellOffset(-1, 0);
                buildingDef.UtilityOutputOffset = new CellOffset(1, 0);
                GeneratedBuildings.RegisterWithOverlay(OverlayScreen.LiquidVentIDs, buildingDef.PrefabID);
            //--------------------------
            if (控制台.Instance.导热液体管道) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
            }
            public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
            {
                GeneratedBuildings.MakeBuildingAlwaysOperational(go);
                BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
                go.AddOrGet<ConduitBridge>().type = ConduitType.Liquid;
            }
            public override void DoPostConfigureComplete(GameObject go)
            {
                UnityEngine.Object.DestroyImmediate(go.GetComponent<RequireInputs>());
                UnityEngine.Object.DestroyImmediate(go.GetComponent<ConduitConsumer>());
                UnityEngine.Object.DestroyImmediate(go.GetComponent<ConduitDispenser>());
            }
            public const string ID = "A54GG1";
            private const ConduitType CONDUIT_TYPE = ConduitType.Liquid;
        }
    }

