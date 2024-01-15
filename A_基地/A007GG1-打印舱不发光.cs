using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.A_基地
{

    //打印舱灯光设置
    [HarmonyPatch(typeof(HeadquartersConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public static class 打印舱灯光设置
    {
        public static void Postfix(ref GameObject go)
        {
            bool A007GG1 = SingletonOptions<控制台>.Instance.A007GG1;
            if (A007GG1)
            {
                Light2D light2D = go.AddOrGet<Light2D>();
                light2D.Range = 0;
                light2D.Lux = 0;
            }
        }
    }


    //迷你舱灯光设置
    [HarmonyPatch(typeof(ExobaseHeadquartersConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public static class 迷你舱灯光设置
    {
        public static void Postfix(ref GameObject go)
        {
            bool A007GG1 = SingletonOptions<控制台>.Instance.A007GG1;
            if (A007GG1)
            {
                Light2D light2D = go.AddOrGet<Light2D>();
                light2D.Range = 0;
                light2D.Lux = 0;
            }
        }
    }
}
