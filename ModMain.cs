using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace ACTQoL
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("AnotherCrabsTreasure.exe")]
    public class ModMain : BaseUnityPlugin
    {
        public static bool fromPretitle = true;
        public static bool DEBUG = true;
        public static ManualLogSource logSource;

        private void Awake()
        {
            // Plugin startup logic
            logSource = Logger;
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony harmony = new("com.example.patch");
            harmony.PatchAll();
        }
    }
}
