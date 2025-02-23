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
        
        public static void Log(string message)
        {
            I.LogInternal(message);
        }

        public static void LogWarning(string message)
        {
            I.LogWarningInternal(message);
        }

        public static void LogError(string message)
        {
            I.LogErrorInternal(message);
        }

        public static void SetDirty(Object obj)
        {
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(obj);
#endif
        }
    }
}