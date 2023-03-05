using TLSOA.Items.ItemsCollection;
using TLSOA.Kart;
using UnityEngine;

namespace TLSOA.Supermarker.CashRegisterer
{
    public class CashRegistererZone : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;
        public bool triggerable = true;
        private void OnTriggerEnter(Collider other)
        {
            if (triggerable)
            {
                if(other.TryGetComponent(out Collector collector))
                {
                    collector.GetComponent<ScoreRegisterer>().AddScore(collector.EmptyKart());
                    _particle.Play();
                }
            }
        }
    }
}