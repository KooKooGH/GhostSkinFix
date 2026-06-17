using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace GhostLeviathanSkinFix;

[BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public new static ManualLogSource Logger { get; private set; }

    private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

    private const string PLUGIN_GUID = "com.KooKoo.GhostSkinFix";
    private const string PLUGIN_NAME = "GhostLeviathanSkinFix";
    private const string PLUGIN_VERSION = "1.0.0";

    private void Awake()
    {
        // plugin startup logic
        Logger = base.Logger;

        // register harmony patches, if there are any
        Harmony.CreateAndPatchAll(Assembly, PLUGIN_GUID);
        Logger.LogInfo($"Plugin {PLUGIN_GUID} is loaded!");
    }
}
