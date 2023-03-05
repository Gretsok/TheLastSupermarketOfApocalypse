using TMPro;
using UnityEngine;

namespace TLSOA.Items.ItemsCollection
{
    public class ItemsCollectedWidget : MonoBehaviour
    {
        [SerializeField]
        private Collector _collector = null;
        [SerializeField]
        private TextMeshProUGUI _text = null;

        private void Start()
        {
            var viewPort = Camera.main.WorldToViewportPoint(transform.parent.position) + Vector3.up * 0.05f;

            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(viewPort.x, viewPort.y, 16f));

            _collector.onLiftedWeightChanged += HandleLiftedWeightChanged;
            HandleLiftedWeightChanged();

        }

        private void Update()
        {
            var viewPort = Camera.main.WorldToViewportPoint(transform.parent.position) + Vector3.up * 0.05f;

            transform.position = Camera.main.ViewportToWorldPoint(new Vector3(viewPort.x, viewPort.y, 16f));
        }


        private void OnDestroy()
        {
            _collector.onLiftedWeightChanged -= HandleLiftedWeightChanged;
        }

        private void HandleLiftedWeightChanged()
        {
            _text.text = _collector.currentLiftWeight.ToString();
        }
    }
}