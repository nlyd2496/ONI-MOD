using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.基础属性
{
    [HarmonyPatch(typeof(TileConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 普通砖行进速度
    {
        private static void Prefix(GameObject go)
        {
            bool 启用砖块行进速度增益 = SingletonOptions<控制台>.Instance.砖块行进速度增益;
            if (启用砖块行进速度增益)
            {
                SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
                simCellOccupier.strengthMultiplier = 1f;//强度系数
                simCellOccupier.movementSpeedMultiplier = SingletonOptions<控制台>.Instance.砖上行进速度;
            }
        }
    }
    [HarmonyPatch(typeof(GasPermeableMembraneConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 透气砖行进速度
    {
        private static void Prefix(GameObject go)
        {
            bool 启用砖块行进速度增益 = SingletonOptions<控制台>.Instance.砖块行进速度增益;
            if (启用砖块行进速度增益)
            {
                SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
                simCellOccupier.strengthMultiplier = 1f;//强度系数     
                simCellOccupier.movementSpeedMultiplier = SingletonOptions<控制台>.Instance.砖上行进速度;
            }
        }
    }
    [HarmonyPatch(typeof(MeshTileConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 网格砖行进速度
    {
        private static void Prefix(GameObject go)
        {
            bool 启用砖块行进速度增益 = SingletonOptions<控制台>.Instance.砖块行进速度增益;
            if (启用砖块行进速度增益)
            {
                SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
                simCellOccupier.strengthMultiplier = 1f;//强度系数
                simCellOccupier.movementSpeedMultiplier = SingletonOptions<控制台>.Instance.砖上行进速度;
            }
        }
    }
    [HarmonyPatch(typeof(InsulationTileConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 隔热砖行进速度
    {
        private static void Prefix(GameObject go)
        {
            bool 启用砖块行进速度增益 = SingletonOptions<控制台>.Instance.砖块行进速度增益;
            if (启用砖块行进速度增益)
            {
                SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
                simCellOccupier.strengthMultiplier = 1f;//强度系数
                simCellOccupier.movementSpeedMultiplier = SingletonOptions<控制台>.Instance.砖上行进速度;
            }
        }
    }
    [HarmonyPatch(typeof(PlasticTileConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 塑料砖行进速度
    {
        private static void Prefix(GameObject go)
        {
            bool 启用砖块行进速度增益 = SingletonOptions<控制台>.Instance.砖块行进速度增益;
            if (启用砖块行进速度增益)
            {
                SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
                simCellOccupier.strengthMultiplier = 1f;//强度系数
                simCellOccupier.movementSpeedMultiplier = SingletonOptions<控制台>.Instance.砖上行进速度;
            }
        }
    }
    [HarmonyPatch(typeof(MetalTileConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 金属砖行进速度
    {
        private static void Prefix(GameObject go)
        {
            bool 启用砖块行进速度增益 = SingletonOptions<控制台>.Instance.砖块行进速度增益;
            if (启用砖块行进速度增益)
            {
                SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
                simCellOccupier.strengthMultiplier = 1f;//强度系数
                simCellOccupier.movementSpeedMultiplier = SingletonOptions<控制台>.Instance.砖上行进速度;
            }
        }
    }
    [HarmonyPatch(typeof(GlassTileConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 窗户砖行进速度
    {
        private static void Prefix(GameObject go)
        {
            bool 启用砖块行进速度增益 = SingletonOptions<控制台>.Instance.砖块行进速度增益;
            if (启用砖块行进速度增益)
            {
                SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
                simCellOccupier.strengthMultiplier = 1f;//强度系数
                simCellOccupier.movementSpeedMultiplier = SingletonOptions<控制台>.Instance.砖上行进速度;
            }
        }
    }
    [HarmonyPatch(typeof(BunkerTileConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 地堡砖行进速度
    {
        private static void Prefix(GameObject go)
        {
            bool 启用砖块行进速度增益 = SingletonOptions<控制台>.Instance.砖块行进速度增益;
            if (启用砖块行进速度增益)
            {
                SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
                simCellOccupier.strengthMultiplier = 1f;//强度系数
                simCellOccupier.movementSpeedMultiplier = SingletonOptions<控制台>.Instance.砖上行进速度;
            }
        }
    }
    [HarmonyPatch(typeof(CarpetTileConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 地毯砖行进速度
    {
        private static void Prefix(GameObject go)
        {
            bool 启用砖块行进速度增益 = SingletonOptions<控制台>.Instance.砖块行进速度增益;
            if (启用砖块行进速度增益)
            {
                SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
                simCellOccupier.strengthMultiplier = 1f;//强度系数
                simCellOccupier.movementSpeedMultiplier = SingletonOptions<控制台>.Instance.砖上行进速度;
            }
        }
    }
    [HarmonyPatch(typeof(StorageTileConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 储存砖行进速度
    {
        private static void Postfix(GameObject go)
        {
            bool 启用砖块行进速度增益 = SingletonOptions<控制台>.Instance.砖块行进速度增益;
            if (启用砖块行进速度增益)
            {
                SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
                simCellOccupier.strengthMultiplier = 1f;//强度系数
                simCellOccupier.movementSpeedMultiplier = SingletonOptions<控制台>.Instance.砖上行进速度;
            }
        }
    }
    [HarmonyPatch(typeof(FarmTileConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 土培砖行进速度
    {
        private static void Postfix(GameObject go)
        {
            bool 启用砖块行进速度增益 = SingletonOptions<控制台>.Instance.砖块行进速度增益;
            if (启用砖块行进速度增益)
            {
                SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
                simCellOccupier.strengthMultiplier = 1f;//强度系数
                simCellOccupier.movementSpeedMultiplier = SingletonOptions<控制台>.Instance.砖上行进速度;
            }
        }
    }
    [HarmonyPatch(typeof(HydroponicFarmConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    public class 液培砖行进速度
    {
        private static void Postfix(GameObject go)
        {
            bool 启用砖块行进速度增益 = SingletonOptions<控制台>.Instance.砖块行进速度增益;
            if (启用砖块行进速度增益)
            {
                SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
                simCellOccupier.strengthMultiplier = 1f;//强度系数
                simCellOccupier.movementSpeedMultiplier = SingletonOptions<控制台>.Instance.砖上行进速度;
            }
        }
    }
    [HarmonyPatch(typeof(Db))]
    [HarmonyPatch("Initialize")]
    public class 砖上行进速度
    {
        private static void Prefix()
        {
            bool 启用砖块行进速度增益 = SingletonOptions<控制台>.Instance.砖块行进速度增益;
            if (启用砖块行进速度增益)
            {
                DUPLICANTSTATS.MOVEMENT.NEUTRAL = SingletonOptions<控制台>.Instance.砖上行进速度;

                DUPLICANTSTATS.MOVEMENT.BONUS_1 = SingletonOptions<控制台>.Instance.砖上行进速度;
                DUPLICANTSTATS.MOVEMENT.BONUS_2 = SingletonOptions<控制台>.Instance.砖上行进速度;
                DUPLICANTSTATS.MOVEMENT.BONUS_3 = SingletonOptions<控制台>.Instance.砖上行进速度;
                DUPLICANTSTATS.MOVEMENT.BONUS_4 = SingletonOptions<控制台>.Instance.砖上行进速度;

                DUPLICANTSTATS.MOVEMENT.PENALTY_1 = SingletonOptions<控制台>.Instance.砖上行进速度;
                DUPLICANTSTATS.MOVEMENT.PENALTY_2 = SingletonOptions<控制台>.Instance.砖上行进速度;
                DUPLICANTSTATS.MOVEMENT.PENALTY_3 = SingletonOptions<控制台>.Instance.砖上行进速度;
                DUPLICANTSTATS.MOVEMENT.PENALTY_4 = SingletonOptions<控制台>.Instance.砖上行进速度;
            }
        }
    }
}

