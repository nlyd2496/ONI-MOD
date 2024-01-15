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
    public class A37GG1_KZQ : KMonoBehaviour, ISingleSliderControl, ISliderControl
    {
        public float GetSliderMin(int index) => 0;//最小值
        public float GetSliderMax(int index) => 100;//最大值
        public int SliderDecimalPlaces(int index) => 0;//小数点
        public string SliderUnits => STRINGS.UI.UNITSUFFIXES.格;//单位
        public string SliderTitleKey => "STRINGS.UI.UNITSUFFIXES.控制器";//窗口名称
        public string GetSliderTooltip(int index) => STRINGS.UI.UNITSUFFIXES.点这里;//滑块空名称 
        //--------------------------
        [Serialize] public float AA = 10f;//AA参数默认值
        //--------------------------
        [MyCmpReq] public KBatchedAnimController a37gg1;
        internal void Update() 
        {
            this.a37gg1.animHeight = this.AA;//将conduitConsumer.capacityKG的值设置为CS
            this.a37gg1.animWidth = this.AA;//将conduitConsumer.capacityKG的值设置为CS
        }
        //将AA的值赋予源功能组件
            public float GetSliderValue(int index) => this.AA;
        public string GetSliderTooltipKey(int index) => "";//空
        [MyCmpAdd] public CopyBuildingSettings copyBuildingSettings;
        protected override void OnSpawn() { base.OnSpawn(); this.Update(); }
        public void SetSliderValue(float value, int index) { this.AA = value; this.Update(); }
        protected override void OnPrefabInit() { base.OnPrefabInit(); base.Subscribe(-905833192, new Action<object>(this.OnCopySettings)); }
        internal void OnCopySettings(object data) { var component = ((GameObject)data).GetComponent<A37GG1_KZQ>(); if (component == null) return; AA = component.AA; Update(); }
        //--------------------------
    }
    [HarmonyPatch(typeof(Building), "OnSpawn")]
    public class 修改高度
    {
        public static void Postfix(Building __instance)
        {
            string[] array = new string[]
            {
                "A37GG1"
            };
            bool flag = __instance.name.Contains(array[0]);
            bool flag2 = flag;
            bool flag3 = flag2;
            if (flag3)
            {
                __instance.gameObject.GetComponent<KBatchedAnimController>().animHeight = 1f;
                __instance.gameObject.GetComponent<KBatchedAnimController>().animWidth = 1f;
            }
        }
    }
}
