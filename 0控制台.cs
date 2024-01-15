using Newtonsoft.Json;
using PeterHan.PLib.Options;


namespace 吐泡泡的小鱼的缺氧模组
{
    [RestartRequired]
    [JsonObject(MemberSerialization.OptIn)]
    [ConfigFile("Controler.json", true, false)]
    //[ModInfo("https://github.com/nlyd2496/ONI-Mods", "mmm.png", true)]

    public class 控制台 : SingletonOptions<控制台>
    {
        [Option("无限缩放", "Amount", "基础属性")][JsonProperty] public bool 无限缩放 { get; set; } = false;

        [Option("永不过热", "Amount", "基础属性")][JsonProperty] public bool 永不过热 { get; set; } = false;
        [Option("永不淹没", "Amount", "基础属性")][JsonProperty] public bool 永不淹没 { get; set; } = false;
        /*
        [Option("万物可水平旋转选其一", "Amount", "基础属性")][JsonProperty] public bool 万物可水平旋转选其一 { get; set; } = false;
        [Option("万物可垂直旋转选其一", "Amount", "基础属性")][JsonProperty] public bool 万物可垂直旋转选其一 { get; set; } = false;
        [Option("万物可圆周旋转选其一", "Amount", "基础属性")][JsonProperty] public bool 万物可圆周旋转选其一 { get; set; } = false;
        */
        //--------------------------
        [Option("超级装饰", "Amount", "基础属性")][JsonProperty] public bool 超级装饰 { get; set; } = false;
        [Option("装饰度", "Amount", "基础属性", Format = "F0")]
        [Limit(1.0, 10.0)]
        [JsonProperty]
        public float 装饰度 { get; set; } = 10f;

        [Option("装饰半径", "Amount", "基础属性", Format = "F0")]
        [Limit(1.0, 10.0)]
        [JsonProperty]
        public float 装饰半径 { get; set; } = 10f;
        //--------------------------
        [Option("砖块行进速度增益", "Amount", "基础属性")][JsonProperty] public bool 砖块行进速度增益 { get; set; } = false;
       
        [Option("砖上行进速度", "Amount", "基础属性", Format = "F0")]
        [Limit(1.0, 10.0)]
        [JsonProperty]
        public float 砖上行进速度 { get; set; } = 5f;
        //--------------------------
        [Option("沉默喷泉", "和 永喷泉 互斥", "基础属性")][JsonProperty] public bool 沉默喷泉 { get; set; } = false;

        [Option("永喷泉", "和 沉默喷泉 互斥", "基础属性")][JsonProperty] public bool 永喷泉 { get; set; } = false;

        [Option("喷发质量倍数", "Amount", "基础属性", Format = "F0")]
        [Limit(1.0, 10.0)]
        [JsonProperty]
        public float 喷发质量倍数 { get; set; } = 5f;
        //--------------------------
        [Option("喷泉无压力反应", "Amount", "基础属性")][JsonProperty] public bool 喷泉无压力反应 { get; set; } = false;
        //--------------------------
        [Option("游戏加速", "Amount", "基础属性")][JsonProperty] public bool 游戏加速 { get; set; } = false;
        //--------------------------
        [Option("高速经验", "Amount", "基础属性")][JsonProperty] public bool 高速经验 { get; set; } = false;

        [Option("经验加成倍数", "Amount", "基础属性", Format = "F0")]
        [Limit(1.0, 10.0)]
        [JsonProperty]
        public float 经验加成倍数 { get; set; } = 5f;

        //--------------------------
        [Option("更大操作距离", "Amount", "基础属性")][JsonProperty] public bool 更大操作距离 { get; set; } = false;
        [Option("箱子隔热密封", "Amount", "基础属性")][JsonProperty] public bool 箱子隔热密封 { get; set; } = false;
        [Option("无需研究", "Amount", "基础属性")][JsonProperty] public bool 无需研究 { get; set; } = false;


        //--------------------------
        [Option("基础电池容量无穷大", "Amount", "电力")][JsonProperty] public bool 基础电池容量无穷大 { get; set; } = false;
        [Option("开发者电池", "Amount", "电力")][JsonProperty] public bool 开发者电池 { get; set; } = false;
        [Option("开发者电池输出无穷大", "Amount", "电力")][JsonProperty] public bool 开发者电池输出无穷大 { get; set; } = false;
        //--------------------------
        [Option("超级氢气发电机", "Amount", "电力")][JsonProperty] public bool 超级氢气发电机 { get; set; } = false;

        [Option("超级氢气发电机功率 W", "Amount", "电力", Format = "F0")]
        [Limit(1.0, 100000.0)]
        [JsonProperty]
        public float 超级氢气发电机功率 { get; set; } = 10000f;

        [Option("超级氢气发电机氢气消耗", "Amount", "电力")]
        [Limit(0.1, 1.0)]
        [JsonProperty]
        public float 超级氢气发电机氢气消耗 { get; set; } = 0.1f;
        //--------------------------
        [Option("南孚电池", "Amount", "电力")][JsonProperty] public bool 南孚电池 { get; set; } = false;

