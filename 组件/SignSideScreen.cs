using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 吐泡泡的小鱼的缺氧模组
{
    internal class SignSideScreen : SideScreenContent
    {
        protected override void OnPrefabInit()
        {
            base.OnPrefabInit();
            this.titleKey = "picture"; // ----------------------修改此处----------------------
            this.flipButton = base.transform.Find("Butttons/FlipButton").gameObject;
            this.stateButtonPrefab = base.transform.Find("ButtonPrefab").gameObject;
            this.debugVictoryButton = base.transform.Find("Butttons/Button").gameObject;
            this.buttonContainer = base.transform.Find("Content/Scroll/Grid").GetComponent<RectTransform>();
        }
        public const string SCREEN_TITLE_KEY = "picture"; // ----------------------修改此处----------------------
        /*
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */
        public override bool IsValidForTarget(GameObject target)
        {
            return target.GetComponent<SelectableSign>() != null;
        }
        protected override void OnSpawn()
        {
            base.OnSpawn();
            this.flipButton.SetActive(false);
            this.debugVictoryButton.SetActive(false);
        }
        public override void SetTarget(GameObject target)
        {
            base.SetTarget(target);
            this.target = target.GetComponent<SelectableSign>();
            base.gameObject.SetActive(true);
            this.GenerateStateButtons();
        }
        private void GenerateStateButtons()
        {
            this.ClearButtons();
            KAnimFile animFile = this.target.GetComponent<KBatchedAnimController>().AnimFiles[0];
            using (List<string>.Enumerator enumerator = this.target.AnimationNames.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    string anim = enumerator.Current;
                    this.AddButton(animFile, anim, anim, delegate
                    {
                        this.target.SetVariant(anim);
                    });
                }
            }
        }
        private void AddButton(KAnimFile animFile, string animName, LocString tooltip, System.Action onClick)
        {
            GameObject gameObject = Util.KInstantiateUI(this.stateButtonPrefab, this.buttonContainer.gameObject, true);
            KButton kbutton;
            bool flag = gameObject.TryGetComponent<KButton>(out kbutton);
            if (flag)
            {
                kbutton.onClick += onClick;
                kbutton.fgImage.sprite = Def.GetUISpriteFromMultiObjectAnim(animFile, animName, false, "");
            }
            this.buttons.Add(gameObject);
        }
        private void ClearButtons()
        {
            foreach (GameObject original in this.buttons)
            {
                Util.KDestroyGameObject(original);
            }
            this.buttons.Clear();
            this.flipButton.SetActive(false);
            this.debugVictoryButton.SetActive(false);
        }
        [SerializeField]
        private RectTransform buttonContainer;
        private GameObject stateButtonPrefab;
        private GameObject debugVictoryButton;
        private GameObject flipButton;
        private readonly List<GameObject> buttons = new List<GameObject>();
        private SelectableSign target;        
    }
}
