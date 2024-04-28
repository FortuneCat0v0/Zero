using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UICommonItem))]
    [EntitySystemOf(typeof(UICommonItem))]
    public static partial class UICommonItemSystem
    {
        [EntitySystem]
        private static void Awake(this UICommonItem self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();

            self.ClickBtn = rc.Get<GameObject>("ClickBtn");
            self.DragEvent = rc.Get<GameObject>("DragEvent");
            self.QualityImg = rc.Get<GameObject>("QualityImg");
            self.IconImg = rc.Get<GameObject>("IconImg");
            self.NumText = rc.Get<GameObject>("NumText");
            self.NameText = rc.Get<GameObject>("NameText");
            self.HighlightImg = rc.Get<GameObject>("HighlightImg");
            self.LockItemImg = rc.Get<GameObject>("LockItemImg");
            self.UpTipImg = rc.Get<GameObject>("UpTipImg");
            self.LockCellImg = rc.Get<GameObject>("LockCellImg");
            self.ItemTipBtn = rc.Get<GameObject>("ItemTipBtn");

            self.ItemTipBtn.GetComponent<Button>().AddListener(self.OnItemTipBtn);
        }

        public static async ETTask Refresh(this UICommonItem self, Item item, Action<Item> onClickAction = null)
        {
            self.ClickBtn.SetActive(false);
            self.DragEvent.SetActive(false);
            self.QualityImg.SetActive(false);
            self.IconImg.SetActive(false);
            self.NumText.SetActive(false);
            self.NameText.SetActive(false);
            self.HighlightImg.SetActive(false);
            self.LockItemImg.SetActive(false);
            self.UpTipImg.SetActive(false);
            self.LockCellImg.SetActive(false);
            self.ItemTipBtn.SetActive(false);
            
            if (null == item)
            {
                return;
            }
            
            self.Item = item;
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(item.ConfigId);
            
            // self.ClickBtn.GetComponent<Button>().onClick.AddListener(() => { onClickAction?.Invoke(item); });
            self.ClickBtn.SetActive(true);
            
            self.QualityImg.GetComponent<Image>().sprite =
                    await resourcesLoaderComponent.LoadAssetAsync<Sprite>(AssetPathHelper.GetItemQualityIconPath(itemConfig.Quality));
            self.QualityImg.SetActive(true);
            
            self.IconImg.GetComponent<Image>().sprite =
                    await resourcesLoaderComponent.LoadAssetAsync<Sprite>(AssetPathHelper.GetItemIconPath(itemConfig.Icon));
            self.IconImg.SetActive(true);
            
            self.NumText.GetComponent<TMP_Text>().text = item.Num.ToString();
            self.NumText.SetActive(true);
            
            self.NameText.GetComponent<TMP_Text>().text = itemConfig.Name;
            self.NameText.SetActive(true);
            
            self.ItemTipBtn.SetActive(true);
        }

        private static void OnItemTipBtn(this UICommonItem self)
        {
            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips() { Item = self.Item, InputPoint = Input.mousePosition });
        }
    }
}