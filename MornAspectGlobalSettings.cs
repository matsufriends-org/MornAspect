using UnityEngine;

namespace MornAspect
{
    [CreateAssetMenu(fileName = nameof(MornAspectGlobalSettings),
        menuName = "Morn/" + nameof(MornAspectGlobalSettings))]
    internal sealed class MornAspectGlobalSettings : ScriptableObject
    {
        [SerializeField] private Vector2 _resolution = new(1920, 1080);
        internal static MornAspectGlobalSettings Instance { get; private set; }

        internal Vector2 Resolution => _resolution;

        private void OnEnable()
        {
            Instance = this;
            MornAspectUtil.Log("Global Settings Loaded");
        }

        private void OnDisable()
        {
            Instance = null;
            MornAspectUtil.Log("Global Settings Unloaded");
        }
    }
}