﻿using UnityEngine;

namespace ET.Client
{
    [ChildOf(typeof(UIServerComponent))]
    public class UIServerItem : Entity, IAwake<GameObject, GameServer>
    {
        public GameObject NameText;
        public GameObject Btn;

        public long ServerId;
    }
}