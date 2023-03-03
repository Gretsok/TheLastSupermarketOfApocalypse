using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TLSOA.MainMenu
{
    public class GameSetUpPanel : MonoBehaviour
    {
        private PlayerInputManagement.PlayerInputHandler _inputHandler = null;
       
        [SerializeField]
        private List<GameObject> _playerWidgets = null;

        private void Awake()
        {
            _inputHandler = FindObjectOfType<PlayerInputManagement.PlayerInputHandler>();
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
    }
}