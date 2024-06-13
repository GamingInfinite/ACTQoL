using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace ACTQoL.Patches.MapPatches
{
    [HarmonyPatch(typeof(AreaMap), nameof(AreaMap.RefreshMapWithFile))]
    internal class CrystalTracker
    {
        [HarmonyPostfix]
        public static void Postfix(AreaMap __instance)
        {
            //MethodInfo triangulate = __instance.GetType().GetMethod("Triangulate", BindingFlags.NonPublic | BindingFlags.Instance);
            //Image icon = __instance.pagurusIcon.image;
            //GameObject mapOverlay = __instance.pagurusIcon.transform.parent.gameObject;
            //List<Enemy> enemies = Enemy.allEnemies;

            //PlayerLocationData location = CrabFile.current.locationData;

            //LevelData dataFromLevel = WorldData.globalWorldData.GetDataFromLevel(location.currentLevel);
            //Vector2 treasureMapBottomLeft = dataFromLevel.treasureMapBottomLeft;
            //Vector2 treasureMapTopRight = dataFromLevel.treasureMapTopRight;
            //AreaMapDataSet areaMapDataSet = Traverse.Create(__instance).Field("activeDataSet").GetValue() as AreaMapDataSet;

            //AreaManager.instance.
        }
    }
}