        [Option("南孚电池容量 W", "Amount", "电力", Format = "F0")]
        [Limit(1, 100000.0)]
        [JsonProperty]
        public float 南孚电池容量 { get; set; } = 10000f;

        [Option("南孚电池损耗 J", "Amount", "电力")]
        [Limit(0.1, 1.0)]
        [JsonProperty]
        public float 南孚电池损耗 { get; set; } = 0.1f;
        //--------------------------
        [Option("民用电池组", "Amount", "电力")][JsonProperty] public bool 民用电池组 { get; set; } = false;

        [Option("民用电池组容量 W", "Amount", "电力", Format = "F0")]
        [Limit(1, 200000.0)]
        [JsonProperty]
        public float 民用电池组容量 { get; set; } = 20000f;

        [Option("民用电池组损耗 J", "Amount", "电力")]
        [Limit(0.1, 1.0)]
        [JsonProperty]
        public float 民用电池组损耗 { get; set; } = 0.1f;
        //--------------------------
        [Option("一格电池", "Amount", "电力")][JsonProperty] public bool 一格电池 { get; set; } = false;

        [Option("一格电池容量 W", "Amount", "电力", Format = "F0")]
        [Limit(1, 50000.0)]
        [JsonProperty]
        public float 一格电池容量 { get; set; } = 5000f;

        [Option("一格电池损耗 J", "Amount", "电力")]
        [Limit(0.1, 1.0)]
        [JsonProperty]
        public float 一格电池损耗 { get; set; } = 0.1f;
        //--------------------------
        [Option("细电线", "Never overheat", "电力")][JsonProperty] public bool 细电线 { get; set; } = false;
        [Option("梦世界的电线", "Amount", "电力")][JsonProperty] public bool 梦世界的电线 { get; set; } = false;
        [Option("高负荷电线可穿墙", "Amount", "电力")][JsonProperty] public bool 高负荷电线可穿墙 { get; set; } = false;
        [Option("高负荷导线可穿墙", "Amount", "电力")][JsonProperty] public bool 高负荷导线可穿墙 { get; set; } = false;
        //--------------------------
        [Option("跨两格电线桥", "Amount", "电力")][JsonProperty] public bool 跨两格电线桥 { get; set; } = false;
        [Option("跨两格导线桥", "Amount", "电力")][JsonProperty] public bool 跨两格导线桥 { get; set; } = false;
        [Option("跨三格电线桥", "Amount", "电力")][JsonProperty] public bool 跨三格电线桥 { get; set; } = false;
        [Option("跨三格导线桥", "Amount", "电力")][JsonProperty] public bool 跨三格导线桥 { get; set; } = false;
        //--------------------------
        [Option("电线及电线桥载荷 W", "Amount", "电力", Format = "F0")]
        [Limit(1000.0, 10000.0)]
        [JsonProperty]
        public float 电线及电线桥载荷 { get; set; } = 5000f;

        [Option("导线及导线桥载荷 W", "Amount", "电力", Format = "F0")]
        [Limit(2000.0, 20000.0)]
        [JsonProperty]
        public float 导线及导线桥载荷 { get; set; } = 10000f;

        [Option("高负荷电线及接线板载荷 W", "Amount", "电力", Format = "F0")]
        [Limit(20000.0, 200000.0)]
        [JsonProperty]
        public float 高负荷电线及接线板载荷 { get; set; } = 100000f;

        [Option("高负荷导线及接线板载荷 W", "Amount", "电力", Format = "F0")]
        [Limit(50000.0, 500000.0)]
        [JsonProperty]
        public float 高负荷导线及接线板载荷 { get; set; } = 200000f;
        //--------------------------
        [Option("超级蒸汽机", "Amount", "电力")][JsonProperty] public bool 超级蒸汽机 { get; set; } = false;

        [Option("蒸汽机热量转移效率", "Amount", "电力")]
        [Limit(0, 0.1)]
        [JsonProperty]
        public float 蒸汽机热量转移效率 { get; set; } = 0.1f;

        [Option("蒸汽机吸收蒸汽最低温度 ℃", "Amount", "电力")]
        [Limit(90, 150)]
        [JsonProperty]
        public float 蒸汽机吸收蒸汽最低温度 { get; set; } = 90f;

        [Option("蒸汽机输出液体温度 ℃", "Amount", "电力")]
        [Limit(10, 80)]
        [JsonProperty]
        public float 蒸汽机输出液体温度 { get; set; } = 20f;

        [Option("蒸汽机功率上限 W", "Amount", "电力", Format = "F0")]
        [Limit(1, 10000)]
        [JsonProperty]
        public float 蒸汽机功率上限 { get; set; } = 1000f;
        //--------------------------
        [Option("喵喵床", "Amount", "家具")][JsonProperty] public bool 喵喵床 { get; set; } = false;
        //--------------------------
        [Option("点唱机", "Amount", "家具")][JsonProperty] public bool 点唱机 { get; set; } = false;

