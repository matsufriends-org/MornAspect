using UnityEngine;
using UnityEngine.UI;

namespace MornAspect
{
    [RequireComponent(typeof(CanvasScaler))]
    [ExecuteAlways]
    internal class MornAspectCanvas : MonoBehaviour
    {
        [SerializeField] private CanvasScaler _canvasScaler;

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
            var settings = MornAspectGlobal.I;
            if (_canvasScaler.uiScaleMode != CanvasScaler.ScaleMode.ScaleWithScreenSize)
            {
                _canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                MornAspectGlobal.I.Log("Canvas Scale Mode Adjusted");
                MornAspectGlobal.I.SetDirty(_canvasScaler);
            }

            if (_canvasScaler.referenceResolution != settings.Resolution)
            {
                _canvasScaler.referenceResolution = settings.Resolution;
                MornAspectGlobal.I.Log("Canvas Reference Resolution Adjusted");
                MornAspectGlobal.I.SetDirty(_canvasScaler);
            }

            if (_canvasScaler.screenMatchMode != CanvasScaler.ScreenMatchMode.Expand)
            {
                _canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
                MornAspectGlobal.I.Log("Canvas Screen Match Mode Adjusted");
                MornAspectGlobal.I.SetDirty(_canvasScaler);
            }
        }
    }
}