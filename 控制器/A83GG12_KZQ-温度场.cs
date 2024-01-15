using KSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.实用;

namespace 吐泡泡的小鱼的缺氧模组.控制器
{
    public class A83GG1_KZQ : KMonoBehaviour, IDualSliderControl
    {
        public float[] sliderMax = { 32, 32 };
        public float[] sliderMin = { 1, 1 };
        public int SliderDecimalPlaces(int index) => 0;//小数位
        public string SliderUnits => STRINGS.UI.UNITSUFFIXES.格;//单位
        public string GetSliderTooltipKey(int index)
        {
            switch (index)
            {
                case 0:
                    return "STRINGS.UI.UNITSUFFIXES.宽";//第一个滑条的名称
                case 1:
                    return "STRINGS.UI.UNITSUFFIXES.高";//第二个滑条的名称
                default:
                    return "";
            }
        }
        public string SliderTitleKey => "STRINGS.UI.UNITSUFFIXES.控制器";//窗口名称
        //--------------------------
        [Serialize] public int AA = 2;//默认值
        [Serialize] public int BB = 2;//默认值
        [MyCmpReq] public A83GG0 a83gg0;//链接建筑功能控制器
        [MyCmpReq] public RangeVisualizer rangeVisualizer;
        private void UpdateRange()
        {
            this.a83gg0.effectWidth = AA;
            this.a83gg0.effectHeight = BB;
            //--------------------------
            this.rangeVisualizer.RangeMin.x = -this.a83gg0.effectWidth / 2;
            this.rangeVisualizer.RangeMin.y = -this.a83gg0.effectHeight / 2;
            this.rangeVisualizer.RangeMax.x = this.a83gg0.effectWidth / 2;
            this.rangeVisualizer.RangeMax.y = this.a83gg0.effectHeight / 2;
            //--------------------------
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
        private void OnCopySettings(object data) { var component = ((GameObject)data).GetComponent<A83GG1_KZQ>(); if (component == null) return; AA = component.AA; BB = component.BB; UpdateRange(); }
    }









    public class A83GG2_KZQ : KMonoBehaviour, ISingleSliderControl, ISliderControl
    {
        public int SliderDecimalPlaces(int index) => 1;//小数点
        public float GetSliderMin(int index) => -270;//最小值
        public float GetSliderMax(int index) => 3000;//最大值
        public string SliderTitleKey => "STRINGS.UI.UNITSUFFIXES.控制器";//窗口名称
        public string GetSliderTooltip(int index) => STRINGS.UI.UNITSUFFIXES.点这里;//滑块名称
        public string SliderUnits => STRINGS.UI.UNITSUFFIXES.摄氏度;//单位
        //--------------------------                                                        
        [Serialize] public float AA = 26f;
        [MyCmpReq] public A83GG0 a83gg0;
        internal void Update() { this.a83gg0.targetTemperature = this.AA + 273.15f; }//将AA的值赋予源功能组件
        //--------------------------
        public float GetSliderValue(int index) => this.AA;
        public string GetSliderTooltipKey(int index) => "";//空
        [MyCmpAdd] public CopyBuildingSettings copyBuildingSettings;
        protected override void OnSpawn() { base.OnSpawn(); this.Update(); }
        public void SetSliderValue(float value, int index) { this.AA = value; this.Update(); }
        protected override void OnPrefabInit() { base.OnPrefabInit(); base.Subscribe(-905833192, new Action<object>(this.OnCopySettings)); }
        internal void OnCopySettings(object data) { var component = ((GameObject)data).GetComponent<A83GG2_KZQ>(); if (component == null) return; AA = component.AA; Update(); }
        //--------------------------
    }
}
