using UnityEngine;

namespace MornAspect
{
    [RequireComponent(typeof(RectTransform))]
    internal sealed class MornAspectFullScreenUI : MornAspectComponentBase
    {
        [SerializeField] private RectTransform _rect;

        private void Reset()
        {
            _rect = GetComponent<RectTransform>();
        }

        protected override void AdjustAspect()
        {
            if (!TryGetGlobal(out var global)) 
                return;
                
            if (_rect != null && _rect.sizeDelta != global.Resolution)
            {
                _rect.sizeDelta = global.Resolution;
                MornAspectGlobal.LogAndSetDirty("Rect Transform Size Adjusted", _rect);
            }
        }
    }
}