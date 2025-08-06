using HarmonyLib;
using IPA;
using SiraUtil.Zenject;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace Tweaks55ChromaWallFix
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public const string HarmonyId = "com.github.Hattiwatti.Tweaks55ChromaWallFix";
        internal static readonly Harmony harmony = new Harmony("com.github.Hattiwatti.Tweaks55ChromaWallFix");

        internal static Plugin Instance { get; private set; }
        /// <summary>
        /// Use to send log messages through BSIPA.
        /// </summary>
        internal static IPALogger Log { get; private set; }

        [Init]
        public Plugin(IPALogger logger, Zenjector zenjector)
        {
            Instance = this;
            Log = logger;

            zenjector.Install<PlayerInstaller>(Location.Player);
        }

        [OnStart]
        public void OnApplicationStart()
        {
            harmony.PatchAll(typeof(Plugin).Assembly);
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            harmony.UnpatchSelf();
        }
    }
}
