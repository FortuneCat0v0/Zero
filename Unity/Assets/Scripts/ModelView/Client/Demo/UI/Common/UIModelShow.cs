using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UIModelShow : Entity, IAwake<GameObject>
    {
        public GameObject GameObject;
        public GameObject RawImg;
        public GameObject Root;
        public GameObject Camera;
        public GameObject ModelRoot;
        public GameObject Model;

        public Vector2 StartPosition;
    }
}