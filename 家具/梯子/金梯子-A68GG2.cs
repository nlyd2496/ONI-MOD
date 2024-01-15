﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUNING;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组.家具
{
    // Token: 0x020002F4 RID: 756
    public class A68GG2 : IBuildingConfig
	{
		// Token: 0x06000B97 RID: 2967 RVA: 0x000A2AF8 File Offset: 0x000A0CF8
		public override BuildingDef CreateBuildingDef()
		{
			string id = "A68GG2";
			int width = 1;
			int height = 1;
			string anim = "A68GG2_kanim";
			int hitpoints = 10;
			float construction_time = 10f;
			float[] tier = BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;

			string[] construction_materials = new string[]
			{
			"Gold"
			};
			EffectorValues decor = new EffectorValues
			{
				amount = 40,
				radius = 4
			};
			float melting_point = 1600f;

			BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
			EffectorValues none = NOISE_POLLUTION.NONE;
			BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, 
				width, height, anim, hitpoints, construction_time, tier, 
				construction_materials, melting_point, build_location_rule,
				 new EffectorValues
				 {
					 amount = 40,
					 radius = 8
				 }, none, 0.2f);

			BuildingTemplates.CreateLadderDef(buildingDef);
			buildingDef.Floodable = false;
			buildingDef.Overheatable = false;
			buildingDef.Entombable = false;
			buildingDef.AudioCategory = "Metal";
			buildingDef.AudioSize = "small";
			buildingDef.BaseTimeUntilRepair = -1f;
			buildingDef.DragBuild = true;
            //--------------------------
            if (控制台.Instance.精致梯子) { buildingDef.Deprecated = false; } else { buildingDef.Deprecated = true; }
            //--------------------------
            return buildingDef;
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x000074A4 File Offset: 0x000056A4
		public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
		{
			GeneratedBuildings.MakeBuildingAlwaysOperational(go);
			Ladder ladde1r = go.AddOrGet<Ladder>();
			ladde1r.upwardsMovementSpeedMultiplier = 8f;
			ladde1r.downwardsMovementSpeedMultiplier = 8f;
			go.AddOrGet<AnimTileable>();
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x00002835 File Offset: 0x00000A35
		public override void DoPostConfigureComplete(GameObject go)
		{
		}

		// Token: 0x040007DD RID: 2013
		public const string ID = "A68GG2";
	}
}
