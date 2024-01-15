using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.管道
{
    [HarmonyPatch(typeof(ShowerConfig), "CreateBuildingDef")]
    public static class 二乘三的淋浴间
    {
        public static BuildingDef Postfix(BuildingDef def)
        {
            bool 二乘三的淋浴间 = SingletonOptions<控制台>.Instance.二乘三的淋浴间;
            if (二乘三的淋浴间)
            {
                int heightInCells = 2;
                def.HeightInCells = heightInCells;
                def.AnimFiles = new KAnimFile[]
                   {
                    Assets.GetAnim("A44GG1_kanim")
                   };
                def.GenerateOffsets();
            }
            return def;
        }
    }
}
