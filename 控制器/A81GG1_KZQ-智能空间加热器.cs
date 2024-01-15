using KSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.控制器
{
    public class A81GG1_KZQ : KMonoBehaviour, ISingleSliderControl, ISliderControl
    {
        public int SliderDecimalPlaces(int index) => 1;//小数点
        public float GetSliderMin(int index) => -200;//最小值
        public float GetSliderMax(int index) => 200;//最大值
        public string SliderTitleKey => "STRINGS.UI.UNITSUFFIXES.控制器";//窗口名称
        public string GetSliderTooltip(int index) => STRINGS.UI.UNITSUFFIXES.点这里;//滑块名称
        public string SliderUnits => STRINGS.UI.UNITSUFFIXES.摄氏度;//单位
        //--------------------------                                                        
        [Serialize] public float AA = 40f;
        [MyCmpReq] public SpaceHeater spaceHeater;
        internal void Update() { this.spaceHeater.targetTemperature = this.AA + 273.15f; }//将AA的值赋予源功能组件
        //--------------------------
        public float GetSliderValue(int index) => this.AA;
        public string GetSliderTooltipKey(int index) => "";//空
        [MyCmpAdd] public CopyBuildingSettings copyBuildingSettings;
        protected override void OnSpawn() { base.OnSpawn(); this.Update(); }
        public void SetSliderValue(float value, int index) { this.AA = value; this.Update(); }
        protected override void OnPrefabInit() { base.OnPrefabInit(); base.Subscribe(-905833192, new Action<object>(this.OnCopySettings)); }
        internal void OnCopySettings(object data) { var component = ((GameObject)data).GetComponent<A81GG1_KZQ>(); if (component == null) return; AA = component.AA; Update(); }
        //--------------------------
    }
}
