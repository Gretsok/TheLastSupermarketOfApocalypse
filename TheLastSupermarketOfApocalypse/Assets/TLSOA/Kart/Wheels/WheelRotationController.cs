using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TLSOA.Kart.Wheels
{
    public class WheelRotationController : MonoBehaviour
    {
        private Vector3 _lastPosition = default;
        private Vector3 _desiredWheelForward = default;
        private void FixedUpdate()
        {
            Vector3 deltaPosition = (transform.position - _lastPosition);
            if(deltaPosition.magnitude > 0.1 * Time.fixedDeltaTime)
            {
                _desiredWheelForward = deltaPosition.normalized;
            }

            transform.forward = Vector3.Slerp(transform.forward, _desiredWheelForward, Time.fixedDeltaTime * 15f);

            _lastPosition = transform.position;
        }
    }
}