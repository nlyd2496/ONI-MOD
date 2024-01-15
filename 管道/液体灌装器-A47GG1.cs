using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.控制器;

namespace 吐泡泡的小鱼的缺氧模组.管道
{
    public class A47GG1 : IBuildingConfig
    {
        //----------------------------------------------------------------------------------------------------------
        public override BuildingDef CreateBuildingDef()
        {
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("A47GG1", 3, 2, "A47GG1_kanim", 100, 120f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER4, MATERIALS.ALL_METALS, 800f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.PENALTY.TIER1, NOISE_POLLUTION.NOISY.TIER0, 0.2f);
            buildingDef.InputConduitType = ConduitType.Liquid;
            buildingDef.Floodable = false;
            buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
            buildingDef.AudioCategory = "HollowMetal";
            buildingDef.UtilityInputOffset = new CellOffset(0, 0);
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.LiquidVentIDs, "LiquidBottler");
            //--------------------------
            if (控制台.Instance.液体灌装器) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        //----------------------------------------------------------------------------------------------------------
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
            storage.showDescriptor = true;
            storage.storageFilters = STORAGEFILTERS.LIQUIDS;
            storage.capacityKg = 50f;
            storage.allowItemRemoval = false;
            go.AddOrGet<DropAllWorkable>().removeTags = new List<Tag>
        {
            GameTags.LiquidSource
        };
            A47GG0 A47GG0 = go.AddOrGet<A47GG0>();
            A47GG0.storage = storage;
            A47GG0.workTime = 9f;
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.storage = storage;
            conduitConsumer.conduitType = ConduitType.Liquid;
            conduitConsumer.ignoreMinMassCheck = true;
            conduitConsumer.forceAlwaysSatisfied = true;
            conduitConsumer.alwaysConsume = true;
            conduitConsumer.capacityKG = 50f;
            conduitConsumer.keepZeroMassObject = false;
            go.AddOrGet<A47GG1_KZQ>();
        }
        //----------------------------------------------------------------------------------------------------------
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.GetComponent<KPrefabID>().AddTag(GameTags.OverlayBehindConduits, false);
        }
        //----------------------------------------------------------------------------------------------------------
        public const string ID = "A47GG1";
        //----------------------------------------------------------------------------------------------------------
    }
    [AddComponentMenu("KMonoBehaviour/Workable/A47GG0")]
    public class A47GG0 : Workable
    {
        protected override void OnSpawn()
        {
            base.OnSpawn();
            this.smi = new A47GG0.Controller.Instance(this);
            this.smi.StartSM();
            this.UpdateStoredItemState();
        }
        protected override void OnCleanUp()
        {
            if (this.smi != null)
            {
                this.smi.StopSM("OnCleanUp");
            }
            base.OnCleanUp();
        }
        private void UpdateStoredItemState()
        {
            this.storage.allowItemRemoval = (this.smi != null && this.smi.GetCurrentState() == this.smi.sm.ready);
            foreach (GameObject gameObject in this.storage.items)
            {
                if (gameObject != null)
                {
                    gameObject.Trigger(-778359855, this.storage);
                }
            }
        }
        public Storage storage;
        private A47GG0.Controller.Instance smi;
        private class Controller : GameStateMachine<A47GG0.Controller, A47GG0.Controller.Instance, A47GG0>
        {
            public override void InitializeStates(out StateMachine.BaseState default_state)
            {
                default_state = this.empty;
                this.empty.PlayAnim("off").EventTransition(GameHashes.OnStorageChange, this.filling, (A47GG0.Controller.Instance smi) => smi.master.storage.IsFull());
                this.filling.PlayAnim("working").OnAnimQueueComplete(this.ready);
                this.ready.EventTransition(GameHashes.OnStorageChange, this.pickup, (A47GG0.Controller.Instance smi) => !smi.master.storage.IsFull()).Enter(delegate (A47GG0.Controller.Instance smi)
                {
                    smi.master.storage.allowItemRemoval = true;
                    foreach (GameObject gameObject in smi.master.storage.items)
                    {
                        gameObject.GetComponent<KPrefabID>().AddTag(GameTags.GasSource, false);
                        gameObject.Trigger(-778359855, smi.master.storage);
                    }
                }).Exit(delegate (A47GG0.Controller.Instance smi)
                {
                    smi.master.storage.allowItemRemoval = false;
                    foreach (GameObject go in smi.master.storage.items)
                    {
                        go.Trigger(-778359855, smi.master.storage);
                    }
                });
                this.pickup.PlayAnim("pick_up").OnAnimQueueComplete(this.empty);
            }
            public GameStateMachine<A47GG0.Controller, A47GG0.Controller.Instance, A47GG0, object>.State empty;
            public GameStateMachine<A47GG0.Controller, A47GG0.Controller.Instance, A47GG0, object>.State filling;
            public GameStateMachine<A47GG0.Controller, A47GG0.Controller.Instance, A47GG0, object>.State ready;
            public GameStateMachine<A47GG0.Controller, A47GG0.Controller.Instance, A47GG0, object>.State pickup;
            public new class Instance : GameStateMachine<A47GG0.Controller, A47GG0.Controller.Instance, A47GG0, object>.GameInstance
            {
                public Instance(A47GG0 master) : base(master)
                {
                }
            }
        }
    }
}
