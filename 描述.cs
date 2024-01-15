using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using STRINGS;
using CaiLib.Utils;
using KMod;
using PeterHan.PLib.Core;
using PeterHan.PLib.Database;
using Klei.AI;

namespace 吐泡泡的小鱼的缺氧模组
{
    internal class STRINGS
    {
        public const string PREFIX = "STRINGS.BUILDINGS.PREFABS.";
        public static void DoReplacement()
        {
            LocString.CreateLocStringKeys(typeof(STRINGS), "");
        }
        [HarmonyPatch(typeof(EntityConfigManager))]
        [HarmonyPatch("LoadGeneratedEntities")]
        public class 实体配置管理器
        {
            public static void Prefix()
            {

                //------------------------------------------------------------建筑------------------------------------------------------------


                StringUtils.AddBuildingStrings("A1GG1", STRINGS.BUILDINGS.PREFABS.A1GG1.NAME, STRINGS.BUILDINGS.PREFABS.A1GG1.DESC, STRINGS.BUILDINGS.PREFABS.A1GG1.EFFECT);//南孚电池
                StringUtils.AddBuildingStrings("A2GG1", STRINGS.BUILDINGS.PREFABS.A2GG1.NAME, STRINGS.BUILDINGS.PREFABS.A2GG1.DESC, STRINGS.BUILDINGS.PREFABS.A2GG1.EFFECT);//民用电池组
                StringUtils.AddBuildingStrings("A3GG1", STRINGS.BUILDINGS.PREFABS.A3GG1.NAME, STRINGS.BUILDINGS.PREFABS.A3GG1.DESC, STRINGS.BUILDINGS.PREFABS.A3GG1.EFFECT);//一格电池
                StringUtils.AddBuildingStrings("A4GG1", STRINGS.BUILDINGS.PREFABS.A4GG1.NAME, STRINGS.BUILDINGS.PREFABS.A4GG1.DESC, STRINGS.BUILDINGS.PREFABS.A4GG1.EFFECT);//细电线
                StringUtils.AddBuildingStrings("A7GG1", STRINGS.BUILDINGS.PREFABS.A7GG1.NAME, STRINGS.BUILDINGS.PREFABS.A7GG1.DESC, STRINGS.BUILDINGS.PREFABS.A7GG1.EFFECT);//跨两格导线桥
                StringUtils.AddBuildingStrings("A8GG1", STRINGS.BUILDINGS.PREFABS.A8GG1.NAME, STRINGS.BUILDINGS.PREFABS.A8GG1.DESC, STRINGS.BUILDINGS.PREFABS.A8GG1.EFFECT);//跨两格电线桥
                StringUtils.AddBuildingStrings("A9GG1", STRINGS.BUILDINGS.PREFABS.A9GG1.NAME, STRINGS.BUILDINGS.PREFABS.A9GG1.DESC, STRINGS.BUILDINGS.PREFABS.A9GG1.EFFECT);//跨三格导线桥
                StringUtils.AddBuildingStrings("A10GG1", STRINGS.BUILDINGS.PREFABS.A10GG1.NAME, STRINGS.BUILDINGS.PREFABS.A10GG1.DESC, STRINGS.BUILDINGS.PREFABS.A10GG1.EFFECT);//跨三格电线桥
                StringUtils.AddBuildingStrings("A11GG1", STRINGS.BUILDINGS.PREFABS.A11GG1.NAME, STRINGS.BUILDINGS.PREFABS.A11GG1.DESC, STRINGS.BUILDINGS.PREFABS.A11GG1.EFFECT);//喵喵床1
                StringUtils.AddBuildingStrings("A14GG1", STRINGS.BUILDINGS.PREFABS.A14GG1.NAME, STRINGS.BUILDINGS.PREFABS.A14GG1.DESC, STRINGS.BUILDINGS.PREFABS.A14GG1.EFFECT);//叠叠床
                StringUtils.AddBuildingStrings("A15GG1", STRINGS.BUILDINGS.PREFABS.A15GG1.NAME, STRINGS.BUILDINGS.PREFABS.A15GG1.DESC, STRINGS.BUILDINGS.PREFABS.A15GG1.EFFECT);//吊床
                StringUtils.AddBuildingStrings("A16GG1", STRINGS.BUILDINGS.PREFABS.A16GG1.NAME, STRINGS.BUILDINGS.PREFABS.A16GG1.DESC, STRINGS.BUILDINGS.PREFABS.A16GG1.EFFECT);//恭喜DRX夺得英雄联盟S12全球总决赛冠军
                StringUtils.AddBuildingStrings("A18GG1", STRINGS.BUILDINGS.PREFABS.A18GG1.NAME, STRINGS.BUILDINGS.PREFABS.A18GG1.DESC, STRINGS.BUILDINGS.PREFABS.A18GG1.EFFECT);//背景灯
                StringUtils.AddBuildingStrings("A19GG1", STRINGS.BUILDINGS.PREFABS.A19GG1.NAME, STRINGS.BUILDINGS.PREFABS.A19GG1.DESC, STRINGS.BUILDINGS.PREFABS.A19GG1.EFFECT);//卡塔尔世界杯吉祥物
                StringUtils.AddBuildingStrings("A20GG1", STRINGS.BUILDINGS.PREFABS.A20GG1.NAME, STRINGS.BUILDINGS.PREFABS.A20GG1.DESC, STRINGS.BUILDINGS.PREFABS.A20GG1.EFFECT);//圣诞树
                StringUtils.AddBuildingStrings("A21GG1", STRINGS.BUILDINGS.PREFABS.A21GG1.NAME, STRINGS.BUILDINGS.PREFABS.A21GG1.DESC, STRINGS.BUILDINGS.PREFABS.A21GG1.EFFECT);//圣诞礼物
                StringUtils.AddBuildingStrings("A22GG1", STRINGS.BUILDINGS.PREFABS.A22GG1.NAME, STRINGS.BUILDINGS.PREFABS.A22GG1.DESC, STRINGS.BUILDINGS.PREFABS.A22GG1.EFFECT);//南瓜灯
                StringUtils.AddBuildingStrings("A23GG1", STRINGS.BUILDINGS.PREFABS.A23GG1.NAME, STRINGS.BUILDINGS.PREFABS.A23GG1.DESC, STRINGS.BUILDINGS.PREFABS.A23GG1.EFFECT);//沥青滴落实验
                StringUtils.AddBuildingStrings("A24GG1", STRINGS.BUILDINGS.PREFABS.A24GG1.NAME, STRINGS.BUILDINGS.PREFABS.A24GG1.DESC, STRINGS.BUILDINGS.PREFABS.A24GG1.EFFECT);//下雪啦
                StringUtils.AddBuildingStrings("A25GG1", STRINGS.BUILDINGS.PREFABS.A25GG1.NAME, STRINGS.BUILDINGS.PREFABS.A25GG1.DESC, STRINGS.BUILDINGS.PREFABS.A25GG1.EFFECT);//启动魔法少女
                StringUtils.AddBuildingStrings("A27GG1", STRINGS.BUILDINGS.PREFABS.A27GG1.NAME, STRINGS.BUILDINGS.PREFABS.A27GG1.DESC, STRINGS.BUILDINGS.PREFABS.A27GG1.EFFECT);//天地棋局
                StringUtils.AddBuildingStrings("A28GG1", STRINGS.BUILDINGS.PREFABS.A28GG1.NAME, STRINGS.BUILDINGS.PREFABS.A28GG1.DESC, STRINGS.BUILDINGS.PREFABS.A28GG1.EFFECT);//中国兵器之武器架
                StringUtils.AddBuildingStrings("A28GG2", STRINGS.BUILDINGS.PREFABS.A28GG2.NAME, STRINGS.BUILDINGS.PREFABS.A28GG2.DESC, STRINGS.BUILDINGS.PREFABS.A28GG2.EFFECT);//中国兵器之武器
                StringUtils.AddBuildingStrings("A29GG1", STRINGS.BUILDINGS.PREFABS.A29GG1.NAME, STRINGS.BUILDINGS.PREFABS.A29GG1.DESC, STRINGS.BUILDINGS.PREFABS.A29GG1.EFFECT);//ACGN之鞋子
                StringUtils.AddBuildingStrings("A29GG2", STRINGS.BUILDINGS.PREFABS.A29GG2.NAME, STRINGS.BUILDINGS.PREFABS.A29GG2.DESC, STRINGS.BUILDINGS.PREFABS.A29GG2.EFFECT);//ACGN之裤子
                StringUtils.AddBuildingStrings("A29GG3", STRINGS.BUILDINGS.PREFABS.A29GG3.NAME, STRINGS.BUILDINGS.PREFABS.A29GG3.DESC, STRINGS.BUILDINGS.PREFABS.A29GG3.EFFECT);//ACGN之衣裳
                StringUtils.AddBuildingStrings("A29GG4", STRINGS.BUILDINGS.PREFABS.A29GG4.NAME, STRINGS.BUILDINGS.PREFABS.A29GG4.DESC, STRINGS.BUILDINGS.PREFABS.A29GG4.EFFECT);//ACGN之头发
                StringUtils.AddBuildingStrings("A30GG1", STRINGS.BUILDINGS.PREFABS.A30GG1.NAME, STRINGS.BUILDINGS.PREFABS.A30GG1.DESC, STRINGS.BUILDINGS.PREFABS.A30GG1.EFFECT);//萤火虫灯
                StringUtils.AddBuildingStrings("A31GG1", STRINGS.BUILDINGS.PREFABS.A31GG1.NAME, STRINGS.BUILDINGS.PREFABS.A31GG1.DESC, STRINGS.BUILDINGS.PREFABS.A31GG1.EFFECT);//香草摇摇床
                StringUtils.AddBuildingStrings("A32GG1", STRINGS.BUILDINGS.PREFABS.A32GG1.NAME, STRINGS.BUILDINGS.PREFABS.A32GG1.DESC, STRINGS.BUILDINGS.PREFABS.A32GG1.EFFECT);//香草花盆
                StringUtils.AddBuildingStrings("A33GG1", STRINGS.BUILDINGS.PREFABS.A33GG1.NAME, STRINGS.BUILDINGS.PREFABS.A33GG1.DESC, STRINGS.BUILDINGS.PREFABS.A33GG1.EFFECT);//香草梯子
                StringUtils.AddBuildingStrings("A34GG1", STRINGS.BUILDINGS.PREFABS.A34GG1.NAME, STRINGS.BUILDINGS.PREFABS.A34GG1.DESC, STRINGS.BUILDINGS.PREFABS.A34GG1.EFFECT);//英雄联盟宣传片
                StringUtils.AddBuildingStrings("A35GG1", STRINGS.BUILDINGS.PREFABS.A35GG1.NAME, STRINGS.BUILDINGS.PREFABS.A35GG1.DESC, STRINGS.BUILDINGS.PREFABS.A35GG1.EFFECT);//熊猫贴纸
                StringUtils.AddBuildingStrings("A36GG1", STRINGS.BUILDINGS.PREFABS.A36GG1.NAME, STRINGS.BUILDINGS.PREFABS.A36GG1.DESC, STRINGS.BUILDINGS.PREFABS.A36GG1.EFFECT);//翻飞幻梦
                StringUtils.AddBuildingStrings("A37GG1", STRINGS.BUILDINGS.PREFABS.A37GG1.NAME, STRINGS.BUILDINGS.PREFABS.A37GG1.DESC, STRINGS.BUILDINGS.PREFABS.A37GG1.EFFECT);//牛战士的面具
                StringUtils.AddBuildingStrings("A38GG1", STRINGS.BUILDINGS.PREFABS.A38GG1.NAME, STRINGS.BUILDINGS.PREFABS.A38GG1.DESC, STRINGS.BUILDINGS.PREFABS.A38GG1.EFFECT);//氢气灶
                StringUtils.AddBuildingStrings("A39GG1", STRINGS.BUILDINGS.PREFABS.A39GG1.NAME, STRINGS.BUILDINGS.PREFABS.A39GG1.DESC, STRINGS.BUILDINGS.PREFABS.A39GG1.EFFECT);//冰淇淋机

                StringUtils.AddBuildingStrings("A43GG1", STRINGS.BUILDINGS.PREFABS.A43GG1.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.DESC, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT);//九块九包邮的花盆
                StringUtils.AddBuildingStrings("A43GG2", STRINGS.BUILDINGS.PREFABS.A43GG2.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.DESC, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT);//九块九包邮的花盆
                StringUtils.AddBuildingStrings("A43GG3", STRINGS.BUILDINGS.PREFABS.A43GG3.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.DESC, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT);//九块九包邮的花盆
                StringUtils.AddBuildingStrings("A43GG4", STRINGS.BUILDINGS.PREFABS.A43GG4.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.DESC, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT);//九块九包邮的花盆
                StringUtils.AddBuildingStrings("A43GG5", STRINGS.BUILDINGS.PREFABS.A43GG5.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.DESC, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT);//九块九包邮的花盆
                StringUtils.AddBuildingStrings("A43GG6", STRINGS.BUILDINGS.PREFABS.A43GG6.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.DESC, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT);//九块九包邮的花盆
                StringUtils.AddBuildingStrings("A43GG7", STRINGS.BUILDINGS.PREFABS.A43GG7.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.DESC, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT);//九块九包邮的花盆
                StringUtils.AddBuildingStrings("A43GG8", STRINGS.BUILDINGS.PREFABS.A43GG8.NAME, STRINGS.BUILDINGS.PREFABS.A43GG1.DESC, STRINGS.BUILDINGS.PREFABS.A43GG1.EFFECT);//九块九包邮的花盆

                StringUtils.AddBuildingStrings("A45GG1", STRINGS.BUILDINGS.PREFABS.A45GG1.NAME, STRINGS.BUILDINGS.PREFABS.A45GG1.DESC, STRINGS.BUILDINGS.PREFABS.A45GG1.EFFECT);//喵喵排风扇
                StringUtils.AddBuildingStrings("A45GG2", STRINGS.BUILDINGS.PREFABS.A45GG2.NAME, STRINGS.BUILDINGS.PREFABS.A45GG2.DESC, STRINGS.BUILDINGS.PREFABS.A45GG2.EFFECT);//喵喵排风扇
                StringUtils.AddBuildingStrings("A45GG3", STRINGS.BUILDINGS.PREFABS.A45GG3.NAME, STRINGS.BUILDINGS.PREFABS.A45GG3.DESC, STRINGS.BUILDINGS.PREFABS.A45GG3.EFFECT);//喵喵排风扇
                StringUtils.AddBuildingStrings("A45GG4", STRINGS.BUILDINGS.PREFABS.A45GG4.NAME, STRINGS.BUILDINGS.PREFABS.A45GG4.DESC, STRINGS.BUILDINGS.PREFABS.A45GG4.EFFECT);//喵喵排风扇
                StringUtils.AddBuildingStrings("A45GG5", STRINGS.BUILDINGS.PREFABS.A45GG5.NAME, STRINGS.BUILDINGS.PREFABS.A45GG5.DESC, STRINGS.BUILDINGS.PREFABS.A45GG5.EFFECT);//喵喵排风扇

                StringUtils.AddBuildingStrings("A46GG1", STRINGS.BUILDINGS.PREFABS.A46GG1.NAME, STRINGS.BUILDINGS.PREFABS.A46GG1.DESC, STRINGS.BUILDINGS.PREFABS.A46GG1.EFFECT);//垂直液泵
                StringUtils.AddBuildingStrings("A47GG1", STRINGS.BUILDINGS.PREFABS.A47GG1.NAME, STRINGS.BUILDINGS.PREFABS.A47GG1.DESC, STRINGS.BUILDINGS.PREFABS.A47GG1.EFFECT);//液体灌装器
                StringUtils.AddBuildingStrings("A48GG1", STRINGS.BUILDINGS.PREFABS.A48GG1.NAME, STRINGS.BUILDINGS.PREFABS.A48GG1.DESC, STRINGS.BUILDINGS.PREFABS.A48GG1.EFFECT);//液体灌装器
                StringUtils.AddBuildingStrings("A49GG1", STRINGS.BUILDINGS.PREFABS.A49GG1.NAME, STRINGS.BUILDINGS.PREFABS.A49GG1.DESC, STRINGS.BUILDINGS.PREFABS.A49GG1.EFFECT);//香草抽水马桶
                StringUtils.AddBuildingStrings("A50GG1", STRINGS.BUILDINGS.PREFABS.A50GG1.NAME, STRINGS.BUILDINGS.PREFABS.A50GG1.DESC, STRINGS.BUILDINGS.PREFABS.A50GG1.EFFECT);//香草餐桌

                StringUtils.AddBuildingStrings("A51GG1", STRINGS.BUILDINGS.PREFABS.A51GG1.NAME, STRINGS.BUILDINGS.PREFABS.A51GG1.DESC, STRINGS.BUILDINGS.PREFABS.A51GG1.EFFECT);//管桥
                StringUtils.AddBuildingStrings("A51GG2", STRINGS.BUILDINGS.PREFABS.A51GG2.NAME, STRINGS.BUILDINGS.PREFABS.A51GG2.DESC, STRINGS.BUILDINGS.PREFABS.A51GG2.EFFECT);//管桥
                StringUtils.AddBuildingStrings("A52GG1", STRINGS.BUILDINGS.PREFABS.A52GG1.NAME, STRINGS.BUILDINGS.PREFABS.A52GG1.DESC, STRINGS.BUILDINGS.PREFABS.A52GG1.EFFECT);//管桥
                StringUtils.AddBuildingStrings("A52GG2", STRINGS.BUILDINGS.PREFABS.A52GG2.NAME, STRINGS.BUILDINGS.PREFABS.A52GG2.DESC, STRINGS.BUILDINGS.PREFABS.A52GG2.EFFECT);//管桥

                StringUtils.AddBuildingStrings("A53GG1", STRINGS.BUILDINGS.PREFABS.A53GG1.NAME, STRINGS.BUILDINGS.PREFABS.A53GG1.DESC, STRINGS.BUILDINGS.PREFABS.A53GG1.EFFECT);//管桥
                StringUtils.AddBuildingStrings("A54GG1", STRINGS.BUILDINGS.PREFABS.A54GG1.NAME, STRINGS.BUILDINGS.PREFABS.A54GG1.DESC, STRINGS.BUILDINGS.PREFABS.A54GG1.EFFECT);//管桥

                StringUtils.AddBuildingStrings("A55GG1", STRINGS.BUILDINGS.PREFABS.A55GG1.NAME, STRINGS.BUILDINGS.PREFABS.A55GG1.DESC, STRINGS.BUILDINGS.PREFABS.A55GG1.EFFECT);//核废水处理桶
                StringUtils.AddBuildingStrings("A58GG1", STRINGS.BUILDINGS.PREFABS.A58GG1.NAME, STRINGS.BUILDINGS.PREFABS.A58GG1.DESC, STRINGS.BUILDINGS.PREFABS.A58GG1.EFFECT);//黄金淋浴间

                StringUtils.AddBuildingStrings("A59GG1", STRINGS.BUILDINGS.PREFABS.A59GG1.NAME, STRINGS.BUILDINGS.PREFABS.A59GG1.DESC, STRINGS.BUILDINGS.PREFABS.A59GG1.EFFECT);//液冷机
                StringUtils.AddBuildingStrings("A59GG2", STRINGS.BUILDINGS.PREFABS.A59GG2.NAME, STRINGS.BUILDINGS.PREFABS.A59GG2.DESC, STRINGS.BUILDINGS.PREFABS.A59GG2.EFFECT);//液冷机

                StringUtils.AddBuildingStrings("A60GG1", STRINGS.BUILDINGS.PREFABS.A60GG1.NAME, STRINGS.BUILDINGS.PREFABS.A60GG1.DESC, STRINGS.BUILDINGS.PREFABS.A60GG1.EFFECT);//催化二氧化碳制乙醇
                StringUtils.AddBuildingStrings("A61GG1", STRINGS.BUILDINGS.PREFABS.A61GG1.NAME, STRINGS.BUILDINGS.PREFABS.A61GG1.DESC, STRINGS.BUILDINGS.PREFABS.A61GG1.EFFECT);//石油裂解器
                StringUtils.AddBuildingStrings("A62GG1", STRINGS.BUILDINGS.PREFABS.A62GG1.NAME, STRINGS.BUILDINGS.PREFABS.A62GG1.DESC, STRINGS.BUILDINGS.PREFABS.A62GG1.EFFECT);//石油精炼器
                StringUtils.AddBuildingStrings("A65GG1", STRINGS.BUILDINGS.PREFABS.A65GG1.NAME, STRINGS.BUILDINGS.PREFABS.A65GG1.DESC, STRINGS.BUILDINGS.PREFABS.A65GG1.EFFECT);//气体液化机
                StringUtils.AddBuildingStrings("A64GG1", STRINGS.BUILDINGS.PREFABS.A64GG1.NAME, STRINGS.BUILDINGS.PREFABS.A64GG1.DESC, STRINGS.BUILDINGS.PREFABS.A64GG1.EFFECT);//热裂解甲烷制钻石

                StringUtils.AddBuildingStrings("A66GG1", STRINGS.BUILDINGS.PREFABS.A66GG1.NAME, STRINGS.BUILDINGS.PREFABS.A66GG1.DESC, STRINGS.BUILDINGS.PREFABS.A66GG1.EFFECT);//医废桶
                StringUtils.AddBuildingStrings("A67GG1", STRINGS.BUILDINGS.PREFABS.A67GG1.NAME, STRINGS.BUILDINGS.PREFABS.A67GG1.DESC, STRINGS.BUILDINGS.PREFABS.A67GG1.EFFECT);//石油井

                StringUtils.AddBuildingStrings("A68GG1", STRINGS.BUILDINGS.PREFABS.A68GG1.NAME, STRINGS.BUILDINGS.PREFABS.A68GG1.DESC, STRINGS.BUILDINGS.PREFABS.A68GG1.EFFECT);//精致梯子
                StringUtils.AddBuildingStrings("A68GG2", STRINGS.BUILDINGS.PREFABS.A68GG2.NAME, STRINGS.BUILDINGS.PREFABS.A68GG2.DESC, STRINGS.BUILDINGS.PREFABS.A68GG2.EFFECT);//精致梯子
                StringUtils.AddBuildingStrings("A68GG3", STRINGS.BUILDINGS.PREFABS.A68GG3.NAME, STRINGS.BUILDINGS.PREFABS.A68GG3.DESC, STRINGS.BUILDINGS.PREFABS.A68GG3.EFFECT);//精致梯子

                StringUtils.AddBuildingStrings("A69GG1", STRINGS.BUILDINGS.PREFABS.A69GG1.NAME, STRINGS.BUILDINGS.PREFABS.A69GG1.DESC, STRINGS.BUILDINGS.PREFABS.A69GG1.EFFECT);//辐射掌

                StringUtils.AddBuildingStrings("A70GG1", STRINGS.BUILDINGS.PREFABS.A70GG1.NAME, STRINGS.BUILDINGS.PREFABS.A70GG1.DESC, STRINGS.BUILDINGS.PREFABS.A70GG1.EFFECT);//核废料处理器
                StringUtils.AddBuildingStrings("A70GG2", STRINGS.BUILDINGS.PREFABS.A70GG2.NAME, STRINGS.BUILDINGS.PREFABS.A70GG2.DESC, STRINGS.BUILDINGS.PREFABS.A70GG2.EFFECT);//核废水处理器

                StringUtils.AddBuildingStrings("A72GG1", STRINGS.BUILDINGS.PREFABS.A72GG1.NAME, STRINGS.BUILDINGS.PREFABS.A72GG1.DESC, STRINGS.BUILDINGS.PREFABS.A72GG1.EFFECT);//信号桥和信号组桥
                StringUtils.AddBuildingStrings("A72GG2", STRINGS.BUILDINGS.PREFABS.A72GG2.NAME, STRINGS.BUILDINGS.PREFABS.A72GG2.DESC, STRINGS.BUILDINGS.PREFABS.A72GG2.EFFECT);//信号桥和信号组桥
                StringUtils.AddBuildingStrings("A72GG3", STRINGS.BUILDINGS.PREFABS.A72GG3.NAME, STRINGS.BUILDINGS.PREFABS.A72GG3.DESC, STRINGS.BUILDINGS.PREFABS.A72GG3.EFFECT);//信号桥和信号组桥
                StringUtils.AddBuildingStrings("A72GG4", STRINGS.BUILDINGS.PREFABS.A72GG4.NAME, STRINGS.BUILDINGS.PREFABS.A72GG4.DESC, STRINGS.BUILDINGS.PREFABS.A72GG4.EFFECT);//信号桥和信号组桥

                StringUtils.AddBuildingStrings("A77GG1", STRINGS.BUILDINGS.PREFABS.A77GG1.NAME, STRINGS.BUILDINGS.PREFABS.A77GG1.DESC, STRINGS.BUILDINGS.PREFABS.A77GG1.EFFECT);//饥荒入侵计划

                StringUtils.AddBuildingStrings("A79GG1", STRINGS.BUILDINGS.PREFABS.A79GG1.NAME, STRINGS.BUILDINGS.PREFABS.A79GG1.DESC, STRINGS.BUILDINGS.PREFABS.A79GG1.EFFECT);//恭喜faker拿下LOL第四个冠军

                StringUtils.AddBuildingStrings("A80GG1", STRINGS.BUILDINGS.PREFABS.A80GG1.NAME, STRINGS.BUILDINGS.PREFABS.A80GG1.DESC, STRINGS.BUILDINGS.PREFABS.A80GG1.EFFECT);//警示牌
                StringUtils.AddBuildingStrings("A80GG2", STRINGS.BUILDINGS.PREFABS.A80GG2.NAME, STRINGS.BUILDINGS.PREFABS.A80GG2.DESC, STRINGS.BUILDINGS.PREFABS.A80GG2.EFFECT);//警示牌
                StringUtils.AddBuildingStrings("A83GG1", STRINGS.BUILDINGS.PREFABS.A83GG1.NAME, STRINGS.BUILDINGS.PREFABS.A83GG1.DESC, STRINGS.BUILDINGS.PREFABS.A83GG1.EFFECT);//温度场
                StringUtils.AddBuildingStrings("A84GG1", STRINGS.BUILDINGS.PREFABS.A84GG1.NAME, STRINGS.BUILDINGS.PREFABS.A84GG1.DESC, STRINGS.BUILDINGS.PREFABS.A84GG1.EFFECT);//恒温空间
                
                
                
                
                
                
                
                //------------------------------------------------------------基地------------------------------------------------------------
                StringUtils.AddBuildingStrings("A001GG1", STRINGS.BUILDINGS.PREFABS.A001GG1.NAME, STRINGS.BUILDINGS.PREFABS.A001GG1.DESC, STRINGS.BUILDINGS.PREFABS.A001GG1.EFFECT);
                StringUtils.AddBuildingStrings("A005GG1", STRINGS.BUILDINGS.PREFABS.A005GG1.NAME, STRINGS.BUILDINGS.PREFABS.A005GG1.DESC, STRINGS.BUILDINGS.PREFABS.A005GG1.EFFECT);
                StringUtils.AddBuildingStrings("A008GG1", STRINGS.BUILDINGS.PREFABS.A008GG1.NAME, STRINGS.BUILDINGS.PREFABS.A008GG1.DESC, STRINGS.BUILDINGS.PREFABS.A008GG1.EFFECT);
                StringUtils.AddBuildingStrings("A009GG1", STRINGS.BUILDINGS.PREFABS.A009GG1.NAME, STRINGS.BUILDINGS.PREFABS.A009GG1.DESC, STRINGS.BUILDINGS.PREFABS.A009GG1.EFFECT);
                StringUtils.AddBuildingStrings("A011GG1", STRINGS.BUILDINGS.PREFABS.A011GG1.NAME, STRINGS.BUILDINGS.PREFABS.A011GG1.DESC, STRINGS.BUILDINGS.PREFABS.A011GG1.EFFECT);









                //------------------------------------------------------------植物------------------------------------------------------------
                StringUtils.AddBuildingStrings("B0GG0", STRINGS.BUILDINGS.PREFABS.B0GG0.NAME, STRINGS.BUILDINGS.PREFABS.B0GG0.DESC, STRINGS.BUILDINGS.PREFABS.B0GG0.EFFECT);//氢气灶

                StringUtils.AddPlantSeedStrings("B1GG1", STRINGS.CREATURES.SPECIES.B1GG1.B1, STRINGS.CREATURES.SPECIES.B1GG1.B2);//添加种子
                StringUtils.AddPlantStrings("B1GG2", STRINGS.CREATURES.SPECIES.B1GG1.B3, STRINGS.CREATURES.SPECIES.B1GG1.B4 , STRINGS.CREATURES.SPECIES.B1GG1.B5);//添加植物
                PlantUtils.AddCropType("B1GG3", 5f, 1);//果实属性
                StringUtils.AddFoodStrings("B1GG3", STRINGS.CREATURES.SPECIES.B1GG1.B6, STRINGS.CREATURES.SPECIES.B1GG1.B7);//添加果实


                //------------------------------------------------------------食物------------------------------------------------------------
                StringUtils.AddFoodStrings("C1GG1", STRINGS.CREATURES.SPECIES.C1GG1.C1, STRINGS.CREATURES.SPECIES.C1GG1.C2); ; // 辣椒炒辣椒
                StringUtils.AddFoodStrings("C2GG1", STRINGS.CREATURES.SPECIES.C2GG1.C1, STRINGS.CREATURES.SPECIES.C2GG1.C2); ; // 水煮鱼
                StringUtils.AddFoodStrings("C3GG1", STRINGS.CREATURES.SPECIES.C3GG1.C1, STRINGS.CREATURES.SPECIES.C3GG1.C2); ; // 辣椒炒肉
                StringUtils.AddFoodStrings("C4GG1", STRINGS.CREATURES.SPECIES.C4GG1.C1, STRINGS.CREATURES.SPECIES.C4GG1.C2); ; // 麻辣烫
                StringUtils.AddFoodStrings("C5GG1", STRINGS.CREATURES.SPECIES.C5GG1.C1, STRINGS.CREATURES.SPECIES.C5GG1.C2); ; // 豆花饭
                StringUtils.AddFoodStrings("C6GG1", STRINGS.CREATURES.SPECIES.C6GG1.C1, STRINGS.CREATURES.SPECIES.C6GG1.C2); ; // 肉饺子
                StringUtils.AddFoodStrings("C7GG1", STRINGS.CREATURES.SPECIES.C7GG1.C1, STRINGS.CREATURES.SPECIES.C7GG1.C2); ; // 菜饺子

                StringUtils.AddFoodStrings("D1GG1", STRINGS.CREATURES.SPECIES.D1GG1.D1, STRINGS.CREATURES.SPECIES.D1GG1.D2); ; // 冰淇淋
                StringUtils.AddFoodStrings("D1GG2", STRINGS.CREATURES.SPECIES.D1GG2.D1, STRINGS.CREATURES.SPECIES.D1GG1.D2); ; // 冰淇淋
                StringUtils.AddFoodStrings("D1GG3", STRINGS.CREATURES.SPECIES.D1GG3.D1, STRINGS.CREATURES.SPECIES.D1GG1.D2); ; // 冰淇淋
                StringUtils.AddFoodStrings("D1GG4", STRINGS.CREATURES.SPECIES.D1GG4.D1, STRINGS.CREATURES.SPECIES.D1GG1.D2); ; // 冰淇淋
                StringUtils.AddFoodStrings("D1GG5", STRINGS.CREATURES.SPECIES.D1GG5.D1, STRINGS.CREATURES.SPECIES.D1GG1.D2); ; // 冰淇淋
                StringUtils.AddFoodStrings("D1GG6", STRINGS.CREATURES.SPECIES.D1GG6.D1, STRINGS.CREATURES.SPECIES.D1GG1.D2); ; // 冰淇淋
                StringUtils.AddFoodStrings("D1GG7", STRINGS.CREATURES.SPECIES.D1GG7.D1, STRINGS.CREATURES.SPECIES.D1GG1.D2); ; // 冰淇淋
                StringUtils.AddFoodStrings("D1GG8", STRINGS.CREATURES.SPECIES.D1GG8.D1, STRINGS.CREATURES.SPECIES.D1GG1.D2); ; // 冰淇淋
                StringUtils.AddFoodStrings("D1GG9", STRINGS.CREATURES.SPECIES.D1GG9.D1, STRINGS.CREATURES.SPECIES.D1GG1.D2); ; // 冰淇淋


                StringUtils.AddFoodStrings("E1GG1", STRINGS.CREATURES.SPECIES.E1GG1.E1, STRINGS.CREATURES.SPECIES.E1GG1.E2); ; // 月饼
                StringUtils.AddFoodStrings("E1GG2", STRINGS.CREATURES.SPECIES.E1GG2.E1, STRINGS.CREATURES.SPECIES.E1GG2.E2); ; // 月饼
                StringUtils.AddFoodStrings("E1GG3", STRINGS.CREATURES.SPECIES.E1GG3.E1, STRINGS.CREATURES.SPECIES.E1GG3.E2); ; // 月饼
                StringUtils.AddFoodStrings("E1GG4", STRINGS.CREATURES.SPECIES.E1GG4.E1, STRINGS.CREATURES.SPECIES.E1GG4.E2); ; // 月饼

                //------------------------------------------------------------氧气------------------------------------------------------------
                StringUtils.AddBuildingStrings("A40GG1", STRINGS.BUILDINGS.PREFABS.A40GG1.NAME, STRINGS.BUILDINGS.PREFABS.A40GG1.DESC, STRINGS.BUILDINGS.PREFABS.A40GG1.EFFECT);//智能制氧机

                StringUtils.AddBuildingStrings("A41GG1", STRINGS.BUILDINGS.PREFABS.A41GG1.NAME, STRINGS.BUILDINGS.PREFABS.A41GG1.DESC, STRINGS.BUILDINGS.PREFABS.A41GG1.EFFECT);//气体发生器
                StringUtils.AddBuildingStrings("A41GG2", STRINGS.BUILDINGS.PREFABS.A41GG2.NAME, STRINGS.BUILDINGS.PREFABS.A41GG2.DESC, STRINGS.BUILDINGS.PREFABS.A41GG2.EFFECT);//气体发生器
                StringUtils.AddBuildingStrings("A41GG3", STRINGS.BUILDINGS.PREFABS.A41GG3.NAME, STRINGS.BUILDINGS.PREFABS.A41GG3.DESC, STRINGS.BUILDINGS.PREFABS.A41GG3.EFFECT);//气体发生器
                StringUtils.AddBuildingStrings("A41GG4", STRINGS.BUILDINGS.PREFABS.A41GG4.NAME, STRINGS.BUILDINGS.PREFABS.A41GG4.DESC, STRINGS.BUILDINGS.PREFABS.A41GG4.EFFECT);//气体发生器
                StringUtils.AddBuildingStrings("A41GG5", STRINGS.BUILDINGS.PREFABS.A41GG5.NAME, STRINGS.BUILDINGS.PREFABS.A41GG5.DESC, STRINGS.BUILDINGS.PREFABS.A41GG5.EFFECT);//气体发生器

                StringUtils.AddBuildingStrings("A42GG1", STRINGS.BUILDINGS.PREFABS.A42GG1.NAME, STRINGS.BUILDINGS.PREFABS.A42GG1.DESC, STRINGS.BUILDINGS.PREFABS.A42GG1.EFFECT);//淘金热


            }
        }
        public class UI
        {
            public class UNITSUFFIXES
            {
                public static LocString 千克 = "kg";//千克
                public static LocString 摄氏度 = "℃";//摄氏度
                public static LocString 卡尔文 = "K";//开尔文
                public static LocString 勒克斯 = "lux";//光强
                public static LocString 瓦 = "W";//瓦
                public static LocString 焦耳 = "J";//焦耳
                public static LocString 拉德 = "Rads";//辐射kDTU/s
                public static LocString 热量 = "kDTU/s";//热量
                public static LocString 格 = "格";//热量
                public static LocString 控制器 = "控制器";//空
                public static LocString 点这里 = "点这里";//空
                public static LocString 空 = "x";//空

