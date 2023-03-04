using System.Collections.Generic;
using UnityEngine;

namespace TLSOA.Kart
{
    public class KartsSpawner : MonoBehaviour
    {
        [SerializeField]
        private KartMovementController _kartPrefab = null;
        [SerializeField]
        private List<Transform> _startingPositions = null;
        [SerializeField]
        private List<Material> _kartMaterials = null;

        private List<KartMovementController> _kartMovementControllers = new List<KartMovementController>();

        private void Start()
        {
            var inputHandler = PlayerInputManagement.PlayerInputHandler.Instance;
            if(inputHandler)
            {
                for(int i = 0; i < inputHandler.PlayerInputManager.playerCount; ++i)
                {
                    var startingPosition = _startingPositions[i];
                    var kart = Instantiate(_kartPrefab, startingPosition.position, startingPosition.rotation, startingPosition);
                    _kartMovementControllers.Add(kart);
                    if(kart.TryGetComponent(out KartPlayerController playerController))
                    {
                        playerController.Initialize(i, _kartMaterials[i]);
                    }
                }
            }
        }
    }
}