using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TLSOA.Kart
{
    public class KartPlayerController : MonoBehaviour
    {
        private InputActionAsset _action = null;

        [SerializeField]
        private KartMovementController _movementController = null;
        [SerializeField]
        private List<MeshRenderer> _renderers = null;
        public void Initialize(int playerIndex, Material material)
        {
            _action = PlayerInputManagement.PlayerInputHandler.Instance.GetAction(playerIndex);
            _renderers?.ForEach(r => r.material = material);
        }

        private void Update()
        {
            if (!_action) return;

            Vector2 input = _action.FindActionMap("Gameplay").FindAction("Movement").ReadValue<Vector2>();
            _movementController.SetDesiredVelocity(new Vector3(input.x, 0, input.y));
        }
    }
}