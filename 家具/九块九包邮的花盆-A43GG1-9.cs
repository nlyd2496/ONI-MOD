using Database;
using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    [HarmonyPatch(typeof(BuildingFacades), MethodType.Constructor, new Type[] { typeof(ResourceSet) })]
    public static class 蓝图系统A43GG1
    {
        public static void Postfix(BuildingFacades __instance)
        {
            bool 九块九包邮的花盆 = SingletonOptions<控制台>.Instance.九块九包邮的花盆;
            if (九块九包邮的花盆)
            {
                __instance.Add("A43GG1",
                STRINGS.BUILDINGS.PREFABS.A43GG1.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT, PermitRarity.Universal,
                "FLOWERVASE", "A43GG1_kanim", null);

                __instance.Add("A43GG2",
               STRINGS.BUILDINGS.PREFABS.A43GG2.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT, PermitRarity.Universal,
               "FLOWERVASE", "A43GG2_kanim", null);

                __instance.Add("A43GG3",
               STRINGS.BUILDINGS.PREFABS.A43GG3.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT, PermitRarity.Universal,
               "FLOWERVASE", "A43GG3_kanim", null);

                __instance.Add("A43GG4",
               STRINGS.BUILDINGS.PREFABS.A43GG4.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT, PermitRarity.Universal,
               "FLOWERVASE", "A43GG4_kanim", null);

                __instance.Add("A43GG5",
               STRINGS.BUILDINGS.PREFABS.A43GG5.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT, PermitRarity.Universal,
               "FLOWERVASE", "A43GG5_kanim", null);

                __instance.Add("A43GG6",
               STRINGS.BUILDINGS.PREFABS.A43GG6.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT, PermitRarity.Universal,
               "FLOWERVASE", "A43GG6_kanim", null);

                __instance.Add("A43GG7",
               STRINGS.BUILDINGS.PREFABS.A43GG7.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT, PermitRarity.Universal,
               "FLOWERVASE", "A43GG7_kanim", null);

                __instance.Add("A43GG8",
               STRINGS.BUILDINGS.PREFABS.A43GG8.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT, PermitRarity.Universal,
               "FLOWERVASE", "A43GG8_kanim", null);
            }
        }
    }
}
