using HarmonyLib;

namespace ACTQoL.Patches.DebugStuff
{
    [HarmonyPatch(typeof(StartScreen), nameof(StartScreen.SetContinueButton))]
    internal class AutoContinue
    {
        [HarmonyPostfix]
        public static void Postfix(StartScreen __instance)
        {
            if (ModMain.fromPretitle)
            {
                __instance.continueButton.OnClick();
                ModMain.fromPretitle = false;
            }
        }
    }
}
