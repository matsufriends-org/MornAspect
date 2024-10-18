using MornGlobal;
using UnityEngine;

namespace MornAspect
{
    [CreateAssetMenu(fileName = nameof(MornAspectGlobal), menuName = "Morn/" + nameof(MornAspectGlobal))]
    internal sealed class MornAspectGlobal : MornGlobalBase<MornAspectGlobal>
    {
#if DISABLE_MORN_ASPECT_LOG
        protected override bool ShowLog => false;
#else
        protected override bool ShowLog => true;
#endif
        protected override string ModuleName => nameof(MornAspect);
        [SerializeField] private Vector2 _resolution = new(1920, 1080);
        internal Vector2 Resolution => _resolution;

        internal void SetDirty(Object obj)
        {
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(obj);
#endif
        }
    }
}