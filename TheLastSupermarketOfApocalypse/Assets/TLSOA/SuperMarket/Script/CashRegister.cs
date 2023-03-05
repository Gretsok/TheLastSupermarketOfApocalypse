using System.Collections;
using System.Collections.Generic;
using TLSOA.Supermarker.CashRegisterer;
using UnityEngine;

public class CashRegister : MonoBehaviour
{
    [SerializeField] private GameObject _openCashRegisterFX;
    [SerializeField] private GameObject _closeCashRegisterFX;
    [SerializeField] private CashRegistererZone _cashRegistererZone;

    // Start is called before the first frame update
    void Start()
    {
        _cashRegistererZone.triggerable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CashRegisterIsClosed()
    {
        Debug.Log("/Is Closed");
        _openCashRegisterFX.gameObject.SetActive(false);
        _closeCashRegisterFX.gameObject.SetActive(true);
        _cashRegistererZone.triggerable = false;
    }
    
    public void CashRegisterIsOpen()
    {
        Debug.Log("/Is Open");
        _openCashRegisterFX.gameObject.SetActive(true);
        _closeCashRegisterFX.gameObject.SetActive(false);
        _cashRegistererZone.triggerable = true;
    }
}
