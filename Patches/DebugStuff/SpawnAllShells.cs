using HarmonyLib;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ACTQoL.Patches.DebugStuff
{
    [HarmonyPatch(typeof(MoonSnailShell), nameof(MoonSnailShell.SpawnPlayer))]
    internal class SpawnAllShells
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            foreach(Shell shell in GameManager.instance.assetCollection.shells)
            {
                if (shell.IsNewShell())
                {
                    ModHelper.Msg(shell.name);
                }
            }
        }
    }
}