        [Option("点唱机功率修改", "Amount", "家具", Format = "F0")]
        [Limit(1, 1000)]
        [JsonProperty]
        public float 点唱机功率修改 { get; set; } = 300f;
        //--------------------------
        [Option("简单漂亮床", "Amount", "家具")][JsonProperty] public bool 简单漂亮床 { get; set; } = false;
        //--------------------------
        [Option("叠叠床", "Amount", "家具")][JsonProperty] public bool 叠叠床 { get; set; } = false;

        [Option("上叠叠床的速度", "Amount", "家具", Format = "F0")]
        [Limit(1, 10)]
        [JsonProperty]
        public float 上叠叠床的速度 { get; set; } = 2f;

        [Option("下叠叠床的速度", "Amount", "家具", Format = "F0")]
        [Limit(1, 10)]
        [JsonProperty]
        public float 下叠叠床的速度 { get; set; } = 2f;

        //--------------------------
        [Option("角顶饰条在建筑前方", "Amount", "家具")][JsonProperty] public bool 角顶饰条在建筑前方 { get; set; } = false;
        [Option("警示牌", "Amount", "家具")][JsonProperty] public bool 警示牌 { get; set; } = false;

        [Option("吊床", "Amount", "家具")][JsonProperty] public bool 吊床 { get; set; } = false;
        [Option("超级冰雕", "Amount", "家具")][JsonProperty] public bool 超级冰雕 { get; set; } = false;
        [Option("DRX", "Amount", "家具")][JsonProperty] public bool DRX { get; set; } = false;
        [Option("智能吸顶灯", "Amount", "家具")][JsonProperty] public bool 智能吸顶灯 { get; set; } = false;
        [Option("背景灯", "Amount", "家具")][JsonProperty] public bool 背景灯 { get; set; } = false;
        [Option("卡塔尔世界杯吉祥物", "Amount", "家具")][JsonProperty] public bool 卡塔尔世界杯吉祥物 { get; set; } = false;
        [Option("圣诞树", "Amount", "家具")][JsonProperty] public bool 圣诞树 { get; set; } = false;
        [Option("圣诞礼物", "Amount", "家具")][JsonProperty] public bool 圣诞礼物 { get; set; } = false;
        [Option("粉红灯", "Amount", "家具")][JsonProperty] public bool 粉红灯 { get; set; } = false;
        [Option("南瓜灯", "Amount", "家具")][JsonProperty] public bool 南瓜灯 { get; set; } = false;
        [Option("沥青滴漏实验", "Amount", "家具")][JsonProperty] public bool 沥青滴漏实验 { get; set; } = false;
        [Option("下雪啦", "Amount", "家具")][JsonProperty] public bool 下雪啦 { get; set; } = false;
        [Option("启动魔法少女", "Amount", "家具")][JsonProperty] public bool 启动魔法少女 { get; set; } = false;
        [Option("梦可床", "Amount", "家具")][JsonProperty] public bool 梦可床 { get; set; } = false;
        [Option("天地棋局", "Amount", "家具")][JsonProperty] public bool 天地棋局 { get; set; } = false;
        [Option("中国兵器", "Amount", "家具")][JsonProperty] public bool 中国兵器 { get; set; } = false; 
        [Option("ACGN之二次元之魂", "Amount", "家具")][JsonProperty] public bool ACGN之二次元之魂 { get; set; } = false;
        [Option("萤火虫灯", "Amount", "家具")][JsonProperty] public bool 萤火虫灯 { get; set; } = false;
        [Option("香草摇摇床", "Amount", "家具")][JsonProperty] public bool 香草摇摇床 { get; set; } = false;
        [Option("香草花盆", "Amount", "家具")][JsonProperty] public bool 香草花盆 { get; set; } = false;
        //--------------------------
        [Option("香草梯子", "Amount", "家具")][JsonProperty] public bool 香草梯子 { get; set; } = false;

        [Option("爬香草梯子的速度", "Amount", "家具", Format = "F0")]
        [Limit(1, 10)]
        [JsonProperty]
        public float 爬香草梯子的速度 { get; set; } = 2f;
        //--------------------------
        [Option("英雄联盟宣传片", "Amount", "家具")][JsonProperty] public bool 英雄联盟宣传片 { get; set; } = false;
        [Option("熊猫贴纸", "Amount", "家具")][JsonProperty] public bool 熊猫贴纸 { get; set; } = false;
        [Option("翻飞幻梦", "Amount", "家具")][JsonProperty] public bool 翻飞幻梦 { get; set; } = false;
        [Option("牛战士的面具", "Amount", "家具")][JsonProperty] public bool 牛战士的面具 { get; set; } = false;
        [Option("九块九包邮的花盆", "Amount", "家具")][JsonProperty] public bool 九块九包邮的花盆 { get; set; } = false;
        [Option("猛男的浴缸", "Amount", "家具")][JsonProperty] public bool 猛男的浴缸 { get; set; } = false;
        [Option("香草餐桌", "Amount", "家具")][JsonProperty] public bool 香草餐桌 { get; set; } = false;
        [Option("精致梯子", "Amount", "家具")][JsonProperty] public bool 精致梯子 { get; set; } = false;
        [Option("闪烁的雕塑", "Amount", "家具")][JsonProperty] public bool 闪烁的雕塑 { get; set; } = false;
        [Option("恭喜faker拿下第四个S赛冠军", "Amount", "家具")][JsonProperty] public bool 恭喜faker拿下第四个S赛冠军 { get; set; } = false;


