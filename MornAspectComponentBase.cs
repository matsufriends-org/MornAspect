using UnityEngine;

namespace MornAspect
{
    [ExecuteAlways]
    internal abstract class MornAspectComponentBase : MonoBehaviour
    {
        protected const float ASPECT_TOLERANCE = 0.001f;

        private void Awake()
        {
            if (Application.isPlaying)
                AdjustAspect();
        }

        private void Update()
        {
            AdjustAspect();
        }

        protected bool TryGetGlobal(out MornAspectGlobal global)
        {
            global = MornAspectGlobal.I;
            return global != null;
        }

        protected abstract void AdjustAspect();
    }
}