                public static LocString 长 = "长";//空
                public static LocString 高 = "高";//空
                public static LocString 宽 = "宽";//空
                public static LocString 能量 = "能量";//空

            }
            public class PICTURE
            {
                public static LocString picture = "图集";//侧边栏名称可使用中文
            }
        }
        public class CREATURES
        {
            public class SPECIES
            {
                //---------------------------------------植物---------------------------------------
                public class B001GG1//超级氧齿阙
                {
                    public static LocString NAME = "超级氧齿阙";
                }
                //------------------------------------------------------------植物------------------------------------------------------------
                public class B1GG1
                {
                    public static LocString B1 = "辣椒籽";//种子名称
                    public static LocString B2 = "播下一粒辣椒籽，长成一株辣椒树。";//种子描述
                    public static LocString B3 = "辣椒树";//植物名称
                    public static LocString B4 = "辣椒，是茄科辣椒属的一年生草本植物，其根系不发达，茎直立；单叶互生，卵圆形，叶面光滑；花单生或簇生，多为白色；果面平滑或皱褶，具光泽；果实呈扁圆、圆球、圆锥或线形，种子为淡黄色的扁肾形；花果期5-11月。";//植物描述
                    public static LocString B5 = "5";//植物描述-------------未知不填
                    public static LocString B6 = "辣椒";//果实名称
                    public static LocString B7 = "辣椒树的果实来辣椒，辣，添加到其它食物里面能够获得别一番的风味。注意，别多放，不然，你会怀疑人生。";//果实描述
                    public static LocString B8 = "等交易获得辣椒籽";//种子配方描述

                }
                //------------------------------------------------------------食物------------------------------------------------------------
                public class C1GG1
                {
                    public static LocString C1 = "炒辣椒";//食物名称
                    public static LocString C2 = "炒辣椒也是一道一场美味的食物，但请注意，对于大多数而言，这并不是一道“美味”的食物。";//食物描述
                    public static LocString C3 = "食材只有辣椒";//食物配方描述
                }
                public class C2GG1
                {
                    public static LocString C1 = "水煮鱼";
                    public static LocString C2 = "水煮鱼的奥秘是什么？一把辣椒！什么，做出来的水煮鱼依然不好吃？那就再来一把辣椒！什么，还是不好吃？把鱼肉挑出来，把辣椒倒进去！！！";
                    public static LocString C3 = "辣.水煮鱼";
                }
                public class C3GG1
                {
                    public static LocString C1 = "辣椒炒肉";
                    public static LocString C2 = "辣椒炒肉的第一个秘诀，辣！辣椒炒肉的第二个秘诀，辣，辣！辣椒炒肉的第三个秘诀，辣，辣，辣！";
                    public static LocString C3 = "辣.辣椒炒肉";
                }
                public class C4GG1
                {
                    public static LocString C1 = "麻辣烫";
                    public static LocString C2 = "麻辣烫主要是将各种食材放入沸腾的麻辣汤中煮熟，然后捞出沾上调味料食用，具有麻、辣、香、鲜的特点！";
                    public static LocString C3 = "辣.麻辣烫";
                }
                public class C5GG1
                {
                    public static LocString C1 = "豆花饭";
                    public static LocString C2 = "简简单单的一碗豆花饭。";
                    public static LocString C3 = "辣.豆花饭";
                }
                public class C6GG1
                {
                    public static LocString C1 = "肉饺子";
                    public static LocString C2 = "高明的厨师，化平凡为传奇。任谁能想到，将肉包裹在面皮里，可以蒸煎炒炸煮，万般手法，万般滋味。";
                    public static LocString C3 = "肉馅的饺子。";
                }
                public class C7GG1
                {
                    public static LocString C1 = "菜饺子";
                    public static LocString C2 = "高明的厨师，化平凡为传奇。任谁能想到，将菜包裹在面皮里，可以蒸煎炒炸煮，万般手法，万般滋味。";
                    public static LocString C3 = "菜馅的饺子";
                }
                public class D1GG1
                {
                    public static LocString D1 = "小爱";
                    public static LocString D2 = "由冰加咸乳制作而成，保留了咸乳的软糯，继承了冰的嫩白。香软可口，让异国他乡的小人们，也能吃上一口熟悉的冰淇淋！";
                    public static LocString D3 = "好吃吗，冰冰的。";
                }
                public class D1GG2
                {
                    public static LocString D1 = "小梦";
                }
                public class D1GG3
                {
                    public static LocString D1 = "小度";
                }
                public class D1GG4
                {
                    public static LocString D1 = "小汪";
                }
                public class D1GG5
                {
                    public static LocString D1 = "小喵";
                }
                public class D1GG6
                {
                    public static LocString D1 = "小笨";
                }
                public class D1GG7
                {
                    public static LocString D1 = "小林";
                }
                public class D1GG8
                {
                    public static LocString D1 = "小小";
                }
                public class D1GG9
                {
                    public static LocString D1 = "小二";
                }
                public class E1GG4
                {
                    public static LocString E1 = "冰皮月饼";
                    public static LocString E2 = "冰皮月饼不用烘烤，用糯米粉和冰糖制成皮，馅料有各种水果、奶油、冰淇淋等，口感清爽甜美，适合夏秋之交食用。";
                    public static LocString E3 = "中秋节快乐！";
                }
                public class E1GG1
                {
                    public static LocString E1 = "鲜肉月饼";
                    public static LocString E2 = "鲜肉月饼是江浙一带的特色，用面粉和猪肉馅制成，外皮金黄酥脆，内馅肉汁丰富，咸香可口，是一种咸味月饼。";
                    public static LocString E3 = "中秋节快乐！";
                }
                public class E1GG3
                {
                    public static LocString E1 = "芝麻月饼";
                    public static LocString E2 = "芝麻月饼是北方地区的传统食品，用面粉和芝麻馅制成，外皮白色或黑色，内馅香甜软糯，富含维生素E和钙质。";
                    public static LocString E3 = "中秋节快乐！";
                }
                public class E1GG2
                {
                    public static LocString E1 = "鲜花月饼";
                    public static LocString E2 = "鲜花月饼特点是馅料主要是果蔬，配料是鲜花，馅心滑软，风味各异，馅料有菊花、玫瑰花、荔枝、草莓、白合、芋头、乌梅、橙等，又配以果汁或果浆，因此更具清新爽甜的风味。";
                    public static LocString E3 = "中秋节快乐！";
                }
            }
        }
        public class BUILDINGS
        {
            public class PREFABS
            {

