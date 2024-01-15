using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.A_基地
{
    public class 气动门
    {
        [HarmonyPatch(typeof(DoorConfig))]
        [HarmonyPatch("CreateBuildingDef")]
        public class 建筑材料
        {
            private static BuildingDef Postfix(BuildingDef def)
            {
                bool A002GG1 = SingletonOptions<控制台>.Instance.A002GG1;
                if (A002GG1)
                {
                    string[] construction_materials = new string[]
                    {
                        "BuildableAny"//全材料建造
                    };
                    def.MaterialCategory = construction_materials;
                }
                return def;
            }
        }
        [HarmonyPatch(typeof(DoorConfig))]
        [HarmonyPatch("DoPostConfigureComplete")]
        public class 开关速度
        {
            private static void Postfix(GameObject go)
            {
                bool A002GG1 = SingletonOptions<控制台>.Instance.A002GG1;
                if (A002GG1)
                {
                    Door door = go.AddOrGet<Door>();
                    door.unpoweredAnimSpeed = 5f;//无电速度
                    door.poweredAnimSpeed = 10f;//有电速度
                    go.AddOrGet<Workable>().workTime = 5f;//工作时间
                }
            }
        }
    }
    public class 手动气闸
    {
        [HarmonyPatch(typeof(ManualPressureDoorConfig))]
        [HarmonyPatch("CreateBuildingDef")]
        public class 建筑材料
        {
            private static BuildingDef Postfix(BuildingDef def)
            {
                bool A002GG1 = SingletonOptions<控制台>.Instance.A002GG1;
                if (A002GG1)
                {
                    string[] construction_materials = new string[]
                    {
                        "BuildableAny"//全材料建造
                    };
                    def.MaterialCategory = construction_materials;
                }
                return def;
            }
        }
        [HarmonyPatch(typeof(ManualPressureDoorConfig))]
        [HarmonyPatch("DoPostConfigureComplete")]
        public class 开关速度
        {
            private static void Postfix(GameObject go)
            {
                bool A002GG1 = SingletonOptions<控制台>.Instance.A002GG1;
                if (A002GG1)
                {
                    Door door = go.AddOrGet<Door>();
                    door.unpoweredAnimSpeed = 5f;//无电速度
                    door.poweredAnimSpeed = 10f;//有电速度
                }
            }
        }
    }
    public class 机械气闸
    {
        [HarmonyPatch(typeof(PressureDoorConfig))]
        [HarmonyPatch("CreateBuildingDef")]
        public class 建筑材料
        {
            private static BuildingDef Postfix(BuildingDef def)
            {
                bool A002GG1 = SingletonOptions<控制台>.Instance.A002GG1;
                if (A002GG1)
                {
                    string[] construction_materials = new string[]
                    {
                        "BuildableAny"//全材料建造
                    };
                    def.MaterialCategory = construction_materials;
                }
                return def;
            }
        }
        [HarmonyPatch(typeof(PressureDoorConfig))]
        [HarmonyPatch("DoPostConfigureComplete")]
        public class 开关速度
        {
            private static void Postfix(GameObject go)
            {
                bool A002GG1 = SingletonOptions<控制台>.Instance.A002GG1;
                if (A002GG1)
                {
                    Door door = go.AddOrGet<Door>();
                    door.unpoweredAnimSpeed = 5f;//无电速度
                    door.poweredAnimSpeed = 10f;//有电速度
                }
            }
        }
    }
    public class 地堡门
    {
        [HarmonyPatch(typeof(BunkerDoorConfig))]
        [HarmonyPatch("CreateBuildingDef")]
        public class 建筑材料
        {
            private static BuildingDef Postfix(BuildingDef def)
            {
                bool A002GG1 = SingletonOptions<控制台>.Instance.A002GG1;
                if (A002GG1)
                {
                    string[] construction_materials = new string[]
                    {
                        "BuildableAny"//全材料建造
                    };
                    def.MaterialCategory = construction_materials;
                }
                return def;
            }
        }
        [HarmonyPatch(typeof(BunkerDoorConfig))]
        [HarmonyPatch("DoPostConfigureComplete")]
        public class 开关速度
        {
            private static void Postfix(GameObject go)
            {
                bool A002GG1 = SingletonOptions<控制台>.Instance.A002GG1;
                if (A002GG1)
                {
                    Door door = go.AddOrGet<Door>();
                    door.unpoweredAnimSpeed = 5f;//无电速度
                    door.poweredAnimSpeed = 10f;//有电速度
                    go.AddOrGet<Workable>().workTime = 5f;//工作时间
                }
            }
        }
    }
}
