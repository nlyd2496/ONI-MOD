using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.医疗
{
    [HarmonyPatch(typeof(MassageTableConfig))]
    [HarmonyPatch("ConfigureBuildingTemplate")]
    public class 高效按摩床
    {
        public static void Postfix(GameObject go)
        {
            bool 高效按摩床 = SingletonOptions<控制台>.Instance.高效按摩床;
            if (高效按摩床)
            {
                MassageTable massageTable = go.AddOrGet<MassageTable>();
                massageTable.stressModificationValue = SingletonOptions<控制台>.Instance.按摩床压力消除率 * 10;
                massageTable.roomStressModificationValue = SingletonOptions<控制台>.Instance.按摩床压力消除率 * 10;
            }
        }
    }
}