                //------------------------------------------------------------电力------------------------------------------------------------
                public class XINHAO
                {
                    public static LocString LOGIC_PORT = "发射信号";
                    public static LocString LOGIC_PORT_ACTIVE = "绿色信号";
                    public static LocString LOGIC_PORT_INACTIVE = "红色信号";
                }
                public class B0GG0//种子研究站
                {
                    public static LocString NAME = "种子研究站";//建筑名
                    public static LocString EFFECT = "等价交易，在这里，你能获得一些想不到的种子。";//建筑效果
                    public static LocString DESC = "有钱，你就拥有了一切。";

                }
                public class A1GG1//南孚电池
                {
                    public static LocString NAME = "北孚电池";//建筑名
                    public static LocString EFFECT = "连接输电线，将电网中多余的电量以化学能的方式储存起来，并在你需要的时候将其释放在电网中。 \n\n 这不是南孚电池，这是北孚电池。我们不生产电能，我们只是电能的搬运工。";//建筑效果
                    public static LocString DESC = "北孚电池，一节更比一节强。";
                }
                public class A2GG1//民用电池组
                {
                    public static LocString NAME = "民用电池组";//建筑名
                    public static LocString EFFECT = "连接输电线，将电网中多余的电量以化学能的方式储存起来，并在你需要的时候将其释放在电网中。 \n\n 可相互堆叠的电池，不仅节省了大量的空间，也能更加便利的管理电源系统。如果喜欢，十个电池重叠建造，也是可以的。";//建筑效果
                    public static LocString DESC = "一个电池不够？那就再来一个！";
                }
                public class A3GG1//一格电池
                {
                    public static LocString NAME = "一格电池";//建筑名
                    public static LocString EFFECT = "连接输电线，将电网中多余的电量以化学能的方式储存起来，并在你需要的时候将其释放在电网中。 \n\n 小小的身躯，大大的能量。在最新的制造工艺下，即便只有方寸大小，依然能够容纳不可估量的容量。";//建筑效果
                    public static LocString DESC = "不要觉得我小，其实我很大。";
                }
                public class A4GG1//细电线
                {
                    public static LocString NAME = "细电线";//建筑名
                    public static LocString EFFECT = "厌倦了拳头粗的电线，厌倦了明明同样使用金属制造却极易过载的普通电线。美观、实用，是它的代名词。在你需要的地方使用它，在你不需要的地方使用它，不要后悔，你会爱上它的细。";//建筑效果
                    public static LocString DESC = "粗，有粗的好处。细，有细的精妙。";
                }
                public class A7GG1//跨两格导线桥
                {
                    public static LocString NAME = "跨两格导线桥";//建筑名
                    public static LocString EFFECT = "这个导线桥由导线制造而成，在它的下方能够穿越两条输电线而不会对它造成影响。但请注意，越复杂的电路越显现出它的作用，但也越发的增加了电路设计和维护的难度，谨记!";//建筑效果
                    public static LocString DESC = "横跨两格，就问你怕不怕！";
                }
                public class A8GG1//跨两格电线桥
                {
                    public static LocString NAME = "跨两格电线桥";//建筑名
                    public static LocString EFFECT = "这个导线桥由电线制造而成，在它的下方能够穿越两条输电线而不会对它造成影响。但请注意，越复杂的电路越显现出它的作用，但也越发的增加了电路设计和维护的难度，谨记!";//建筑效果
                    public static LocString DESC = "横跨两格，就问你怕不怕！";
                }
                public class A9GG1//跨三格导线桥
                {
                    public static LocString NAME = "跨三格导线桥";//建筑名
                    public static LocString EFFECT = "这个导线桥由导线制造而成，在它的下方能够穿越三条输电线而不会对它造成影响。但请注意，越复杂的电路越显现出它的作用，但也越发的增加了电路设计和维护的难度，谨记!";//建筑效果
                    public static LocString DESC = "横跨三格，就问你怕不怕！";
                }
                public class A10GG1//跨三格电线桥
                {
                    public static LocString NAME = "跨三格电线桥";//建筑名
                    public static LocString EFFECT = "这个导线桥由导线制造而成，在它的下方能够穿越三条输电线而不会对它造成影响。但请注意，越复杂的电路越显现出它的作用，但也越发的增加了电路设计和维护的难度，谨记!";//建筑效果
                    public static LocString DESC = "横跨三格，就问你怕不怕！";
                }

