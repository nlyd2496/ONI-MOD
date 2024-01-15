using Database;
using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.运输
{
    [HarmonyPatch(typeof(BuildingFacades), MethodType.Constructor, new Type[] { typeof(ResourceSet) })]
    public static class 蓝图系统A75GG1
    {
        public static void Postfix(BuildingFacades __instance)
        {
            bool 超次元矿机 = SingletonOptions<控制台>.Instance.超次元矿机;
            if (超次元矿机)
            {
                __instance.Add("A75GG1",
                STRINGS.BUILDINGS.PREFABS.A75GG1.NAME, STRINGS.BUILDINGS.PREFABS.A75GG1.EFFECT, PermitRarity.Universal,
                "AutoMiner", "A75GG1_kanim", null);
            }
        }
    }
}
