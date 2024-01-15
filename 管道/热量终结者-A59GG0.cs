using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using TUNING;
using Database;
using STRINGS;
using KSerialization;

namespace 吐泡泡的小鱼的缺氧模组.管道
{
    



    [SerializationConfig(MemberSerialization.OptIn)]
    [AddComponentMenu("KMonoBehaviour/scripts/A59GG0")]
    public class A59GG0 : KMonoBehaviour, ISaveLoadable, IGameObjectEffectDescriptor, ISim200ms
    {
        // Token: 0x1700016D RID: 365
        // (get) Token: 0x06001EE9 RID: 7913 RVA: 0x000A6FC7 File Offset: 0x000A51C7
        // (set) Token: 0x06001EEA RID: 7914 RVA: 0x000A6FCF File Offset: 0x000A51CF
        public float lastEnvTemp { get; private set; }

        // Token: 0x1700016E RID: 366
        // (get) Token: 0x06001EEB RID: 7915 RVA: 0x000A6FD8 File Offset: 0x000A51D8
        // (set) Token: 0x06001EEC RID: 7916 RVA: 0x000A6FE0 File Offset: 0x000A51E0
        public float lastGasTemp { get; private set; }

        // Token: 0x1700016F RID: 367
        // (get) Token: 0x06001EED RID: 7917 RVA: 0x000A6FE9 File Offset: 0x000A51E9
        public float TargetTemperature
        {
            get
            {
                return this.targetTemperature;
            }
        }

        // Token: 0x06001EEE RID: 7918 RVA: 0x000A6FF1 File Offset: 0x000A51F1
        protected override void OnPrefabInit()
        {
            base.OnPrefabInit();
            base.Subscribe<A59GG0>(-592767678, A59GG0.OnOperationalChangedDelegate);
            base.Subscribe<A59GG0>(824508782, A59GG0.OnActiveChangedDelegate);
        }

        // Token: 0x06001EEF RID: 7919 RVA: 0x000A701C File Offset: 0x000A521C
        protected override void OnSpawn()
        {
            base.OnSpawn();
            GameScheduler.Instance.Schedule("InsulationTutorial", 2f, delegate (object obj)
            {
                Tutorial.Instance.TutorialMessage(Tutorial.TutorialMessages.TM_Insulation, true);
            }, null, null);
            this.structureTemperature = GameComps.StructureTemperatures.GetHandle(base.gameObject);
            this.cooledAirOutputCell = this.building.GetUtilityOutputCell();
        }

        // Token: 0x06001EF0 RID: 7920 RVA: 0x000A708C File Offset: 0x000A528C
        public void Sim200ms(float dt)
        {
            if (this.operational != null && !this.operational.IsOperational)
            {
                this.operational.SetActive(false, false);
                return;
            }
            this.UpdateState(dt);
        }

        // Token: 0x06001EF1 RID: 7921 RVA: 0x000A70BE File Offset: 0x000A52BE
        private static bool UpdateStateCb(int cell, object data)
        {
            A59GG0 A59GG0 = data as A59GG0;
            A59GG0.cellCount++;
            A59GG0.envTemp += Grid.Temperature[cell];
            return true;
        }

