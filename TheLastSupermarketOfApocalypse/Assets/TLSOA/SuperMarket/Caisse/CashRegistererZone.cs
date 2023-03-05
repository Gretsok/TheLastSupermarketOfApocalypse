using TLSOA.Items.ItemsCollection;
using TLSOA.Kart;
using UnityEngine;

namespace TLSOA.Supermarker.CashRegisterer
{
    public class CashRegistererZone : MonoBehaviour
    {
        public bool triggerable;
        private void OnTriggerEnter(Collider other)
        {
            if (triggerable)
            {
                if(other.TryGetComponent(out Collector collector))
                {
                    collector.GetComponent<ScoreRegisterer>().AddScore(collector.EmptyKart());
                }
            }
        }
    }
}