        //--------------------------
        [Option("被诅咒的冰箱门", "和 强化冰箱 互斥", "食物")][JsonProperty] public bool 被诅咒的冰箱门 { get; set; } = false;
        [Option("氢气灶", "Amount", "食物")][JsonProperty] public bool 氢气灶 { get; set; } = false;
        //--------------------------
        [Option("强化冰箱", "和 被诅咒的冰箱门 互斥", "食物")][JsonProperty] public bool 强化冰箱 { get; set; } = false;

        [Option("冰箱容量", "Amount", "食物", Format = "F0")]
        [Limit(100, 100000)]
        [JsonProperty]
        public float 冰箱容量 { get; set; } = 1000f;
        //--------------------------
        [Option("冰霜萝卜", "Amount", "植物")][JsonProperty] public bool 冰霜萝卜 { get; set; } = false;

        [Option("冰霜萝卜辐射", "Amount", "植物", Format = "F0")]
        [Limit(100, 10000)]
        [JsonProperty]
        public float 冰霜萝卜辐射 { get; set; } = 0f;

        [Option("冰霜萝卜磷矿", "Amount", "植物")]
        [Limit(0, 100)]
        [JsonProperty]
        public float 冰霜萝卜磷矿 { get; set; } = 0f;
        //--------------------------
        [Option("智能制氧机", "Amount", "氧气")][JsonProperty] public bool 智能制氧机 { get; set; } = false;

        [Option("智能制氧机输出氧气", "Amount", "氧气")]
        [Limit(0.1, 10)]
        [JsonProperty]
        public float 智能制氧机输出氧气 { get; set; } = 0.88f;

        [Option("智能制氧机输出氢气", "Amount", "氧气")]
        [Limit(0.1, 10)]
        [JsonProperty]
        public float 智能制氧机输出氢气 { get; set; } = 0.11f;
        //--------------------------
        [Option("气体发生器", "Amount", "氧气")][JsonProperty] public bool 气体发生器 { get; set; } = false;
        [Option("淘金热", "Amount", "氧气")][JsonProperty] public bool 淘金热 { get; set; } = false;


        [Option("二乘三的淋浴间", "Amount", "管道")][JsonProperty] public bool 二乘三的淋浴间 { get; set; } = false;
        [Option("管道检测器可穿墙", "Amount", "管道")][JsonProperty] public bool 管道检测器可穿墙 { get; set; } = false;
        //--------------------------
        [Option("超级管道", "Amount", "管道")][JsonProperty] public bool 超级管道 { get; set; } = false;

        [Option("液体管道容量", "Amount", "管道", Format = "F0")]
        [Limit(10, 1000)]
        [JsonProperty]
        public float 液体管道容量 { get; set; } = 100f;

        [Option("气体管道容量", "Amount", "管道", Format = "F0")]
        [Limit(1, 100)]
        [JsonProperty]
        public float 气体管道容量 { get; set; } = 10f;
        //--------------------------
        [Option("管道阀可穿墙", "Amount", "管道")][JsonProperty] public bool 管道阀可穿墙 { get; set; } = false;
        [Option("隐藏排气口", "Amount", "管道")][JsonProperty] public bool 隐藏排气口 { get; set; } = false;
        [Option("喵喵排风扇", "Amount", "管道")][JsonProperty] public bool 喵喵排风扇 { get; set; } = false;
        [Option("垂直液泵", "Amount", "管道")][JsonProperty] public bool 垂直液泵 { get; set; } = false;
        [Option("开发者液泵", "Amount", "管道")][JsonProperty] public bool 开发者液泵 { get; set; } = false;
        [Option("开发者气泵", "Amount", "管道")][JsonProperty] public bool 开发者气泵 { get; set; } = false;
        [Option("液体灌装器", "Amount", "管道")][JsonProperty] public bool 液体灌装器 { get; set; } = false;
        [Option("迷你液泵", "Amount", "管道")][JsonProperty] public bool 迷你液泵 { get; set; } = false;
        [Option("绝命毒师", "Amount", "管道")][JsonProperty] public bool 绝命毒师 { get; set; } = false;

