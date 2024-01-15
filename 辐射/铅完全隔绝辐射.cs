using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.辐射
{
    [HarmonyPatch(typeof(ElementLoader), "CopyEntryToElement")]
    public class 铅完全阻隔辐射
    {
        private static void Prefix(ref ElementLoader.ElementEntry entry, ref Element elem)
        {
            bool 铅完全阻隔辐射 = SingletonOptions<控制台>.Instance.铅完全隔绝辐射;
            if (铅完全阻隔辐射)
            {
                if (entry.elementId == "Lead") { entry.radiationAbsorptionFactor = 2f; }
            }
        }
    }
}
