using UnityEngine;

namespace TLSOA.Kart
{
    [RequireComponent(typeof(Rigidbody))]
    public class KartMovementController : MonoBehaviour
    {
        [Header("Physics Parameters")]
        [SerializeField]
        private float _baseMaxVelocityLength = 20f;
        private float _maxVelocityLength => _baseMaxVelocityLength;
        [SerializeField]
        private float _movementForce = 700f;

        [Header("References")]
        [SerializeField]
        private Transform _model = null;
        [SerializeField]
        private Tools.CollisionsRelay _collisionsRelay = null;

        private Rigidbody _rigidbody = null;
        private Vector3 _desiredVelocity = default;
        private Vector3 _desiredForwardOfModel = default;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            //_collisionsRelay.onCollisionEnter += OnCollisionEnter;
        }

        private void OnDestroy()
        {
            //_collisionsRelay.onCollisionEnter -= OnCollisionEnter;
        }

        public void SetDesiredVelocity(Vector3 desiredVelocity)
        {
            _desiredVelocity = desiredVelocity;
            if(_desiredVelocity.sqrMagnitude > 1)
            {
                _desiredVelocity.Normalize();
            }
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_desiredVelocity * _movementForce, ForceMode.Force);

            if (_desiredVelocity.sqrMagnitude > 0.1)
                _desiredForwardOfModel = _desiredVelocity;
            _rigidbody.MoveRotation(Quaternion.LookRotation(Vector3.Slerp(_model.transform.forward, _desiredForwardOfModel, Time.fixedDeltaTime * 15f), Vector3.up));
            
            
            if (_rigidbody.velocity.magnitude > _maxVelocityLength)
            {
                var normalizedVelocity = _rigidbody.velocity.normalized;
                _rigidbody.velocity = normalizedVelocity * _maxVelocityLength;
            }
        }

        public void Bumped(Vector3 force)
        {
            _rigidbody.AddRelativeForce(force, ForceMode.Impulse);
        }
        
        /*
        public void AddForce(Vector3 force)
        {

        }
        
        private void OnCollisionEnter(Collision collision)
        {
            _rigidbody.AddForce()
        }*/
    }
}