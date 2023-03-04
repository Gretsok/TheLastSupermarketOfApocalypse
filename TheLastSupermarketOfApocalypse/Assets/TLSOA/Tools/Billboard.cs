using UnityEngine;

namespace TLSOA.Tools
{
    public class Billboard : MonoBehaviour
    {
        private void Update()
        {
            if (Camera.main == null) return;

            transform.rotation = Camera.main.transform.rotation;
        }
    }
}