        [Option("超级泵", "Amount", "管道")][JsonProperty] public bool 超级泵 { get; set; } = false;
        [Option("香草抽水马桶", "Amount", "管道")][JsonProperty] public bool 香草抽水马桶 { get; set; } = false;
        [Option("跨两格气管桥", "Amount", "管道")][JsonProperty] public bool 跨两格气管桥 { get; set; } = false;
        [Option("跨两格液管桥", "Amount", "管道")][JsonProperty] public bool 跨两格液管桥 { get; set; } = false;
        [Option("跨三格气管桥", "Amount", "管道")][JsonProperty] public bool 跨三格气管桥 { get; set; } = false;
        [Option("跨三格液管桥", "Amount", "管道")][JsonProperty] public bool 跨三格液管桥 { get; set; } = false;
        [Option("导热气体管道", "Amount", "管道")][JsonProperty] public bool 导热气体管道 { get; set; } = false;
        [Option("导热液体管道", "Amount", "管道")][JsonProperty] public bool 导热液体管道 { get; set; } = false;
        [Option("核废水处理桶", "Amount", "辐射")][JsonProperty] public bool 核废水处理桶 { get; set; } = false;
        [Option("可调节的气体灌装器", "Amount", "管道")][JsonProperty] public bool 可调节的气体灌装器 { get; set; } = false;
        [Option("可调节的气体灌装器", "Amount", "管道")][JsonProperty] public bool 可调节的空罐器 { get; set; } = false;
        [Option("黄金淋浴间", "Amount", "管道")][JsonProperty] public bool 黄金淋浴间 { get; set; } = false;
        [Option("热量终结者", "Amount", "管道")][JsonProperty] public bool 热量终结者 { get; set; } = false;
        [Option("户外环保厕所", "Amount", "管道")][JsonProperty] public bool 户外环保厕所 { get; set; } = false;





        [Option("催化二氧化碳制乙醇", "Amount", "精炼")][JsonProperty] public bool 催化二氧化碳制乙醇 { get; set; } = false;
        [Option("石油裂解器", "Amount", "精炼")][JsonProperty] public bool 石油裂解器 { get; set; } = false;
        [Option("石油精炼器", "Amount", "精炼")][JsonProperty] public bool 石油精炼器 { get; set; } = false;
        [Option("精炼镁铁质岩生产铁", "Amount", "精炼")][JsonProperty] public bool 精炼镁铁质岩生产铁 { get; set; } = false;
        [Option("粉碎镁铁质岩生产铁", "Amount", "精炼")][JsonProperty] public bool 粉碎镁铁质岩生产铁 { get; set; } = false;
        //--------------------------
        [Option("热裂解甲烷制钻石", "Amount", "精炼")][JsonProperty] public bool 热裂解甲烷制钻石 { get; set; } = false;

        [Option("热裂解制钻石的产物钻石", "Amount", "精炼")]
        [Limit(0, 10)]
        [JsonProperty]
        public float 热裂解制钻石的产物钻石 { get; set; } = 0.5f;

        [Option("热裂解制钻石的产物氢气", "Amount", "精炼")]
        [Limit(0, 10)]
        [JsonProperty]
        public float 热裂解制钻石的产物氢气 { get; set; } = 0.25f;
        //--------------------------
        [Option("调整藻类蒸馏器", "Amount", "精炼")][JsonProperty] public bool 调整藻类蒸馏器 { get; set; } = false;
        [Option("堆肥堆不会释放气体", "Amount", "精炼")][JsonProperty] public bool 堆肥堆不会释放气体 { get; set; } = false;
        [Option("气体液化机", "Amount", "精炼")][JsonProperty] public bool 气体液化机 { get; set; } = false;




        [Option("开发者维生器", "Amount", "医疗")][JsonProperty] public bool 开发者维生器 { get; set; } = false;
        //--------------------------
        [Option("高效按摩床", "Amount", "医疗")][JsonProperty] public bool 高效按摩床 { get; set; } = false;

        [Option("按摩床压力消除率（%）", "Amount", "医疗")]
        [Limit(0, 10)]
        [JsonProperty]
        public float 按摩床压力消除率 { get; set; } = 0.5f;
        //--------------------------
        [Option("医废桶", "Amount", "医疗")][JsonProperty] public bool 医废桶 { get; set; } = false;
        [Option("饥荒入侵计划", "Amount", "医疗")][JsonProperty] public bool 饥荒入侵计划 { get; set; } = false;

        [Option("辐射药丸使用阈值", "Amount", "医疗")][JsonProperty] public bool 辐射药丸使用阈值 { get; set; } = false;

        [Option("辐射药丸阈值", "Amount", "医疗")]
        [Limit(200, 1000)]
        [JsonProperty]
        public float 辐射药丸阈值 { get; set; } = 200f;

        [Option("石油井", "Amount", "精炼")][JsonProperty] public bool 石油井 { get; set; } = false;




        [Option("辐射粒子收集器功率", "Amount", "管道", Format = "F0")]
        [Limit(10, 1000)]
        [JsonProperty]
        public float 辐射粒子收集器功率 { get; set; } = 100f;

        [Option("辐射粒子收集器发热", "Amount", "管道", Format = "F0")]
        [Limit(0, 10)]
        [JsonProperty]
        public float 辐射粒子收集器发热 { get; set; } = 0f;

