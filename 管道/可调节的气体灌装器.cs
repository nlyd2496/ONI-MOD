﻿using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.控制器;

namespace 吐泡泡的小鱼的缺氧模组.管道
{
    [HarmonyPatch(typeof(GasBottlerConfig), "ConfigureBuildingTemplate")]
    public static class 可调节的气体灌装器
    {

        public static void Postfix(GameObject go)
        {
            bool 可调节的气体灌装器 = SingletonOptions<控制台>.Instance.可调节的气体灌装器;
            if (可调节的气体灌装器)
            {
                go.AddOrGet<A56GG1_KZQ>();//将CSKZMM20230828GG1的功能添加到GasBottlerConfig中
            }
        }
    }
}
