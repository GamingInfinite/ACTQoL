using HarmonyLib;
using UnityEngine.SceneManagement;

namespace ACTQoL.Patches.DebugStuff
{
    [HarmonyPatch(typeof(UserSettings), nameof(UserSettings.InitSettings))]
    internal class PreTitleSkip
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            SceneManager.LoadSceneAsync("Title");
        }
    }
}
