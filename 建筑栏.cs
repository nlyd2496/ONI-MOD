using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 吐泡泡的小鱼的缺氧模组;

namespace 吐泡泡的小鱼的缺氧模组
{
    [HarmonyPatch(typeof(GeneratedBuildings))]
    [HarmonyPatch("LoadGeneratedBuildings")]
    public class 建筑栏
    {
        public static void Prefix()
        {
            BasicModUtils.MakeSideScreenStrings("picture", STRINGS.UI.PICTURE.picture);
            //---------------------------------------电力---------------------------------------

            ModUtil.AddBuildingToPlanScreen("Power", "A1GG1");//南孚电池
            ModUtil.AddBuildingToPlanScreen("Power", "A2GG1");//民用电池组
            ModUtil.AddBuildingToPlanScreen("Power", "A3GG1");//一格电池
            ModUtil.AddBuildingToPlanScreen("Power", "A4GG1");//细电线
            ModUtil.AddBuildingToPlanScreen("Power", "A7GG1");//跨两格导线桥
            ModUtil.AddBuildingToPlanScreen("Power", "A8GG1");//跨两格电线桥
            ModUtil.AddBuildingToPlanScreen("Power", "A9GG1");//跨三格导线桥
            ModUtil.AddBuildingToPlanScreen("Power", "A10GG1");//跨三格电线桥

            //---------------------------------------家具---------------------------------------

            ModUtil.AddBuildingToPlanScreen("Furniture", "A11GG1");//喵喵床
            ModUtil.AddBuildingToPlanScreen("Furniture", "A14GG1");//叠叠床
            ModUtil.AddBuildingToPlanScreen("Furniture", "A15GG1");//吊床
            ModUtil.AddBuildingToPlanScreen("Furniture", "A12GG1");//恭喜DRX夺得英雄联盟S12全球总决赛冠军
            ModUtil.AddBuildingToPlanScreen("Furniture", "A18GG1");//背景灯
            ModUtil.AddBuildingToPlanScreen("Furniture", "A19GG1");//卡塔尔世界杯吉祥物
            ModUtil.AddBuildingToPlanScreen("Furniture", "A20GG1");//圣诞树
            ModUtil.AddBuildingToPlanScreen("Furniture", "A21GG1");//圣诞礼物
            ModUtil.AddBuildingToPlanScreen("Furniture", "A22GG1");//南瓜灯
            ModUtil.AddBuildingToPlanScreen("Furniture", "A23GG1");//沥青滴落实验
            ModUtil.AddBuildingToPlanScreen("Furniture", "A24GG1");//下雪啦
            ModUtil.AddBuildingToPlanScreen("Furniture", "A25GG1");//启动魔法少女
            ModUtil.AddBuildingToPlanScreen("Furniture", "A27GG1");//天地棋局
            ModUtil.AddBuildingToPlanScreen("Furniture", "A28GG1");//中国兵器之武器架
            ModUtil.AddBuildingToPlanScreen("Furniture", "A28GG2");//中国兵器之武器
            ModUtil.AddBuildingToPlanScreen("Furniture", "A29GG1");//ACGN之鞋子
            ModUtil.AddBuildingToPlanScreen("Furniture", "A29GG2");//ACGN之裤子
            ModUtil.AddBuildingToPlanScreen("Furniture", "A29GG3");//ACGN之衣裳
            ModUtil.AddBuildingToPlanScreen("Furniture", "A29GG4");//ACGN之头发
            ModUtil.AddBuildingToPlanScreen("Furniture", "A30GG1");//萤火虫灯
            ModUtil.AddBuildingToPlanScreen("Furniture", "A31GG1");//香草摇摇床
            ModUtil.AddBuildingToPlanScreen("Furniture", "A32GG1");//香草花盆
            ModUtil.AddBuildingToPlanScreen("Furniture", "A33GG1");//香草梯子
            ModUtil.AddBuildingToPlanScreen("Furniture", "A34GG1");//英雄联盟宣传片
            ModUtil.AddBuildingToPlanScreen("Furniture", "A35GG1");//熊猫贴纸
            ModUtil.AddBuildingToPlanScreen("Furniture", "A36GG1");//翻飞幻梦
            ModUtil.AddBuildingToPlanScreen("Furniture", "A37GG1");//牛战士的面具
            ModUtil.AddBuildingToPlanScreen("Furniture", "A68GG1");//牛战士的面具
            ModUtil.AddBuildingToPlanScreen("Furniture", "A68GG2");//牛战士的面具
            ModUtil.AddBuildingToPlanScreen("Furniture", "A68GG3");//牛战士的面具

            ModUtil.AddBuildingToPlanScreen("Furniture", "A79GG1");//恭喜faker拿下LOL第四个冠军
            ModUtil.AddBuildingToPlanScreen("Furniture", "A80GG1");//警示牌
            ModUtil.AddBuildingToPlanScreen("Furniture", "A80GG2");//警示牌


            //---------------------------------------食物---------------------------------------
            ModUtil.AddBuildingToPlanScreen("Food", "A38GG1");//氢气灶
            ModUtil.AddBuildingToPlanScreen("Food", "B0GG0");//种子研究站
            ModUtil.AddBuildingToPlanScreen("Food", "A39GG1");//冰淇淋机

            //---------------------------------------氧气---------------------------------------
            ModUtil.AddBuildingToPlanScreen("Oxygen", "A40GG1");//智能制氧机

            ModUtil.AddBuildingToPlanScreen("Oxygen", "A41GG1");//气体发生器
            ModUtil.AddBuildingToPlanScreen("Oxygen", "A41GG2");//气体发生器
            ModUtil.AddBuildingToPlanScreen("Oxygen", "A41GG3");//气体发生器
            ModUtil.AddBuildingToPlanScreen("Oxygen", "A41GG4");//气体发生器
            ModUtil.AddBuildingToPlanScreen("Oxygen", "A41GG5");//气体发生器

            ModUtil.AddBuildingToPlanScreen("Oxygen", "A42GG1");//淘金热

            //---------------------------------------管道---------------------------------------

            ModUtil.AddBuildingToPlanScreen("HVAC", "A45GG1");//喵喵排风扇
            ModUtil.AddBuildingToPlanScreen("HVAC", "A45GG2");//喵喵排风扇
            ModUtil.AddBuildingToPlanScreen("HVAC", "A45GG3");//喵喵排风扇
            ModUtil.AddBuildingToPlanScreen("HVAC", "A45GG4");//喵喵排风扇
            ModUtil.AddBuildingToPlanScreen("HVAC", "A45GG5");//喵喵排风扇

            ModUtil.AddBuildingToPlanScreen("Plumbing", "A46GG1");//垂直液泵
            ModUtil.AddBuildingToPlanScreen("Plumbing", "A47GG1");//液体灌装器

            ModUtil.AddBuildingToPlanScreen("Plumbing", "A48GG1");//迷你液泵

            ModUtil.AddBuildingToPlanScreen("Plumbing", "A49GG1");//香草马桶
            ModUtil.AddBuildingToPlanScreen("Furniture", "A50GG1");//香草餐桌

            ModUtil.AddBuildingToPlanScreen("Plumbing", "A51GG1");//管桥
            ModUtil.AddBuildingToPlanScreen("Plumbing", "A51GG2");//管桥
            ModUtil.AddBuildingToPlanScreen("HVAC", "A52GG1");//管桥
            ModUtil.AddBuildingToPlanScreen("HVAC", "A52GG2");//管桥

            ModUtil.AddBuildingToPlanScreen("HVAC", "A53GG1");//导热管道
            ModUtil.AddBuildingToPlanScreen("Plumbing", "A54GG1");//导热管道

            ModUtil.AddBuildingToPlanScreen("HEP", "A55GG1");//核废水处理桶
            ModUtil.AddBuildingToPlanScreen("Plumbing", "A58GG1");//黄金淋浴间

            ModUtil.AddBuildingToPlanScreen("Plumbing", "A59GG1");//液冷机
            ModUtil.AddBuildingToPlanScreen("HVAC", "A59GG2");//气冷机

            ModUtil.AddBuildingToPlanScreen("Refining", "A60GG1");//催化二氧化碳制乙醇
            ModUtil.AddBuildingToPlanScreen("Refining", "A61GG1");//石油裂解器
            ModUtil.AddBuildingToPlanScreen("Refining", "A62GG1");//石油精炼器
            ModUtil.AddBuildingToPlanScreen("Refining", "A64GG1");//热裂解甲烷制钻石
            ModUtil.AddBuildingToPlanScreen("Refining", "A65GG1");//气体液化机

            ModUtil.AddBuildingToPlanScreen("Medical", "A66GG1");//医废桶
            ModUtil.AddBuildingToPlanScreen("Medical", "A77GG1");//饥荒入侵计划


            ModUtil.AddBuildingToPlanScreen("Refining", "A67GG1");//石油井


            ModUtil.AddBuildingToPlanScreen("HEP", "A69GG1");//辐射掌


            ModUtil.AddBuildingToPlanScreen("HEP", "A70GG1");//核废料处理器
            ModUtil.AddBuildingToPlanScreen("HEP", "A70GG2");//核废水处理器


            ModUtil.AddBuildingToPlanScreen("Automation", "A72GG2");//信号桥和信号组桥
            ModUtil.AddBuildingToPlanScreen("Automation", "A72GG3");//信号桥和信号组桥
            ModUtil.AddBuildingToPlanScreen("Automation", "A72GG4");//信号桥和信号组桥
            ModUtil.AddBuildingToPlanScreen("Automation", "A72GG1");//信号桥和信号组桥

            ModUtil.AddBuildingToPlanScreen("Utilities", "A83GG1");//温度场
            ModUtil.AddBuildingToPlanScreen("Utilities", "A84GG1");//恒温空间



            //---------------------------------------基地---------------------------------------
            ModUtil.AddBuildingToPlanScreen("Base", "A001GG1");
            ModUtil.AddBuildingToPlanScreen("Base", "A005GG1");
            ModUtil.AddBuildingToPlanScreen("Base", "A008GG1");
            ModUtil.AddBuildingToPlanScreen("Base", "A009GG1");
            ModUtil.AddBuildingToPlanScreen("Base", "A011GG1");




        }
    }
}
//  基地 氧气   电力  食物 液管     气管 精炼     医疗    家具      站台      实用      自动化     运输       火箭     辐射
//  Base Oxygen Power Food Plumbing HVAC Refining Medical Furniture Equipment Utilities Automation Conveyance Rocketry HEP
