using TLSOA.Items.ItemsCollection;
using TLSOA.Kart;
using UnityEngine;

namespace TLSOA.Supermarker.CashRegisterer
{
    public class CashRegistererZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Collector collector))
            {
                collector.GetComponent<ScoreRegisterer>().AddScore(collector.EmptyKart());
            }
        }
    }
}