        [Option("辐射粒子收集器发射间隔", "Amount", "管道", Format = "F0")]
        [Limit(1, 10)]
        [JsonProperty]
        public float 辐射粒子收集器发射间隔 { get; set; } = 1f;
        //--------------------------

        [Option("天工复制人探测器", "Amount", "自动化")][JsonProperty] public bool 天工复制人探测器 { get; set; } = false;

        [Option("信号组桥", "Amount", "自动化")][JsonProperty] public bool 信号组桥 { get; set; } = false;
        [Option("信号桥", "Amount", "自动化")][JsonProperty] public bool 信号桥 { get; set; } = false;
        [Option("闹钟", "Amount", "自动化")][JsonProperty] public bool 闹钟 { get; set; } = false;

        [Option("超级开发者固体泵", "Amount", "运输")][JsonProperty] public bool 超级开发者固体泵 { get; set; } = false;

        [Option("超级矿机", "Amount", "运输")][JsonProperty] public bool 超级矿机 { get; set; } = false;
        [Option("超次元矿机", "Amount", "运输")][JsonProperty] public bool 超次元矿机 { get; set; } = false;


        [Option("火箭燃料仓输入更改", "Amount", "火箭")][JsonProperty] public bool 火箭燃料仓输入更改 { get; set; } = false;

        //--------------------------
        [Option("超级液氢引擎", "Amount", "火箭")][JsonProperty] public bool 超级液氢引擎 { get; set; } = false;
        [Option("液氢引擎负担", "Amount", "火箭", Format = "F0")][Limit(1, 10)][JsonProperty] public float 液氢引擎负担 { get; set; } = 1f;
        [Option("液氢引擎功率", "Amount", "火箭", Format = "F0")][Limit(1, 100)][JsonProperty] public float 液氢引擎功率 { get; set; } = 50f;
        [Option("液氢引擎火箭高度", "Amount", "火箭", Format = "F0")][Limit(10, 100)][JsonProperty] public float 液氢引擎火箭高度 { get; set; } = 50f;
        [Option("液氢火箭每格燃料消耗(kg）", "Amount", "火箭", Format = "F0")][Limit(1, 10)][JsonProperty] public float 液氢火箭每格燃料消耗 { get; set; } = 1f;
        //--------------------------
        [Option("超级石油引擎", "Amount", "火箭")][JsonProperty] public bool 超级石油引擎 { get; set; } = false;
        [Option("石油引擎负担", "Amount", "火箭", Format = "F0")][Limit(1, 10)][JsonProperty] public float 石油引擎负担 { get; set; } = 1f;
        [Option("石油引擎功率", "Amount", "火箭", Format = "F0")][Limit(1, 100)][JsonProperty] public float 石油引擎功率 { get; set; } = 50f;
        [Option("石油引擎火箭高度", "Amount", "火箭", Format = "F0")][Limit(10, 100)][JsonProperty] public float 石油引擎火箭高度 { get; set; } = 50f;
        [Option("石油火箭每格燃料消耗(kg）", "Amount", "火箭", Format = "F0")][Limit(1, 10)][JsonProperty] public float 石油火箭每格燃料消耗 { get; set; } = 1f;
        //--------------------------
        [Option("超级小型石油引擎", "Amount", "火箭")][JsonProperty] public bool 超级小型石油引擎 { get; set; } = false;
        [Option("小型石油引擎负担", "Amount", "火箭", Format = "F0")][Limit(1, 10)][JsonProperty] public float 小型石油引擎负担 { get; set; } = 1f;
        [Option("小型石油引擎功率", "Amount", "火箭", Format = "F0")][Limit(1, 100)][JsonProperty] public float 小型石油引擎功率 { get; set; } = 50f;
        [Option("小型石油引擎火箭高度", "Amount", "火箭", Format = "F0")][Limit(10, 100)][JsonProperty] public float 小型石油引擎火箭高度 { get; set; } = 50f;
        [Option("小型石油火箭每格燃料消耗(kg）", "Amount", "火箭", Format = "F0")][Limit(1, 10)][JsonProperty] public float 小型石油火箭每格燃料消耗 { get; set; } = 1f;
        //--------------------------
        [Option("超级蒸汽引擎", "Amount", "火箭")][JsonProperty] public bool 超级蒸汽引擎 { get; set; } = false;
        [Option("蒸汽引擎负担", "Amount", "火箭", Format = "F0")][Limit(1, 10)][JsonProperty] public float 蒸汽引擎负担 { get; set; } = 1f;
        [Option("蒸汽引擎功率", "Amount", "火箭", Format = "F0")][Limit(1, 100)][JsonProperty] public float 蒸汽引擎功率 { get; set; } = 50f;
        [Option("蒸汽引擎火箭高度", "Amount", "火箭", Format = "F0")][Limit(10, 100)][JsonProperty] public float 蒸汽引擎火箭高度 { get; set; } = 50f;
        [Option("蒸汽火箭每格燃料消耗(kg）", "Amount", "火箭", Format = "F0")][Limit(1, 10)][JsonProperty] public float 蒸汽火箭每格燃料消耗 { get; set; } = 1f;
        //--------------------------
        [Option("超级糖素引擎", "Amount", "火箭")][JsonProperty] public bool 超级糖素引擎 { get; set; } = false;
        [Option("糖素引擎负担", "Amount", "火箭", Format = "F0")][Limit(1, 10)][JsonProperty] public float 糖素引擎负担 { get; set; } = 1f;
        [Option("糖素引擎功率", "Amount", "火箭", Format = "F0")][Limit(1, 100)][JsonProperty] public float 糖素引擎功率 { get; set; } = 50f;
        [Option("糖素引擎火箭高度", "Amount", "火箭", Format = "F0")][Limit(10, 100)][JsonProperty] public float 糖素引擎火箭高度 { get; set; } = 50f;
        [Option("糖素火箭每格燃料消耗(kg）", "Amount", "火箭", Format = "F0")][Limit(1, 10)][JsonProperty] public float 糖素火箭每格燃料消耗 { get; set; } = 1f;
        //--------------------------
        [Option("超级二氧化碳引擎", "Amount", "火箭")][JsonProperty] public bool 超级二氧化碳引擎 { get; set; } = false;
        [Option("二氧化碳引擎负担", "Amount", "火箭", Format = "F0")][Limit(1, 10)][JsonProperty] public float 二氧化碳引擎负担 { get; set; } = 1f;
        [Option("二氧化碳引擎功率", "Amount", "火箭", Format = "F0")][Limit(1, 100)][JsonProperty] public float 二氧化碳引擎功率 { get; set; } = 50f;
        [Option("二氧化碳引擎火箭高度", "Amount", "火箭", Format = "F0")][Limit(10, 100)][JsonProperty] public float 二氧化碳引擎火箭高度 { get; set; } = 50f;
        [Option("二氧化碳火箭每格燃料消耗(kg）", "Amount", "火箭", Format = "F0")][Limit(1, 10)][JsonProperty] public float 二氧化碳火箭每格燃料消耗 { get; set; } = 1f;
        //--------------------------
        [Option("超级辐射粒子引擎", "Amount", "火箭")][JsonProperty] public bool 超级辐射粒子引擎 { get; set; } = false;
        [Option("辐射粒子引擎负担", "Amount", "火箭", Format = "F0")][Limit(1, 10)][JsonProperty] public float 辐射粒子引擎负担 { get; set; } = 1f;
        [Option("辐射粒子引擎功率", "Amount", "火箭", Format = "F0")][Limit(1, 100)][JsonProperty] public float 辐射粒子引擎功率 { get; set; } = 50f;
        [Option("辐射粒子引擎火箭高度", "Amount", "火箭", Format = "F0")][Limit(10, 100)][JsonProperty] public float 辐射粒子引擎火箭高度 { get; set; } = 50f;
        [Option("辐射粒子火箭每格燃料消耗(kg）", "Amount", "火箭", Format = "F0")][Limit(1, 10)][JsonProperty] public float 辐射粒子火箭每格燃料消耗 { get; set; } = 1f;
        //--------------------------
        [Option("火箭更大货仓", "Amount", "火箭")] [JsonProperty] public bool 火箭更大货仓 { get; set; } = false;
        [Option("火箭货仓容量", "Amount", "火箭", Format = "F0")] [Limit(1, 100000)][JsonProperty] public float 火箭货仓容量 { get; set; } = 10000f;
        //--------------------------
        [Option("侦察者电量增加", "Amount", "火箭")][JsonProperty] public bool 侦察者电量增加 { get; set; } = false;

