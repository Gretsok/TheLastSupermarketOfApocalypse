using UnityEngine;
using UnityEngine.Events;

namespace TLSOA.MainMenu
{
    public class CreditsPanel : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onBackButtonPressed = null;
        public void GoBack()
        {
            _onBackButtonPressed?.Invoke();
        }
    }
}