        // Token: 0x06001EF2 RID: 7922 RVA: 0x000A70EC File Offset: 0x000A52EC
        private void UpdateState(float dt)
        {
            bool value = this.consumer.IsSatisfied;
            this.envTemp = 0f;
            this.cellCount = 0;
            if (this.occupyArea != null && base.gameObject != null)
            {
                this.occupyArea.TestArea(Grid.PosToCell(base.gameObject), this, A59GG0.UpdateStateCbDelegate);
                this.envTemp /= (float)this.cellCount;
            }
            this.lastEnvTemp = this.envTemp;
            List<GameObject> items = this.storage.items;
            for (int i = 0; i < items.Count; i++)
            {
                PrimaryElement component = items[i].GetComponent<PrimaryElement>();
                if (component.Mass > 0f && (!this.isLiquidConditioner || !component.Element.IsGas) && (this.isLiquidConditioner || !component.Element.IsLiquid))
                {
                    value = true;
                    this.lastGasTemp = component.Temperature;
                    float num = component.Temperature + this.temperatureDelta;
                    if (num < 1f)
                    {
                        num = 1f;
                        this.lowTempLag = Mathf.Min(this.lowTempLag + dt / 5f, 1f);
                    }
                    else
                    {
                        this.lowTempLag = Mathf.Min(this.lowTempLag - dt / 5f, 0f);
                    }
                    float num2 = (this.isLiquidConditioner ? Game.Instance.liquidConduitFlow : Game.Instance.gasConduitFlow).AddElement(this.cooledAirOutputCell, component.ElementID, component.Mass, num, component.DiseaseIdx, component.DiseaseCount);
                    component.KeepZeroMassObject = true;
                    float num3 = num2 / component.Mass;
                    int num4 = (int)((float)component.DiseaseCount * num3);
                    component.Mass -= num2;
                    component.ModifyDiseaseCount(-num4, "AirConditioner.UpdateState");
                    float num5 = (num - component.Temperature) * component.Element.specificHeatCapacity * num2;
                    float display_dt = (this.lastSampleTime > 0f) ? (Time.time - this.lastSampleTime) : 1f;
                    this.lastSampleTime = Time.time;
                    GameComps.StructureTemperatures.ProduceEnergy(this.structureTemperature, -num5 * 0, BUILDING.STATUSITEMS.OPERATINGENERGY.PIPECONTENTS_TRANSFER, display_dt);
                    break;
                }
            }
            if (Time.time - this.lastSampleTime > 2f)
            {
                GameComps.StructureTemperatures.ProduceEnergy(this.structureTemperature, 0f, BUILDING.STATUSITEMS.OPERATINGENERGY.PIPECONTENTS_TRANSFER, Time.time - this.lastSampleTime);
                this.lastSampleTime = Time.time;
            }
            this.operational.SetActive(value, false);
            this.UpdateStatus();
        }

        // Token: 0x06001EF3 RID: 7923 RVA: 0x000A7390 File Offset: 0x000A5590
        private void OnOperationalChanged(object data)
        {
            if (this.operational.IsOperational)
            {
                this.UpdateState(0f);
            }
        }

        // Token: 0x06001EF4 RID: 7924 RVA: 0x000A73AA File Offset: 0x000A55AA
        private void OnActiveChanged(object data)
        {
            this.UpdateStatus();
        }

        // Token: 0x06001EF5 RID: 7925 RVA: 0x000A73B4 File Offset: 0x000A55B4
        private void UpdateStatus()
        {
            if (this.operational.IsActive)
            {
                if (this.lowTempLag >= 1f && !this.showingLowTemp)
                {
                    this.statusHandle = (this.isLiquidConditioner ? this.selectable.SetStatusItem(Db.Get().StatusItemCategories.Main, Db.Get().BuildingStatusItems.CoolingStalledColdLiquid, this) : this.selectable.SetStatusItem(Db.Get().StatusItemCategories.Main, Db.Get().BuildingStatusItems.CoolingStalledColdGas, this));
                    this.showingLowTemp = true;
                    this.showingHotEnv = false;
                    return;
                }
                if (this.lowTempLag <= 0f && (this.showingHotEnv || this.showingLowTemp))
                {
                    this.statusHandle = this.selectable.SetStatusItem(Db.Get().StatusItemCategories.Main, Db.Get().BuildingStatusItems.Cooling, null);
                    this.showingLowTemp = false;
                    this.showingHotEnv = false;
                    return;
                }
                if (this.statusHandle == Guid.Empty)
                {
                    this.statusHandle = this.selectable.SetStatusItem(Db.Get().StatusItemCategories.Main, Db.Get().BuildingStatusItems.Cooling, null);
                    this.showingLowTemp = false;
                    this.showingHotEnv = false;
                    return;
                }
            }
            else
            {
                this.statusHandle = this.selectable.SetStatusItem(Db.Get().StatusItemCategories.Main, null, null);
            }
        }

