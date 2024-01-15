using KSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.控制器
{
    //------------------------------------------------------------xx------------------------------------------------------------
    public class A78GG1_KZQ : KMonoBehaviour, ISingleSliderControl, ISliderControl
    {
        public int SliderDecimalPlaces(int index) => 0;//小数点
        public float GetSliderMin(int index) => 20;//最小值
        public float GetSliderMax(int index) => 200;//最大值
        public string SliderTitleKey => "STRINGS.UI.UNITSUFFIXES.控制器";//窗口名称
        public string GetSliderTooltip(int index) => STRINGS.UI.UNITSUFFIXES.点这里;//滑块名称
        public string SliderUnits => STRINGS.UI.UNITSUFFIXES.千克;//单位
        //--------------------------
        [MyCmpReq] public SuitTank suitTank;//添加源功能组件1
        //--------------------------
        [Serialize] public float AA = 40f;//AA参数默认值
        //--------------------------
        internal void Update() { this.suitTank.capacity = this.AA; }//将AA的值赋予源功能组件
        //--------------------------
        //以下内容无需更改
        public float GetSliderValue(int index) => this.AA;
        public string GetSliderTooltipKey(int index) => "";//空
        [MyCmpAdd] public CopyBuildingSettings copyBuildingSettings;
        protected override void OnSpawn() { base.OnSpawn(); this.Update(); }
        public void SetSliderValue(float value, int index) { this.AA = value; this.Update(); }
        protected override void OnPrefabInit() { base.OnPrefabInit(); base.Subscribe(-905833192, new Action<object>(this.OnCopySettings)); }
        internal void OnCopySettings(object data) { var component = ((GameObject)data).GetComponent<A78GG1_KZQ>(); if (component == null) return; AA = component.AA; Update(); }
        //--------------------------
    }
    //------------------------------------------------------------xx------------------------------------------------------------
    public class A78GG2_KZQ : KMonoBehaviour, ISingleSliderControl, ISliderControl
    {
        public int SliderDecimalPlaces(int index) => 0;//小数点
        public float GetSliderMin(int index) => 100;//最小值
        public float GetSliderMax(int index) => 1000;//最大值
        public string SliderTitleKey => "STRINGS.UI.UNITSUFFIXES.控制器";//窗口名称
        public string GetSliderTooltip(int index) => STRINGS.UI.UNITSUFFIXES.点这里;//滑块名称
        public string SliderUnits => STRINGS.UI.UNITSUFFIXES.千克;//单位
        //--------------------------
        [MyCmpReq] public SuitTank suitTank;//添加源功能组件1
        //--------------------------
        [Serialize] public float AA = 100f;//AA参数默认值
        //--------------------------
        internal void Update() { this.suitTank.capacity = this.AA; }//将AA的值赋予源功能组件
        //--------------------------
        //以下内容无需更改
        public float GetSliderValue(int index) => this.AA;
        public string GetSliderTooltipKey(int index) => "";//空
        [MyCmpAdd] public CopyBuildingSettings copyBuildingSettings;
        protected override void OnSpawn() { base.OnSpawn(); this.Update(); }
        public void SetSliderValue(float value, int index) { this.AA = value; this.Update(); }
        protected override void OnPrefabInit() { base.OnPrefabInit(); base.Subscribe(-905833192, new Action<object>(this.OnCopySettings)); }
        internal void OnCopySettings(object data) { var component = ((GameObject)data).GetComponent<A78GG2_KZQ>(); if (component == null) return; AA = component.AA; Update(); }
        //--------------------------
    }
    //------------------------------------------------------------xx------------------------------------------------------------
    public class A78GG3_KZQ : KMonoBehaviour, ISingleSliderControl, ISliderControl
    {
        public int SliderDecimalPlaces(int index) => 0;//小数点
        public float GetSliderMin(int index) => 100;//最小值
        public float GetSliderMax(int index) => 1000;//最大值
        public string SliderTitleKey => "STRINGS.UI.UNITSUFFIXES.控制器";//窗口名称
        public string GetSliderTooltip(int index) => STRINGS.UI.UNITSUFFIXES.点这里;//滑块名称
        public string SliderUnits => STRINGS.UI.UNITSUFFIXES.千克;//单位
        //--------------------------
        [MyCmpReq] public SuitTank suitTank;//添加源功能组件1
        //--------------------------
        [Serialize] public float AA = 100f;//AA参数默认值
        //--------------------------
        internal void Update() { this.suitTank.capacity = this.AA; }//将AA的值赋予源功能组件
        //--------------------------
        //以下内容无需更改
        public float GetSliderValue(int index) => this.AA;
        public string GetSliderTooltipKey(int index) => "";//空
        [MyCmpAdd] public CopyBuildingSettings copyBuildingSettings;
        protected override void OnSpawn() { base.OnSpawn(); this.Update(); }
        public void SetSliderValue(float value, int index) { this.AA = value; this.Update(); }
        protected override void OnPrefabInit() { base.OnPrefabInit(); base.Subscribe(-905833192, new Action<object>(this.OnCopySettings)); }
        internal void OnCopySettings(object data) { var component = ((GameObject)data).GetComponent<A78GG3_KZQ>(); if (component == null) return; AA = component.AA; Update(); }
        //--------------------------
    }
    //------------------------------------------------------------xx------------------------------------------------------------
    public class A78GG4_KZQ : KMonoBehaviour, ISingleSliderControl, ISliderControl
    {
        public int SliderDecimalPlaces(int index) => 0;//小数点
        public float GetSliderMin(int index) => 100;//最小值
        public float GetSliderMax(int index) => 1000;//最大值
        public string SliderTitleKey => "STRINGS.UI.UNITSUFFIXES.控制器";//窗口名称
        public string GetSliderTooltip(int index) => STRINGS.UI.UNITSUFFIXES.点这里;//滑块名称
        public string SliderUnits => STRINGS.UI.UNITSUFFIXES.千克;//单位
        //--------------------------
        [MyCmpReq] public SuitTank suitTank;//添加源功能组件1
        //--------------------------
        [Serialize] public float AA = 100f;//AA参数默认值
        //--------------------------
        internal void Update() { this.suitTank.capacity = this.AA; }//将AA的值赋予源功能组件
        //--------------------------
        //以下内容无需更改
        public float GetSliderValue(int index) => this.AA;
        public string GetSliderTooltipKey(int index) => "";//空
        [MyCmpAdd] public CopyBuildingSettings copyBuildingSettings;
        protected override void OnSpawn() { base.OnSpawn(); this.Update(); }
        public void SetSliderValue(float value, int index) { this.AA = value; this.Update(); }
        protected override void OnPrefabInit() { base.OnPrefabInit(); base.Subscribe(-905833192, new Action<object>(this.OnCopySettings)); }
        internal void OnCopySettings(object data) { var component = ((GameObject)data).GetComponent<A78GG4_KZQ>(); if (component == null) return; AA = component.AA; Update(); }
        //--------------------------
    }
    //------------------------------------------------------------xx------------------------------------------------------------
}
