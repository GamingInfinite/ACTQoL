using HarmonyLib;
using UnityEngine;
using static PrefabTracker;

namespace ACTQoL.Patches.DebugStuff
{
    [HarmonyPatch(typeof(MoonSnailShell), nameof(MoonSnailShell.SpawnPlayer))]
    internal class EnemySpawnTesting
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            foreach(TrackedPrefab prefab in PrefabTracker.allTrackedPrefabs)
            {
                ModHelper.Msg(prefab.prefabName);
            }
        }
    }
}