                //------------------------------------------------------------家具------------------------------------------------------------

                public class A11GG1//喵喵床
                {
                    public static LocString NAME = "粉色喵喵床";//建筑名
                    public static LocString EFFECT = "软乎乎，毛绒绒，如果躺在她的怀里睡觉，一定很舒服的吧。真可爱，我最乖的小猫猫，喵喵喵。";//建筑效果
                    public static LocString DESC = "送给好友的礼物，愿你永远青春美丽，愿你永远开心快乐*-*";
                }
                public class A11GG2//喵喵床
                {
                    public static LocString NAME = "黄色喵喵床";//建筑名
                    public static LocString EFFECT = "软乎乎，毛绒绒，如果躺在她的怀里睡觉，一定很舒服的吧。真可爱，我最乖的小猫猫，喵喵喵。";//建筑效果
                    public static LocString DESC = "送给好友的礼物，愿你永远青春美丽，愿你永远开心快乐*-*";
                }
                public class A13GG1//简单漂亮床
                {
                    public static LocString NAME = "简单漂亮床";//建筑名
                    public static LocString EFFECT = "三只气球，一只小熊猫，这又是哪位毛孩子的港湾。后面挂着的那“I LOVE YOU”，一定代表了那海枯石烂的爱情吧，不知，那梦中的情人，在何方。";//建筑效果
                    public static LocString DESC = "A13GG1";
                }
                public class A14GG1//叠叠床
                {
                    public static LocString NAME = "叠叠床";//建筑名
                    public static LocString EFFECT = "人口数量太多，床不够，怎么办，叠叠床来凑数。能够相互重叠建造，一层一个小人，在荒郊野外，简直爽歪歪。";//建筑效果
                    public static LocString DESC = "A14GG1";
                }
                public class A15GG1//吊床1
                {
                    public static LocString NAME = "海湾吊床";//建筑名
                    public static LocString EFFECT = "天蓝的色彩，轻巧的造型，圆润的曲线，五一不透露出它的美。小人睡在上面有点晃，是真的吗，并不是，那是调皮的小人在做着美梦。";//建筑效果
                    public static LocString DESC = "哪怕只是离地一尺，那也是天空的味道。";
                }
                public class A15GG2//吊床2
                {
                    public static LocString NAME = "北欧吊床";//建筑名
                    public static LocString EFFECT = "独具匠心，石质工艺。远古的岁月让人们遗忘了仰望星空的感觉，忘记了在大自然的微风吹拂下，安然入睡的美妙。粗糙的技巧，不及曾经的十分之一，在这个年代，却又显得弥足珍贵。";//建筑效果
                    public static LocString DESC = "哪怕只是离地一尺，那也是天空的味道。";
                }
                public class A16GG1//恭喜DRX夺得英雄联盟S12全球总决赛冠军
                {
                    public static LocString NAME = "恭喜DRX夺得英雄联盟S12全球总决赛冠军";//建筑名
                    public static LocString EFFECT = "恭喜DRX夺得英雄联盟S12全球总决赛冠军";//建筑效果
                    public static LocString DESC = "恭喜DRX夺得英雄联盟S12全球总决赛冠军";
                }
                public class A18GG1//背景灯
                {
                    public static LocString NAME = "背景灯";//建筑名
                    public static LocString EFFECT = "它可以建造在普通建筑后面，光亮没有那么的强，用来给雕塑增加一点点氛围感，足够了。";//建筑效果
                    public static LocString DESC = "一丝微光，一丝点缀。";
                }
                public class A19GG1//卡塔尔世界杯吉祥物
                {
                    public static LocString NAME = "卡塔尔世界杯吉祥物";//建筑名
                    public static LocString EFFECT = "喜欢足球吗，亲切的为你提供了几个可以选择的足球小子。想要在游戏里踢足球吗，啊，或许圆滚滚的哈奇是一个不错的选择。嘘，小心别被听见了，它会咬人，大概，或许，可能吧。";//建筑效果
                    public static LocString DESC = "请注意，那不是饺子。";
                }
                public class A20GG1//圣诞树
                {
                    public static LocString NAME = "圣诞树";//建筑名
                    public static LocString EFFECT = "圣诞节怎么能够没有圣诞树呢，还是一颗能够发光的圣诞树。在这美好的节日里，未来的每一天，都是幸运的一天。";//建筑效果
                    public static LocString DESC = "圣诞节快乐";
                }
                public class A21GG1//圣诞礼物
                {
                    public static LocString NAME = "圣诞礼物";//建筑名
                    public static LocString EFFECT = "没有圣诞老人，圣诞老人没有办法在没有烟囱的游戏里出现。但我们仍能收到圣诞老人送出的礼物，或许老爷爷也会编程，所以通过烟囱漏洞悄咪咪的将礼物送出，也说不定哟。";//建筑效果
                    public static LocString DESC = "圣诞节快乐";
                }
                public class A22GG1//南瓜灯
                {
                    public static LocString NAME = "南瓜灯";//建筑名
                    public static LocString EFFECT = "厌倦了白炽灯白色的光芒，增加了一点点的色彩，让世界不是那么非黑即白。如果某天，没有食物了，南瓜灯去掉灯，或许可以吃，在掉下一排牙齿的前提下。";//建筑效果
                    public static LocString DESC = "别吃，它不是真的南瓜！";
                }
                public class A23GG1//沥青滴落实验
                {
                    public static LocString NAME = "沥青滴落实验";//建筑名
                    public static LocString EFFECT = "还记得初中物理对于固体液体气体的描述吗，那么问题来了，沥青是固体还是液体。如果你看它比较硬硬的，就说它是固体，这是不对的。科学，需要事实的支撑，需要数据的支撑。一年，两年，三年，很多年。或许某一天你能观察到沥青滴落的那一瞬间。那个是时候，你或许会感叹，科学，神奇。";//建筑效果
                    public static LocString DESC = "沥青是一种液体哟。";
                }
                public class A24GG1//下雪啦
                {
                    public static LocString NAME = "下雪啦";//建筑名
                    public static LocString EFFECT = "想家了，想起了家乡的雪。这个世界没有雪，自己造。最新3D成像技术，带你体验下雪的美妙快感。";//建筑效果
                    public static LocString DESC = "假的，全都是假的，这个世界。";
                }
                public class A25GG1//启动魔法少女
                {
                    public static LocString NAME = "启动魔法少女";//建筑名
                    public static LocString EFFECT = "孩子，想要成为魔法少女吗？缔结契约，一起拯救世界。";//建筑效果
                    public static LocString DESC = "小心，学姐的头被拧下来了。";
                }
                public class A27GG1//天地棋局
                {
                    public static LocString NAME = "天地棋局";//建筑名
                    public static LocString EFFECT = "以大地为棋盘，以江河为线，以日月山川为子。这是一盘棋，可以是围棋，可以是将棋，也可以是五子棋。心够大，一切皆有可能。";//建筑效果
                    public static LocString DESC = "放轻松，这只是一个游戏。";
                }
                public class A28GG1//武器架
                {
                    public static LocString NAME = "武器架";//建筑名
                    public static LocString EFFECT = "平平无奇的木头架子，上面或许可以放一点东西。放一些什么呢，当然是放一排的武器了，你想要放什么，最好是放冷兵器，因为热兵器太热了。";//建筑效果
                    public static LocString DESC = "大人，你就不想把它填满吗。";
                }
                public class A28GG2//武器
                {
                    public static LocString NAME = "武器";//建筑名
                    public static LocString EFFECT = "刀枪剑戟......十八般兵器尽入其中。你想要什么，这里不一定有，如果你是铁匠，那到有可能有。";//建筑效果
                    public static LocString DESC = "看着就吓人。";
                }
                public class A29GG1//ACGN之鞋子
                {
                    public static LocString NAME = "ACGN之鞋子";//建筑名
                    public static LocString EFFECT = "这是鞋子，你可以更换不同的鞋子。";//建筑效果
                    public static LocString DESC = "鞋子。";
                }
                public class A29GG2//ACGN之裤子
                {
                    public static LocString NAME = "ACGN之裤子";//建筑名
                    public static LocString EFFECT = "这是裤子，你可以更换不同的裤子。";//建筑效果
                    public static LocString DESC = "裤子";
                }
                public class A29GG3//ACGN之衣裳
                {
                    public static LocString NAME = "ACGN之衣裳";//建筑名
                    public static LocString EFFECT = "这是衣裳，你可以更换不同的衣裳。";//建筑效果
                    public static LocString DESC = "衣裳";
                }
                public class A29GG4//ACGN之头发
                {
                    public static LocString NAME = "ACGN之发型";//建筑名
                    public static LocString EFFECT = "这是发型，你可以更换不同的发型。";//建筑效果
                    public static LocString DESC = "发型";
                }
                public class A30GG1//萤火虫灯
                {
                    public static LocString NAME = "萤火虫灯";//建筑名
                    public static LocString EFFECT = "酷似萤火虫的灯，你可以控制它的灯光范围和亮度，注意，范围越大能耗越高。";//建筑效果
                    public static LocString DESC = "可爱的萤火虫灯。";
                }
                public class A31GG1//香草摇摇床
                {
                    public static LocString NAME = "香草摇摇床";//建筑名
                    public static LocString EFFECT = "睡惯了方的床，睡惯了圆的床。这里有不方不圆的床，可以考虑一下。带着青草的香味入眠，想来，也是极好的。";//建筑效果
                    public static LocString DESC = "不要想多了，它不会晃。";
                }
                public class A32GG1//香草花盆
                {
                    public static LocString NAME = "香草蓝花盆";//建筑名
                    public static LocString EFFECT = "蓝色的花盆，带着一点点点缀，高端大气上档次。";//建筑效果
                    public static LocString DESC = "不要怀疑，奢华风。";
                }
                public class A32GG2//香草花盆
                {
                    public static LocString NAME = "香草金花盆";//建筑名
                    public static LocString EFFECT = "金色的花盆，带着一点点点缀，高端大气上档次。";//建筑效果
                    public static LocString DESC = "不要怀疑，奢华风。";
                }
                public class A32GG3//香草花盆
                {
                    public static LocString NAME = "香草粉花盆";//建筑名
                    public static LocString EFFECT = "粉色的花盆，带着一点点点缀，高端大气上档次。";//建筑效果
                    public static LocString DESC = "不要怀疑，奢华风。";
                }
                public class A32GG4//香草花盆
                {
                    public static LocString NAME = "香草红花盆";//建筑名
                    public static LocString EFFECT = "红色的花盆，带着一点点点缀，高端大气上档次。";//建筑效果
                    public static LocString DESC = "不要怀疑，奢华风。";
                }
                public class A33GG1//香草梯子
                {
                    public static LocString NAME = "香草梯子";//建筑名
                    public static LocString EFFECT = "藤蔓编织，香草梯子。";//建筑效果
                    public static LocString DESC = "爱我就请踩我。";
                }
                public class A34GG1//英雄联盟宣传片
                {
                    public static LocString NAME = "英雄联盟宣传片";//建筑名
                    public static LocString EFFECT = "游戏里能做到什么，这个游戏里面能够做到什么。我喜欢这个游戏，我喜欢另外一个游戏，该如何。";//建筑效果
                    public static LocString DESC = "人在，塔在。";
                }
                public class A35GG1//熊猫贴纸
                {
                    public static LocString NAME = "熊猫贴纸";//建筑名
                    public static LocString EFFECT = "各种熊猫可以任君选择，拟人化的化的熊猫也是熊猫，可爱，萌。";//建筑效果
                    public static LocString DESC = "人均一只？牢底坐穿！";
                }
                public class A36GG1//翻飞幻梦
                {
                    public static LocString NAME = "翻飞幻梦";//建筑名
                    public static LocString EFFECT = "喜欢动漫吗，喜欢二次元吗，在这里，有很多。";//建筑效果
                    public static LocString DESC = "好可爱，想拥有。";
                }
                public class A37GG1//牛战士的面具
                {
                    public static LocString NAME = "牛战士的面具";//建筑名
                    public static LocString EFFECT = "挖空的，就遮起来，看不见，就没有。你可以放大缩小它的大小，变大，变小，很方便哟。";//建筑效果
                    public static LocString DESC = "牛战士，从不取下他的面具。";
                }

