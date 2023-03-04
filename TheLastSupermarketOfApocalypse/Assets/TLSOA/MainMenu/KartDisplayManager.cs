using System.Collections.Generic;
using UnityEngine;

namespace TLSOA.MainMenu
{
    public class KartDisplayManager : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _kartsVisual = null;
        private void Start()
        {
            var inputHandler = PlayerInputManagement.PlayerInputHandler.Instance;
            if(inputHandler)
            {
                inputHandler.onPlayersUpdated += HandlePlayersUpdated;
            }
            RefreshKartVisuals();
        }

        private void OnDestroy()
        {
            var inputHandler = PlayerInputManagement.PlayerInputHandler.Instance;
            if (inputHandler)
            {
                inputHandler.onPlayersUpdated -= HandlePlayersUpdated;
            }
        }

        private void HandlePlayersUpdated()
        {
            RefreshKartVisuals();
        }

        private void RefreshKartVisuals()
        {
            var inputHandler = PlayerInputManagement.PlayerInputHandler.Instance;
            if (inputHandler)
            {
                for(int i = 0; i < inputHandler.PlayerInputManager.playerCount; ++i)
                {
                    _kartsVisual[i].SetActive(true);
                }
                for (int i = inputHandler.PlayerInputManager.playerCount; i < _kartsVisual.Count; ++i)
                {
                    _kartsVisual[i].SetActive(false);
                }
            }
        }
    }
}
