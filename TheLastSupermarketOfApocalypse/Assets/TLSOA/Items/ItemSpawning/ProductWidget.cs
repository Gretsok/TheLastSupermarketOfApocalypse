using UnityEngine;

namespace TLSOA.Items.ItemSpawning
{
    public class ProductWidget : MonoBehaviour
    {
        private void Start()
        {
            var viewPort = Camera.main.WorldToViewportPoint(transform.position) + Vector3.up * 0.05f;

            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(viewPort.x, viewPort.y, 16f));
        }
    }
}