                //------------------------------------------------------------食物------------------------------------------------------------

                public class A38GG1//氢气灶
                {
                    public static LocString NAME = "氢气灶";//建筑名
                    public static LocString EFFECT = "氢能源是世界公认的清洁能源，使用天然气则会排放出大量的温室气体（二氧化碳），为了小人未来的青山绿水，使用氢气的氢气灶，由此而生。";//建筑效果
                    public static LocString DESC = "绿色清洁无污染。";
                }
                public class A39GG1//冰淇淋机
                {
                    public static LocString NAME = "冰淇淋机";//建筑名
                    public static LocString EFFECT = "高端科技，即便是平平无奇咸乳，也能化腐朽为神奇。一点点冰，一点点咸乳，一点点爱，冰淇淋，闪亮登场。";//建筑效果
                    public static LocString DESC = "轻一点，别把小章鱼吓跑了。";
                }
                public class A40GG1//智能制氧机
                {
                    public static LocString NAME = "智能制氧机";//建筑名
                    public static LocString EFFECT = "廉价的制氧机，大众喜欢的制氧机。";//建筑效果
                    public static LocString DESC = "抛去华而不实的外表，剩下的是什么。";
                }
                public class A41GG1//气体发生器
                {
                    public static LocString NAME = "氧气发生器";//建筑名
                    public static LocString EFFECT = "消耗大量藻类，获得氧气。";//建筑效果
                    public static LocString DESC = "咕咕鱼生物科技有限公司";
                }
                public class A41GG2//气体发生器
                {
                    public static LocString NAME = "天然气发生器";//建筑名
                    public static LocString EFFECT = "消耗大量藻类，获得天然气。";//建筑效果
                    public static LocString DESC = "咕咕鱼生物科技有限公司";
                }
                public class A41GG3//气体发生器
                {
                    public static LocString NAME = "氯气发生器";//建筑名
                    public static LocString EFFECT = "消耗大量藻类，获得氯气。";//建筑效果
                    public static LocString DESC = "咕咕鱼生物科技有限公司";
                }
                public class A41GG4//气体发生器
                {
                    public static LocString NAME = "二氧化碳发生器";//建筑名
                    public static LocString EFFECT = "消耗大量藻类，获得二氧化碳。";//建筑效果
                    public static LocString DESC = "咕咕鱼生物科技有限公司";
                }
                public class A41GG5//气体发生器
                {
                    public static LocString NAME = "氢气发生器";//建筑名
                    public static LocString EFFECT = "消耗大量藻类，获得氢气。";//建筑效果
                    public static LocString DESC = "咕咕鱼生物科技有限公司";
                }
                public class A42GG1//淘金热
                {
                    public static LocString NAME = "天工-污水淘金机";//建筑名
                    public static LocString EFFECT = "从污水中过滤出微量黄金。";//建筑效果
                    public static LocString DESC = "我们不生产黄金，我们只是黄金的搬运工。";
                }


