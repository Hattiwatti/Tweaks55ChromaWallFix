using SiraUtil.Affinity;
using UnityEngine;
using Chroma.Colorizer;
using System.Reflection;
using System;
using HarmonyLib;

namespace Tweaks55ChromaWallFix
{
    internal class HarmonyPatches : IAffinity
    {
        private bool _wallOutlineEnabled;

        private HarmonyPatches()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(Tweaks55.Plugin));
            Type t = assembly.GetType("Tweaks55.HarmonyPatches.WallOutline", true);
            _wallOutlineEnabled = Traverse.Create(t).Field("enabled").GetValue<bool>();
        }

        [AffinityPrefix]
        [AffinityPatch(typeof(ObstacleColorizerManager), "Colorize")]
        private bool Colorize(ObstacleControllerBase obstactleController, Color? color)
        {
            return !_wallOutlineEnabled;
        }
    }
}
