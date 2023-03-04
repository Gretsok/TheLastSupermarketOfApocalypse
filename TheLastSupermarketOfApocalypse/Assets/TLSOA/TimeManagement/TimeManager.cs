using System.Collections;
using System.Collections.Generic;
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
        // Start is called before the first frame update
        void Start()
        {
            _startTime = Time.time;
        }
    }

}
