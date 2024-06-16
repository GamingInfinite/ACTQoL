using ACTQoL.Utils;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ACTQoL
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("AnotherCrabsTreasure.exe")]
    public class ModMain : BaseUnityPlugin
    {
        public static bool fromPretitle = true;
        public static bool DEBUG = true;
        public static ManualLogSource logSource;
        public static List<Enemy> crystalEnemies;
        public static List<Item> items;
        public static List<GameObject> mapMarkers = new();

        public static bool RenderWorldMarkers = true;

        private void Awake()
        {
            // Plugin startup logic
            logSource = Logger;
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony harmony = new("com.example.patch");
            harmony.PatchAll();
        }

        public void Update()
        {
            crystalEnemies = FindObjectsOfType<Enemy>(true).ToList();
            items = FindObjectsOfType<Item>(true).ToList();
        }

        public void OnGUI()
        {
            if (RenderWorldMarkers)
            {
                if (crystalEnemies != null)
                {
                    foreach (Enemy enemy in crystalEnemies)
                    {
                        SaveStateKillableEntity state = Traverse.Create(enemy).Field("saveState").GetValue() as SaveStateKillableEntity;
                        if (state == null) { continue; }
                        if (enemy.transform == null || enemy.isBoss || state.killedPreviously)
                        {
                            continue;
                        }
                        if (enemy.umamiDrops > 0)
                        {
                            Vector3 center = enemy.GetCenter();
                            Vector3 screenPoint = Camera.main.WorldToScreenPoint(center);
                            Texture2D crystal = ModHelper.GetSprite("crystal").texture;
                            float iconSize = 64;

                            if (screenPoint.z > 0)
                            {
                                GUI.DrawTexture(new Rect(new Vector2(screenPoint.x - iconSize/2, Screen.height - screenPoint.y - iconSize/2), new Vector2(iconSize, iconSize)), crystal, ScaleMode.ScaleToFit);
                            }
                        }
                    }
                }
                if (items != null)
                {
                    foreach(Item item in items)
                    {
                        string itemName = item.DisplayName.Replace("Item_", "").Replace("_Name", "").ToLower();
                        string resourceName;
                        if (ItemNameToResource.ItemToResource.ContainsKey(itemName))
                        {
                            resourceName = ItemNameToResource.ItemToResource[itemName];
                        }
                        else if (itemName.Contains("stowaway"))
                        {
                            resourceName = "stowaways";
                        } else if (itemName.Contains("claw"))
                        {
                            resourceName = "junk";
                        } else if (itemName.Contains("costume"))
                        {
                            resourceName = "costume";
                        }
                        else
                        {
                            resourceName = "junk";
                        }
                        SaveStateKillableEntity state = Traverse.Create(item).Field("save").GetValue() as SaveStateKillableEntity;
                        if (state == null)
                        {
                            continue;
                        }
                        if (item == null || state.killedPreviously)
                        {
                            continue;
                        }
                        Vector3 center = item.GetCenter();
                        Vector3 screenPoint = Camera.main.WorldToScreenPoint(center);
                        Texture2D crystal = ModHelper.GetSprite(resourceName).texture;
                        float iconSize = 64;

                        if (screenPoint.z > 0)
                        {
                            GUI.DrawTexture(new Rect(new Vector2(screenPoint.x - iconSize / 2, Screen.height - screenPoint.y - iconSize / 2), new Vector2(iconSize, iconSize)), crystal, ScaleMode.ScaleToFit);
                        }
                    }
                }
            }
        }

        public static bool EnemiesAggro()
        {
            bool aggro = false;
            foreach (Enemy enemy in crystalEnemies)
            {
                if (enemy.aggro)
                {
                    aggro = true;
                }
            }
            return aggro;
        }
    }
}