                public class A43GG1//九块九包邮的花盆
                {
                    public static LocString NAME = "一壹号花盆";//建筑名
                    public static LocString EFFECT = "九块九包邮的花盆大甩卖了啊！";//建筑效果
                    public static LocString DESC = "兰有秀兮菊有芳，怀佳人兮不能忘。";
                }
                public class A43GG2//九块九包邮的花盆
                {
                    public static LocString NAME = "贰号花盆";//建筑名
                }
                public class A43GG3//九块九包邮的花盆
                {
                    public static LocString NAME = "叁号花盆";//建筑名
                }
                public class A43GG4//九块九包邮的花盆
                {
                    public static LocString NAME = "肆号花盆";//建筑名
                }
                public class A43GG5//九块九包邮的花盆
                {
                    public static LocString NAME = "伍号花盆";//建筑名
                }
                public class A43GG6//九块九包邮的花盆
                {
                    public static LocString NAME = "陆号花盆";//建筑名
                }
                public class A43GG7//九块九包邮的花盆
                {
                    public static LocString NAME = "柒号花盆";//建筑名
                }
                public class A43GG8//九块九包邮的花盆
                {
                    public static LocString NAME = "捌号花盆";//建筑名
                }
                //------------------------------------------------------------管道------------------------------------------------------------

