using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.管道
{
    [HarmonyPatch(typeof(Game))]
    [HarmonyPatch("OnPrefabInit")]
    public class 超级管道
    {
        public static void Postfix(Game __instance)
        {
            bool 超级管道 = SingletonOptions<控制台>.Instance.超级管道;
            if (超级管道)
            {
                __instance.liquidConduitFlow = new ConduitFlow(ConduitType.Liquid, Grid.CellCount, __instance.liquidConduitSystem, SingletonOptions<控制台>.Instance.液体管道容量, 0.1f);//液管容量
                __instance.liquidFlowVisualizer = new ConduitFlowVisualizer(__instance.liquidConduitFlow, __instance.liquidConduitVisInfo, GlobalResources.Instance().ConduitOverlaySoundLiquid, Lighting.Instance.Settings.LiquidConduit);//液管液体流动可视化
                __instance.gasConduitFlow = new ConduitFlow(ConduitType.Gas, Grid.CellCount, __instance.gasConduitSystem, SingletonOptions<控制台>.Instance.气体管道容量, 0.1f);//气管容量
                __instance.gasFlowVisualizer = new ConduitFlowVisualizer(__instance.gasConduitFlow, __instance.gasConduitVisInfo, GlobalResources.Instance().ConduitOverlaySoundGas, Lighting.Instance.Settings.GasConduit);//气管气体流动可视化
            }
        }
        
    }
}
