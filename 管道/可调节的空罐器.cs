using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.控制器;

namespace 吐泡泡的小鱼的缺氧模组.管道
{
    [HarmonyPatch(typeof(BottleEmptierGasConfig), "ConfigureBuildingTemplate")]
    public static class 可调节的气体空罐器
    {
        public static void Postfix(GameObject go)
        {
            bool 可调节的空罐器 = SingletonOptions<控制台>.Instance.可调节的空罐器;
            if (可调节的空罐器)
            {
                go.AddOrGet<Storage>().capacityKg = 1000000f;
                go.AddOrGet<A57GG1_KZQ>();
            }
        }
    }
    [HarmonyPatch(typeof(BottleEmptierConfig), "ConfigureBuildingTemplate")]
    public static class 可调节的液体空罐器
    {
        public static void Postfix(GameObject go)
        {
            bool 可调节的空罐器 = SingletonOptions<控制台>.Instance.可调节的空罐器;
            if (可调节的空罐器)
            {
                go.AddOrGet<Storage>().capacityKg = 1000000f;
                go.AddOrGet<A57GG2_KZQ>();
            }
        }
    }
}
