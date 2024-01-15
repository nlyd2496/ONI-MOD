using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.火箭
{
    [HarmonyPatch(typeof(LiquidFuelTankClusterConfig), "CreateBuildingDef")]
    public class 火箭燃料仓输入更改_谨以此纪念我第一个模组
    {
        public static void Postfix(ref BuildingDef __result)
        {
            bool 火箭燃料仓输入更改 = SingletonOptions<控制台>.Instance.火箭燃料仓输入更改;
            if (火箭燃料仓输入更改)
            {
                __result.UtilityInputOffset = new CellOffset(0, 2);
            }
        }
    }
}
