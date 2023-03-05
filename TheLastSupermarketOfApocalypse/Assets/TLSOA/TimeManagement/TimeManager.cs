using System;
using UnityEngine;

namespace TLSOA.TimeManagement
{
    public class TimeManager : MonoBehaviour
    {
        private float _startTime;
        [SerializeField] private float _gameDuration = 90;
        public float timeLeft => _gameDuration - (Time.time - _startTime);
        public float timeSpent => Time.time - _startTime;
        public float gameDuration => _gameDuration;

        public Action onGameEnded = null;

        private bool _gameRunning = false;
        // Start is called before the first frame update
        void Start()
        {
            _startTime = Time.time;
            _gameRunning = true;
        }

        private void Update()
        {
            if (!_gameRunning) return;

            if(Time.time - _startTime > _gameDuration)
            {
                _gameRunning = false;
                onGameEnded?.Invoke();
            }
        }
    }

}
