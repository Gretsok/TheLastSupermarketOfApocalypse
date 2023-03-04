using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TLSOA.TimeManagement
{
    public class TimerWidget : MonoBehaviour
    {
        [SerializeField]
        private TimeManager _timeManager = null;

        [SerializeField]
        private TextMeshProUGUI _timerText = null;

        [SerializeField]
        private Image _filler = null;

        private void Update()
        {
            if (!_timeManager) return;

            _timerText.text = $"{_timeManager.timeLeft.ToString("0")} s";
            _filler.fillAmount = _timeManager.timeLeft / _timeManager.gameDuration;
        }
    }
}