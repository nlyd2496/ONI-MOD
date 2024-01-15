using HarmonyLib;
using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.基础属性
{
    [HarmonyPatch("OnResearchClicked")]
    [HarmonyPatch(typeof(ResearchEntry))]
    internal class 无需研究
    {
        public static void Postfix()
        {
            bool 无需研究 = SingletonOptions<控制台>.Instance.无需研究;
            if (无需研究)
            {
                for (int i = 0; i < Db.Get().Techs.Count; i++)
                {
                    Tech tech = Db.Get().Techs[i];
                    if (!tech.IsComplete())
                    {
                        foreach (KeyValuePair<string, float> keyValuePair in tech.costsByResearchTypeID)
                        {
                            Research.Instance.AddResearchPoints(keyValuePair.Key, keyValuePair.Value);
                        }
                    }
                }
            }
            
        }
    }

}
