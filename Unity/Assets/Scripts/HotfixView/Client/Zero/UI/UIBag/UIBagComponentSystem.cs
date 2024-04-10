using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UICommonItem))]
    [FriendOf(typeof(UIBagComponent))]
    [EntitySystemOf(typeof(UIBagComponent))]
    public static partial class UIBagComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIBagComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.ItemTypeTG = rc.Get<GameObject>("ItemTypeTG");
            self.AllToggle = rc.Get<GameObject>("AllToggle");
            self.EquipToggle = rc.Get<GameObject>("EquipToggle");
            self.MaterialToggle = rc.Get<GameObject>("MaterialToggle");
            self.ConsumeToggle = rc.Get<GameObject>("ConsumeToggle");
            self.UICommonItemsRoot = rc.Get<GameObject>("UICommonItemsRoot");

            self.ItemTypeTG.GetComponent<ToggleGroup>().AddListener(self.OnItemTypeTG);

            self.AllToggle.GetComponent<Toggle>().IsSelected(true);
        }

        private static void OnItemTypeTG(this UIBagComponent self, int index)
        {
            self.AllToggle.SetToggleShow(index == 0);
            self.EquipToggle.SetToggleShow(index == 1);
            self.MaterialToggle.SetToggleShow(index == 2);
            self.ConsumeToggle.SetToggleShow(index == 3);

            self.CurrentType = index;
            self.Refresh().Coroutine();
        }

        private static async ETTask Refresh(this UIBagComponent self)
        {
            // List<Item> items = new List<Item>();
            //
            // foreach (Item item in ItemHelper.GetAllItem(self.Root(), ItemContainerType.Bag))
            // {
            //     ItemConfig itemConfig = ItemConfigCategory.Instance.Get(item.ConfigId);
            //
            //     if (self.CurrentType == 0)
            //     {
            //         items.Add(item);
            //         continue;
            //     }
            //
            //     if (self.CurrentType == 1)
            //     {
            //         if (itemConfig.Type == (int)ItemType.Equipment)
            //         {
            //             items.Add(item);
            //             continue;
            //         }
            //     }
            //
            //     if (self.CurrentType == 2)
            //     {
            //         if (itemConfig.Type == (int)ItemType.Material)
            //         {
            //             items.Add(item);
            //             continue;
            //         }
            //     }
            //
            //     if (self.CurrentType == 3)
            //     {
            //         if (itemConfig.Type == (int)ItemType.Consume)
            //         {
            //             items.Add(item);
            //             continue;
            //         }
            //     }
            // }
            //
            // int count = self.UICommonItems.Count;
            // int num = 0;
            //
            // string assetsName = $"Assets/Bundles/UI/Common/UICommonItem.prefab";
            // GameObject bundleGameObject =
            //         await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            //
            // for (int i = 0; i < 50; i++)
            // {
            //     GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, self.UICommonItemsRoot.GetComponent<Transform>());
            //     self.UICommonItems.Add(self.AddChild<UICommonItem, GameObject>(gameObject));
            // }
            //
            // for (int i = 0; i < items.Count; i++)
            // {
            //     if (i >= count)
            //     {
            //         GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, self.UICommonItemsRoot.GetComponent<Transform>());
            //         self.UICommonItems.Add(self.AddChild<UICommonItem, GameObject>(gameObject));
            //     }
            //
            //     UICommonItem uiCommonItem = self.UICommonItems[i];
            //     await uiCommonItem.Refresh(items[i]);
            //     uiCommonItem.GameObject.SetActive(true);
            //     num++;
            // }
            //
            // for (int i = num; i < self.UICommonItems.Count; i++)
            // {
            //     UICommonItem uiCommonItem = self.UICommonItems[i];
            //     await uiCommonItem.Refresh(null);
            // }
            await ETTask.CompletedTask;
        }
    }
}