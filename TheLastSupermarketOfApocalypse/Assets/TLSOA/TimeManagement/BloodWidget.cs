using UnityEngine;
using UnityEngine.UI;

namespace TLSOA.TimeManagement
{
    public class BloodWidget : MonoBehaviour
    {
        [SerializeField]
        private TimeManager _timeManager = null;

        [SerializeField]
        private Image _bloodScreen = null;

        [SerializeField]
        private float _pulseAmplitude = 0.2f;
        [SerializeField]
        private float _speed = 2f;

        private void Update()
        {
            var colorTemp = _bloodScreen.color;
            colorTemp.a = _timeManager.timeSpent / _timeManager.gameDuration + Mathf.Cos(Time.time * (_speed / (2 * Mathf.PI))) * _pulseAmplitude;
            _bloodScreen.color = colorTemp;
            Debug.Log(Mathf.Cos(Time.time * (_speed * (2 * Mathf.PI))) * _pulseAmplitude);
        }
    }
}
