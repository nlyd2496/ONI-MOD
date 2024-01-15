using KSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.控制器
{
    public class A18GG1_KZQ : KMonoBehaviour, ISingleSliderControl, ISliderControl
    {
        public float GetSliderMin(int index) => 0;//最小值
        public float GetSliderMax(int index) => 1000;//最大值
        public int SliderDecimalPlaces(int index) => 0;//小数点
        public string SliderUnits => STRINGS.UI.UNITSUFFIXES.勒克斯;//单位
        public string SliderTitleKey => "STRINGS.UI.UNITSUFFIXES.控制器";//窗口名称
        public string GetSliderTooltip(int index) => STRINGS.UI.UNITSUFFIXES.点这里;//滑块空名称 
        //--------------------------
        [Serialize] public float AA = 100f;//AA参数默认值
        //--------------------------
        [MyCmpReq] public EnergyConsumer energyConsumer;//能量
        [MyCmpReq] public Light2D light2D;//灯
        internal void Update() { this.light2D.Lux = (int)this.AA; this.energyConsumer.BaseWattageRating = this.energyConsumer.WattsNeededWhenActive * 0.001f * AA; }//将AA的值赋予源功能组件
        //--------------------------
        //以下内容无需更改
        public float GetSliderValue(int index) => this.AA;
        public string GetSliderTooltipKey(int index) => "";//空
        [MyCmpAdd] public CopyBuildingSettings copyBuildingSettings;
        protected override void OnSpawn() { base.OnSpawn(); this.Update(); }
        public void SetSliderValue(float value, int index) { this.AA = value; this.Update(); }
        protected override void OnPrefabInit() { base.OnPrefabInit(); base.Subscribe(-905833192, new Action<object>(this.OnCopySettings)); }
        internal void OnCopySettings(object data) { var component = ((GameObject)data).GetComponent<A18GG1_KZQ>(); if (component == null) return; AA = component.AA; Update(); }
        //--------------------------
    }
}
