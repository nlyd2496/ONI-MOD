using System;
using HarmonyLib;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组
{
    [HarmonyPatch(typeof(Db))]
    [HarmonyPatch("Initialize")]
    public class 研究栏
    {
        public static void Postfix()
        {
            Db.Get().Techs.Get("Combustion").unlockedItemIDs.Add("A1GG1");//南孚电池-燃烧
            Db.Get().Techs.Get("Combustion").unlockedItemIDs.Add("A2GG1");//民用电池组-燃烧
            Db.Get().Techs.Get("Combustion").unlockedItemIDs.Add("A3GG1");//一格电池-燃烧
            Db.Get().Techs.Get("Combustion").unlockedItemIDs.Add("A4GG1");//细电线-燃烧
            Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add("A11GG1");//喵喵床-豪华家装
            Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add("A15GG1");//吊床-豪华家装
            Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add("A31GG1");//香草摇摇床-豪华家装
            Db.Get().Techs.Get("RenaissanceArt").unlockedItemIDs.Add("A34GG1");//英雄联盟宣传片-文艺复兴时期艺术





        }
    }
    /*
Farming Tech	        农业技术
FineDining	            美食餐厅
FoodRepurposing	        食物回收
Finer Dining	        更精致的餐饮
Agriculture	            农业
Ranching	            牧场
AnimalControl	        动画控件
ImprovedOxygen      	改进的氧气
GasPiping	            气体管道
ImprovedGasPiping	    改进的气体管道
PressureManagement  	压力管理
PortableGasses	        便携式气体
DirectedAirStreams	    定向气流
LiquidFiltering	        液体过滤
MedicineI	            医学I
MedicineII	            医学II
MedicineIII	            美第奇III
MedicineIV	            医学IV
LiquidPiping	        液化管道
ImprovedLiquidPiping	改进的液体管道
PrecisionPlumbing	    精密管道
SanitationSciences	    卫生科学
FlowRedirection	        流量重定向
AdvancedFiltration	    高级过滤
Distillation	        蒸馏
Catalytics	            催化剂
PowerRegulation	        功率调节
Advanced Power Regulation	高级功率调节
PrettyGood Conductors	相当好的导体
RenewableEnergy	        可再生能源
Combustion	            燃烧
ImprovedCombustion	    改进的燃烧
InteriorDecor	        室内装饰
Artistry	            艺术性
Clothing	            服装
Acoustics	            声学
NuclearRefinement   	核细化
Fine Art	            美术
EnvironmentalAppreciation	环境欣赏
Luxury	                豪华家装
RefractiveDecor     	折射装饰
GlassFurnishings	    玻璃家具
Screens	                屏幕
RenaissanceArt      	文艺复兴时期艺术
Plastics	            塑料
ValveMiniaturization	阀门小型化
HydrocarbonPropulsion	碳氢化合物推进
Suits	                西装
Jobs	                工作
AdvancedResearch    	高级研究
SpaceProgram	        太空计划
CrashPlan	            碰撞平面图
Durable Life Support	耐用的生命支持
NuclearResearch	        核能研究
NotificationSystems	    通知系统
ArtificialFriends	    人造之友
RoboticTools	        机器人工具
BasicRefinement	        基本细化
RefinedObjects	        优化的对象
Smelting	            熔炼
HighTempForging	        高温锻造
RadiationProtection	    辐射防护
TemperatureModulation	温度调节
HVAC	                暖通空调
LiquidTemperature	    液体温度
LogicControl	        逻辑控制
GenericSensors	        通用传感器
LogicCircuits	        逻辑电路
Parallel Automation	    并行自动化
DupeTraffic Control	    双重流量控制
Multiplexing	        多路复用
SkyDetectors	        天空探测器
TravelTubes	            旅行管
SmartStorage	        智能仓储
SolidTransport      	固体运输
Solid Management	    扎实的管理
Basic Rocketry	        基本岩石力学
CargoI	                货物I
CargoII	                货物II
CargoIII            	货物III
EnginesI	            发动机I
EnginesII	            发动机II
EnginesIII	            发动机III
Jetpacks	            喷气式飞机
*/
}
