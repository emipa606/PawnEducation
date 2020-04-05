using HarmonyLib;
using Verse;
using System;

namespace PawnEducation.Harmony
{
    [HarmonyPatch(typeof(Dialog_DebugActionsMenu), "DoListingItems")]
    internal static class Dialog_DebugActionsMenu_Patch_DoListingItems
    {
        [HarmonyPostfix]
        public static void Postfix(Dialog_DebugActionsMenu __instance)
        {
            try
            {
                DoListingItems_Mod(__instance);
            }
            catch(Exception e)
            {
                Log.Message($"PawnEducation : DoListingItems_Postfix error - {e.Message}", true);
            }
        }

        private static void DoListingItems_Mod(Dialog_DebugActionsMenu __instance)
        {
            Action clear = new Action(DebugAction_ClearCraftThoughts);
            Action write = new Action(DebugAction_WriteModSettings);

            Traverse t = Traverse.Create(__instance);
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
}
