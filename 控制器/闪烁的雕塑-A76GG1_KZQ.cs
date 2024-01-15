using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Klei;

namespace 吐泡泡的小鱼的缺氧模组.控制器
{
    using System;
    // 定义一个公共类，继承自KMonoBehaviour，实现ISim200ms接口
    // 给类起一个更有意义的名字，例如ColorChanger
    public class A76GG1_KZQ : KMonoBehaviour, ISim200ms
    {
        // 定义一个私有字段，用于存储随机数生成器的实例
        // 在私有字段前加上下划线，例如_random
        private Random _random = new Random();
        // 定义一个私有字段，用于存储当前颜色
        // 在私有字段前加上下划线，例如_currentColor
        private Color32 _currentColor;
        // 定义一个私有字段，用于存储上一次改变颜色的时间
        // 在私有字段前加上下划线，例如_lastChangeTime
        private DateTime _lastChangeTime;
        // 定义一个私有方法，用于更新游戏对象的颜色
        // 在私有方法前加上下划线，并使用驼峰命名法，例如_UpdateColor()
        // 添加XML注释，说明方法的功能
        /// <summary>
        /// 更新游戏对象的颜色为随机数，并记录当前时间
        /// </summary>
        private void UpdateColor()
        {
            // 使用animController属性的TintColour方法，设置颜色为随机数（random.Next(256), random.Next(256), random.Next(256), 255）
            _currentColor = new Color32((byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256), byte.MaxValue);
            this.animController.TintColour = _currentColor;
            // 更新上一次改变颜色的时间为当前时间
            _lastChangeTime = DateTime.Now;
        }
        // 定义一个公共方法，用于每隔200毫秒执行一次
        // 使用驼峰命名法，例如Sim200ms()
        // 添加XML注释,说明方法的功能、参数、实现的接口等信息
        /// <summary>
        /// 每隔200毫秒执行一次的方法
        /// </summary>
        /// <param name="dt">时间间隔</param>
        /// <remarks>实现ISim200ms接口</remarks>
        public void Sim200ms(float dt)
        {
            DateTime currentTime = DateTime.Now;
            // 如果当前时间的分钟数是整十
            if (currentTime.Minute % 10 == 0 && currentTime.Second == 0)
            {
                // 如果上一次改变颜色的时间不是当前时间（避免重复改变）
                if (_lastChangeTime != currentTime)
                {
                    // 调用_UpdateColor方法，更新颜色
                    this._UpdateColor();
                }
            }
            // 否则，使用animController属性的TintColour方法，设置颜色为当前颜色（不改变）
            else
            {
                this.animController.TintColour = _currentColor;
            }
        }
        // 重写OnSpawn方法，用于游戏对象生成时执行
        // 添加XML注释,说明方法的功能、重写的基类方法等信息
        /// <summary>
        /// 游戏对象生成时执行的方法
        /// </summary>
        /// <remarks>重写KMonoBehaviour的OnSpawn方法</remarks>
        protected override void OnSpawn()
        {
            // 调用基类的OnSpawn方法
            base.OnSpawn();
            // 使用animController属性的TintColour方法，设置颜色为白色（255, 255, 255, 255）
            _currentColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
            this.animController.TintColour = _currentColor;
            // 设置上一次改变颜色的时间为当前时间
            _lastChangeTime = DateTime.Now;
        }
        // 使用MyCmpGet特性，获取游戏对象的KBatchedAnimController组件，赋值给animController属性
        [MyCmpGet]
        internal KBatchedAnimController animController;

        // 定义一个静态字段，用于存储所有游戏对象的颜色列表
        private static List<Color32> colorList = new List<Color32>();
        // 定义一个静态方法，用于检查颜色是否已经存在于列表中
        // 使用驼峰命名法，例如checkColorExist()
        // 添加XML注释,说明方法的功能、参数、返回值等信息
        /// <summary>
        /// 检查颜色是否已经存在于列表中
        /// </summary>
        /// <param name="color">要检查的颜色</param>
        /// <returns>如果存在，返回true，否则返回false</returns>
        private static bool checkColorExist(Color32 color)
        {
            // 遍历列表中的每个颜色
            foreach (var c in colorList)
            {
                // 如果找到相同的颜色，返回true
                if (c.r == color.r && c.g == color.g && c.b == color.b)
                {
                    return true;
                }
            }
            // 如果没有找到相同的颜色，返回false
            return false;
        }
        // 修改_UpdateColor方法，使其生成不重复的颜色，并添加到列表中
        private void _UpdateColor()
        {
            // 定义一个布尔变量，用于标记是否生成了新的颜色
            bool newColor = false;
            // 循环直到生成了新的颜色
            while (!newColor)
            {
                // 使用animController属性的TintColour方法，设置颜色为随机数（random.Next(256), random.Next(256), random.Next(256), 255）
                _currentColor = new Color32((byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256), byte.MaxValue);
                this.animController.TintColour = _currentColor;
                // 调用checkColorExist方法，检查颜色是否已经存在于列表中
                if (!checkColorExist(_currentColor))
                {
                    // 如果不存在，将新的颜色添加到列表中，并将newColor设为true
                    colorList.Add(_currentColor);
                    newColor = true;
                }
            }
            // 更新上一次改变颜色的时间为当前时间
            _lastChangeTime = DateTime.Now;
        }
    }
}
