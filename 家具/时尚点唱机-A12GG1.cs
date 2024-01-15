using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    [HarmonyPatch(typeof(PhonoboxConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public class 点唱机功率修改
    {
        public static void Postfix(PhonoboxConfig __instance, ref BuildingDef __result)
        {
            bool 启用点唱机 = SingletonOptions<控制台>.Instance.点唱机;
            if (启用点唱机)
            {
                __result.EnergyConsumptionWhenActive = SingletonOptions<控制台>.Instance.点唱机功率修改;
            }
        }
    }
    [HarmonyPatch(typeof(PhonoboxConfig), "CreateBuildingDef")]
    public class 点唱机贴图更换
    {
        private static BuildingDef Postfix(BuildingDef def)
        {
            bool 启用点唱机 = SingletonOptions<控制台>.Instance.点唱机;
            if (启用点唱机)
            {
                int widthInCells = 3;
                def.WidthInCells = widthInCells;
                def.AnimFiles = new KAnimFile[]
                {
                    Assets.GetAnim("A12GG1_kanim")
                };
                def.GenerateOffsets();
            } 
            return def;
        }
    }
}
