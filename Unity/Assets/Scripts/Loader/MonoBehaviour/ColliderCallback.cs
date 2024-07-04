using System;
using UnityEngine;



namespace ET
{
    public class ColliderCallback : MonoBehaviour
    {
        public Action<Collider> OnTriggerEnterAction;
        public Action<Collider> OnTriggerStayAction;
        public Action<Collider> OnTriggerExitAction;

        private void OnTriggerEnter(Collider other)
        {
            this.OnTriggerEnterAction?.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            this.OnTriggerStayAction?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            this.OnTriggerExitAction?.Invoke(other);
        }
    }
}