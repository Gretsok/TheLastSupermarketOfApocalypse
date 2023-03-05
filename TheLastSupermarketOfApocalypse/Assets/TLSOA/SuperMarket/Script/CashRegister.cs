using System.Collections;
using System.Collections.Generic;
using TLSOA.Supermarker.CashRegisterer;
using UnityEngine;

public class CashRegister : MonoBehaviour
{
    [SerializeField] private GameObject _openCashRegisterFX;
    [SerializeField] private GameObject _closeCashRegisterFX;
    [SerializeField] private CashRegistererZone _cashRegisterer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CashRegisterIsClosed()
    {
        _openCashRegisterFX.gameObject.SetActive(false);
        _closeCashRegisterFX.gameObject.SetActive(true);
        _cashRegisterer.triggerable = false;
    }
}
