using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CashRegisterManager : MonoBehaviour
{

    [SerializeField] private List<CashRegister> _cashRegisterList;

    public float timeBeforeChangeCashRegister = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CashRegisterChange());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/// <summary>
/// 
/// </summary>
/// <returns></returns>
    IEnumerator CashRegisterChange()
    {
        var FirstCashRegister = Random.Range(0, _cashRegisterList.Count);
        var SecondCashRegister = Random.Range(0, _cashRegisterList.Count);
        
        Debug.Log("/First item Cash Register :  " + FirstCashRegister + " Second item Cash Register : " + SecondCashRegister);
        
        while ( SecondCashRegister == FirstCashRegister )
        {
            Debug.Log("/Je suis dans le while");
            SecondCashRegister = Random.Range(0, _cashRegisterList.Count);
        }
        Debug.Log("/J'entre dans le premier Closed");
        _cashRegisterList[FirstCashRegister].CashRegisterIsClosed();
        Debug.Log("/J'entre dans le Second Closed");
        _cashRegisterList[SecondCashRegister].CashRegisterIsClosed();
        
        for (int i = 0; i < _cashRegisterList.Count; i++)
        {
            if (i != FirstCashRegister && i != SecondCashRegister)
            {
                _cashRegisterList[i].CashRegisterIsOpen();
            }
        }
        
        Debug.Log("/Avant fin coroutine");
        yield return new WaitForSeconds(timeBeforeChangeCashRegister);
        Debug.Log("/Après fin coroutine");
        StartCoroutine(CashRegisterChange());
    }
}
