using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TLSOA.PlayerInputManagement;

namespace TLSOA.MainMenu
{
    public class GameSetUpPanel : MonoBehaviour
    {
        private PlayerInputHandler _inputHandler = null;
       
        [SerializeField]
        private List<GameObject> _playerWidgets = null;
        [SerializeField]
        private CreditsPanel _creditsPanel = null;

        private void Start()
        {
            _inputHandler = PlayerInputHandler.Instance;
            if(_inputHandler)
            {
                _inputHandler.onPlayersUpdated += HandlePlayersUpdated;
                _inputHandler.ListenToNewPlayers();
            }
            RefreshPanel();
        }

        private void OnDestroy()
        {
            if(_inputHandler)
            {
                _inputHandler.onPlayersUpdated -= HandlePlayersUpdated;
            }
        }

        private void HandlePlayersUpdated()
        {
            RefreshPanel();
        }

        private void RefreshPanel()
        {
            if (_inputHandler)
            {
                for(int i = 0; i < _inputHandler.PlayerInputManager.playerCount; ++i)
                {
                    _playerWidgets[i].SetActive(true);
                }
                for (int i = _inputHandler.PlayerInputManager.playerCount; i < _inputHandler.PlayerInputManager.maxPlayerCount; ++i)
                {
                    _playerWidgets[i].SetActive(false);
                }
            }
        }

        public void StartGame()
        {
            _inputHandler.ReadyUpForGameplay();
            SceneManager.LoadSceneAsync(1);
        }

        public void ShowCredits()
        {
            _creditsPanel.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void HideCredits()
        {
            _creditsPanel.gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}