        // Token: 0x06001EF6 RID: 7926 RVA: 0x000A7528 File Offset: 0x000A5728
        public List<Descriptor> GetDescriptors(GameObject go)
        {
            List<Descriptor> list = new List<Descriptor>();
            string formattedTemperature = GameUtil.GetFormattedTemperature(this.temperatureDelta, GameUtil.TimeSlice.None, GameUtil.TemperatureInterpretation.Relative, true, false);
            Element element = ElementLoader.FindElementByName(this.isLiquidConditioner ? "Water" : "Oxygen");
            float num;
            if (this.isLiquidConditioner)
            {
                num = Mathf.Abs(this.temperatureDelta * element.specificHeatCapacity * 0f);
            }
            else
            {
                num = Mathf.Abs(this.temperatureDelta * element.specificHeatCapacity * 0f);
            }
            float dtu = num * 1f;
            Descriptor item = default(Descriptor);
            string txt = string.Format(this.isLiquidConditioner ? UI.BUILDINGEFFECTS.HEATGENERATED_LIQUIDCONDITIONER : UI.BUILDINGEFFECTS.HEATGENERATED_AIRCONDITIONER, GameUtil.GetFormattedHeatEnergy(dtu, GameUtil.HeatEnergyFormatterUnit.Automatic), GameUtil.GetFormattedTemperature(Mathf.Abs(this.temperatureDelta), GameUtil.TimeSlice.None, GameUtil.TemperatureInterpretation.Relative, true, false));
            string tooltip = string.Format(this.isLiquidConditioner ? UI.BUILDINGEFFECTS.TOOLTIPS.HEATGENERATED_LIQUIDCONDITIONER : UI.BUILDINGEFFECTS.TOOLTIPS.HEATGENERATED_AIRCONDITIONER, GameUtil.GetFormattedHeatEnergy(dtu, GameUtil.HeatEnergyFormatterUnit.Automatic), GameUtil.GetFormattedTemperature(Mathf.Abs(this.temperatureDelta), GameUtil.TimeSlice.None, GameUtil.TemperatureInterpretation.Relative, true, false));
            item.SetupDescriptor(txt, tooltip, Descriptor.DescriptorType.Effect);
            list.Add(item);
            Descriptor item2 = default(Descriptor);
            item2.SetupDescriptor(string.Format(this.isLiquidConditioner ? UI.BUILDINGEFFECTS.LIQUIDCOOLING : UI.BUILDINGEFFECTS.GASCOOLING, formattedTemperature), string.Format(this.isLiquidConditioner ? UI.BUILDINGEFFECTS.TOOLTIPS.LIQUIDCOOLING : UI.BUILDINGEFFECTS.TOOLTIPS.GASCOOLING, formattedTemperature), Descriptor.DescriptorType.Effect);
            list.Add(item2);
            return list;
        }

        // Token: 0x040011A4 RID: 4516
        [MyCmpReq]
        private KSelectable selectable;

        // Token: 0x040011A5 RID: 4517
        [MyCmpReq]
        protected Storage storage;

        // Token: 0x040011A6 RID: 4518
        [MyCmpReq]
        protected Operational operational;

        // Token: 0x040011A7 RID: 4519
        [MyCmpReq]
        private ConduitConsumer consumer;

        // Token: 0x040011A8 RID: 4520
        [MyCmpReq]
        private BuildingComplete building;

        // Token: 0x040011A9 RID: 4521
        [MyCmpGet]
        private OccupyArea occupyArea;

        // Token: 0x040011AA RID: 4522
        private HandleVector<int>.Handle structureTemperature;

        // Token: 0x040011AB RID: 4523
        public float temperatureDelta = -14f;

        // Token: 0x040011AC RID: 4524
        public float maxEnvironmentDelta = -50f;

        // Token: 0x040011AD RID: 4525
        private float lowTempLag;

        // Token: 0x040011AE RID: 4526
        private bool showingLowTemp;

        // Token: 0x040011AF RID: 4527
        public bool isLiquidConditioner;

        // Token: 0x040011B0 RID: 4528
        private bool showingHotEnv;

        // Token: 0x040011B3 RID: 4531
        private Guid statusHandle;

        // Token: 0x040011B4 RID: 4532
        [Serialize]
        private float targetTemperature;

        // Token: 0x040011B5 RID: 4533
        private int cooledAirOutputCell = -1;

        // Token: 0x040011B6 RID: 4534
        private static readonly EventSystem.IntraObjectHandler<A59GG0> OnOperationalChangedDelegate = new EventSystem.IntraObjectHandler<A59GG0>(delegate (A59GG0 component, object data)
        {
            component.OnOperationalChanged(data);
        });

        // Token: 0x040011B7 RID: 4535
        private static readonly EventSystem.IntraObjectHandler<A59GG0> OnActiveChangedDelegate = new EventSystem.IntraObjectHandler<A59GG0>(delegate (A59GG0 component, object data)
        {
            component.OnActiveChanged(data);
        });

        // Token: 0x040011B8 RID: 4536
        private float lastSampleTime = -1f;

        // Token: 0x040011B9 RID: 4537
        private float envTemp;

        // Token: 0x040011BA RID: 4538
        private int cellCount;

        // Token: 0x040011BB RID: 4539
        private static readonly Func<int, object, bool> UpdateStateCbDelegate = (int cell, object data) => A59GG0.UpdateStateCb(cell, data);
    }
}
