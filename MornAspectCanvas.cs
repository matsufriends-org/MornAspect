using UnityEngine;
using UnityEngine.UI;

namespace MornAspect
{
    [RequireComponent(typeof(CanvasScaler))]
    internal sealed class MornAspectCanvas : MornAspectComponentBase
    {
        [SerializeField] private CanvasScaler _canvasScaler;
        [SerializeField] private RectTransform _contents;

        private void Reset()
        {
            _canvasScaler = GetComponent<CanvasScaler>();
        }

        protected override void AdjustAspect()
        {
            if (!TryGetGlobal(out var global)) 
                return;
            
            if (_canvasScaler.uiScaleMode != CanvasScaler.ScaleMode.ScaleWithScreenSize)
            {
                _canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                MornAspectGlobal.LogAndSetDirty("Canvas Scale Mode Adjusted", _canvasScaler);
            }

            if (_canvasScaler.referenceResolution != global.Resolution)
            {
                _canvasScaler.referenceResolution = global.Resolution;
                MornAspectGlobal.LogAndSetDirty("Canvas Reference Resolution Adjusted", _canvasScaler);
            }

            if (_canvasScaler.screenMatchMode != CanvasScaler.ScreenMatchMode.Expand)
            {
                _canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
                MornAspectGlobal.LogAndSetDirty("Canvas Screen Match Mode Adjusted", _canvasScaler);
            }
            
            if (_contents != null && _contents.sizeDelta != global.Resolution)
            {
                _contents.sizeDelta = global.Resolution;
                MornAspectGlobal.LogAndSetDirty("Contents Size Delta Adjusted", _contents);
            }
        }
    }
}