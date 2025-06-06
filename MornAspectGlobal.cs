using MornGlobal;
using UnityEngine;

namespace MornAspect
{
    [CreateAssetMenu(fileName = nameof(MornAspectGlobal), menuName = "Morn/" + nameof(MornAspectGlobal))]
    internal sealed class MornAspectGlobal : MornGlobalBase<MornAspectGlobal>
    {
        protected override string ModuleName => nameof(MornAspect);
        [SerializeField] private Vector2 _resolution = new(1920, 1080);
        public Vector2 Resolution => _resolution;
        
        internal static void Log(string message)
        {
            I.LogInternal(message);
        }

        internal static void LogWarning(string message)
        {
            I.LogWarningInternal(message);
        }

        internal static void LogError(string message)
        {
            I.LogErrorInternal(message);
        }

        internal static void SetDirty(Object obj)
        {
            I.SetDirtyInternal(obj);
        }

        internal static void LogAndSetDirty(string message, Object obj)
        {
            Log(message);
            SetDirty(obj);
        }
    }
}