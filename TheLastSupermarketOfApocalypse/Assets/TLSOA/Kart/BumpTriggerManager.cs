using System;
using System.Collections;
using System.Collections.Generic;
using TLSOA.Kart;
using UnityEngine;

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
        _speed = _relay.getKartRigidbody().velocity.magnitude;
        _kartMovementController = _relay.getKartMovement();
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        // Faire le calcul vectorielle, position du kart actuel et position du centre du kart tapé, normaliser le vecteur et multiplié la velocity
        if (other.CompareTag("Kart"))
        {
            other.GetComponent<RigidbodyColissionRelay>().getKartMovement().Bumped(_speed);
        }
    }
    
}
