using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.基础属性
{
    [HarmonyPatch(typeof(MinionResume))]
    [HarmonyPatch("AddExperience")]
    public class 高速经验
    {
        private static bool Prefix(MinionStartingStats __instance, ref float amount)
        {
            bool 高速经验 = SingletonOptions<控制台>.Instance.高速经验;
            if (高速经验)
            {
                amount = SingletonOptions<控制台>.Instance.经验加成倍数 * 0.1f;
            }
            return true;
        }
    }
}
