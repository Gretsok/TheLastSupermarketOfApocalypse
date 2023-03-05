using System;
using System.Collections;
using System.Collections.Generic;
using TLSOA.Kart;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class BumpTriggerManager : MonoBehaviour
{

    [SerializeField] private RigidbodyColissionRelay _relay;
    private float _speed;
    private KartMovementController _kartMovementController = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        // Faire le calcul vectorielle, position du kart actuel et position du centre du kart tapé, normaliser le vecteur et multiplié la velocity
        if (other.CompareTag("Kart"))
        {
            _speed = _relay.getKartRigidbody().velocity.magnitude;
            _kartMovementController = _relay.getKartMovement();
            var otherCollision = other.GetComponent<RigidbodyColissionRelay>();
            var normalizedVector = (otherCollision.getKartRigidbody().transform.position - _relay.getKartRigidbody().transform.position).normalized;
            otherCollision.getKartMovement().Bumped(_speed * normalizedVector);
        }
    }
    
}
