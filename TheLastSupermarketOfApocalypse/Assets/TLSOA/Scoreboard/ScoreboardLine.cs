using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TLSOA.Scoreboard
{
    public class ScoreboardLine : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreText = null;
        [SerializeField]
        private Image _icon = null;

        public void SetUp(int score, Sprite icon)
        {
            _scoreText.text = $"Score: {score}";
            _icon.sprite = icon;
        }
    }
}