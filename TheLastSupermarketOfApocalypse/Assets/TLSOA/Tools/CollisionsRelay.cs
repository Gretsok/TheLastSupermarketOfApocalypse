using System;
using UnityEngine;

namespace TLSOA.Tools
{
    public class CollisionsRelay : MonoBehaviour
    {
        public Action<Collider> onTriggerEnter = null;
        public Action<Collider> onTriggerExit = null;
        public Action<Collision> onCollisionEnter = null;
        public Action<Collision> onCollisionExit = null;

        private void OnTriggerEnter(Collider other)
        {
            onTriggerEnter?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            onTriggerExit?.Invoke(other);
        }

        private void OnCollisionEnter(Collision collision)
        {
            onCollisionEnter?.Invoke(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            onCollisionExit?.Invoke(collision);
        }
    }
}