using HarmonyLib;
using KSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组
{
    internal class FUI_SideScreen
    {
        public static void AddClonedSideScreen<T>(string name, string originalName, Type originalType)
        {
            List<DetailsScreen.SideScreenRef> list;
            GameObject contentBody;
            bool elements = FUI_SideScreen.GetElements(out list, out contentBody);
            if (elements)
            {
                SideScreenContent prefab = FUI_SideScreen.Copy<T>(FUI_SideScreen.FindOriginal(originalName, list), contentBody, name, originalType);
                list.Add(FUI_SideScreen.NewSideScreen(name, prefab));
            }
        }
        private static bool GetElements(out List<DetailsScreen.SideScreenRef> screens, out GameObject contentBody)
        {
            Traverse traverse = Traverse.Create(DetailsScreen.Instance);
            screens = traverse.Field("sideScreens").GetValue<List<DetailsScreen.SideScreenRef>>();
            contentBody = traverse.Field("sideScreenContentBody").GetValue<GameObject>();
            return screens != null && contentBody != null;
        }
        private static SideScreenContent Copy<T>(SideScreenContent original, GameObject contentBody, string name, Type originalType)
        {
            GameObject gameObject = Util.KInstantiateUI<SideScreenContent>(original.gameObject, contentBody, false).gameObject;
            UnityEngine.Object.Destroy(gameObject.GetComponent(originalType));
            SideScreenContent sideScreenContent = gameObject.AddComponent(typeof(T)) as SideScreenContent;
            sideScreenContent.name = name.Trim();
            gameObject.SetActive(false);
            return sideScreenContent;
        }
        private static SideScreenContent FindOriginal(string name, List<DetailsScreen.SideScreenRef> screens)
        {
            SideScreenContent screenPrefab = screens.Find((DetailsScreen.SideScreenRef s) => s.name == name).screenPrefab;
            bool flag = screenPrefab == null;
            if (flag)
            {
                global::Debug.LogWarning("Could not find a sidescreen with the name " + name);
                global::Debug.LogWarning("找不到具有该名称的侧屏 " + name);
            }
            return screenPrefab;
        }
        private static DetailsScreen.SideScreenRef NewSideScreen(string name, SideScreenContent prefab)
        {
            return new DetailsScreen.SideScreenRef
            {
                name = name,
                offset = Vector2.zero,
                screenPrefab = prefab
            };
        }
        public static ToolTip AddSimpleToolTip(GameObject gameObject, string message, bool alignCenter = false, float wrapWidth = 0f)
        {
            bool flag = gameObject.GetComponent<ToolTip>() != null;
            ToolTip result;
            if (flag)
            {
                global::Debug.Log("GO already had a tooltip! skipping");
                global::Debug.Log("GO 已经有了工具提示！跳过");
                result = null;
            }
            else
            {
                ToolTip toolTip = gameObject.AddComponent<ToolTip>();
                toolTip.tooltipPivot = (alignCenter ? new Vector2(0.5f, 0f) : new Vector2(1f, 0f));
                toolTip.tooltipPositionOffset = new Vector2(0f, 20f);
                toolTip.parentPositionAnchor = new Vector2(0.5f, 0.5f);
                bool flag2 = wrapWidth > 0f;
                if (flag2)
                {
                    toolTip.WrapWidth = wrapWidth;
                    toolTip.SizingSetting = ToolTip.ToolTipSizeSetting.MaxWidthWrapContent;
                }
                ToolTipScreen.Instance.SetToolTip(toolTip);
                toolTip.SetSimpleTooltip(message);
                result = toolTip;
            }
            return result;
        }
    }
    [SerializationConfig(MemberSerialization.OptIn)]
    internal class SelectableSign : KMonoBehaviour
    {
        protected override void OnSpawn()
        {
            bool flag = this.AnimationNames == null || this.AnimationNames.Count == 0;
            if (!flag)
            {
                bool flag2 = this.selectedIndex >= this.AnimationNames.Count;
                if (flag2)
                {
                    this.selectedIndex = 0;
                }
                this.kbac.Play(this.AnimationNames[this.selectedIndex], KAnim.PlayMode.Once, 1f, 0f);
            }
        }
        public void SetVariant(string variant)
        {
            bool flag = !this.AnimationNames.Contains(variant);
            if (!flag)
            {
                this.selectedIndex = this.AnimationNames.FindIndex((string str) => str == variant);
                this.kbac.Play(variant, KAnim.PlayMode.Once, 1f, 0f);
            }
        }
        [MyCmpGet]
        private KBatchedAnimController kbac;

        [Serialize]
        public List<string> AnimationNames = new List<string>();

        [Serialize]
        public int selectedIndex;
    }
    internal class BasicModUtils
    {
        public static void MakeSideScreenStrings(string key, string name)
        {
            Strings.Add(new string[]
            {
                key,
                name
            });
        }
    }
    internal class screen_information
    {
        [HarmonyPatch(typeof(DetailsScreen), "OnPrefabInit")]
        public static class PrefabInit_Patch
        {
            public static void Postfix()
            {
                FUI_SideScreen.AddClonedSideScreen<SignSideScreen>("标志侧屏", "MonumentSideScreen", typeof(MonumentSideScreen));
            }
        }
    }
}

