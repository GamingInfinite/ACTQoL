using HarmonyLib;
using UnityEngine;

namespace ACTQoL.Patches.MapPatches
{
    [HarmonyPatch(typeof(AreaMap), "OnDisable")]
    internal class ClearMapMarkers
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            foreach (GameObject marker in ModMain.mapMarkers)
            {
                Object.Destroy(marker);
            }
            ModMain.mapMarkers.Clear();
            ModMain.RenderWorldMarkers = true;
        }
    }
}
