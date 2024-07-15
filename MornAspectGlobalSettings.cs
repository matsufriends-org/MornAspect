using System.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

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
#if UNITY_EDITOR
            var preloadedAssets = PlayerSettings.GetPreloadedAssets().ToList();
            if (preloadedAssets.Contains(this) &&
                preloadedAssets.Count(x => x is MornAspectGlobalSettings) == 1) return;
            preloadedAssets.RemoveAll(x => x is MornAspectGlobalSettings);
            preloadedAssets.Add(this);
            PlayerSettings.SetPreloadedAssets(preloadedAssets.ToArray());
            MornAspectUtil.Log("Global Settings Added to Preloaded Assets!");
#endif
        }

        private void OnDisable()
        {
            Instance = null;
            MornAspectUtil.Log("Global Settings Unloaded");
        }
    }
}