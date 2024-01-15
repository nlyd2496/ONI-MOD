using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.管道
{
    //------------------------------------------------------------------------------------------------------------------------
    //液体调节阀
    [HarmonyPatch(typeof(LiquidValveConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 液体调节阀可穿墙
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 管道阀可穿墙 = SingletonOptions<控制台>.Instance.管道阀可穿墙;
            if (管道阀可穿墙)
            {
                __result.BuildLocationRule = BuildLocationRule.Conduit;
            }
        }
    }
    //------------------------------------------------------------------------------------------------------------------------
    //液体开关阀
    [HarmonyPatch(typeof(LiquidLogicValveConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 液体开关阀可穿墙
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 管道阀可穿墙 = SingletonOptions<控制台>.Instance.管道阀可穿墙;
            if (管道阀可穿墙)
            {
                __result.BuildLocationRule = BuildLocationRule.Conduit;
            }
        }
    }
    //------------------------------------------------------------------------------------------------------------------------
    //液体计量阀
    [HarmonyPatch(typeof(LiquidLimitValveConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 液体计量阀可穿墙
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 管道阀可穿墙 = SingletonOptions<控制台>.Instance.管道阀可穿墙;
            if (管道阀可穿墙)
            {
                __result.BuildLocationRule = BuildLocationRule.Conduit;
            }
        }
    }
    //------------------------------------------------------------------------------------------------------------------------
    //气体调节阀
    [HarmonyPatch(typeof(GasValveConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 气体调节阀可穿墙
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 管道阀可穿墙 = SingletonOptions<控制台>.Instance.管道阀可穿墙;
            if (管道阀可穿墙)
            {
                __result.BuildLocationRule = BuildLocationRule.Conduit;
            }
        }
    }
    //------------------------------------------------------------------------------------------------------------------------
    //气体开关阀
    [HarmonyPatch(typeof(GasLogicValveConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 气体开关阀可穿墙
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 管道阀可穿墙 = SingletonOptions<控制台>.Instance.管道阀可穿墙;
            if (管道阀可穿墙)
            {
                __result.BuildLocationRule = BuildLocationRule.Conduit;
            }
        }
    }
    //------------------------------------------------------------------------------------------------------------------------
    //气体计量阀
    [HarmonyPatch(typeof(GasLimitValveConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 气体计量阀可穿墙
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 管道阀可穿墙 = SingletonOptions<控制台>.Instance.管道阀可穿墙;
            if (管道阀可穿墙)
            {
                __result.BuildLocationRule = BuildLocationRule.Conduit;
            }
        }
    }
    //------------------------------------------------------------------------------------------------------------------------
}