        [Option("侦查者电量修改", "Amount", "火箭", Format = "F0")][Limit(1, 1000000000)][JsonProperty] public float 侦查者电量修改 { get; set; } = 1000000f;

        //--------------------------
        [Option("高效钻头前锥", "Amount", "火箭")][JsonProperty] public bool 高效钻头前锥 { get; set; } = false;
        [Option("钻头前锥容量", "Amount", "火箭", Format = "F0")][Limit(1000, 1000000)][JsonProperty] public float 钻头前锥容量 { get; set; } = 100000f;
        [Option("钻头前锥挖掘速度", "Amount", "火箭", Format = "F0")][Limit(10, 100)][JsonProperty] public float 钻头前锥挖掘速度 { get; set; } = 50f;
        //--------------------------

        [Option("优化氧气面罩", "Amount", "站台")][JsonProperty] public bool 优化氧气面罩 { get; set; } = false;
        [Option("气压服氧气容量修改", "Amount", "站台")][JsonProperty] public bool 气压服氧气容量修改 { get; set; } = false;
        [Option("喷气服氧气容量修改", "Amount", "站台")][JsonProperty] public bool 喷气服氧气容量修改 { get; set; } = false;
        [Option("铅服氧气容量修改（DLC）", "Amount", "站台")][JsonProperty] public bool 铅服氧气容量修改 { get; set; } = false;



