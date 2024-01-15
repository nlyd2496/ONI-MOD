using HarmonyLib;
using KSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.控制器
{
    public class A69GG1_KZQ : KMonoBehaviour, IDualSliderControl
    {
        //------------------------------------------------------------------------------------------------
        public float[] sliderMax = { 32, 32 };                                      
        public float[] sliderMin = { 1, 1 }; 
        public int SliderDecimalPlaces(int index) => 0;//小数位
        public string SliderUnits => STRINGS.UI.UNITSUFFIXES.空;//单位
        public string GetSliderTooltipKey(int index)
        {
            switch (index)
            {
                case 0:
                    return "STRINGS.UI.UNITSUFFIXES.长";//第一个滑条的名称
                case 1:
                    return "STRINGS.UI.UNITSUFFIXES.能量";//第二个滑条的名称
                default:
                    return "";
            }
        }
        public string SliderTitleKey => "STRINGS.UI.UNITSUFFIXES.控制器";//窗口名称
        //--------------------------
        [Serialize] public int AA = 2;//默认值
        [Serialize] public int BB = 2;//默认值
        [MyCmpReq] public RadiationEmitter radiationEmitter;
        private void UpdateRange() 
        { 
            this.radiationEmitter.emitRadiusX = (short)AA; 
            this.radiationEmitter.emitRads = BB;
        }
        //--------------------------
        public float GetSliderMax(int index) => sliderMax[index];
        public float GetSliderMin(int index) => sliderMin[index];
        [MyCmpAdd] public CopyBuildingSettings copyBuildingSettings;
        protected override void OnSpawn() { base.OnSpawn(); UpdateRange(); }
        public string GetSliderTooltip(int index) => Strings.Get(GetSliderTooltipKey(index));
        protected override void OnPrefabInit() { base.OnPrefabInit(); Subscribe((int)GameHashes.CopySettings, OnCopySettings); }
        public float GetSliderValue(int index) { switch (index) { case 0: return AA; case 1: return BB; default: throw new ArgumentException("Invalid index"); } }
        public void SetSliderValue(float percent, int index) { switch (index) { case 0: AA = Convert.ToInt32(percent); break; case 1: BB = Convert.ToInt32(percent); break; } UpdateRange(); }
        private void OnCopySettings(object data) { var component = ((GameObject)data).GetComponent<A69GG1_KZQ>(); if (component == null) return; AA = component.AA; BB = component.BB; UpdateRange(); }
    }
    /*
    [HarmonyPatch(typeof(DualSliderSideScreen), "SetTarget")] 
    public static class 双滑条控制器组件
    { public static void Prefix(DualSliderSideScreen __instance, GameObject new_target) { if (new_target.GetComponent<A69GG1_KZQ>() == null) return; var sliderSets = __instance.sliderSets; for (var i = 0; i < sliderSets.Count; i++) { sliderSets[i].index = i; } } }
*/
}
