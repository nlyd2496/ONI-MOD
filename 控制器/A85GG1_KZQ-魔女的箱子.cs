using KSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.控制器
{
    [AddComponentMenu("KMonoBehaviour/scripts/MM2023M819GG1X1")]
    //定义一个类，继承自KMonoBehaviour和IUserControlledCapacity接口
    public class A001GG1_KZQ : KMonoBehaviour, IUserControlledCapacity
    {
        //定义一个私有字段，类型为LoggerFS，用于记录日志信息
        private LoggerFS log;
        //添加序列化特性，表示该字段可以被序列化和反序列化
        [Serialize]
        //定义一个私有字段，类型为浮点数，初始值为正无穷，表示用户最大容量的默认值
        private float userMaxCapacity = float.PositiveInfinity;
        //添加序列化特性，表示该字段可以被序列化和反序列化
        [Serialize]
        //定义一个公共字段，类型为字符串，初始值为空字符串，表示储物柜的名称
        public string lockerName = "";
        //定义一个受保护的字段，类型为FilteredStorage，用于管理存储空间和过滤器
        protected FilteredStorage filteredStorage;
        //添加MyCmpGet特性，表示该字段可以从游戏对象中获取指定类型的组件
        [MyCmpGet]
        //定义一个私有字段，类型为UserNameable，用于设置游戏对象的名称
        private UserNameable nameable;
        //定义一个公共字段，类型为字符串，初始值为数据库中的StorageFetch任务类型的ID，表示任务类型的ID
        public string choreTypeID = Db.Get().ChoreTypes.StorageFetch.Id;
        //定义一个私有静态只读字段，类型为事件系统中的内部对象处理器，在声明时赋值为一个匿名方法，接受一个MM2023M819GG1X1对象和一个对象作为参数
        private static readonly EventSystem.IntraObjectHandler<A001GG1_KZQ> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<A001GG1_KZQ>(delegate (A001GG1_KZQ component, object data)
        {
            //调用component的OnCopySettings方法，传入data作为参数
            component.OnCopySettings(data);
        });

        //重写OnPrefabInit方法，在预制体初始化时调用
        protected override void OnPrefabInit()
        {
            //调用Initialize方法，传入false作为参数
            this.Initialize(false);
        }

        //定义一个受保护的方法，接受一个布尔值作为参数
        protected void Initialize(bool use_logic_meter)
        {
            //调用基类的OnPrefabInit方法
            base.OnPrefabInit();
            //创建一个LoggerFS对象，传入字符串和整数作为参数
            this.log = new LoggerFS("A001GG1_KZQ", 35);
            //从数据库中获取指定的任务类型
            ChoreType fetch_chore_type = Db.Get().ChoreTypes.Get(this.choreTypeID);
            //创建一个FilteredStorage对象，传入当前对象，空值，当前对象，布尔值和任务类型作为参数
            this.filteredStorage = new FilteredStorage(this, null, this, use_logic_meter, fetch_chore_type);
            //订阅一个事件，传入一个整数和一个委托作为参数
            base.Subscribe<A001GG1_KZQ>(-905833192, A001GG1_KZQ.OnCopySettingsDelegate);
        }

        //重写OnSpawn方法，在生成时调用
        protected override void OnSpawn()
        {
            //调用filteredStorage的FilterChanged方法，更新过滤器
            this.filteredStorage.FilterChanged();
            //如果nameable不为空且lockerName不是空白字符串
            if (this.nameable != null && !this.lockerName.IsNullOrWhiteSpace())
            {
                //调用nameable的SetName方法，传入lockerName作为参数
                this.nameable.SetName(this.lockerName);
            }
            //触发一个事件，传入一个整数和空值作为参数
            base.Trigger(-1683615038, null);
        }

        //重写OnCleanUp方法，在清理时调用
        protected override void OnCleanUp()
        {
            //调用filteredStorage的CleanUp方法，清理存储空间
            this.filteredStorage.CleanUp();
        }

        //定义一个私有方法，接受一个对象作为参数
        private void OnCopySettings(object data)
        {
            //将参数转换为游戏对象类型
            GameObject gameObject = (GameObject)data;
            //如果游戏对象为空
            if (gameObject == null)
            {
                //返回，不执行后续代码
                return;
            }
            //从游戏对象中获取StorageLocker组件
            A001GG1_KZQ component = gameObject.GetComponent<A001GG1_KZQ>();
            //如果组件为空
            if (component == null)
            {
                //返回，不执行后续代码
                return;
            }
            //将组件的UserMaxCapacity属性赋值给当前对象的UserMaxCapacity属性
            this.UserMaxCapacity = component.UserMaxCapacity;
        }

        //定义一个公共方法，接受一个标签和一个布尔值作为参数
        public void UpdateForbiddenTag(Tag game_tag, bool forbidden)
        {
            //如果布尔值为真
            if (forbidden)
            {
                //调用filteredStorage的RemoveForbiddenTag方法，传入标签作为参数，移除禁止的标签
                this.filteredStorage.RemoveForbiddenTag(game_tag);
                //返回，不执行后续代码
                return;
            }
            //调用filteredStorage的AddForbiddenTag方法，传入标签作为参数，添加禁止的标签
            this.filteredStorage.AddForbiddenTag(game_tag);
        }

        //定义一个虚拟的浮点数属性，表示用户最大容量
        public virtual float UserMaxCapacity
        {
            //定义get访问器，获取属性值时调用
            get
            {
                //返回userMaxCapacity和存储组件的capacityKg属性中较小的值
                return Mathf.Min(this.userMaxCapacity, 2000000f);
            }
            //定义set访问器，设置属性值时调用
            set
            {
                //将参数赋值给userMaxCapacity
                this.userMaxCapacity = value;
                //调用filteredStorage的FilterChanged方法，更新过滤器
                this.filteredStorage.FilterChanged();
            }
        }

        //定义一个浮点数属性，表示存储的数量
        public float AmountStored
        {
            //定义get访问器，获取属性值时调用
            get
            {
                //返回存储组件的MassStored方法的返回值，表示存储的质量
                return base.GetComponent<Storage>().MassStored();
            }
        }

        //定义一个浮点数属性，表示最小容量
        public float MinCapacity
        {
            //定义get访问器，获取属性值时调用
            get
            {
                //返回0，表示没有最小容量限制
                return 0f;
            }
        }

        //定义一个浮点数属性，表示最大容量
        public float MaxCapacity
        {
            //定义get访问器，获取属性值时调用
            get
            {
                //返回1000000，表示有很大的最大容量限制
                return 2000000f;
            }
        }

        //定义一个布尔值属性，表示是否使用整数值
        public bool WholeValues
        {
            //定义get访问器，获取属性值时调用
            get
            {
                //返回false，表示不使用整数值
                return false;
            }
        }

        //定义一个本地化字符串属性，表示容量的单位
        public LocString CapacityUnits
        {
            //定义get访问器，获取属性值时调用
            get
            {
                //返回GameUtil的GetCurrentMassUnit方法的返回值，传入false作为参数，表示使用公制单位
                return GameUtil.GetCurrentMassUnit(false);
            }
        }
    }

















    /*
    public class A001GG1_KZQ : KMonoBehaviour, IUserControlledCapacity
    {
        [MyCmpReq] public Storage storage;
        public float AmountStored { get => storage.capacityKg; }
        internal void Update() { this.storage.capacityKg = this.AA; }
        [Serialize] public float AA = 2000000f;
        public float MinCapacity { get => 0; }//最小值
        public float MaxCapacity { get => 2000000; }//最大值
        public LocString CapacityUnits { get => STRINGS.UI.UNITSUFFIXES.千克; }//单位

        [MyCmpAdd] public CopyBuildingSettings copyBuildingSettings;
        protected override void OnSpawn() { base.OnSpawn(); this.Update(); }
        protected override void OnPrefabInit() { base.OnPrefabInit(); base.Subscribe(-905833192, new Action<object>(this.OnCopySettings)); }
        internal void OnCopySettings(object data) { var component = ((GameObject)data).GetComponent<A001GG1_KZQ>(); if (component == null) return; AA = component.AA; Update(); }
        public float UserMaxCapacity { get => AA; set => AA = value; }
        public bool WholeValues { get => false; }
    }
    */
}
