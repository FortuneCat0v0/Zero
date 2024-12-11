using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class GameObjectComponent : Entity, IAwake<string>, IDestroy
    {
        public GameObject GameObject { get; set; }
        public GameObject MountGameObject; // 坐骑
    }
}