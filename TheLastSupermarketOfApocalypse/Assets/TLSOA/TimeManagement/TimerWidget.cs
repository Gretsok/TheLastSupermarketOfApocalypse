using TMPro;
using UnityEngine;

namespace TLSOA.TimeManagement
{
    public class TimerWidget : MonoBehaviour
    {
        [SerializeField]
        private TimeManager _timeManager = null;

        [SerializeField]
        private TextMeshProUGUI _timerText = null;

        private void Update()
        {
            if (!_timeManager) return;

            _timerText.text = $"{_timeManager.timeLeft.ToString("0")} s";
        }
    }
}