                public class A45GG1//喵喵排风扇
                {
                    public static LocString NAME = "排二氧化碳风扇";//建筑名
                    public static LocString EFFECT = "抽取二氧化碳";//建筑效果
                    public static LocString DESC = "小巧而精致";
                }
                public class A45GG2//喵喵排风扇
                {
                    public static LocString NAME = "排甲烷风扇";//建筑名
                    public static LocString EFFECT = "抽取甲烷";//建筑效果
                    public static LocString DESC = "小巧而精致";
                }
                public class A45GG3//喵喵排风扇
                {
                    public static LocString NAME = "排氯气风扇";//建筑名
                    public static LocString EFFECT = "抽取氯气";//建筑效果
                    public static LocString DESC = "小巧而精致";
                }
                public class A45GG4//喵喵排风扇
                {
                    public static LocString NAME = "排氢气风扇";//建筑名
                    public static LocString EFFECT = "抽取氢气";//建筑效果
                    public static LocString DESC = "小巧而精致";
                }
                public class A45GG5//喵喵排风扇
                {
                    public static LocString NAME = "排污染氧风扇";//建筑名
                    public static LocString EFFECT = "抽取污染氧";//建筑效果
                    public static LocString DESC = "小巧而精致";
                }

                public class A46GG1//垂直液泵
                {
                    public static LocString NAME = "垂直液泵";//建筑名
                    public static LocString EFFECT = "神奇的液泵";//建筑效果
                    public static LocString DESC = "神奇的液泵";
                }
                public class A47GG1//液体灌装器
                {
                    public static LocString NAME = "液体灌装器";//建筑名
                    public static LocString EFFECT = "神奇的液泵神奇的液泵。";//建筑效果
                    public static LocString DESC = "把液体装进瓶子里。";
                }
                public class A48GG1//迷你液泵
                {
                    public static LocString NAME = "迷你液泵";//建筑名
                    public static LocString EFFECT = "小小的身体，大大的能力。利用了流体力学和杠杆学，水将被运送到高高的远方。添加了最新的防漏电技术，再也不用担心触电了。添加了最新的液体检测技术，在没有液体的环境中，避免了设备空转。好产品，请选择“喵喵喵”牌迷你液泵。";//建筑效果
                    public static LocString DESC = "北冥有鱼,其名为鲲。";
                }

                public class A49GG1//香草抽水马桶
                {
                    public static LocString NAME = "香草抽水马桶";//建筑名
                    public static LocString EFFECT = "采薇采薇，薇亦作止。";//建筑效果
                    public static LocString DESC = "小雅·采薇。";
                }
                public class A50GG1//香草餐桌
                {
                    public static LocString NAME = "香草餐桌";//建筑名
                    public static LocString EFFECT = "靡室靡家，玁狁之故。";//建筑效果
                    public static LocString DESC = "小雅·采薇。";
                }
                public class A51GG1//管桥
                {
                    public static LocString NAME = "跨两液桥";//建筑名
                    public static LocString EFFECT = "跨两格液体管桥。";//建筑效果
                    public static LocString DESC = "喵喵喵。";
                }
                public class A51GG2//管桥
                {
                    public static LocString NAME = "跨三液桥";//建筑名
                    public static LocString EFFECT = "跨三格液体管桥。";//建筑效果
                    public static LocString DESC = "喵喵喵。";
                }
                public class A52GG1//管桥
                {
                    public static LocString NAME = "跨两气桥";//建筑名
                    public static LocString EFFECT = "跨两格气体管桥。";//建筑效果
                    public static LocString DESC = "喵喵喵。";
                }
                public class A52GG2//管桥
                {
                    public static LocString NAME = "跨三气桥";//建筑名
                    public static LocString EFFECT = "跨三格气体管桥。";//建筑效果
                    public static LocString DESC = "喵喵喵。";
                }

                public class A53GG1//导热气体管道
                {
                    public static LocString NAME = "导热气体管道";//建筑名
                    public static LocString EFFECT = "导热的气体管道。";//建筑效果
                    public static LocString DESC = "喵喵喵。";
                }

                public class A54GG1//导热液体管道
                {
                    public static LocString NAME = "导热液体管道";//建筑名
                    public static LocString EFFECT = "导热的液体管道。";//建筑效果
                    public static LocString DESC = "喵喵喵。";
                }
                public class A55GG1//核废水处理桶
                {
                    public static LocString NAME = "核废水处理桶";//建筑名
                    public static LocString EFFECT = "核废水是一种含有大量放射性物质的废水，对人类和环境都有严重的危害。核废水对人体的危害主要有以下几方面：\r\n\r\n致癌。放射性物质可以破坏人体细胞的正常功能，导致癌变或突变。\r\n遗传。放射性物质可以影响人体的DNA，导致基因缺陷或变异。这些缺陷或变异可能会传给后代，造成先天性疾病或畸形。\r\n器官损伤。放射性物质可以通过食物链或呼吸道进入人体，积累在某些器官或组织中，造成慢性损伤或功能障碍。例如，氚可以积累在骨骼中，影响骨髓造血功能。\r\n因此，核废水是一种非常危险的污染源，应该尽量避免接触或食用受到核废水污染的水源或食物。海洋产品也可能受到核废水的影响，因为核废水会污染海洋生态系统，导致海洋生物的死亡或变异5。在食用海洋产品之前，应该检查其是否安全无害。";//建筑效果
                    public static LocString DESC = "关爱生命，远离核污染。";
                }
                public class A55GG2//核废水处理桶
                {
                    public static LocString NAME = "核废水处理桶";//建筑名
                    public static LocString EFFECT = "人类只有一个地球。";//建筑效果
                    public static LocString DESC = "关爱生命，远离核污染。";
                }
                public class A58GG1//黄金淋浴间
                {
                    public static LocString NAME = "黄金淋浴间";//建筑名
                    public static LocString EFFECT = "她只是闪闪发光而已，她能有什么错呢。";//建筑效果
                    public static LocString DESC = "土豪的气息，怎能被泥土所掩盖。";
                }
                public class A59GG1//液冷机
                {
                    public static LocString NAME = "超级液冷机";//建筑名
                    public static LocString EFFECT = "我来自太阳，只为在地球吃上一块雪糕。";//建筑效果
                    public static LocString DESC = "冰霜巨人的液冷机，不产生热量的液冷机。";
                }
                public class A59GG2//气冷机
                {
                    public static LocString NAME = "超级气冷机";//建筑名
                    public static LocString EFFECT = "我来自太阳，只为在地球吃上一块雪糕。";//建筑效果
                    public static LocString DESC = "冰霜巨人的气冷机，不产生热量的液冷机。";
                }

                public class A60GG1//催化二氧化碳制乙醇
                {
                    public static LocString NAME = "二氧化碳制乙醇";//建筑名
                    public static LocString EFFECT = "吸收CO2，消耗水，催化生成氧气和乙醇。";//建筑效果
                    public static LocString DESC = "2CO2+3H2O=C2H6O+3O2。";
                }
                public class A61GG1//石油裂解器
                {
                    public static LocString NAME = "石油裂解器";//建筑名
                    public static LocString EFFECT = "输入石油，裂解产物是甲烷和天然气。";//建筑效果
                    public static LocString DESC = "现代工业基础。";
                }
                public class A62GG1//石油精炼器
                {
                    public static LocString NAME = "石油精炼器";//建筑名
                    public static LocString EFFECT = "输入石油，输出甲烷和精炼碳。";//建筑效果
                    public static LocString DESC = "请不要和石油裂解器搞混了哟。";
                }
                public class A63GG1//精炼器
                {
                    public static LocString A63GG0 = "Extracts pure {0} from {1}.";
                }
                public class A64GG1//热裂解甲烷制钻石
                {
                    public static LocString NAME = "热裂解甲烷制钻石";//建筑名
                    public static LocString EFFECT = "热裂解甲烷，铜催化分解，生成氢气和钻石。";//建筑效果
                    public static LocString DESC = "咕咕鱼催化有限公司。";
                }
                public class A65GG1//气体液化机
                {
                    public static LocString NAME = "气体液化机";//建筑名
                    public static LocString EFFECT = "将气体液化成对应的液体：\n 氧气>>>液氧；\n 氢气>>>液氢；\n 氯气>>>液氯；\n 蒸汽>>>水；\n 气态乙醇>>>乙醇；\n 天然气>>>液态甲烷；\n 二氧化碳>>>液态二氧化碳。";//建筑效果
                    public static LocString DESC = "夏国重工。";
                }
                public class A66GG1//医废桶
                {
                    public static LocString NAME = "医废桶";//建筑名
                    public static LocString EFFECT = "请将医疗废弃用品置于此箱中，它会自动将其送入虚空！";//建筑效果
                    public static LocString DESC = "生命与安全。";
                }

