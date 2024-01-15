using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.动物
{
    //--------------------------
    [HarmonyPatch(typeof(CrabConfig))]
    [HarmonyPatch("CreateCrab")]
    public static class 抛壳蟹生命值修改A
    {
        private static bool 斯巴达300螃蟹 = SingletonOptions<控制台>.Instance.斯巴达300螃蟹;

        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> list = new List<CodeInstruction>(instructions);
            for (int i = 0; i < list.Count; i++)
            {
                bool flag = list[i].opcode == OpCodes.Ldc_R4 && (float)list[i].operand == 25f && list[i + 1].opcode == OpCodes.Ldarg_1;

                if (flag)
                {
                    if (斯巴达300螃蟹)
                    {
                        list[i].operand = 666f;
                    }
                }
            }
            return list.AsEnumerable<CodeInstruction>();
        }
    }
    //--------------------------
    [HarmonyPatch(typeof(CrabFreshWaterConfig))]
    [HarmonyPatch("CreateCrabFreshWater")]
    public static class 抛砂蟹生命值修改A
    {
        private static bool 斯巴达300螃蟹 = SingletonOptions<控制台>.Instance.斯巴达300螃蟹;

        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> list = new List<CodeInstruction>(instructions);
            for (int i = 0; i < list.Count; i++)
            {
                bool flag = list[i].opcode == OpCodes.Ldc_R4 && (float)list[i].operand == 25f && list[i + 1].opcode == OpCodes.Ldarg_1;

                if (flag)
                {
                    if (斯巴达300螃蟹)
                    {
                        list[i].operand = 666f;
                    }
                }
            }
            return list.AsEnumerable<CodeInstruction>();
        }
    }
    //--------------------------
    [HarmonyPatch(typeof(CrabWoodConfig))]
    [HarmonyPatch("CreateCrabWood")]
    public static class 抛木蟹生命值修改A
    {
        private static bool 斯巴达300螃蟹 = SingletonOptions<控制台>.Instance.斯巴达300螃蟹;

        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> list = new List<CodeInstruction>(instructions);
            for (int i = 0; i < list.Count; i++)
            {
                bool flag = list[i].opcode == OpCodes.Ldc_R4 && (float)list[i].operand == 25f && list[i + 1].opcode == OpCodes.Ldarg_1;

                if (flag)
                {
                    if (斯巴达300螃蟹)
                    {
                        list[i].operand = 666f;
                    }
                }
            }
            return list.AsEnumerable<CodeInstruction>();
        }
    }
    //--------------------------
    [HarmonyPatch(typeof(BaseCrabConfig))]
    [HarmonyPatch("BaseCrab")]
    public static class 螃蟹攻击力_攻击对象个数_攻击范围设置
    {
        public static void Postfix(GameObject __result)
        {
            bool 斯巴达300螃蟹 = SingletonOptions<控制台>.Instance.斯巴达300螃蟹;
            if (斯巴达300螃蟹)
            {
                __result.AddWeapon(30f, 60f, AttackProperties.DamageType.Standard, AttackProperties.TargetType.AreaOfEffect, 2, 1f);
            }
        }
    }
}