        [Option("活得久的海牛", "Amount", "动物")][JsonProperty] public bool 活得久的海牛 { get; set; } = false;
        [Option("斯巴达300螃蟹", "Amount", "动物")][JsonProperty] public bool 斯巴达300螃蟹 { get; set; } = false;



        [Option("智能空间加热器", "Amount", "实用")][JsonProperty] public bool 智能空间加热器 { get; set; } = false;
        [Option("智能液体加热器", "Amount", "实用")][JsonProperty] public bool 智能液体加热器 { get; set; } = false;
        [Option("温度场", "Amount", "实用")][JsonProperty] public bool 温度场 { get; set; } = false;
        [Option("恒温空间", "Amount", "实用")][JsonProperty] public bool 恒温空间 { get; set; } = false;



        //---------------------------------------基地---------------------------------------
        [Option("魔女的箱子", "添加一个更大容量的箱子，多蓝图", "基地")] [JsonProperty] public bool A001GG1 { get; set; } = false;
        [Option("墨家的门", "门，全材料建造，开关速度大幅增加", "基地")] [JsonProperty] public bool A002GG1 { get; set; } = false;
        [Option("大储存砖", "储存砖的储量增加", "基地")] [JsonProperty] public bool A003GG1 { get; set; } = false;
        [Option("精致墙壁", "干板墙和导热板具有一定的装饰度", "基地")] [JsonProperty] public bool A004GG1 { get; set; } = false;
        [Option("看不见的门", "这是一道看不见的门", "基地")] [JsonProperty] public bool A005GG1 { get; set; } = false;
        [Option("隔热砖不导热", "隔热砖的导热系数为零", "基地")] [JsonProperty] public bool A006GG1 { get; set; } = false;
        [Option("打印舱不发光", "打印舱和迷你打印舱不发光", "基地")][JsonProperty] public bool A007GG1 { get; set; } = false;
        [Option("智能台阶", "没人的时候隐形，有人的时候显现", "基地")][JsonProperty] public bool A008GG1 { get; set; } = false;
        [Option("安全门", "占据二乘二空间的门", "基地")][JsonProperty] public bool A009GG1 { get; set; } = false;
        [Option("大箱子", "箱子、储气罐、储液桶容量修改", "基地")][JsonProperty] public bool A010GG1 { get; set; } = false;
        [Option("存储箱容量", "存储箱容量 kg", "基地", Format = "F0")][Limit(10, 1000000)][JsonProperty] public float A010GG2 { get; set; } = 100000f;
        [Option("智能存储箱容量", "智能存储箱容量 kg", "基地", Format = "F0")][Limit(10, 1000000)][JsonProperty] public float A010GG3 { get; set; } = 100000f;
        [Option("储液库容量", "储液库容量 kg", "基地", Format = "F0")][Limit(10, 100000)][JsonProperty] public float A010GG4 { get; set; } = 100000f;
        [Option("储气库容量", "储气库容量 kg", "基地", Format = "F0")][Limit(10, 100000)][JsonProperty] public float A010GG5 { get; set; } = 100000f;
        [Option("红色和蓝色的垃圾桶", "添加一个垃圾桶，将放入其中的物质消失不见，多蓝图", "基地")][JsonProperty] public bool A011GG1 { get; set; } = false;




        //---------------------------------------植物---------------------------------------
        [Option("超级氧齿阙", "全面加强氧齿阙的属性", "植物")][JsonProperty] public bool B001GG1 { get; set; } = false;





        //---------------------------------------管道---------------------------------------
        [Option("隔热管道不导热", "隔热液管和隔热气管的导热系数为零", "管道")] [JsonProperty] public bool C001GG1 { get; set; } = false;








        //---------------------------------------辐射---------------------------------------
        [Option("辐射掌", "发出一道可控辐射，游戏内设置数值后，重启游戏生效", "辐射（DLC限定）")][JsonProperty] public bool 辐射掌 { get; set; } = false;
        [Option("核废料处理器", "将核废料转变为其余物质", "辐射（DLC限定）")][JsonProperty] public bool 核废料处理器 { get; set; } = false;
        [Option("核废水处理器", "将核废水转变为其余物质", "辐射（DLC限定）")][JsonProperty] public bool 核废水处理器 { get; set; } = false;
        [Option("铅完全隔绝辐射", "铅的辐射阻隔率为100%", "辐射（DLC限定）")][JsonProperty] public bool 铅完全隔绝辐射 { get; set; } = false;
        [Option("强化辐射粒子收集器", "辐射粒子收集器的效率被强化", "辐射（DLC限定）")][JsonProperty] public bool 强化辐射粒子收集器 { get; set; } = false;
        [Option("辐射粒子收集器收集倍率", "辐射粒子收集倍率", "辐射（DLC限定）")] [Limit(1, 2)] [JsonProperty] public float 辐射粒子收集器收集倍率 { get; set; } = 1.1f;
        [Option("超级开发者辐射器", "普通模式也能使用开发者辐射器", "辐射（DLC限定）")][JsonProperty] public bool 超级开发者辐射器 { get; set; } = false;
    }
}
