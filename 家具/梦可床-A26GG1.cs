using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    [HarmonyPatch(typeof(BedConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    internal class 梦可床
    {
        private static BuildingDef Postfix(BuildingDef def)
        {
            bool 梦可床 = SingletonOptions<控制台>.Instance.梦可床;
            if (梦可床)
            {
                def.AnimFiles = new KAnimFile[]
                {
                    Assets.GetAnim("A26GG1_kanim")
                 };
            }
            return def;
        }
    }
}
