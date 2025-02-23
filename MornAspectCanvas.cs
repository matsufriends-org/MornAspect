using UnityEngine;
using UnityEngine.UI;

namespace MornAspect
{
    [RequireComponent(typeof(CanvasScaler))]
    [ExecuteAlways]
    internal class MornAspectCanvas : MonoBehaviour
    {
        [SerializeField] private CanvasScaler _canvasScaler;
        [SerializeField] private RectTransform _contents;

        private void Awake()
        {
            if (Application.isPlaying) AdjustCanvas();
        }

        private void Reset()
        {
            _canvasScaler = GetComponent<CanvasScaler>();
        }

        private void Update()
        {
            AdjustCanvas();
        }

        private void AdjustCanvas()
        {
            if (MornAspectGlobal.I == null) return;
            var global = MornAspectGlobal.I;
            if (_canvasScaler.uiScaleMode != CanvasScaler.ScaleMode.ScaleWithScreenSize)
            {
                _canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                MornAspectGlobal.Log("Canvas Scale Mode Adjusted");
                MornAspectGlobal.SetDirty(_canvasScaler);
            }

            if (_canvasScaler.referenceResolution != global.Resolution)
            {
                _canvasScaler.referenceResolution = global.Resolution;
                MornAspectGlobal.Log("Canvas Reference Resolution Adjusted");
                MornAspectGlobal.SetDirty(_canvasScaler);
            }

            if (_canvasScaler.screenMatchMode != CanvasScaler.ScreenMatchMode.Expand)
            {
                _canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
                MornAspectGlobal.Log("Canvas Screen Match Mode Adjusted");
                MornAspectGlobal.SetDirty(_canvasScaler);
            }
            
            if (_contents != null && _contents.sizeDelta != global.Resolution)
            {
                _contents.sizeDelta = global.Resolution;
                MornAspectGlobal.Log("Contents Size Delta Adjusted");
                MornAspectGlobal.SetDirty(_contents);
            }
        }
    }
}