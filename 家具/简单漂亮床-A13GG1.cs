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
    public static class 蓝图系统A13GG1
    {
        public static void Postfix(BuildingFacades __instance)
        {
            bool 启用简单漂亮床 = SingletonOptions<控制台>.Instance.简单漂亮床;
            if (启用简单漂亮床)
            {
                __instance.Add("A13GG1",
                STRINGS.BUILDINGS.PREFABS.A13GG1.NAME, STRINGS.BUILDINGS.PREFABS.A13GG1.EFFECT, PermitRarity.Universal,
                "Bed", "A13GG1_kanim", null);
            }
        }
    }
}
