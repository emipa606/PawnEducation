using System;
using HarmonyLib;
using Verse;

namespace PawnEducation.Harmony;

[HarmonyPatch(typeof(Dialog_DebugOptionLister), "DoListingItems")]
internal static class Dialog_DebugActionsMenu_Patch_DoListingItems
{
    [HarmonyPostfix]
    public static void Postfix(Dialog_DebugOptionLister __instance)
    {
        try
        {
            DoListingItems_Mod(__instance);
        }
        catch (Exception e)
        {
            Log.Message($"PawnEducation : DoListingItems_Postfix error - {e.Message}");
        }
    }

    private static void DoListingItems_Mod(Dialog_DebugOptionLister __instance)
    {
        var clear = new Action(DebugAction_ClearCraftThoughts);
        var write = new Action(DebugAction_WriteModSettings);

        var t = Traverse.Create(__instance);
        t.Method("DoGap").GetValue();
        t.Method("DoLabel", "Mods - Misc").GetValue();
        t.Method("DebugAction", "Clear Play Log", clear).GetValue();
        t.Method("DebugAction", "Write Mod Settings", write).GetValue();
    }

    private static void DebugAction_ClearCraftThoughts()
    {
        Find.PlayLog.AllEntries.Clear();
    }

    private static void DebugAction_WriteModSettings()
    {
        ModSettings.WriteModSettings();
    }
}