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
            AdjustCanvas();
        }

        private void Update()
        {
            AdjustCanvas();
        }

        private void Reset()
        {
            _canvasScaler = GetComponent<CanvasScaler>();
        }

        private void AdjustCanvas()
        {
            if (MornAspectGlobalSettings.Instance == null)
            {
                return;
            }

            var settings = MornAspectGlobalSettings.Instance;
            var anyChanged = false;

            if (_canvasScaler.uiScaleMode != CanvasScaler.ScaleMode.ScaleWithScreenSize)
            {
                _canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                MornAspectUtil.Log("Canvas Scale Mode Adjusted");
                anyChanged = true;
            }

            if (_canvasScaler.referenceResolution != settings.Resolution)
            {
                _canvasScaler.referenceResolution = settings.Resolution;
                MornAspectUtil.Log("Canvas Reference Resolution Adjusted");
                anyChanged = true;
            }

            if (_canvasScaler.screenMatchMode != CanvasScaler.ScreenMatchMode.Expand)
            {
                _canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
                MornAspectUtil.Log("Canvas Screen Match Mode Adjusted");
                anyChanged = true;
            }

            if (anyChanged)
            {
#if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(_canvasScaler);
#endif
            }
        }
    }
}