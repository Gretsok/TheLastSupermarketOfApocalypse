using System;
using UnityEngine;

namespace TLSOA.Kart
{
    public class ScoreRegisterer : MonoBehaviour
    {
        private int _totalScore = 0;
        public int TotalScore => _totalScore;

        public Action<ScoreRegisterer> onScoreChange;
        public void AddScore(int scoreToAdd)
        {
            _totalScore += scoreToAdd;
            onScoreChange?.Invoke(this);
        }
    }
}