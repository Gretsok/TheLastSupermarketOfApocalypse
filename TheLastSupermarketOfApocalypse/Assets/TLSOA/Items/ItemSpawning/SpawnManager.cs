using System;
using System.Collections;
using System.Collections.Generic;
using TLSOA.Items.ItemSpawning;
using TLSOA.TimeManagement;
using UnityEngine;

namespace TLSOA.Items.ItemSpawning
{
    public class SpawnManager : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private List<StoreProduct> products;
        [SerializeField] private List<GameObject> spawnPointList;
        [SerializeField] private AnimationCurve _multiplierOverTime;
        [SerializeField] private TimeManager _timeManager;
        [SerializeField] private int _maxMultiplier = 5;
        //[SerializeField] private int _baseProductCount;
        private int _productCount => Mathf.RoundToInt(_multiplierOverTime.Evaluate(_timeManager.timeLeft / _timeManager.gameDuration).Remap(0,1,1,_maxMultiplier));
        public float scoreMultiplier => _multiplierOverTime.Evaluate(_timeManager.timeSpent / _timeManager.gameDuration).Remap(0, 1, 1, _maxMultiplier);

        private List<GameObject> _availableSpawnPoints;
        private List<StoreProduct> _spawnedProducts;
        void Start()
        {
            _availableSpawnPoints = new List<GameObject>(spawnPointList);
            _spawnedProducts = new List<StoreProduct>();
            //StartCoroutine(Spawner());
        }

        // Update is called once per frame
        void Update()
        {
            if(_spawnedProducts.Count< _productCount)
            {
                CreateNewItem();

            }
            
        }

        private void CreateNewItem()
        {
            int positionIndex = UnityEngine.Random.Range(0, _availableSpawnPoints.Count);
            Debug.Log(positionIndex);
            Vector3 pos = _availableSpawnPoints[positionIndex].transform.position;


            int productIndex = UnityEngine.Random.Range(0, products.Count);

            Debug.Log(products[productIndex].name);

            var newProduct = Instantiate(products[productIndex], pos, Quaternion.identity);
            newProduct.Initialize(_availableSpawnPoints[positionIndex].transform, scoreMultiplier);
            newProduct.onCollected += HandleCollected;

            _availableSpawnPoints.RemoveAt(positionIndex);
            _spawnedProducts.Add(newProduct);
        }

        private void HandleCollected(Transform position, StoreProduct product)
        {
            product.onCollected-= HandleCollected;
            _spawnedProducts.Remove(product);
            _availableSpawnPoints.Add(position.gameObject);
        }
    }

}
