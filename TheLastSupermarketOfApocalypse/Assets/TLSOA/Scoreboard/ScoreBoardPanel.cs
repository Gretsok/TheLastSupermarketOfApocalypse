using System.Collections.Generic;
using TLSOA.Kart;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TLSOA.Scoreboard
{
    public class ScoreBoardPanel : MonoBehaviour
    {
        [SerializeField]
        private KartsSpawner _spawner = null;
        [SerializeField]
        private TimeManagement.TimeManager _timeManager = null;
        [SerializeField]
        private ScoreboardLine _linePrefab = null;
        [SerializeField]
        private Transform _lineContainer = null;
        [SerializeField]
        private List<Sprite> _playerIcons = null;

        private List<ScoreboardLine> _lines = new List<ScoreboardLine>();

        [SerializeField]
        private float _panelDuration = 10f;

        private void Start()
        {
            gameObject.SetActive(false);
            _timeManager.onGameEnded += HandleGameEnded;
        }

        private void HandleGameEnded()
        {
            _timeManager.onGameEnded -= HandleGameEnded;
            SetUp();
            gameObject.SetActive(true);
            Invoke(nameof(LoadMenu), _panelDuration);
        }

        public void SetUp()
        {
            List<ScoreRegisterer> scoreRegisterers = new List<ScoreRegisterer>();
            for(int i = 0; i < _spawner.kartMovementControllers.Count; ++i)
            {
                scoreRegisterers.Add(_spawner.kartMovementControllers[i].GetComponent<ScoreRegisterer>());
            }

            List<ScoreRegisterer> sortedScorer = new List<ScoreRegisterer>(scoreRegisterers);
            for (int i = sortedScorer.Count - 1; i >= 1; --i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (sortedScorer[j + 1].TotalScore > sortedScorer[j].TotalScore)
                    {
                        var temp = sortedScorer[j + 1];
                        sortedScorer[j + 1] = sortedScorer[j];
                        sortedScorer[j] = temp;
                    }
                }
            }

            for (int i = 0; i < sortedScorer.Count; ++i)
            {
                int index = scoreRegisterers.FindIndex(x => x == sortedScorer[i]);
                var line = Instantiate(_linePrefab, _lineContainer);
                line.SetUp(sortedScorer[i].TotalScore, _playerIcons[index]);
                _lines.Add(line);
            }
        }


        public void LoadMenu()
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}