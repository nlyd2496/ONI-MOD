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
    [HarmonyPatch(typeof(OuthouseConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 户外环保厕所
    {
        public static void Postfix(GameObject go)
        {
            bool 户外环保厕所 = SingletonOptions<控制台>.Instance.户外环保厕所;
            if (户外环保厕所)
            {
                //--------------------------------
                go.AddOrGet<Toilet>().solidWastePerUse = new Toilet.SpawnInfo(SimHashes.Fertilizer, 6.7f, 0f);//产出肥料
                go.AddOrGet<Toilet>().maxFlushes = 100;//使用次数100
                                                       //--------------------------------
                go.AddOrGet<ManualDeliveryKG>().capacity = 1300f;//储存容量1300

            }
        }
    }
}
