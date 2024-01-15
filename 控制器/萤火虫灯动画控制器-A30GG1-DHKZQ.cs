using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 吐泡泡的小鱼的缺氧模组.控制器
{
    public class A30GG1_DHKZQ : GameStateMachine<A30GG1_DHKZQ, A30GG1_DHKZQ.Instance>
    {
        public override void InitializeStates(out StateMachine.BaseState default_state)
        {
            default_state = this.off;
            this.off.PlayAnim("off").EventTransition(GameHashes.OperationalChanged, this.working_pre, (A30GG1_DHKZQ.Instance smi) => smi.GetComponent<Operational>().IsOperational);
            this.working_pre.PlayAnim("working_pre").OnAnimQueueComplete(this.working_loop);
            this.working_loop.PlayAnim("working_loop", KAnim.PlayMode.Loop).EventTransition(GameHashes.OperationalChanged, this.off, (A30GG1_DHKZQ.Instance smi) => !smi.GetComponent<Operational>().IsOperational).ToggleStatusItem(Db.Get().BuildingStatusItems.EmittingLight, null).Enter("SetActive", delegate (A30GG1_DHKZQ.Instance smi)
            {
                smi.GetComponent<Operational>().SetActive(true, false);
            });
        }
        public GameStateMachine<A30GG1_DHKZQ, A30GG1_DHKZQ.Instance, IStateMachineTarget, object>.State off;
        public GameStateMachine<A30GG1_DHKZQ, A30GG1_DHKZQ.Instance, IStateMachineTarget, object>.State working_pre;
        public GameStateMachine<A30GG1_DHKZQ, A30GG1_DHKZQ.Instance, IStateMachineTarget, object>.State working_loop;
        public class Def : StateMachine.BaseDef
        {
        }
        public new class Instance : GameStateMachine<A30GG1_DHKZQ, A30GG1_DHKZQ.Instance, IStateMachineTarget, object>.GameInstance
        {
            public Instance(IStateMachineTarget master, A30GG1_DHKZQ.Def def) : base(master, def)
            {
            }
        }
    }
}
