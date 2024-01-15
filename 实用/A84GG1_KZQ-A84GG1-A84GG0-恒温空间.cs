using PeterHan.PLib.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;
using 吐泡泡的小鱼的缺氧模组.控制器;

namespace 吐泡泡的小鱼的缺氧模组.实用
{
    public class A84GG1 : IBuildingConfig
    {
        
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A84GG1";
            int width = 1;
            int height = 1;
            string anim = "A84GG1_kanim";
            int hitpoints = 30;
            float construction_time = 30f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER5;
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 9999f;
            BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, any_BUILDABLE, melting_point, build_location_rule, BUILDINGS.DECOR.BONUS.TIER2, none, 0.2f);
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.ThermalConductivity = 0f;
            //--------------------------
            if (控制台.Instance.恒温空间) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        




        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            Storage storage = BuildingTemplates.CreateDefaultStorage(go, false);
            storage.showInUI = true;
            storage.capacityKg = 200f;
            storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
            //----------------------------
            //链接温度控制
            go.AddOrGet<A84GG1_KZQ>();
            //----------------------------
            //链接索引1温度设置
            A84GG0 a84gg0 = go.AddOrGet<A84GG0>();
            a84gg0.targetTemperature = 20f;
            //----------------------------
            go.AddOrGet<MinimumOperatingTemperature>().minimumTemperature = 2.15f;//最低工作温度30K
        }
        
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGetDef<OperationalController.Def>();
        }
        
        public const string ID = "A84GG1";
        
    }





    // 定义一个类 A84GG0，继承自 KMonoBehaviour，并实现 ISim200ms 接口
    public class A84GG0 : KMonoBehaviour, ISim200ms
    {
        // 定义一个方法 Sim200ms，每 200 毫秒执行一次，参数 dt 表示时间间隔
        public void Sim200ms(float dt)
        {
            // 定义一个二维向量 vector2I，表示左下角的坐标，取负的效果半径
            Vector2I vector2I = new Vector2I(-this.effectRadius, -this.effectRadius);
            // 定义一个二维向量 vector2I2，表示右上角的坐标，取正的效果半径
            Vector2I vector2I2 = new Vector2I(this.effectRadius, this.effectRadius);
            // 定义两个整数变量 num 和 num2，用于存储当前对象的位置的 x 和 y 坐标
            int num;
            int num2;
            // 调用 Grid 的 PosToXY 方法，根据当前对象的位置，计算出 x 和 y 坐标，并赋值给 num 和 num2
            Grid.PosToXY(base.transform.GetPosition(), out num, out num2);
            // 调用 Grid 的 XYToCell 方法，根据 x 和 y 坐标，计算出当前对象所在的单元格的索引，并赋值给 num3
            int num3 = Grid.XYToCell(num, num2);
            // 判断 num3 是否是一个有效的单元格索引
            if (Grid.IsValidCell(num3))
            {
                // 定义一个整数变量 world，表示当前对象所在的世界的索引，从 Grid 的 WorldIdx 数组中获取
                int world = (int)Grid.WorldIdx[num3];
                // 用两层循环，遍历以当前对象为中心，以效果半径为边长的正方形区域内的所有单元格
                for (int i = vector2I.y; i <= vector2I2.y; i++)
                {
                    for (int j = vector2I.x; j <= vector2I2.x; j++)
                    {
                        // 定义一个整数变量 num4，表示当前循环中的单元格的索引，根据当前对象的 x 和 y 坐标，加上偏移量 j 和 i，计算出 num4
                        int num4 = Grid.XYToCell(num + j, num2 + i);
                        // 判断 num4 是否是一个有效的单元格索引，并且与当前对象在同一个世界中
                        if (Grid.IsValidCellInWorld(num4, world))
                        {
                            // 定义一个浮点数变量 num5，表示当前循环中的单元格的温度与目标温度的差值，乘以该单元格的元素的比热容和质量
                            float num5 = (this.targetTemperature - Grid.Temperature[num4]) * Grid.Element[num4].specificHeatCapacity * Grid.Mass[num4];
                            // 判断 num5 是否不等于 0
                            if (!Mathf.Approximately(0f, num5))
                            {
                                // 调用 SimMessages 的 ModifyEnergy 方法，修改当前循环中的单元格的能量，参数分别为单元格索引，能量变化量，最大能量，和能量来源
                                SimMessages.ModifyEnergy(num4, num5 * 0.2f, 8000f, (num5 > 0f) ? SimMessages.EnergySourceID.DebugHeat : SimMessages.EnergySourceID.DebugCool);
                            }
                        }
                    }
                }
            }
        }
        // 定义一个公共的浮点数变量 targetTemperature，表示目标温度，初始值为 303.15 K
        public float targetTemperature = 303.15f;
        // 定义一个公共的整数变量 effectRadius，表示效果半径，初始值为 2
        public int effectRadius = 2;
    }

}
