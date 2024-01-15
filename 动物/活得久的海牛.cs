using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.动物
{
    [HarmonyPatch(typeof(MooConfig))]
    [HarmonyPatch("CreateMoo")]
    public static class 活得久的海牛A
    {
        // 定义一个布尔变量来存储超级辐射粒子引擎的状态
        private static bool 活得久的海牛 = SingletonOptions<控制台>.Instance.活得久的海牛;

        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> list = new List<CodeInstruction>(instructions);
            for (int i = 0; i < list.Count; i++)
            {
                // 查找加载MooTuning.STANDARD_LIFESPAN的指令
                bool flag = list[i].opcode == OpCodes.Ldsfld && list[i].operand is FieldInfo field && field.Name == "STANDARD_LIFESPAN";
                if (flag)
                {
                    // 如果超级辐射粒子引擎开启，将其替换为加载1000000f的指令
                    // 否则保持原来的指令
                    if (活得久的海牛)
                    {
                        list[i] = new CodeInstruction(OpCodes.Ldc_R4, 1000f);
                    }
                }
            }
            return list.AsEnumerable<CodeInstruction>();
        }
    }
    /*
    [HarmonyPatch(typeof(MooConfig))]
    [HarmonyPatch("CreateMoo")]
    public static class 海牛寿命增加
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> list = new List<CodeInstruction>(instructions);
            for (int i = 0; i < list.Count; i++)
            {
                // 查找加载MooTuning.STANDARD_LIFESPAN的指令
                bool flag = list[i].opcode == OpCodes.Ldsfld && list[i].operand is FieldInfo field && field.Name == "STANDARD_LIFESPAN";
                if (flag)
                {
                    // 将其替换为加载100f的指令
                    list[i] = new CodeInstruction(OpCodes.Ldc_R4, 1000f);
                }
            }
            return list.AsEnumerable<CodeInstruction>();
        }
    }
    */
}
