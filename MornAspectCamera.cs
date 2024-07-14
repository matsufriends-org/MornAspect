using UnityEngine;

namespace MornAspect
{
    [RequireComponent(typeof(Camera))]
    [ExecuteAlways]
    internal sealed class MornAspectCamera : MonoBehaviour
    {
        [SerializeField] private Camera _targetCamera;

        private void Awake()
        {
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
            if (MornAspectGlobalSettings.Instance == null) return;
            var screenRes = new Vector2(Screen.width, Screen.height);
            var settings = MornAspectGlobalSettings.Instance;
            var currentAspect = screenRes.y / screenRes.x;
            var aimAspect = settings.Resolution.y / settings.Resolution.x;
            Rect newRect;
            if (currentAspect > aimAspect)
            {
                var gameRes = new Vector2(screenRes.x, screenRes.x * aimAspect);
                newRect = new Rect(0, (screenRes.y - gameRes.y) / screenRes.y / 2, 1, gameRes.y / screenRes.y);
            }
            else
            {
                newRect = new Rect(0, 0, 1, 1);
            }

            if (_targetCamera.rect != newRect)
            {
                _targetCamera.rect = newRect;
                MornAspectUtil.Log("Camera Rect Adjusted");
                MornAspectUtil.SetDirty(_targetCamera);
            }
        }
    }
}