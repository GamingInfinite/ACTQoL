﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACTQoL.Patches.MSS
{
    [HarmonyPatch(typeof(MSSMenuManager), "OnEnable")]
    internal class MSSHideMarkers
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            ModMain.RenderWorldMarkers = false;
        }
    }

    [HarmonyPatch(typeof(MoonSnailShell), nameof(MoonSnailShell.SpawnPlayer))]
    internal class MSSShowMarkers
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            ModMain.RenderWorldMarkers = true;
        }
    }
}
