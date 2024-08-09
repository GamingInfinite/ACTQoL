using HarmonyLib;

namespace ACTQoL.Patches.MapPatches
{
    [HarmonyPatch(typeof(Enemy), nameof(Enemy.Aggro))]
    internal class EnemyAggroHide
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            ModMain.RenderWorldMarkers = !ModMain.EnemiesAggro();
        }
    }

    [HarmonyPatch(typeof(Enemy), nameof(Enemy.DropAggro))]
    internal class EnemyDropAggroHide
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            ModMain.RenderWorldMarkers = !ModMain.EnemiesAggro();
        }
    }
}
