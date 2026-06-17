namespace GhostLeviathanSkinFix.Patches
{
    using HarmonyLib;
    using UnityEngine;

    // used for my application for jr programmer in the modding server!! :D
    [HarmonyPatch(typeof(Creature))]
    public static class GhostLeviathanSkinPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        public static void Postfix_Start(Creature __instance)
        {
            // Only patch ghost leviathans so we don't break anything
            if (!(__instance is GhostLeviathan) && !(__instance is GhostLeviatanVoid))
                return;

            SkinnedMeshRenderer renderer = __instance.GetComponentInChildren<SkinnedMeshRenderer>();
            if (renderer == null) return;

            foreach (Material mat in renderer.materials)
            {
                if (mat.name.Contains("Ghost_Leviathan_shell"))
                {
                    // set cull to zero, did anyone at UWE even test this before adding it?
                    mat.SetFloat("_MyCullVariable", 0f);
                    break;
                }
            }
        }
    }
}
// Note this file is less than 100 lines, per Eldritch's suggestion, can you believe it?
// Learned this technique from JBeast the Goat
