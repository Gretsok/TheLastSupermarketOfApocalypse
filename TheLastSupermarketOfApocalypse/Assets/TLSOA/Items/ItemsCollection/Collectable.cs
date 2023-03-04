using TLSOA.Items.ItemSpawning;
using UnityEngine;

namespace TLSOA.Items.ItemsCollection
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField]
        private StoreProduct _storeProduct = null;
        [SerializeField]
        private GameObject _collectableVisual = null;
        public GameObject CollectableVisual => _collectableVisual;

        public int Collect()
        {
            _storeProduct.NotifyCollected();
            return _storeProduct.Score;
        }
    }
}