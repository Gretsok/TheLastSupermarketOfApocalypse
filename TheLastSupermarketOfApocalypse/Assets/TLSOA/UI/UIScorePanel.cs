using System;
using System.Collections;
using System.Collections.Generic;
using TLSOA.Kart;
using TMPro;
using UnityEngine;

public class UIScorePanel : MonoBehaviour
{
    [SerializeField] private KartsSpawner _kartSpawner;
    [SerializeField] private List<GameObject> _widgetContainers;
    [SerializeField] private List<TextMeshProUGUI> _scoreText;
    // Start is called before the first frame update

    private void Awake()
    {
        _kartSpawner.onKartSetUp+=setUpWidgets;
    }

    private void setUpWidgets()
    {
        _kartSpawner.onKartSetUp -= setUpWidgets;
        for(int i =0;i<_kartSpawner.kartMovementControllers.Count;i++)
        {
            _kartSpawner.kartMovementControllers[i].GetComponent<ScoreRegisterer>().onScoreChange += handleScoreChange;
            _widgetContainers[i].gameObject.SetActive(true);
        }
        for(int i = _kartSpawner.kartMovementControllers.Count; i < _widgetContainers.Count; i++)
        {
            _widgetContainers[i].gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _kartSpawner.kartMovementControllers.Count; i++)
        {
            _kartSpawner.kartMovementControllers[i].GetComponent<ScoreRegisterer>().onScoreChange -= handleScoreChange;
        }
    }

    private void handleScoreChange(ScoreRegisterer scoreRegisterer)
    {
        var movementController = scoreRegisterer.GetComponent<KartMovementController>();
        int scoreIndex = _kartSpawner.kartMovementControllers.FindIndex(x => x == movementController);
        _scoreText[scoreIndex].text = scoreRegisterer.TotalScore.ToString();
    }
}
