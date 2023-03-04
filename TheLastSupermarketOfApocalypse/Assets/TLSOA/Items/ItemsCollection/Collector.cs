using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TLSOA.ItemsCollection
{
    public class Collector : MonoBehaviour
    {
        private int _currentLiftWeight = 0;
        private List<GameObject> _currentVisualsInKart = new List<GameObject>();

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Collectable collectable))
            {

            }
        }
    }
}