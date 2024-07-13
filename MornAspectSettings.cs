using UnityEngine;

namespace MornAspect
{
    [CreateAssetMenu(fileName = nameof(MornAspectSettings), menuName = "Morn/" + nameof(MornAspectSettings))]
    internal sealed class MornAspectSettings : ScriptableObject
    {
        internal static MornAspectSettings Instance { get; private set; }
        [SerializeField] private Vector2 _resolution = new(1920, 1080);

        internal Vector2 Resolution => _resolution;

        private void OnEnable()
        {
            Instance = this;
            MornAspectUtil.Log("Settings Loaded");
        }

        private void OnDisable()
        {
            Instance = null;
            MornAspectUtil.Log("Settings Unloaded");
        }
    }
}