using HarmonyLib;

namespace ACTQoL.Patches.MapPatches
{
    [HarmonyPatch(typeof(AudioManager), nameof(AudioManager.OnGamePaused))]
    internal class HideWorldMarkers
    {
        [HarmonyPostfix]
        public static void Postfix(bool paused)
        {
            ModMain.RenderWorldMarkers = !paused;
        }
    }
}
