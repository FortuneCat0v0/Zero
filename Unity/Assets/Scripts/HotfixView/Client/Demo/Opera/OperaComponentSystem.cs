using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(OperaComponent))]
    [FriendOf(typeof(OperaComponent))]
    public static partial class OperaComponentSystem
    {
        [EntitySystem]
        private static void Awake(this OperaComponent self)
        {
            self.mapMask = LayerMask.GetMask("Map");
        }

        [EntitySystem]
        private static void Update(this OperaComponent self)
        {
            if (InputHelper.IsClickOrTouchBegan(1) && !InputHelper.IsPointerOverUI())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000, self.mapMask))
                {
                    C2M_PathfindingResult c2MPathfindingResult = C2M_PathfindingResult.Create();
                    c2MPathfindingResult.Position = hit.point;
                    self.Root().GetComponent<ClientSenderComponent>().Send(c2MPathfindingResult);
                }
            }

            // if (InputHelper.GetKeyDown(KeyCode.R))
            // {
            //     CodeLoader.Instance.Reload();
            //     return;
            // }
            //
            // if (InputHelper.GetKeyDown(KeyCode.T))
            // {
            //     C2M_TransferMap c2MTransferMap = C2M_TransferMap.Create();
            //     self.Root().GetComponent<ClientSenderComponent>().Call(c2MTransferMap).Coroutine();
            // }
        }
    }
}