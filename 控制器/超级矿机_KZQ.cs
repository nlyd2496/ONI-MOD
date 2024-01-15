using KSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.控制器
{
    public class A74GG1_KZQ : KMonoBehaviour, IDualSliderControl
    {
        //------------------------------------------------------------------------------------------------
        public float[] sliderMax = { 64, 64 };
        public float[] sliderMin = { 1, 1 };
        public int SliderDecimalPlaces(int index) => 0;//小数位
        public string SliderUnits => STRINGS.UI.UNITSUFFIXES.格;//单位
        public string GetSliderTooltipKey(int index)
        {
            switch (index)
            {
                case 0:
                    return "STRINGS.UI.UNITSUFFIXES.高";//第一个滑条的名称
                case 1:
                    return "STRINGS.UI.UNITSUFFIXES.宽";//第二个滑条的名称
                default:
                    return "";
            }
        }
        public string SliderTitleKey => "STRINGS.UI.UNITSUFFIXES.控制器";//窗口名称
        //--------------------------
        [Serialize] public int AA = 6;//默认值
        [Serialize] public int BB = 6;//默认值

        [MyCmpReq] public AutoMiner autoMiner;
        [MyCmpReq] public RangeVisualizer rangeVisualizer;
        [MyCmpReq] public EnergyConsumer energyConsumer;//接入原始能量控制程序
        private void UpdateRange()
        {
            autoMiner.height = AA;//建筑功能1接受AA的值
            autoMiner.width = BB;//建筑功能2接受BB的值
            //--------------------------
            //范围显示更新
            this.autoMiner.x = -this.autoMiner.width / 2 + 1;
            this.rangeVisualizer.RangeMin.x = -this.autoMiner.width / 2 + 1;
            this.rangeVisualizer.RangeMin.y = -1;
            this.rangeVisualizer.RangeMax.x = this.rangeVisualizer.RangeMin.x + this.autoMiner.width - 1;
            this.rangeVisualizer.RangeMax.y = this.autoMiner.height - 2;
            //--------------------------
            //能量更新
            this.energyConsumer.BaseWattageRating = 0.8f * this.AA * this.BB;
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
        private void OnCopySettings(object data) { var component = ((GameObject)data).GetComponent<A74GG1_KZQ>(); if (component == null) return; AA = component.AA; BB = component.BB; UpdateRange(); }
    }
}
