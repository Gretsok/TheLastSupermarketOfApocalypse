using TMPro;
using UnityEngine;

namespace TLSOA.Items.ItemSpawning
{
    public class ScoreMultiplierWidget : MonoBehaviour
    {
        [SerializeField]
        private SpawnManager _spawnManager = null;
        [SerializeField]
        private TextMeshProUGUI _multiplierText = null;

        private void Update()
        {
            SetMultiplier(_spawnManager.scoreMultiplier);
        }

        public void SetMultiplier(float multiplier)
        {
            _multiplierText.text = $"x{multiplier.ToString("0.0")}";
        }
    }
}