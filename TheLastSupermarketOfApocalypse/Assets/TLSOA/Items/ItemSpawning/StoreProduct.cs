using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TLSOA.Items.ItemSpawning
{
    public class StoreProduct : MonoBehaviour
    {
        [SerializeField] private int _baseScore;
        private int _score;
        private Transform _position;
        public Action<Transform, StoreProduct> onCollected;

        public void Initialize(Transform position, float multiplier)
        {
            _position= position;
            _score= Mathf.RoundToInt(_baseScore*multiplier);
        }

        public void NotifyCollected()
        {
            onCollected?.Invoke(_position, this);
        }
    }

}

