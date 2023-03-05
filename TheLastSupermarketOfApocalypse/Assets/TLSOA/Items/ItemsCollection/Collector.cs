using System;
using System.Collections.Generic;
using UnityEngine;

namespace TLSOA.Items.ItemsCollection
{
    public class Collector : MonoBehaviour
    {
        private int _currentLiftWeight = 0;
        public int currentLiftWeight => _currentLiftWeight;
        private List<GameObject> _currentVisualsInKart = new List<GameObject>();
        [SerializeField]
        private Transform _visualSpawnPoint = null;

        public Action onLiftedWeightChanged = null;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Collectable collectable))
            {
                _currentLiftWeight += collectable.Collect();
                var visual = Instantiate(collectable.CollectableVisual, _visualSpawnPoint.position, _visualSpawnPoint.rotation, _visualSpawnPoint);
                _currentVisualsInKart.Add(visual);
                Destroy(collectable.gameObject);
                onLiftedWeightChanged?.Invoke();
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
            onLiftedWeightChanged?.Invoke();
            return weight;
        }
    }
}