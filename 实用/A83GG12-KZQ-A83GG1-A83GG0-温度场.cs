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
    public class A83GG1 : IBuildingConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            string id = "A83GG1";
            int width = 1;
            int height = 1;
            string anim = "A83GG1_kanim";
            int hitpoints = 10;
            float construction_time = 10f;
            float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
            string[] any_BUILDABLE = MATERIALS.ANY_BUILDABLE;
            float melting_point = 1600f;
            BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, any_BUILDABLE, melting_point, build_location_rule, new EffectorValues { amount = 10, radius = 4 }, none, 0.2f);
            BuildingTemplates.CreateLadderDef(buildingDef);
            buildingDef.Floodable = false;
            buildingDef.Overheatable = false;
            buildingDef.ThermalConductivity = 2f;
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            //--------------------------
            if (控制台.Instance.温度场) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<A83GG1_KZQ>();
            go.AddOrGet<A83GG2_KZQ>();
            A83GG0 a83gg0 = go.AddOrGet<A83GG0>();
            a83gg0.effectWidth = 2;
            a83gg0.effectHeight = 2;
            a83gg0.targetTemperature = 300.15f;
            A83GG1.AddVisualizer(go, false);

            go.AddOrGet<MinimumOperatingTemperature>().minimumTemperature = 2.15f;//最低工作温度30K
        }
        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
            A83GG1.AddVisualizer(go, true);
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            A83GG1.AddVisualizer(go, false);
        }
        private static void AddVisualizer(GameObject prefab, bool movable)
        {
            RangeVisualizer rangeVisualizer = prefab.AddOrGet<RangeVisualizer>();
            rangeVisualizer.RangeMin.x = -1;
            rangeVisualizer.RangeMin.y = -1;
            rangeVisualizer.RangeMax.x = 1;
            rangeVisualizer.RangeMax.y = 1;
            rangeVisualizer.OriginOffset = new Vector2I(0, 0);
            rangeVisualizer.BlockingTileVisible = false;
            prefab.GetComponent<KPrefabID>().instantiateFn += delegate (GameObject go) // 为预制体的KPrefabID组件的实例化函数添加一个委托
            {
                go.GetComponent<RangeVisualizer>().BlockingCb = new Func<int, bool>(delegate (int cell) // 为游戏对象的RangeVisualizer组件的遮挡回调函数赋值为一个匿名函数
                {
                    return false; // 这个匿名函数无论传入什么格子，都返回假，表示所有格子都不是阻挡
                });
            };

        }
        public override void DoPostConfigureComplete(GameObject go)
        {
        }
        public const string ID = "A83GG1";
    }









    // 定义一个类，继承自KMonoBehaviour，实现ISim200ms接口
    public class A83GG0 : KMonoBehaviour, ISim200ms//WDFSQ+序号+MM+时间+GG+序号
    {
        // 定义一个方法，每200毫秒模拟一次，传入一个浮点型参数dt
        public void Sim200ms(float dt)
        {
            // 定义一个二维整数向量vector2I，表示温度范围的左下角坐标，根据effectWidth和effectHeight计算
            Vector2I vector2I = new Vector2I(-this.effectWidth / 2, -this.effectHeight / 2);
            // 定义一个二维整数向量vector2I2，表示温度范围的右上角坐标，根据effectWidth和effectHeight计算
            Vector2I vector2I2 = new Vector2I(this.effectWidth / 2, this.effectHeight / 2);
            // 定义两个整数变量num和num2，表示当前对象的坐标
            int num;
            int num2;
            // 调用Grid.PosToXY方法，传入当前对象的位置，将结果赋值给num和num2
            Grid.PosToXY(base.transform.GetPosition(), out num, out num2);
            // 调用Grid.XYToCell方法，传入num和num2，将结果赋值给整数变量num3，表示当前对象所在的单元格
            int num3 = Grid.XYToCell(num, num2);
            // 调用Grid.IsValidCell方法，传入num3，判断是否为有效的单元格
            if (Grid.IsValidCell(num3))
            {
                // 调用Grid.WorldIdx属性，传入num3，将结果转换为整数，并赋值给整数变量world，表示当前对象所在的世界索引
                int world = (int)Grid.WorldIdx[num3];
                // 使用for循环，遍历vector2I.y到vector2I2.y之间的所有值，将结果赋值给整数变量i
                for (int i = vector2I.y; i <= vector2I2.y; i++)
                {
                    // 使用for循环，遍历vector2I.x到vector2I2.x之间的所有值，将结果赋值给整数变量j
                    for (int j = vector2I.x; j <= vector2I2.x; j++)
                    {
                        // 调用Grid.XYToCell方法，传入num加上j和num2加上i，将结果赋值给整数变量num4，表示温度范围内的单元格
                        int num4 = Grid.XYToCell(num + j, num2 + i);
                        // 调用Grid.IsValidCellInWorld方法，传入num4和world，判断是否为有效的单元格
                        if (Grid.IsValidCellInWorld(num4, world))
                        {
                            // 定义一个浮点型变量num5，表示温度调节器对单元格产生的能量变化量，根据targetTemperature、Grid.Temperature、Grid.Element、Grid.Mass和temperatureControlK计算
                            float num5 = (this.targetTemperature - Grid.Temperature[num4]) * Grid.Element[num4].specificHeatCapacity * Grid.Mass[num4] * temperatureControlK;
                            // 判断num5是否不接近于0
                            if (!Mathf.Approximately(0f, num5))
                            {
                                // 调用SimMessages.ModifyEnergy方法，传入num4、num5、5000f和一个三元运算符（根据num5是否大于0选择不同的能源ID），表示修改单元格的能量
                                SimMessages.ModifyEnergy(num4, num5, 5000f, (num5 > 0f) ? SimMessages.EnergySourceID.DebugHeat : SimMessages.EnergySourceID.DebugCool);
                            }
                        }
                    }
                }
            }
        }
        //-------------------------------------------------------------------------------------------
        // 定义一个浮点型变量，表示温度调节器的目标温度
        public float targetTemperature;
        // 定义一个整数变量，表示温度调节器的温度范围的宽度
        public int effectWidth;
        // 定义一个整数变量，表示温度调节器的温度范围的高度
        public int effectHeight;
        // 定义一个浮点型常量，表示温度调节器的温度控制系数
        private const float temperatureControlK = 0.2f;
    }
}
