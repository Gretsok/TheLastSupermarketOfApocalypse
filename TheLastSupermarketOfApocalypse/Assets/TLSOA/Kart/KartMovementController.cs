using UnityEngine;

namespace TLSOA.Kart
{
    [RequireComponent(typeof(Rigidbody))]
    public class KartMovementController : MonoBehaviour
    {
        private Rigidbody _rigidbody = null;
        private Vector3 _desiredVelocity = default;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetDesiredVelocity(Vector3 desiredVelocity)
        {
            _desiredVelocity = desiredVelocity;
        }

        private void FixedUpdate()
        {
            
        }
    }
}