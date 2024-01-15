using Database;
using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.自动化
{
    [HarmonyPatch(typeof(BuildingFacades), MethodType.Constructor, new Type[] { typeof(ResourceSet) })]
    public static class 蓝图系统A73GG1
    {
        public static void Postfix(BuildingFacades __instance)
        {
            bool 闹钟 = SingletonOptions<控制台>.Instance.闹钟;
            if (闹钟)
            {
                __instance.Add("A73GG1",
                STRINGS.BUILDINGS.PREFABS.A73GG1.NAME, STRINGS.BUILDINGS.PREFABS.A73GG1.EFFECT, PermitRarity.Universal,
                "LogicTimeOfDaySensor", "A73GG1_kanim", null);
            }
        }
    }
}
