using System.Numerics;
using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 技能发射子弹
    /// </summary>
    [ActionEvent(EActionEventType.Bullet)]
    [FriendOf(typeof(ActionEvent))]
    public class ActionEventBullet : IActionEvent
    {
        public void Run(ActionEvent actionEvent, EventType.ActionEventData args)
        {
            Unit owner = args.owner;
            Log.Info($"emit a bullet");
            if (owner == null)
                return;

            Scene scene = actionEvent.Scene();
            ActionEventConfig actionEventConfig = actionEvent.ActionEventConfig;

            quaternion ownerRotation = args.owner.Rotation;
            int direct = 1;
            for (int i = 0; i < actionEventConfig.Params[1]; i++)
            {
                direct = -direct;

                quaternion rotatedQuaternion = math.mul(quaternion.RotateY(i * direct * 15f), ownerRotation);

                UnitFactory.CreateBullet(scene, IdGenerater.Instance.GenerateId(), actionEvent.OwnerSkill, actionEventConfig.Params[0],
                    rotatedQuaternion);
            }
        }
    }
}