using System;
using HarmonyLib;
using KMod;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;
using UnityEngine.Diagnostics;

namespace 吐泡泡的小鱼的缺氧模组
{
	public class ModLoad : UserMod2
	{
        public static string Namespace { get; private set; }
        public override void OnLoad(Harmony harmony)
		{
            //--------------------------
            base.OnLoad(harmony);
            ModLoad.Namespace = base.GetType().Namespace;
            //--------------------------
            //参数控制器组件
            //LocString.CreateLocStringKeys(typeof(UII), "STRINGS.");
            //--------------------------
            //配置项组件
            //new POptions().RegisterOptions(this, typeof(TestModSettings));
            PUtil.InitLibrary(true);
            new POptions().RegisterOptions(this, typeof(控制台));
            //--------------------------
            Namespace = base.GetType().Namespace;
            //--------------------------
        }
        [HarmonyPatch(typeof(Localization), "Initialize")]
        private class 添加翻译组件
        {
            public static void Postfix()
            {
                Utils.Localize(typeof(STRINGS));
            }
        }
    }
}