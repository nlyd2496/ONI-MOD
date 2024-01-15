using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.电力
{
    [HarmonyPatch(typeof(Wire))]
    [HarmonyPatch("GetMaxWattageAsFloat")]
    public class 输电线载荷
    {
        public static void Postfix(Wire.WattageRating rating, ref float __result)
        {
            // 使用 switch-case 语句根据电压等级设置最大功率
            switch (rating)
            {
                case Wire.WattageRating.Max500:
                    __result = 500f; // 设置最大功率为 500
                    break;
                case Wire.WattageRating.Max1000:
                    __result = SingletonOptions<控制台>.Instance.电线及电线桥载荷;//电线及电线桥载荷
                    break;
                case Wire.WattageRating.Max2000:
                    __result = SingletonOptions<控制台>.Instance.导线及导线桥载荷;//导线及导线桥载荷
                    break;
                case Wire.WattageRating.Max20000:
                    __result = SingletonOptions<控制台>.Instance.高负荷电线及接线板载荷;//高负荷电线及接线板载荷
                    break;
                case Wire.WattageRating.Max50000:
                    __result = SingletonOptions<控制台>.Instance.高负荷导线及接线板载荷;//高负荷导线及接线板载荷
                    break;
                default:
                    __result = 0f; // 设置最大功率为 0
                    break;
            }
        }
    }

}
