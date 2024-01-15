using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.管道
{
    [HarmonyPatch(typeof(FlushToiletConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 绝命毒师
    {
        public static void Postfix(GameObject go)
        {
            bool 绝命毒师 = SingletonOptions<控制台>.Instance.绝命毒师;
            if (绝命毒师)
            {
                go.AddOrGet<FlushToilet>().diseasePerFlush = 0;//每次重洗的疾病
                go.AddOrGet<FlushToilet>().diseaseOnDupePerFlush = 1000000;//每次使用产生多少个食物中毒细菌
            }
        }
    }
}
