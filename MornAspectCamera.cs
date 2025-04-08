using UnityEngine;

namespace MornAspect
{
    [RequireComponent(typeof(Camera))]
    [ExecuteAlways]
    internal sealed class MornAspectCamera : MonoBehaviour
    {
        [SerializeField] private Camera _targetCamera;
        [SerializeField, Range(0, 1f)] private float _scale = 1;

        private void Awake()
        {
            if (Application.isPlaying)
                AdjustCamera();
        }

        private void Reset()
        {
            _targetCamera = GetComponent<Camera>();
        }

        private void Update()
        {
            AdjustCamera();
        }

        private void AdjustCamera()
        {
            if (MornAspectGlobal.I == null)
                return;
            var screenRes = new Vector2(Screen.width, Screen.height);
            var settings = MornAspectGlobal.I;
            var currentAspect = screenRes.y / screenRes.x;
            var aimAspect = settings.Resolution.y / settings.Resolution.x;
            Rect newRect;
            if (Mathf.Abs(currentAspect - aimAspect) < 0.001f || currentAspect <= aimAspect)
            {
                newRect = new Rect(0, 0, 1, 1);
            }
            else
            {
                var gameRes = new Vector2(screenRes.x, screenRes.x * aimAspect);
                newRect = new Rect(0, (screenRes.y - gameRes.y) / screenRes.y / 2, 1, gameRes.y / screenRes.y);
            }

            // newRectを、0.5,0.5中心に scale 倍する
            newRect.x = (newRect.x - 0.5f) * _scale + 0.5f;
            newRect.y = (newRect.y - 0.5f) * _scale + 0.5f;
            newRect.width *= _scale;
            newRect.height *= _scale;
            if (_targetCamera.rect != newRect)
            {
                _targetCamera.rect = newRect;
                MornAspectGlobal.Log("Camera Rect Adjusted");
                MornAspectGlobal.SetDirty(_targetCamera);
            }
        }
    }
}