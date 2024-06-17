using HarmonyLib;

namespace ACTQoL.Patches.MSS
{
    [HarmonyPatch(typeof(MoonSnailShell), nameof(MoonSnailShell.Rest))]
    internal class ShellHealthRestore
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            if (Player.singlePlayer.equippedShell)
            {
                float shellHealth = Player.singlePlayer.equippedShell.startingHealth;
                Player.singlePlayer.equippedShell.SetHealth(shellHealth);
            }

            if (Player.singlePlayer.equippedShellHammer)
            {
                float shellHealth = Player.singlePlayer.equippedShellHammer.startingHealth;
                Player.singlePlayer.equippedShellHammer.SetHealth(shellHealth);
            }
        }
    }
}