                public class A67GG1//石油井
                {
                    public static LocString NAME = "石油井";//建筑名
                    public static LocString EFFECT = "喵喵喵。";//建筑效果
                    public static LocString DESC = "喵喵喵。";
                }

                public class A68GG1//精致梯子
                {
                    public static LocString NAME = "冰梯子";//建筑名
                    public static LocString EFFECT = "冰块做的梯子，龟速爬上，飞速滑落。";//建筑效果
                    public static LocString DESC = "西山白雪三城戍。";
                }
                public class A68GG2//精致梯子
                {
                    public static LocString NAME = "金梯子";//建筑名
                    public static LocString EFFECT = "黄金做的梯子，飞速爬上，飞速爬下。";//建筑效果
                    public static LocString DESC = "黄金印绶悬腰底。";
                }
                public class A68GG3//精致梯子
                {
                    public static LocString NAME = "木头梯子";//建筑名
                    public static LocString EFFECT = "木头做的梯子，快快爬上，快快爬下。";//建筑效果
                    public static LocString DESC = "树阴照水爱晴柔。";
                }

                public class A69GG1//辐射掌
                {
                    public static LocString NAME = "辐射掌";//建筑名
                    public static LocString EFFECT = "远古生物，开天辟地，无所不能。";//建筑效果
                    public static LocString DESC = "大日如来神棍，又或许，大辐射棍。";
                }

                public class A70GG1//核废料处理器
                {
                    public static LocString NAME = "核废料处理器";//建筑名
                    public static LocString EFFECT = "裂解核废料，强制衰变，生成铁和污染水。";//建筑效果
                    public static LocString DESC = "废物，是放错地方的资源。";
                }
                public class A70GG2//核废水处理器
                {
                    public static LocString NAME = "核废水处理器";//建筑名
                    public static LocString EFFECT = "裂解核废水，强制衰变，生成铁和污染水。";//建筑效果
                    public static LocString DESC = "废物，是放错地方的资源。";
                }
                public class A71GG1//天工复制人探测器
                {
                    public static LocString NAME = "天工复制人探测器";//建筑名
                    public static LocString EFFECT = "别看我，我害羞。";//建筑效果
                    public static LocString DESC = "无情的智能机器。";
                }
                public class A72GG1//信号桥和信号组桥
                {
                    public static LocString NAME = "两格信号桥";//建筑名
                    public static LocString EFFECT = "跨越两格的信号桥。";//建筑效果
                    public static LocString DESC = "信号信号，0101。";
                }
                public class A72GG2//信号桥和信号组桥
                {
                    public static LocString NAME = "两格信号组桥";//建筑名
                    public static LocString EFFECT = "跨越两格的信号组桥。";//建筑效果
                    public static LocString DESC = "信号信号，0101。";
                }
                public class A72GG3//信号桥和信号组桥
                {
                    public static LocString NAME = "三格信号桥";//建筑名
                    public static LocString EFFECT = "跨越三格的信号桥。";//建筑效果
                    public static LocString DESC = "信号信号，0101。";
                }
                public class A72GG4//信号桥和信号组桥
                {
                    public static LocString NAME = "三格信号组桥";//建筑名
                    public static LocString EFFECT = "跨越三格的信号组桥。";//建筑效果
                    public static LocString DESC = "信号信号，0101。";
                }

                public class A73GG1//闹钟
                {
                    public static LocString NAME = "闹钟";//建筑名
                    public static LocString EFFECT = "自动化集大成之作。";//建筑效果
                    public static LocString DESC = "自动化集大成之作。";
                }

                public class A75GG1//超次元矿机
                {
                    public static LocString NAME = "超次元矿机";//建筑名
                    public static LocString EFFECT = "不要问，问就是未来五彩斑斓。";//建筑效果
                    public static LocString DESC = "不要问，问就是未来五彩斑斓。";
                }

                public class A77GG1//饥荒入侵计划
                {
                    public static LocString NAME = "跳舞牛";//建筑名
                    public static LocString EFFECT = "献上礼金，伟大的牛牛会为你施加一个祝福，前提是你得欣赏它的舞蹈。";//建筑效果
                    public static LocString DESC = "来呀，一起舞蹈。";
                }
                public class A77GG2//饥荒入侵计划
                {
                    public static LocString NAME = "拒绝牛";//建筑名
                    public static LocString EFFECT = "叔叔，不约。";//建筑效果
                    public static LocString DESC = "111111。";
                }
                public class A77GG3//饥荒入侵计划
                {
                    public static LocString NAME = "哈气牛";//建筑名
                    public static LocString EFFECT = "呼呼呼，喘气。";//建筑效果
                    public static LocString DESC = "111111。";
                }
                public class A77GG4//饥荒入侵计划
                {
                    public static LocString NAME = "摔倒牛";//建筑名
                    public static LocString EFFECT = "啊，牛牛我摔倒了。";//建筑效果
                    public static LocString DESC = "111111。";
                }
                public class A77GG5//饥荒入侵计划
                {
                    public static LocString NAME = "暴力牛";//建筑名
                    public static LocString EFFECT = "不打你，我打底板。";//建筑效果
                    public static LocString DESC = "111111。";
                }
                public class A77GG6//饥荒入侵计划
                {
                    public static LocString NAME = "疑问牛";//建筑名
                    public static LocString EFFECT = "马什么梅，马冬梅。";//建筑效果
                    public static LocString DESC = "111111。";
                }

                public class A79GG1//恭喜faker拿下第四个S赛冠军
                {
                    public static LocString NAME = "Faker！NB！";//建筑名
                    public static LocString EFFECT = "    没有人躲得过岁月，但大部分人选择逃避守着自己的半寸土地，而小部分人选择扛起自己的江山直面新时代的挑战。  \r\n倘若faker S3夺冠退役，那么留给他的是史上最强刺客的名号。  \r\n倘若faker S5退役，留给他的则是无与伦比的首个S双冠王。  \r\n倘若faker S6退役，不败魔王至今也是最可望不可及的高峰。  \r\n但他选择一直坚持到现在！十年依旧！";//建筑效果
                    public static LocString DESC = "恭喜faker拿下LOL全球总决赛S13冠军。";
                }
                public class A80GG1//警示牌
                {
                    public static LocString NAME = "警示牌";//建筑名
                    public static LocString EFFECT = "暗号。";//建筑效果
                    public static LocString DESC = "许可通行。";
                }

                public class A80GG2//警示牌
                {
                    public static LocString NAME = "警示牌图标";//建筑名
                    public static LocString EFFECT = "为警示牌添加更加明显的图标。";//建筑效果
                    public static LocString DESC = "图标。";
                }

                public class A83GG1//温度场
                {
                    public static LocString NAME = "温度场";//建筑名
                    public static LocString EFFECT = "一定区域保持温度不变，你可以控制它的作用范围以及温度。";//建筑效果
                    public static LocString DESC = "“恒温空间”是我的哥哥。";
                }
                public class A84GG1//恒温空间
                {
                    public static LocString NAME = "恒温空间";//建筑名
                    public static LocString EFFECT = "一定范围内，温度保持不变。";//建筑效果
                    public static LocString DESC = "魔法的力量，无穷无尽。";
                }


                //---------------------------------------基地---------------------------------------
                public class A001GG1 // 魔女的箱子
                {
                    public static LocString NAME = "魔女的粉色箱子";
                    public static LocString EFFECT = "更大的容量，更好的密封，更好的材料。";
                    public static LocString DESC = "粉色，难道不是一种很好看的颜色吗？";
                }
                public class A001GG2 // 魔女的箱子
                {
                    public static LocString NAME = "魔女的四角星箱子";
                    public static LocString EFFECT = "可爱吗？箱子里也许隐藏着毁灭世界的力量！";
                    public static LocString DESC = "粉色，难道不是一种很好看的颜色吗？";
                }
                public class A005GG1 // 看不见的门
                {
                    public static LocString NAME = "看不见的门";
                    public static LocString EFFECT = "看不见的门，隐形的气动门。";
                    public static LocString DESC = "小心，别撞头！";
                }
                public class A008GG1 // 隐形台阶
                {
                    public static LocString NAME = "隐形台阶";
                    public static LocString EFFECT = "来自潘多拉星球的高科技技术，有人的时候梯子会隐身，没有人的时候梯子会隐身。";
                    public static LocString DESC = "来玩啊，大爷！";
                }
                public class A009GG1 // 安全门
                {
                    public static LocString NAME = "安全门";
                    public static LocString EFFECT = "两个宽，两格高。并不那么美观，但盛在使用。";
                    public static LocString DESC = "走快点，不然把你头给夹扁了。";
                }
                public class A011GG1 // 红色和蓝色的垃圾桶
                {
                    public static LocString NAME = "蓝色垃圾箱";
                    public static LocString EFFECT = "不要小瞧我，我能吃下一切。";
                    public static LocString DESC = "喜欢一个人，就要接受她的一切。";
                }
                public class A011GG2 // 红色和蓝色的垃圾桶
                {
                    public static LocString NAME = "蓝蓝色垃圾桶";
                    public static LocString EFFECT = "我是蓝色垃圾箱的双胞胎弟弟蓝色二号。";
                }
                public class A011GG3 // 红色和蓝色的垃圾桶
                {
                    public static LocString NAME = "红色垃圾箱";
                    public static LocString EFFECT = "我是蓝色二号的姐姐，粉色一号。";
                }
                public class A011GG4 // 红色和蓝色的垃圾桶
                {
                    public static LocString NAME = "粉粉色垃圾桶";
                    public static LocString EFFECT = "我是粉色一号的双胞胎妹妹，粉色二号。";
                }
            }

        }
    }
}
