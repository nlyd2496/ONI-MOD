using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PeterHan.PLib.Options;

namespace 吐泡泡的小鱼的缺氧模组.火箭
{
    /*
    [HarmonyPatch(typeof(ScoutRoverConfig))]
    [HarmonyPatch("CreatePrefab")]
    public static class 侦查者电量修改
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> list = new List<CodeInstruction>(instructions);
            for (int i = 0; i < list.Count; i++)
            {
                // 查找加载MooTuning.STANDARD_LIFESPAN的指令
                bool flag = list[i].opcode == OpCodes.Ldsfld && list[i].operand is FieldInfo field && field.Name == "BATTERY_CAPACITY";
                if (flag)
                {
                    // 将其替换为加载100f的指令者
                    list[i] = new CodeInstruction(OpCodes.Ldc_R4, SingletonOptions<控制台>.Instance.侦查者电量修改);
                }
            }
            return list.AsEnumerable<CodeInstruction>();
        }
    }
    */
    [HarmonyPatch(typeof(ScoutRoverConfig))]
    [HarmonyPatch("CreatePrefab")]
    public static class 侦察者电量增加A
    {
        // 定义一个布尔变量来存储超级辐射粒子引擎的状态
        private static bool 侦察者电量增加 = SingletonOptions<控制台>.Instance.侦察者电量增加;

        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> list = new List<CodeInstruction>(instructions);
            for (int i = 0; i < list.Count; i++)
            {
                // 查找加载MooTuning.STANDARD_LIFESPAN的指令
                bool flag = list[i].opcode == OpCodes.Ldsfld && list[i].operand is FieldInfo field && field.Name == "BATTERY_CAPACITY";
                if (flag)
                {
                    // 如果超级辐射粒子引擎开启，将其替换为加载1000000f的指令
                    // 否则保持原来的指令
                    if (侦察者电量增加)
                    {
                        list[i] = new CodeInstruction(OpCodes.Ldc_R4, SingletonOptions<控制台>.Instance.侦查者电量修改);
                    }
                }
            }
            return list.AsEnumerable<CodeInstruction>();
        }
    }
}
