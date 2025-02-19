using UnityEngine;

namespace MornAspect
{
    [RequireComponent(typeof(RectTransform))]
    [ExecuteAlways]
    internal class MornAspectFullScreenUI : MonoBehaviour
    {
        [SerializeField] private RectTransform _rect;

        private void Awake()
        {
            if (Application.isPlaying) AdjustCanvas();
        }

        private void Reset()
        {
            _rect = GetComponent<RectTransform>();
        }

        private void Update()
        {
            AdjustCanvas();
        }

        private void AdjustCanvas()
        {
            var global = MornAspectGlobal.I;
            if (global == null) return;
            if (_rect != null && _rect.sizeDelta != global.Resolution)
            {
                _rect.sizeDelta = global.Resolution;
                global.Log("Rect Transform Size Adjusted");
                global.SetDirty(_rect);
            }
        }
    }
}