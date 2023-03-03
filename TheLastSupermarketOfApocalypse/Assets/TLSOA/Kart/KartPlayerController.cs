using UnityEngine;
using UnityEngine.InputSystem;

namespace TLSOA.Kart
{
    public class KartPlayerController : MonoBehaviour
    {
        private InputActionAsset _action = null;

        [SerializeField]
        private KartMovementController _movementController = null;
        public void Initialize(int playerIndex)
        {
            _action = PlayerInputManagement.PlayerInputHandler.Instance.GetAction(playerIndex);
        }

        private void Update()
        {
            if (!_action) return;

            Vector2 input = _action.FindActionMap("Gameplay").FindAction("Movement").ReadValue<Vector2>();
            _movementController.SetDesiredVelocity(new Vector3(input.x, 0, input.y));
        }
    }
}