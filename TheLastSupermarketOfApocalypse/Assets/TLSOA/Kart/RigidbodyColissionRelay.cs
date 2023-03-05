using System.Collections;
using System.Collections.Generic;
using TLSOA.Kart;
using UnityEngine;

public class RigidbodyColissionRelay : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private KartMovementController _kartMovementController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Rigidbody getKartRigidbody()
    {
        return _rigidbody;
    }

    public KartMovementController getKartMovement()
    {
        return _kartMovementController;
    }
    
}
