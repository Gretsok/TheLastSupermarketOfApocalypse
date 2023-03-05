using System.Collections.Generic;
using UnityEngine;

namespace TLSOA.Items.ItemsCollection
{
    public class Collector : MonoBehaviour
    {
        private int _currentLiftWeight = 0;
        private List<GameObject> _currentVisualsInKart = new List<GameObject>();
        [SerializeField]
        private Transform _visualSpawnPoint = null;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Collectable collectable))
            {
                _currentLiftWeight += collectable.Collect();
                var visual = Instantiate(collectable.CollectableVisual, _visualSpawnPoint.position, _visualSpawnPoint.rotation, _visualSpawnPoint);
                _currentVisualsInKart.Add(visual);
                Destroy(collectable.gameObject);
            }
        }

        public int EmptyKart()
        {
            int weight = _currentLiftWeight;

            _currentLiftWeight = 0;

            for(int i = _currentVisualsInKart.Count -1; i >= 0; --i) 
            {
                Destroy(_currentVisualsInKart[i]);
            }

            return weight;
        }
    }
}