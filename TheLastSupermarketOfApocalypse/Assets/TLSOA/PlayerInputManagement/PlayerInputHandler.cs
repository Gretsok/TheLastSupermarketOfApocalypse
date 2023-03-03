using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TLSOA.PlayerInputManagement
{
    [RequireComponent(typeof(PlayerInputManager))]
    public class PlayerInputHandler : MonoBehaviour
    {
        private static PlayerInputHandler _instance = null;
        public static PlayerInputHandler Instance => _instance;

        private PlayerInputManager _playerInputManager = null;
        public PlayerInputManager PlayerInputManager => _playerInputManager;
        private EPlayerManagementState _playerManagementState = EPlayerManagementState.Invalid;

        private List<PlayerInput> _playerInputs = new List<PlayerInput>();

        public Action onPlayersUpdated = null;

        private void Awake()
        {
            if(_instance)
            {
                Destroy(_instance);
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);
            _playerInputManager = GetComponent<PlayerInputManager>();
            RegisterEvents();
        }

        private void OnDestroy()
        {
            UnregisterEvents();
        }

        protected virtual void RegisterEvents()
        {
            _playerInputManager.onPlayerJoined += HandlePlayerJoined;
            _playerInputManager.onPlayerLeft += HandlePlayerLeft;
        }

        protected virtual void UnregisterEvents()
        {
            _playerInputManager.onPlayerJoined -= HandlePlayerJoined;
            _playerInputManager.onPlayerLeft -= HandlePlayerLeft;
        }

        public void ListenToNewPlayers()
        {
            _playerInputManager.joinBehavior = PlayerJoinBehavior.JoinPlayersWhenButtonIsPressed;
            _playerManagementState = EPlayerManagementState.ListeningToNewPlayers;
        }

        public void ReadyUpForGameplay()
        {
            _playerInputManager.joinBehavior = PlayerJoinBehavior.JoinPlayersManually;
            _playerManagementState = EPlayerManagementState.ClosedAndReadyForGameplay;
        }

        private void HandlePlayerJoined(PlayerInput playerInput)
        {
            _playerInputs.Add(playerInput);
            onPlayersUpdated?.Invoke();
        }

        private void HandlePlayerLeft(PlayerInput playerInput)
        {
            _playerInputs.Remove(playerInput);
            onPlayersUpdated?.Invoke();
        }

        public InputActionAsset GetAction(int playerIndex)
        {
            if (_playerInputs.Count <= playerIndex) return null;
            return _playerInputs[playerIndex].actions;
        }
    }

    public enum EPlayerManagementState
    {
        Invalid,
        ListeningToNewPlayers,
        ClosedAndReadyForGameplay
    }
}