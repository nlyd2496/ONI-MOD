using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    [HarmonyPatch(typeof(IceSculptureConfig))]
    [HarmonyPatch("CreateBuildingDef")]
    public static class 超级冰雕
    {
        private static BuildingDef Postfix(BuildingDef def)
        {
            bool 超级冰雕 = SingletonOptions<控制台>.Instance.超级冰雕;
            if (超级冰雕)
            {
                string[] construction_materials = new string[]
                {

                    "Plastic"
                };
                def.MaterialCategory = construction_materials;
            }
            return def;
        }
    }
}
