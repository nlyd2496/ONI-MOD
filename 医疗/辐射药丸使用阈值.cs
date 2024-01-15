using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using Klei.AI;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;
using Newtonsoft.Json;

namespace 吐泡泡的小鱼的缺氧模组.医疗
{
    [HarmonyPatch(typeof(MedicinalPillWorkable), "CanBeTakenBy")]
    public static class 辐射药丸使用阈值
    {
        public static void Postfix(ref bool __result, ref MedicinalPill ___pill, GameObject consumer)
        {
            bool 辐射药丸使用阈值 = SingletonOptions<控制台>.Instance.辐射药丸使用阈值;
            if (辐射药丸使用阈值)
            {
                if (___pill.info.id == "BasicRadPill")
                {
                    if (consumer.GetAmounts().Get(Db.Get().Amounts.RadiationBalance.Id).value < SingletonOptions<控制台>.Instance.辐射药丸阈值)
                    {
                        __result = false;
                    }
                }
            }
        }
    }
}
