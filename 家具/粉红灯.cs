using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    [HarmonyPatch(typeof(FloorLampConfig))]
    [HarmonyPatch("DoPostConfigureComplete")]
    internal class 粉红灯
    {
        private static void Postfix(GameObject go)
        {
            bool 粉红灯 = SingletonOptions<控制台>.Instance.粉红灯;
            if (粉红灯)
            {
                Light2D light2D = go.AddOrGet<Light2D>();
                light2D.Color = new Color(5f, 0f, 4f, 1f);//灯光颜色为浅粉色
                light2D.Angle = 10f;//灯光颜色渲染为圆形
            }
        }
    }
}