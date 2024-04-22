using System.Collections.Generic;
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
            UnitFactory.CreateBullet(scene, IdGenerater.Instance.GenerateId(), actionEvent.OwnerSkill, 5001,
                actionEvent.ActionEventConfig.Params);
        }
    }
}