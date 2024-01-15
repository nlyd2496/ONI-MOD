using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.基础属性
{
    [HarmonyPatch(typeof(SpeedControlScreen))]
    [HarmonyPatch("OnChanged")]
    internal class 游戏加速
    {
        private static bool ChangeTimeScale(SpeedControlScreen __instance, ref bool __result)
        {
            bool 游戏加速 = SingletonOptions<控制台>.Instance.游戏加速;
            if (游戏加速)
            {
                if (__instance.IsPaused)
                {
                    Time.timeScale = 0f;
                    return false;
                }
                switch (__instance.GetSpeed())
                {
                    case 0:
                        Time.timeScale = 1f;
                        break;
                    case 1:
                        Time.timeScale = 3f;
                        break;
                    case 2:
                        Time.timeScale = 6f;
                        break;
                    default:
                        Time.timeScale = 1f;
                        break;
                }
            }
            return true; // 返回原方法的返回值
        }
    }

}
